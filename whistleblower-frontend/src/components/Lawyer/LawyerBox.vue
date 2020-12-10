<template>
  <body>
    <h1 style="text-align: center">
      Välkommen till SafepostBox
    </h1>
<section ref="chatArea" class="chat-area">
<p v-for="conversation in conversations"
:key="conversation.conversationID" class="message"
:class="{ 'message-out': conversation.sender === 0, 'message-in': conversation.sender !== 0 }">
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
import conversations from '../../apicalls/conversation';
import mix from '../../mixins/myMixin';

export default {
  name: 'lawyerBox',
  mixins: [mix],
  data: () => ({
    whistle: {},
    conversations: [],
    active: false,
    disableButton: false,
    newMessage: false,
    postMessage: '',
  }),
  props: {
    whistleID: {},
  },
  computed: {
    canSendMsg() {
      return this.disableButton ? 'disabled' : '';
    },
  },
  methods: {
    async createPostMessage() {
      const messageData = {
        conversationID: 0,
        message: this.postMessage,
        whistleID: this.whistleID,
        sender: 0,
        sent: this.mixGetNow(),
        read: '1900-01-01T00:00:00',
        fileID: 2,
      };
      await conversations.postMessage(
        this.$store.getters.StateUserToken,
        messageData,
      );
      this.conversations.push(messageData);
    },
    async getConversations() {
      await conversations.getAll(this.$store.getters.StateUserToken, this.whistleID)
        .then((response) => {
          this.conversations = response;
        });
    },
    async sendMessage() {
      await this.createPostMessage();
    },
  },
  async mounted() {
    await this.getConversations();
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
