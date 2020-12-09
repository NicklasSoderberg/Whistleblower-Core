<template>
  <div id="spaceframe">
    <vs-row
          justify="center"
          align="center">
          <vs-dialog blur not-close v-model="active2">
            <vs-row justify="center">
            <h3>Ändra lösenord</h3>
            </vs-row>
            <vs-row justify="center">
            <vs-input placeholder="Gammalt Lösenord" type="password" v-model="password">
            </vs-input>
            </vs-row>
            <vs-row justify="center">
            <vs-input placeholder="Nytt Lösenord" type="password" v-model="newpassword">
            </vs-input>
            </vs-row>
            <vs-row justify="center">
              <vs-button @click="ChangePassword()">
                Ändra lösenord
              </vs-button>
            </vs-row>
            <vs-row>
              <p>Vid första inloggning måste du ändra lösenord av säkerhetskäl</p>
            </vs-row>
          </vs-dialog>
      <vs-table
        id="table"
        v-model="selected"
        >
        <template #header>
          <vs-input v-model="search" border placeholder="Sök" />
        </template>
        <template #thead>
          <vs-tr>
            <vs-th class="whistle" sort
                                  @click="whistles = $vs.sortData($event, whistles, 'lastSender')">
              <span class="bx bxs-message"></span>
            </vs-th>
            <vs-th class="whistle" sort
                                  @click="whistles = $vs.sortData($event, whistles, 'whistleID')">
              ID
            </vs-th>
            <vs-th class="whistle" sort
                                  @click="whistles = $vs.sortData($event, whistles, 'aboutInfo')">
              Ärende
            </vs-th>
              <vs-th class="status" sort
                                    @click="whistles = $vs.sortData($event, whistles,
                                    'currentStatus')">
                  Status
              </vs-th>
            <vs-th class="type" sort @click="whistles = $vs.sortData($event, whistles, 'created')">
              Skapad
            </vs-th>
            <vs-th class="type" sort @click="whistles = $vs.sortData($event, whistles, 'modified')">
              Ändrad
            </vs-th>
          </vs-tr>
        </template>
        <template #tbody>
          <vs-tr
            :key="i"
            v-for="(tr, i) in $vs.getPage($vs.getSearch(whistles, search), page, max)"
            :data="tr"
            :is-selected="selected == tr"
          >
          <vs-td>
             <span v-if="tr.lastSender === 1" class="bx bxs-message"></span>
            </vs-td>
          <vs-td>
             {{ tr.whistleID}}
            </vs-td>
           <vs-td>
             {{ tr.aboutInfo}}
            </vs-td>
            <vs-td>
             {{ tr.currentStatus}}
            </vs-td>
            <vs-td >
              {{tr.created}}
            </vs-td>
            <vs-td >
             {{tr.modified}}
            </vs-td>
          </vs-tr>
        </template>
        <template #footer>
          <vs-pagination v-model="page"
                          :length="$vs.getLength($vs.getSearch(whistles, search), max)"/>
        </template>
      </vs-table>
     <vs-row
          justify="center"
          align="center">
     <vs-button @click="openWhistle()">Välj</vs-button>
     </vs-row>
    </vs-row>
    <vs-dialog blur width="850px" not-center v-model="active">
        <template #header>
          <vs-row>
           <p> <b>Ärende:</b> {{selected.whistleID}}</p>
          </vs-row>
        </template>
        <vs-row style="text-align:center;">
        <vs-col>
        <div class="con-content">
          <p><b>Status</b></p>
          <p>{{selected.currentStatus}}</p>
      <p><b>Vad gäller ärendet?</b></p>
      <p>{{selected.aboutInfo}}</p>
      <p><b>Detaljer om ärendet</b></p>
      <p>{{selected.descriptionInfo}}</p>
      <p><b>När inträffade händelsen?</b></p>
      <p>{{selected.whenInfo}}</p>
      <p><b>Vart inträffade händelsen?</b></p>
      <p>{{selected.whereInfo}}</p>
      <p><b>Vet några andra anställda om händelsen?</b></p>
      <p>{{selected.otherEmployeeInfo}}</p>
      <vs-row id="buttons" justify="center">
        <vs-button @click="active=false" >
              Stäng
            </vs-button>
            <vs-button v-on:click="RouteClick()" >
              Safebox
            </vs-button>
      </vs-row>
        </div>
        </vs-col>
      </vs-row>
      </vs-dialog>
  </div>
</template>
<style>

</style>
<script>
import lawyer from '../../apicalls/lawyer';

export default {
  name: 'WhistleHandler',
  data: () => ({
    firstlogin: null,
    active2: null,
    password: '',
    newpassword: '',
    selected: '',
    SelectedWhistle: {},
    active: false,
    search: '',
    allCheck: false,
    page: 1,
    max: 30,
    editActive: false,
    edit: null,
    editProp: {},
    value: '',
    whistles: [{ aboutInfo: '' }], // Är den tom & bindad snear tabellen
  }),
  methods: {
    ChangePassword() {
      lawyer.ChangeLawyerPassword(this.$store.getters.StateUserToken,
        this.$store.getters.StateUserId,
        this.password, this.newpassword);
      this.active2 = !this.active2;
    },
    RouteClick() {
      // this.$router.push(route, params({ this.selected.whistleID});

      this.$router.push({ path: 'inbox', name: 'lawyerBox', params: { whistleID: this.selected.whistleID } });
    },
    openNotification(duration) {
      // eslint-disable-next-line no-unused-vars
      const noti = this.$vs.notification({
        duration,
        progress: 'auto',
        sticky: true,
        color: 'success',
        text: 'Var snäll välj ett ärende i listan',
      });
    },
    // eslint-disable-next-line no-unused-vars
    openWhistle() {
      if (this.selected === '') {
        this.openNotification(4000);
      } else {
        this.active = true;
      }
    },
    async getWhistles() {
      await lawyer.getWhistlesByLawyerID(this.$store.getters.StateUserToken,
        this.$store.getters.StateUserId).then((response) => {
        this.whistles = response;
      });
    },
    async getFirstLogin() {
      await lawyer.getLawyerFirstLoginById(this.$store.getters.StateUserToken,
        this.$store.getters.StateUserId).then((response) => {
        this.firstlogin = response;
        if (this.firstlogin === true) {
          this.active2 = true;
        }
      });
    },
  },
  async mounted() {
    await this.getWhistles();
    await this.getFirstLogin();
  },
};
</script>
<style>
h3 {
  font-size: 11px;
}
.W100{
  width: 100%;
}
#spaceframe{
  margin-left: 25px;
  margin-right: 25px;
}
#buttons{
  margin-top: 55px;
}
#table{
  margin-top: 55px;
}
</style>
