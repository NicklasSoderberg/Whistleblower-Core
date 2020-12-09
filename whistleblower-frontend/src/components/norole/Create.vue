<template>
  <div class="hello">
    <div class="center content-inputs">
      <vs-row type="flex" justify="center" align="center">
      <label id="top" class="LabelMargin">Vad gäller ärendet?</label>
      </vs-row>
      <vs-row type="flex" justify="center" align="center">
      <select v-model="about" style="outline: none;">
        <option></option>
        <option v-for="(option, index) in options" :key="index">
          {{option.text}}
        </option>
      </select>
      </vs-row>
            <vs-row justify="center" align="center">
      <div class="error" v-if="aboutStatus" >
           Du måste välja en typ</div>
      </vs-row>
      <vs-row type="flex" justify="center" align="center">
      <label class="LabelMargin">När inträffa händelsen?</label>
      </vs-row>
      <vs-row type="flex" justify="center" align="center">
      <textarea name="" id="WhenText" cols="100" rows="7" placeholder=""
                v-model="when"></textarea>
      </vs-row>
      <vs-row justify="center" align="center">
      <div class="error" v-if="!$v.when.maxLength" >
           Max 280 tecken</div>
      </vs-row>

      <vs-row type="flex" justify="center" align="center">
      <label class="LabelMargin">Vart inträffade händelsen?</label>
      </vs-row>
      <vs-row type="flex" justify="center" align="center">
      <textarea name="" id="WhereText" cols="100" rows="7" placeholder=""
                v-model="where"></textarea>
      </vs-row>
      <vs-row justify="center" align="center">
            <div class="error" v-if="!$v.where.maxLength" >
           Max 280 tecken</div>
      </vs-row>

      <vs-row type="flex" justify="center" align="center">
      <label class="LabelMargin">Detailjer om ärendet?</label>
      </vs-row>
      <vs-row type="flex" justify="center" align="center">
      <textarea name="" id="DetailsText" cols="100" rows="7" placeholder=""
                v-model="description"></textarea>
      </vs-row>
            <vs-row justify="center" align="center">
      <div class="error" v-if="!$v.description.maxLength" >
           Max 280 tecken</div>
      </vs-row>

      <vs-row type="flex" justify="center" align="center">
      <label class="LabelMargin">Är andra anställda medvetna om detta?</label>
      </vs-row>
      <vs-row type="flex" justify="center" align="center">
      <textarea name="" id="otherEmployeeText" cols="100" rows="7" placeholder=""
                v-model="otherEmployee"></textarea>
      </vs-row>
           <vs-row justify="center" align="center">
      <div class="error" v-if="!$v.otherEmployee.maxLength" >
           Max 280 tecken</div>
      </vs-row>
      <vs-row justify="center" align="center">
      <input type="file"
      id="file"
      ref="myFiles"
       accept="image/png, image/jpeg"
       @change="previewFiles()"
       multiple>
       </vs-row>
    </div>
    <vs-row type="flex" justify="center" align="center">
    <vs-button flat @click="checkDetails()">Nästa</vs-button>
    </vs-row>
    <vs-row type="flex" justify="center" align="center">
    <div id="preview"></div>
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
import { required, maxLength } from 'vuelidate/lib/validators';
import whistle from '../../apicalls/whistle';
import subject from '../../apicalls/subject';
import mix from '../../mixins/myMixin';
import files from '../../apicalls/file';

