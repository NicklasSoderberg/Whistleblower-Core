<template>
  <div class="center content-inputs wrapper">
      <vs-row id="space" type="flex" justify="center" align="center">
      <h3>Ange Ärende ID och lösenord för att följa ditt ärende</h3>
      </vs-row>
      <vs-row id="space" type="flex" justify="center" align="center">
      <vs-input v-model="value1" v-model.trim="$v.value1.$model" placeholder="Ärende ID">
      </vs-input>
      </vs-row>
       <vs-row justify="center">
         <div class="error" v-if="!$v.value1.required" >Ärende ID måste vara ifyllt</div>
      </vs-row>
      <vs-row type="flex" justify="center" align="center">
      <vs-input id="space" type="password"
       v-model.trim="$v.value2.$model" icon-after v-model="value2" placeholder="Lösenord">
      </vs-input>
      </vs-row>
      <vs-row justify="center">
         <div class="error" v-if="!$v.value2.required" >Lösenordet måste vara ifyllt</div>
      </vs-row>
      <vs-row id="space" type="flex" justify="center" align="center">
      <vs-button gradient primary>Följ upp ärende</vs-button>
      </vs-row>
    </div>
</template>

<script>
import { required } from 'vuelidate/lib/validators';

export default {
  name: 'FollowUp',
  data: () => ({
    value1: '',
    value2: '',
  }),
  validations: {
    value1: {
      required,
    },
    value2: {
      required,
    },
  },
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
