<template>
  <div>
      <vs-table v-model="selected" striped>
        <template #header>
          <vs-input v-model="search" border placeholder="Search" />
        </template>
        <template #thead>
          <vs-tr>
            <vs-th sort @click="whistles = $vs.sortData($event ,whistles, 'currentStatus')">
              Status
            </vs-th>
            <vs-th sort @click="whistles = $vs.sortData($event ,whistles, 'whistleID')">
              ID
            </vs-th>
            <vs-th sort @click="whistles = $vs.sortData($event ,whistles, 'aboutInfo')">
              Ämne
            </vs-th>
            <vs-th sort @click="whistles = $vs.sortData($event ,whistles, 'created')">
              Skapad
            </vs-th>
            <vs-th sort @click="whistles = $vs.sortData($event ,whistles, 'modified')">
              Ändrad
            </vs-th>
            <vs-th sort @click="whistles = $vs.sortData($event ,whistles, 'lawyerName')">
              Advokat
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
            <vs-td edit @click="edit = tr, editProp = 'currentStatus',
                        editActive = true">
              {{ tr.currentStatus }}
            </vs-td>
            <vs-td>
              {{ tr.whistleID }}
            </vs-td>
            <vs-td>
              {{ tr.aboutInfo }}
            </vs-td>
            <vs-td>
              {{ tr.created }}
            </vs-td>
            <vs-td>
              {{ tr.modified }}
            </vs-td>
            <vs-td edit @click="edit = tr, editProp = 'lawyerID', editActive = true">
              {{ getLawyerNameByID(tr.lawyerID) }}
            </vs-td>
          </vs-tr>
        </template>
        <template #footer>
          <vs-pagination v-model="page" :length="$vs.getLength(whistles, max)" />
        </template>
      </vs-table>
      <vs-dialog v-model="editActive">
        <template #header>
            <h3 v-if="editProp == 'lawyerID'">Ändra advokat</h3>
            <h3 v-if="editProp == 'currentStatus'">Ändra status</h3>
        </template>
        <vs-row type="flex" justify="center" align="center">
        <vs-select @change="editActive = false, editStatus(edit), openNotification(4000)"
                    block v-if="editProp == 'currentStatus'"
                  placeholder="Select" v-model="edit[editProp]">
          <vs-option value="Aktiv">
            Aktiv
          </vs-option>
          <vs-option value="Hanteras">
            Hanteras
          </vs-option>
          <vs-option value="Avslutad">
            Avslutad
          </vs-option>
        </vs-select>
        <vs-select @change="editActive = false, editStatus(edit), openNotification(4000)"
                    block v-if="editProp == 'lawyerID'"
                  placeholder="Select" v-model="edit[editProp]">
          <vs-option :key="index" v-for="(item, index) in lawyers" :value="item.id">
            {{item.firstName + ' ' + item.lastName}}
          </vs-option>
        </vs-select>
        </vs-row>
      </vs-dialog>
    </div>
</template>

<script>
import whistle from '../../apicalls/whistle';
import NotificationHelper from './NotificationHelper.vue';
import lawyer from '../../apicalls/lawyer';
import mix from '../../mixins/myMixin';

export default {
  components: {},
  name: 'TableWhistle',
  mixins: [mix],
  data: () => ({
    selected: { name: '' },
    active: false,
    search: '',
    page: 1,
    max: 10,
    editActive: false,
    edit: {},
    editProp: {},
    whistles: [],
    lawyers: [],
  }),
  methods: {
    async fillTable() {
      const loading = this.$vs.loading();
      setTimeout(() => {
        whistle.getAll(this.$store.getters.StateUserToken).then((response) => {
          this.whistles = response;
          loading.close();
        });
      }, 500);
    },
    async getLawyers() {
      lawyer.getAll(this.$store.getters.StateUserToken).then((response) => {
        this.lawyers = response;
      });
    },
    updateWhistle(whistleToUpdate) {
      whistle.update(this.$store.getters.StateUserToken, whistleToUpdate);
    },
    editStatus(input) {
      this.updateWhistle(input);
    },
    openNotification(duration) {
      // eslint-disable-next-line no-unused-vars
      const noti = this.$vs.notification({
        duration,
        progress: 'auto',
        sticky: true,
        color: 'success',
        content: NotificationHelper,
      });
    },
    getLawyerNameByID(lawyerID) {
      let lawyerResult;
      // eslint-disable-next-line prefer-const
      lawyerResult = this.lawyers.find((n) => n.id === lawyerID);
      if (typeof lawyerResult === 'undefined') {
        return 'Lägg till';
      }
      return `${lawyerResult.firstName} ${lawyerResult.lastName}`;
    },
  },
  async mounted() {
    await this.getLawyers();
    await this.fillTable();
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>
#space{
  margin-top: 25px;
}
#firstspace{
  margin-top: 35px;
}
.W100{
  width: 100%;
}
</style>
