<template>
  <body>
    <h1 style="text-align: center">Välkommen till SafepostBox</h1>
    <section ref="chatArea" class="chat-area">
      <p
        v-for="conversation in conversations"
        :key="conversation.conversationID"
        class="message"
        :class="{
          'message-out': conversation.sender === 1,
          'message-in': conversation.sender !== 1,
        }"
      >
        {{ conversation.message }}
      </p>
    </section>

    <vs-dialog blur prevent-close v-model="active">
      <template #header>
        <h3 class="not-margin">meddelande till juristen.</h3>
      </template>
      <input
        type="file"
        id="file"
        ref="myFiles"
        accept="image/png, image/jpeg"
        @change="previewFiles()"
        multiple
      />
      <form
        @submit.prevent="sendMessage()"
        id="person2-form"
        style="width: 100%; height: 200px"
      >
        <textarea
          v-model="postMessage"
          id="person2-input"
          type="text"
          placeholder="Type your message"
        >
        </textarea>
        <vs-button
          type="submit"
          gradient
          primary
          @click="disableButton === true"
          >Skicka meddelande</vs-button
        >
      </form>
    </vs-dialog>
    <div justify="center" align="center">
      <vs-button
        primary
        @click="active = !active"
        class="btn"
        :disabled="disableButton"
      >
        Svara
      </vs-button>
      <div v-if="images.length > 0">
          <img
            class="images"
            v-for="(image, i) in images"
            :key="i"
            :src="image.base64"
          />
        </div>
        <div v-else>
          <p>No images added</p>
        </div>
    </div>
  </body>
</template>

<script>
import { required } from 'vuelidate/lib/validators';
import whistle from '../../apicalls/whistle';
import conversations from '../../apicalls/conversation';
import mix from '../../mixins/myMixin';
import files from '../../apicalls/file';

