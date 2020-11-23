<template>
  <div>
      <vs-table v-model="selected" striped>
        <template #header>
          <vs-input v-model="search" border placeholder="Search" />
        </template>
        <template #thead>
          <vs-tr>
            <vs-th sort @click="subjects = $vs.sortData($event ,subjects, 'id')">
              ID
            </vs-th>
            <vs-th sort @click="subjects = $vs.sortData($event ,subjects, 'name')">
              Subject
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
            <vs-td>
              {{ tr.id }}
            </vs-td>
            <vs-td>
            {{ tr.name }}
            </vs-td>
            <template #expand>
              <vs-row align="flex" justify="center">
              <vs-button>
                <i class="bx bxs-edit"></i>Redigera
              </vs-button>
              <vs-button danger @click="active=!active">
                <i class="bx bxs-trash"></i>Ta bort
              </vs-button>
              </vs-row>
            </template>
          </vs-tr>
        </template>
        <template #footer>
          <vs-pagination v-model="page" :length="$vs.getLength(subjects, max)" />
        </template>
      </vs-table>
      <vs-dialog blur not-close v-model="active">
        <DialogDelete :Name=selected.name></DialogDelete>
        <vs-row type="flex" justify="center" align="center">
         <vs-button flat @click="active=!active">Avbryt</vs-button>
         <vs-button gradient primary @click="active=!active">
           <i class="bx bxs-user-plus"></i>Delete</vs-button>
        </vs-row>
      </vs-dialog>
    </div>
</template>

<script>
import DialogDelete from './DialogDelete.vue';

export default {
  components: { DialogDelete },
  name: 'TableSubject',
  data: () => ({
    selected: { name: '' },
    active: false,
    search: '',
    page: 1,
    max: 10,
    subjects: [
      {
        id: 1,
        name: 'Missbruk av urkund',
        numberWhistles: '3',
      },
      {
        id: 2,
        name: 'Korruption',
        numberWhistles: '8',
      },
      {
        id: 3,
        name: 'Mutor',
        numberWhistles: '11',
      },
      {
        id: 4,
        name: 'Okänt',
        numberWhistles: '35',
      },
      {
        id: 5,
        name: 'Penningtvätt',
        numberWhistles: '45',
      },
      {
        id: 6,
        name: 'Terrorism',
        numberWhistles: '25',
      },
      {
        id: 7,
        name: 'Olaga hot',
        numberWhistles: '432',
      },
      {
        id: 8,
        name: 'Misstänksamheter',
        numberWhistles: '5',
      },
      {
        id: 9,
        name: 'Oro för medarbetare',
        numberWhistles: '1',
      },
      {
        id: 10,
        name: 'Beroendeställning',
        numberWhistles: '37',
      },
    ],
  }),
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
