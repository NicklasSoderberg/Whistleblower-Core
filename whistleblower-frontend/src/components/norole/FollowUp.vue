<template>
  <div class="center content-inputs wrapper">
      <vs-row id="space" type="flex" justify="center" align="center">
      <h3>Ange Ärende ID och lösenord för att följa ditt ärende</h3>
      </vs-row>
      <vs-row id="space" type="flex" justify="center" align="center">
      <vs-input v-model="value1" placeholder="Ärende ID">
      </vs-input>
      </vs-row>
      <vs-row type="flex" justify="center" align="center">
      <vs-input id="space" type="password" icon-after v-model="value2" placeholder="Lösenord">
      </vs-input>
      </vs-row>
      <vs-row id="space" type="flex" justify="center" align="center">
      <vs-button gradient primary>Följ upp ärende</vs-button>
      </vs-row>
    </div>
</template>

<script>
export default {
  name: 'FollowUp',
  data: () => ({
    value1: '',
    value2: '',
  }),
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin-top: 170px;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
#space{
  margin-top: 10px;
}
</style>