export default {
  name: 'SafepostBox',
  mixins: [mix],
  data: () => ({
    whistle: {},
    conversations: [],
    active: false,
    disableButton: false,
    newMessage: false,
    postMessage: '',
    timestamp: '',
    mixintime: '',
    files: [],
    images: {},
  }),
  validations: {
    postMessage: {
      required,
    },
  },
  computed: {
    canSendMsg() {
      return this.disableButton ? 'disabled' : '';
    },
  },
  created() {},
  methods: {
    async createPostMessage() {
      if (this.$v.postMessage.required !== false) {
        const messageData = {
          conversationID: 0,
          message: this.postMessage,
          whistleID: this.whistle.whistleID,
          sender: 1,
          sent: this.mixGetNow(),
          read: '1900-01-01T00:00:00',
          fileID: 2,
        };

        await conversations.postMessage(
          this.$store.getters.StateUserToken,
          messageData,
        );

        this.conversations.push(messageData);
        if (this.files.length > 0) {
          // eslint-disable-next-line func-names
          // eslint-disable-next-line no-restricted-syntax
          for (const file of this.files) {
            // eslint-disable-next-line no-await-in-loop
            await files.post(this.$store.getters.StateUserToken, {
              fileID: 0,
              // eslint-disable-next-line no-await-in-loop
              base64: await this.getBase64(file),
              extension: file.type,
              whistleID: this.whistle.whistleID,
            });
          }
        }

        this.active = !this.active;
      } else {
        document.getElementById('person2-input').placeholder = 'Du måste skriva ett meddelande för att skicka!';
      }
    },
    async getWhistle() {
      await whistle
        .getByUserId(
          this.$store.getters.StateUserToken,
          this.$store.getters.StateUserId,
        )
        .then((response) => {
          this.whistle = response;
        });
    },
    async getConversations(whistleId) {
      await conversations
        .getAll(this.$store.getters.StateUserToken, whistleId)
        .then((response) => {
          this.conversations = response;
          console.log(this.conversations);
        });

      this.answerDisable();
    },
    async getFiles() {
      await files.get(this.$store.getters.StateUserToken, this.whistle.whistleID)
        .then((response) => {
          this.images = response;
        });
    },
    async sendMessage() {
      await this.createPostMessage();

      this.answerDisable();
    },
    answerDisable() {
      const i = this.conversations.length - 1;
      const lastMsg = this.conversations[i];
      console.log(i);
      console.log(lastMsg);
      if (i !== -1) {
        if (lastMsg.sender === 1) {
          this.disableButton = true;
        } else {
          this.disableButton = false;
        }
      } else {
        this.disableButton = true;
      }
    },
    previewFiles() {
      this.files = this.$refs.myFiles.files;
      let fileType;
      const acceptFiles = ['image/jpg', 'image/jpeg', 'image/png'];
      // eslint-disable-next-line no-plusplus
      for (let i = 0; i < this.files.length; i++) {
        if (this.files[i].size > 5000000) {
          // eslint-disable-next-line no-alert
          alert(
            `${this.files[i].name} is over the 5mb limit!\n\nPlease try again..`,
          );
          this.$refs.myFiles.value = '';
          return;
        }
        fileType = this.files[i].type;
        if (!acceptFiles.includes(fileType)) {
          // eslint-disable-next-line no-alert
          alert(
            `${fileType} is not an supported filetype!\n\nPlease try again..`,
          );
          this.$refs.myFiles.value = '';
          return;
        }
      }
      // eslint-disable-next-line prefer-const
      let reader = new FileReader();
      reader.readAsDataURL(this.files[0]);
      // eslint-disable-next-line func-names
      // reader.onload = function () {
      //  console.log(reader.result);
      // };
      // eslint-disable-next-line func-names
      // reader.onerror = function (error) {
      //  console.log('Error: ', error);
      // };
    },
    async getBase64(file) {
      return new Promise((resolve, reject) => {
        const reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = () => resolve(reader.result);
        reader.onerror = (error) => reject(error);
      });
    },
  },
  async mounted() {
    await this.getWhistle();
    await this.getConversations(this.whistle.whistleID);
    await this.getFiles();
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
body,
html {
  width: 100%;
  height: 100%;
  font-family: sans-serif;
  font-weight: 100;
  margin: 0px;
}
textarea {
  resize: none;
  font-family: "Source Sans Pro", "Helvetica Neue", Helvetica, Arial, sans-serif;
  font-size: 16px;
  -webkit-border-radius: 5px;
  -moz-border-radius: 1px;
  border-radius: 6px;
  width: 95%;
  height: 80%;
  outline: none;
  background-color: transparent;
}
.btn {
  position: relative;
  bottom: 20px;
  max-width: 520px;
  width: 250px;
}
.reply-button {
  height: 40px;
  width: 90px;
}
.headline {
  text-align: center;
  font-weight: 100;
  color: white;
}
.chat-area {
  /*   border: 1px solid #ccc; */
  background: white;
  height: 50vh;
  padding: 1em;
  overflow: auto;
  max-width: 500px;
  margin: 0 auto 2em auto;
  box-shadow: 2px 2px 5px 2px rgba(0, 0, 0, 0.3);
  border-radius: 5%;
  margin-top: 5%;
}
.avatar {
  position: absolute;
  bottom: 42px;
  left: 10px;
  color: #6e6464;
}
.message {
  border-radius: 10px;
  padding: 0.5em;
  /*   margin-bottom: .5em; */
}
.message-out {
  background: #407fff;
  color: white;
  margin-left: 50%;
  word-wrap: break-word;
  justify-content: right;
}
.message-in {
  background: #f1f0f0;
  color: black;
  word-wrap: break-word;
  width: 45%;
}
.chat-inputs {
  display: flex;
  justify-content: space-between;
}
#person1-input {
  padding: 0.5em;
}
#person2-input {
  padding: 0.5em;
}
h1 {
  font-size: 27px;
  margin-top: 100px;
}
</style>
