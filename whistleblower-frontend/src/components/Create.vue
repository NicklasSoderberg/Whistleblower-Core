<template>
  <div class="hello">
    <div class="center content-inputs">
      <vs-row type="flex" justify="center" align="center">
      <label id="top">Vad gäller ärendet?</label>
      </vs-row>
      <select>
        <option></option>
        <option>Bedrägeri</option>
        <option>Penningtvätt</option>
      </select>
      <vs-row type="flex" justify="center" align="center">
      <label>När inträffa händelsen?</label>
      </vs-row>
      <textarea name="" id="" cols="100" rows="7" placeholder=""></textarea>

      <vs-row type="flex" justify="center" align="center">
      <label>Vart inträffade händelsen?</label>
      </vs-row>
      <textarea name="" id="" cols="100" rows="7" placeholder=""></textarea>

      <vs-row type="flex" justify="center" align="center">
      <label>Detailjer om ärendet?</label>
      </vs-row>
      <textarea name="" id="" cols="100" rows="7" placeholder=""></textarea>

      <vs-row type="flex" justify="center" align="center">
      <label>Är andra anställda medvetna om detta?</label>
      </vs-row>
      <textarea name="" id="" cols="100" rows="7" placeholder=""></textarea>
    </div>
    <vs-row type="flex" justify="center" align="center">
    <vs-button flat @click="active=!active">Nästa</vs-button>
    </vs-row>

    <vs-dialog blur="true" not-close="true" v-model="active">
        <h2>Vill du skicka ärendet?</h2>
        <div class="con-form">
          <h4>Du kan inte redigera ditt ärende förrens du fått svar från oss.</h4>
        </div>
      <vs-row type="flex" justify="center" align="center">
         <vs-button flat @click="active=!active">Avbryt</vs-button>
         <vs-button gradient primary @click="active=!active">Skicka ärende</vs-button>
      </vs-row>
      </vs-dialog>

  </div>
</template>

<script>

export default {
  name: 'Create',
  data: () => ({
    value: '',
    active: false,
  }),
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
#top{
  margin-top: 25px;
}

h3 {
  margin: 40px 0 0;
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
textarea {
  resize: none;
  margin-bottom: 25px;
  font-family:"Source Sans Pro", "Helvetica Neue", Helvetica, Arial, sans-serif;
  font-size: 16px;
  -webkit-border-radius: 5px;
    -moz-border-radius: 5px;
    border-radius: 5px;
}
select{
  margin-bottom: 25px;
  width: 300px;
  font-size: 16px;
}
label{
  font-family: Arial, Helvetica, sans-serif;
  font-weight: bold;
  margin-bottom: 5px;
}
</style>
