<template>
  <div>
      <vs-table v-model="selected" striped>
        <template #header>
          <vs-input v-model="search" border placeholder="Search" />
        </template>
        <template #thead>
          <vs-tr>
            <vs-th sort @click="subjects = $vs.sortData($event ,subjects, 'text')">
              Ämne
            </vs-th>
            <vs-th sort @click="subjects = $vs.sortData($event ,subjects, 'active')">
              Aktiv
            </vs-th>
          </vs-tr>
        </template>
        <template #tbody>
          <vs-tr
            :key="i"
            v-for="(tr, i) in $vs.getPage($vs.getSearch(subjects, search), page, max)"
            :data="tr"
            :is-selected="selected == tr"
          >
            <vs-td :key="tr.text">
            {{ tr.text }}
            </vs-td>
            <vs-td edit @click="edit = tr, editActive = true" :key="tr.active">
              <span v-if="tr.active">Visas</span>
              <span v-else>Visas inte</span>
            </vs-td>
          </vs-tr>
        </template>
        <template #footer>
          <vs-pagination v-model="page" :length="$vs.getLength(subjects, max)" />
        </template>
      </vs-table>
      <vs-dialog blur not-close v-model="editActive">
        <template #header>
            <p v-if="edit.active">Är du säker du vill gömma ämnet "{{edit.text}}"?</p>
            <p v-else>Är du säker du vill visa ämnet "{{edit.text}}"?</p>
        </template>
        <vs-row type="flex" justify="center" align="center">
          <vs-button gradient danger v-model="edit"
                    @click="updateSubject(edit),
                            openNotification(4000),
                            editActive = !editActive">
              Genomför
          </vs-button>
          <vs-button flat @click="editActive = !editActive">Avbryt</vs-button>
        </vs-row>
      </vs-dialog>
    </div>
</template>

<script>
import subject from '../../apicalls/subject';
import NotificationHelper from './NotificationHelper.vue';
import mix from '../../mixins/myMixin';

export default {
  components: { },
  name: 'TableSubject',
  mixins: [mix],
  data: () => ({
    selected: { name: '' },
    active: false,
    active2: false,
    search: '',
    page: 1,
    max: 20,
    subjects: [],
    edit: '',
    editActive: false,
  }),
  methods: {
    getOptions() {
      subject.getAll().then((response) => {
        this.subjects = response;
      });
    },
    updateSubject(subjectToUpdate) {
      subject.update(this.$store.getters.StateUserToken, {
        active: !subjectToUpdate.active,
        modified: this.mixGetNow(),
        subjectID: subjectToUpdate.subjectID,
        text: subjectToUpdate.text,
      }).then(() => {
        this.getOptions();
      });
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
  },
  mounted() {
    this.getOptions();
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
#deleteButton{
  margin-top: 40px;
}
</style>
