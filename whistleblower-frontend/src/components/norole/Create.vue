<template>
  <div class="hello">
    <div class="center content-inputs">
      <vs-row type="flex" justify="center" align="center">
      <label id="top">Vad gäller ärendet?</label>
      </vs-row>
      <vs-row type="flex" justify="center" align="center">
      <select v-model="newWhistle.About" style="outline: none;">
        <option></option>
        <option v-for="(option, index) in options" :key="index">
          {{option.text}}
        </option>
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
                v-model="newWhistle.otherEmployee"></textarea>
      </vs-row>
    </div>
    <vs-row type="flex" justify="center" align="center">
    <vs-button flat @click="active=!active">Nästa</vs-button>
    </vs-row>

    <vs-dialog blur not-close overflow-hidden v-model="active" prevent-close>
      <vs-row type="flex" justify="center" align="center">
            <h2>Vill du skicka ärendet?</h2>
      </vs-row>
        <div class="con-content">
          <h4>Du kan inte redigera ditt ärende förrens du fått svar från oss.</h4>
        </div>
          <vs-row type="flex" justify="center" align="center">
         <vs-button flat @click="active=!active">Avbryt</vs-button>
         <vs-button gradient primary @click="active2=!active2, active=!active,
                    createWhistle()">Skicka ärende</vs-button>
      </vs-row>
      </vs-dialog>
      <vs-dialog v-model="active2" blur not-close prevent-close>
        <template #header>
          <h4>
            Ditt ärende är nu inskickat.
          </h4>
        </template>
        <h2 style="font-weight: normal; font-size: 20px; word-wrap: break-word;">
            Detta är dina kontouppgifter du kommer logga in med för att följa ärendet.
           <b style="color: red">OBS du kommer inte kunna få tag på uppgifterna igen
           så se till att skriva ner de och spara de.</b>
           </h2>
        <div class="con-form">
          <h2 style="font-weight: normal; font-size: 22px">
            Användarnamn: <b>{{createdUser.username}}
              </b></h2>
          <h2 style="font-weight: normal; font-size: 22px">
            Lösenord: <b>{{createdUser.password}}
              </b></h2>
        </div>

        <template #footer>
          <div class="footer-dialog">
            <vs-button block @click="navigateLogin()">
              Gå till första sidan.
            </vs-button>
          </div>
        </template>
      </vs-dialog>
  </div>
</template>

<script>
import whistle from '../../apicalls/whistle';
import subject from '../../apicalls/subject';

export default {
  name: 'Create',
  data: () => ({
    value: '',
    createdUser: {
    },
    active: false,
    active2: false,
    options: [],
    newWhistle: {
      about: '',
      when: '',
      where: '',
      description: '',
      otherEmployee: '',
    },
  }),
  methods: {
    async createWhistle() {
      await whistle.createUser().then((response) => {
        this.createdUser = response;
      });
      await whistle.create({
        whistleID: 0,
        lawyerID: '00000000-0000-0000-0000-000000000000',
        userID: this.createdUser.userId,
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
        lastSender: -1,
      });
    },
    navigateLogin() {
      this.$router.push('Login');
    },
    getOptions() {
      subject.getAllActive().then((response) => {
        this.options = response;
      });
    },
  },
  mounted() {
    this.getOptions();
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
