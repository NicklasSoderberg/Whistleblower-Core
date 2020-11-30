<template>
  <div class="hello">
    <div class="center content-inputs">
      <vs-row type="flex" justify="center" align="center">
      <label id="top">Vad gäller ärendet?</label>
      </vs-row>
      <vs-row type="flex" justify="center" align="center">
      <select v-model="newWhistle.About" style="outline: none;">
        <option></option>
        <option>Bedrägeri</option>
        <option>Penningtvätt</option>
      </select>
      </vs-row>
      <vs-row type="flex" justify="center" align="center">
      <label>När inträffa händelsen?</label>
      </vs-row>
      <vs-row type="flex" justify="center" align="center">
      <textarea name="" id="" cols="100" rows="7" placeholder=""
                v-model="newWhistle.When"></textarea>
      </vs-row>

      <vs-row type="flex" justify="center" align="center">
      <label>Vart inträffade händelsen?</label>
      </vs-row>
      <vs-row type="flex" justify="center" align="center">
      <textarea name="" id="" cols="100" rows="7" placeholder=""
                v-model="newWhistle.Where"></textarea>
      </vs-row>

      <vs-row type="flex" justify="center" align="center">
      <label>Detailjer om ärendet?</label>
      </vs-row>
      <vs-row type="flex" justify="center" align="center">
      <textarea name="" id="" cols="100" rows="7" placeholder=""
                v-model="newWhistle.Description"></textarea>
      </vs-row>

      <vs-row type="flex" justify="center" align="center">
      <label>Är andra anställda medvetna om detta?</label>
      </vs-row>
      <vs-row type="flex" justify="center" align="center">
      <textarea name="" id="" cols="100" rows="7" placeholder=""
                v-model="newWhistle.OtherEmployee"></textarea>
      </vs-row>
    </div>
    <vs-row type="flex" justify="center" align="center">
    <vs-button flat @click="active=!active">Nästa</vs-button>
    </vs-row>
    <vs-dialog blur not-close v-model="active">
      <vs-row type="flex" justify="center" align="center">
        <h2>Vill du skicka ärendet?</h2>
      </vs-row>
        <div class="con-form">
          <h4>Du kan inte redigera ditt ärende förrens du fått svar från oss.</h4>
        </div>
      <vs-row type="flex" justify="center" align="center">
         <vs-button flat @click="active=!active">Avbryt</vs-button>
         <vs-button gradient primary @click="active=!active,
                    createWhistle()">Skicka ärende</vs-button>
      </vs-row>
      </vs-dialog>
  </div>
</template>

<script>
import whistle from '../../apicalls/whistle';

export default {
  name: 'Create',
  data: () => ({
    value: '',
    active: false,
    newWhistle: {
      about: '',
      when: '',
      where: '',
      description: '',
      otherEmployee: '',
    },
  }),
  methods: {
    createWhistle() {
      whistle.create({
        whistleID: 0,
        lawyerID: null,
        userID: null,
        aboutInfo: this.newWhistle.About,
        whenInfo: this.newWhistle.When,
        whereInfo: this.newWhistle.Where,
        descriptionInfo: this.newWhistle.Description,
        otherEmployeeInfo: this.newWhistle.otherEmployee,
        currentStatus: 'Aktiv',
        created: null,
        modified: null,
        deleted: null,
        active: true,
        removedAdminID: null,
      });
    },
  },
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
     outline: none;
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
