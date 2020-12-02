<template>
  <div>
      <vs-table v-model="selected" striped>
        <template #header>
          <vs-input v-model="search" border placeholder="Search" />
        </template>
        <template #thead>
          <vs-tr>
            <vs-th sort @click="lawyers = $vs.sortData($event ,lawyers, 'firstname')">
              Förnamn
            </vs-th>
            <vs-th sort @click="lawyers = $vs.sortData($event ,lawyers, 'lastname')">
              Efternamn
            </vs-th>
            <vs-th sort @click="lawyers = $vs.sortData($event ,lawyers, 'email')">
              Email
            </vs-th>
            <vs-th sort @click="lawyers = $vs.sortData($event ,lawyers, 'phonenumber')">
              Phonenumber
            </vs-th>
          </vs-tr>
        </template>
        <template #tbody>
          <vs-tr
            :key="i"
            v-for="(tr, i) in $vs.getPage($vs.getSearch(lawyers, search), page, max)"
            :data="tr"
            :is-selected="selected == tr"
          >
            <vs-td>
              {{ tr.firstName }}
            </vs-td>
            <vs-td>
              {{ tr.lastName }}
            </vs-td>
            <vs-td>
            {{ tr.email }}
            </vs-td>
            <vs-td>
            {{ tr.phoneNumber }}
            </vs-td>
          </vs-tr>
        </template>
        <template #footer>
          <vs-pagination v-model="page" :length="$vs.getLength(lawyers, max)" />
        </template>
      </vs-table>
    </div>
</template>

<script>
import lawyer from '../../apicalls/lawyer';

export default {
  name: 'TableLawyer',
  data: () => ({
    selected: { name: '' },
    active: false,
    active2: false,
    search: '',
    page: 1,
    max: 10,
    lawyers: [],
  }),
  methods: {
    async fillTable() {
      const loading = this.$vs.loading();
      setTimeout(() => {
        lawyer.getAll(this.$store.getters.StateUserToken).then((response) => {
          this.lawyers = response;
          loading.close();
        });
      }, 1000);
    },
  },
  mounted() {
    this.fillTable();
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
