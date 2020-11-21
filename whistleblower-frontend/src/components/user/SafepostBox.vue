<template>
  <body>
    <h1 style="text-align: center">
      Välkommen till SafepostBox
    </h1>
<section ref="chatArea" class="chat-area">
  <vs-row>
<vs-avatar circle size="30">
        <template #text>
          L
        </template>
</vs-avatar>
    <p class="message message-in">
      Kan du förklara mer om ditt ärende.
      Kan du förklara mer om ditt ärende.
      Kan du förklara mer om ditt ärende.
      Kan du förklara mer om ditt ärende.
      Kan du förklara mer om ditt ärende.
      Kan du förklara mer om ditt ärende.
    </p>
  </vs-row>

<vs-row>

  <vs-avatar circle size="30" style="margin-left: 90%">
        <template #text>
          W
        </template>
</vs-avatar>

  <p class="message message-out">
      Absolut klockan var 10.
    </p>

</vs-row>
  </section>
  </body>
</template>

<script>

export default {
  name: 'SafepostBox',
  data: () => ({
    bobMessage: '',
    youMessage: '',
    messages: [
      {
        body: 'Lawyer test inc message',
        author: 'lawyer',
      },
      {
        body: 'user test inc message',
        author: 'you',
      },
      {
        body: 'You\'re most welcome',
        author: 'bob',
      },
    ],
  }),
  computed: {

  },
  methods: {

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
background: #7b4397;  /* fallback for old browsers */
background: -webkit-linear-gradient(to right, #fffeff, #8c8b8d);  /* Chrome 10-25, Safari 5.1-6 */
background: linear-gradient(to right, #fffeff, #8c8b8d);
/* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
margin: 0px;
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
  max-width: 350px;
  margin: 0 auto 2em auto;
  box-shadow: 2px 2px 5px 2px rgba(0, 0, 0, 0.3);
  border-radius: 5%;
}
.message {
  width: 45%;
  border-radius: 10px;
  padding: .5em;
/*   margin-bottom: .5em; */
  font-size: .8em;
}
.message-out {
  background: #407FFF;
  color: white;
  margin-left: 50%;
}
.message-in {
  background: #F1F0F0;
  color: black;
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
