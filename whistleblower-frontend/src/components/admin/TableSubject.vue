<template>
  <div>
      <vs-table v-model="selected" striped>
        <template #header>
          <vs-input v-model="search" border placeholder="Search" />
        </template>
        <template #thead>
          <vs-tr>
            <vs-th sort @click="subjects = $vs.sortData($event ,subjects, 'subjectID')">
              ID
            </vs-th>
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
            <vs-td :key="tr.subjectID">
              {{ tr.subjectID }}
            </vs-td>
            <vs-td :key="tr.text">
            {{ tr.text }}
            </vs-td>
            <vs-td edit @click="edit = tr, editActive = true" :key="tr.active">
            {{ tr.active }}
            </vs-td>
          </vs-tr>
        </template>
        <template #footer>
          <vs-pagination v-model="page" :length="$vs.getLength(subjects, max)" />
        </template>
      </vs-table>
      <vs-dialog v-model="editActive">
        <template #header>
            <p>Sätt ämnet "{{edit.text}}" till {{!edit.active}}?</p>
        </template>
        <vs-row type="flex" justify="center" align="center">
          <vs-button flat @click="editActive = !editActive">Avbryt</vs-button>
          <vs-button gradient danger v-model="edit"
                    @click="updateSubject(edit), editActive = !editActive">
              Genomför
          </vs-button>
        </vs-row>
      </vs-dialog>
    </div>
</template>

<script>
import subject from '../../apicalls/subject';

export default {
  components: { },
  name: 'TableSubject',
  data: () => ({
    selected: { name: '' },
    active: false,
    active2: false,
    search: '',
    page: 1,
    max: 10,
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
        created: null,
        deleted: null,
        modified: null,
        subjectID: subjectToUpdate.subjectID,
        text: subjectToUpdate.text,
      }).then(() => {
        this.getOptions();
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
</style>
