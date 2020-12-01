<template>
  <body>
    <h1 style="text-align: center">
      Välkommen till SafepostBox
    </h1>
<section ref="chatArea" class="chat-area">
<p v-for="conversation in conversations"
:key="conversation.conversationID" class="message"
:class="{ 'message-out': conversation.sender === 1, 'message-in': conversation.sender !== 1 }">
      {{ conversation.message }}
    </p>

  </section>

  <vs-dialog blur prevent-close v-model="active">
    <template #header>
          <h3 class="not-margin">
            meddelande till juristen.
          </h3>
        </template>
      <form @submit.prevent="sendMessage()" id="person2-form"
      style="width: 100%; height: 200px;">
      <textarea v-model="postMessage"
      id="person2-input" type="text" placeholder="Type your message">

      </textarea>
<vs-button type="submit" gradient primary @click="active=!active &&
 disableButton === true">Skicka meddelande</vs-button>
    </form>
      </vs-dialog>
      <div justify="center" align="center">
    <vs-button
        primary
        @click="active=!active"
        class="btn"
        :disabled="disableButton"
      >
        Svara
      </vs-button>
  </div>
  </body>
</template>

<script>
import whistle from '../../apicalls/whistle';
import conversations from '../../apicalls/conversation';

export default {
  name: 'SafepostBox',
  data: () => ({
    whistle: {},
    conversations: [],
    active: false,
    disableButton: false,
    newMessage: false,
    postMessage: '',
  }),
  created() {
    // this.interval = setInterval(() => this.userLastCount(), 1000);
    // Todo call this method in another compontent
    // this.answerDisable();
  },
  computed: {
    canSendMsg() {
      return this.disableButton ? 'disabled' : '';
    },
  },

  methods: {
    async createPostMessage() {
      await conversations.postMessage(this.$store.getters.StateUserToken,
        {
          conversationID: 0,
          message: this.postMessage,
          whistleID: this.whistle.whistleID,
          sender: 1,
          sent: '1900-01-01T00:00:00',
          read: '1900-01-01T00:00:00',
          fileID: 2,
        });
      this.conversations.push({
        conversationID: 0,
        message: this.postMessage,
        whistleID: this.whistle.whistleID,
        sender: 1,
        sent: '1900-01-01T00:00:00',
        read: '1900-01-01T00:00:00',
        fileID: 2,
      });
    },
    async getWhistle() {
      await whistle.getByUserId(this.$store.getters.StateUserToken,
        this.$store.getters.StateUserId).then((response) => {
        this.whistle = response;
      });
    },
    async getConversations(whistleId) {
      await conversations.getAll(this.$store.getters.StateUserToken,
        whistleId).then((response) => {
        this.conversations = response;
      });
      this.answerDisable();
    },
    async sendMessage() {
      console.log('send button');
      // this.answerDisable();
      await this.createPostMessage();
      this.answerDisable();
    },
    answerDisable() {
      const i = this.conversations.length - 1;
      const lastMsg = this.conversations[i];
      if (lastMsg.sender === 1) {
        this.disableButton = true;
      } else {
        this.disableButton = false;
      }
    },
  },
  async mounted() {
    await this.getWhistle();
    await this.getConversations(this.whistle.whistleID);
    // this.interval = setInterval(() => this.getConversations(this.whistle.whistleID), 10000);
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
body, html {
width: 100%;
height: 100%;
  font-family: sans-serif;
  font-weight: 100;
margin: 0px;
}
textarea {
  resize: none;
  font-family:"Source Sans Pro", "Helvetica Neue", Helvetica, Arial, sans-serif;
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
  padding: .5em;
/*   margin-bottom: .5em; */
}
.message-out {
  background: #407FFF;
  color: white;
  margin-left: 50%;
  word-wrap: break-word;
  justify-content: right;
}
.message-in {
  background: #F1F0F0;
  color: black;
  word-wrap: break-word;
    width: 45%;
}
.chat-inputs {
  display: flex;
  justify-content: space-between;
}
#person1-input {
  padding: .5em;
}
#person2-input {
  padding: .5em;
}
h1 {
  font-size: 27px;
  margin-top: 100px;
}
</style>
