<template>
  <body>
    <h1 style="text-align: center">
      Välkommen till SafepostBox
    </h1>
<section ref="chatArea" class="chat-area">
<p v-for="message in messages"
:key="message.name" class="message"
:class="{ 'message-out': message.author === 'you', 'message-in': message.author !== 'you' }">
      {{ message.body }}
    </p>

  </section>

  <vs-dialog blur prevent-close v-model="active">
    <template #header>
          <h3 class="not-margin">
            meddelande till juristen.
          </h3>
        </template>
      <form @submit.prevent="sendMessage('out')" id="person2-form"
      style="width: 100%; height: 200px;">
      <textarea v-model="youMessage" id="person2-input" type="text" placeholder="Type your message">

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
    conversation: [],
    active: false,
    disableButton: false,
    bobMessage: '',
    youMessage: '',
    newMessage: false,
    messages: [
      {
        body: 'Har du någon slags konkret bevis att Andre tvättar pengar?',
        author: 'lawyer',
      },
      {
        body: 'Ja jag har papper och dokument som bevisar det.',
        author: 'you',
      },
      {
        body: 'Vill du bifoga filerna och skicka dom.',
        author: 'lawyer',
      },
    ],
  }),
  created() {
    // this.interval = setInterval(() => this.userLastCount(), 1000);
    // Todo call this method in another compontent
    this.answerDisable();
  },
  computed: {
    canSendMsg() {
      return this.disableButton ? 'disabled' : '';
    },
  },

  methods: {
    getConversations() {
      whistle.getByUserId(this.$store.getters.StateUserToken,
        this.$store.getters.StateUserId).then((response) => {
        this.whistle = response;
      });
      conversations.getAll(this.$store.getters.StateUserToken,
        this.whistle.whistleID).then((response) => {
        this.conversation = response;
      });
    },
    sendMessage(direction) {
      if (!this.youMessage && !this.bobMessage) {
        return;
      }
      if (direction === 'out') {
        this.messages.push({ body: this.youMessage, author: 'you' });
        this.youMessage = '';
        this.answerDisable();
      } else if (direction === 'in') {
        this.messages.push({ body: this.bobMessage, author: 'bob' });
        this.bobMessage = '';
      }
    },
    answerDisable() {
      const i = this.messages.length - 1;
      const lastMsg = this.messages[i];
      if (lastMsg.author === 'you') {
        this.disableButton = true;
      } else {
        this.disableButton = false;
      }
    },
  },
  mounted() {
    this.getConversations();
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
</style>
