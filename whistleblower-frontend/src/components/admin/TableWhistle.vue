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
            <vs-th sort @click="whistles = $vs.sortData($event ,whistles, 'id')">
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
            <vs-td edit @click="edit = tr, editProp = 'currentStatus', editActive = true">
              {{ tr.currentStatus }}
            </vs-td>
            <vs-td>
              {{ tr.id }}
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
            <vs-td edit @click="edit = tr, editProp = 'lawyerName', editActive = true">
              {{ tr.lawyerName }}
            </vs-td>
          </vs-tr>
        </template>
        <template #footer>
          <vs-pagination v-model="page" :length="$vs.getLength(whistles, max)" />
        </template>
      </vs-table>
      <vs-dialog v-model="editActive">
        <template #header>
            <h3 v-if="editProp == 'lawyerName'">Ändra advokat</h3>
            <h3 v-if="editProp == 'currentStatus'">Ändra status</h3>
        </template>
        <vs-row type="flex" justify="center" align="center">
        <vs-select @change="editActive = false" block v-if="editProp == 'currentStatus'"
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
        <vs-select @change="editActive = false" block v-if="editProp == 'lawyerName'"
                  placeholder="Select" v-model="edit[editProp]">
          <vs-option value="Sven">
            Sven
          </vs-option>
          <vs-option value="Göran">
            Göran
          </vs-option>
          <vs-option value="Gunnar">
            Gunnar
          </vs-option>
          <vs-option value="Erik">
            Erik
          </vs-option>
          <vs-option value="Gösta">
            Gösta
          </vs-option>
        </vs-select>
        </vs-row>
      </vs-dialog>
    </div>
</template>

<script>

export default {
  components: {},
  name: 'TableWhistle',
  data: () => ({
    selected: { name: '' },
    active: false,
    search: '',
    page: 1,
    max: 10,
    editActive: false,
    edit: null,
    editProp: {},
    whistles: [
      {
        id: 1,
        lawyerName: 'Sven',
        aboutInfo: 'Terrorism',
        currentStatus: 'Aktiv',
        created: '2020-11-20 09:38',
        modified: '2020-11-20 10:18',
        active: true,
      },
      {
        id: 2,
        lawyerName: 'Gunnar',
        aboutInfo: 'Olaga hot',
        currentStatus: 'Aktiv',
        created: '2020-11-18 09:38',
        modified: '2020-11-20 17:18',
        active: true,
      },
      {
        id: 3,
        lawyerName: 'Olof',
        aboutInfo: 'Penningtvätt',
        currentStatus: 'Aktiv',
        created: '2020-11-12 19:38',
        modified: '2020-11-20 07:18',
        active: true,
      },
      {
        id: 4,
        lawyerName: 'Sven',
        aboutInfo: 'Olaga hot',
        currentStatus: 'Aktiv',
        created: '2020-11-18 09:38',
        modified: '2020-11-20 17:18',
        active: true,
      },
      {
        id: 5,
        lawyerName: 'Gunnar',
        aboutInfo: 'Bombhot',
        currentStatus: 'Inaktiv',
        created: '2020-11-18 09:38',
        modified: '2020-11-20 17:18',
        active: true,
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