export default {
  name: 'Create',
  mixins: [mix],
  data: () => ({
    value: '',
    files: [],
    createdUser: {
    },
    active: false,
    active2: false,
    options: [],
    about: '',
    when: '',
    where: '',
    description: '',
    otherEmployee: '',
    aboutStatus: false,
    whenStatus: false,
    whereStatus: false,
    descriptionStatus: false,
    otherEmployeeStatus: false,
  }),
  validations: {
    about: {
      required,
      maxLength: maxLength(280),
    },
    when: {
      required,
      maxLength: maxLength(280),
    },
    where: {
      required,
      maxLength: maxLength(280),
    },
    description: {
      required,
      maxLength: maxLength(280),
    },
    otherEmployee: {
      required,
      maxLength: maxLength(280),
    },

  },
  methods: {
    checkDetails() {
      if (this.about !== '' && this.when !== '' && this.where !== '' && this.description !== '' && this.otherEmployee !== '') {
        this.active = !this.active;
      } else {
        // eslint-disable-next-line no-lonely-if
        if (this.about === '') {
          this.aboutStatus = true;
        } else {
          this.aboutStatus = false;
        }
        // eslint-disable-next-line no-lonely-if
        if (this.when === '') {
          document.getElementById('WhenText').placeholder = 'Du måste fylla i när det hände';
          document.getElementById('WhenText').classList.add('error-textarea');
        }
        // eslint-disable-next-line no-lonely-if
        if (this.where === '') {
          document.getElementById('WhereText').placeholder = 'Du måste fylla i vart det hände';
          document.getElementById('WhereText').classList.add('error-textarea');
        }
        // eslint-disable-next-line no-lonely-if
        if (this.description === '') {
          document.getElementById('DetailsText').placeholder = 'Du måste fylla i detaljer om det som hänt';
          document.getElementById('DetailsText').classList.add('error-textarea');
        }
        // eslint-disable-next-line no-lonely-if
        if (this.otherEmployee === '') {
          document.getElementById('otherEmployeeText').placeholder = 'Du måste fylla i om några andra är medvetna om det här';
          document.getElementById('otherEmployeeText').classList.add('error-textarea');
        }
      }
    },
    async getBase64(file) {
      return new Promise((resolve, reject) => {
        const reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = () => resolve(reader.result);
        reader.onerror = (error) => reject(error);
      });
    },
    async createWhistle() {
      await whistle.createUser().then((response) => {
        this.createdUser = response;
      });
      let newWhistle;
      await whistle.create({
        whistleID: 0,
        lawyerID: '00000000-0000-0000-0000-000000000000',
        userID: this.createdUser.userId,
        aboutInfo: this.about,
        whenInfo: this.when,
        whereInfo: this.where,
        descriptionInfo: this.description,
        otherEmployeeInfo: this.otherEmployee,
        currentStatus: 'Aktiv',
        created: this.mixGetNow(),
        modified: null,
        deleted: null,
        active: true,
        removedAdminID: null,
        lastSender: -1,
      }).then((response) => {
        newWhistle = response;
      });
      if (this.files.length > 0) {
        // eslint-disable-next-line func-names
        // eslint-disable-next-line no-restricted-syntax
        for (const file of this.files) {
          // eslint-disable-next-line no-await-in-loop
          await files.post(this.$store.getters.StateUserToken,
            {
              fileID: 0,
              // eslint-disable-next-line no-await-in-loop
              base64: await this.getBase64(file),
              extension: file.type,
              whistleID: newWhistle.whistleID,
            });
        }
      }
    },
    navigateLogin() {
      this.$router.push('Login');
    },
    getOptions() {
      subject.getAllActive().then((response) => {
        this.options = response;
      });
    },
    previewFiles() {
      this.files = this.$refs.myFiles.files;
      let fileType;
      const acceptFiles = ['image/jpg', 'image/jpeg', 'image/png'];
      // eslint-disable-next-line no-plusplus
      for (let i = 0; i < this.files.length; i++) {
        if (this.files[i].size > 5000000) {
          // eslint-disable-next-line no-alert
          alert(`${this.files[i].name} is over the 5mb limit!\n\nPlease try again..`);
          this.$refs.myFiles.value = '';
          return;
        }
        fileType = this.files[i].type;
        if (!acceptFiles.includes(fileType)) {
          // eslint-disable-next-line no-alert
          alert(`${fileType} is not an supported filetype!\n\nPlease try again..`);
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
  },
  mounted() {
    this.getOptions();
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.LabelMargin{
  margin-top: 25px;
}
.error-textarea::-webkit-input-placeholder {
    color: red;
 }
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
  font-family:"Source Sans Pro", "Helvetica Neue", Helvetica, Arial, sans-serif;
  font-size: 16px;
  -webkit-border-radius: 5px;
    -moz-border-radius: 5px;
    border-radius: 5px;
     outline: none;
}
select{
  width: 300px;
  font-size: 16px;
}
label{
  font-family: Arial, Helvetica, sans-serif;
  font-weight: bold;
  margin-bottom: 5px;
}
#file{
  margin-top: 15px;
}
</style>
