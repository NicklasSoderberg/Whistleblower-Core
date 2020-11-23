<template>
  <div>
    <vs-row   justify="center"
          align="center">
     <vs-col w="6">
      <vs-table
        v-model="selected"
        >
        <template #header>
          <vs-input v-model="search" border placeholder="Sök" />
        </template>
        <template #thead>
          <vs-tr>
              <vs-th sort @click="users = $vs.sortData($event ,users, 'status')">
                  Status
              </vs-th>
            <vs-th sort @click="users = $vs.sortData($event ,users, 'name')">
              Ärende
            </vs-th>
            <vs-th sort @click="users = $vs.sortData($event ,users, 'email')">
              Typ
            </vs-th>
            <vs-th >
            </vs-th>
          </vs-tr>
        </template>
        <template #tbody>
          <vs-tr
            :key="i"
            v-for="(tr, i) in $vs.getPage($vs.getSearch(users, search), page, max)"
            :data="tr"
            :is-selected="!!selected.includes(tr)"
            not-click-selected
            open-expand-only-td
          >
            <vs-td>
                 <vs-button success size="mini" v-if="tr.status == 'Aktiv'">
        <p>
          {{tr.status}}
        </p>
      </vs-button>
       <vs-button warn size="mini" v-else-if="tr.status == 'Hanteras'">
           <p>
          {{tr.status}}
        </p>
       </vs-button>
       <vs-button danger size="mini" v-else-if="tr.status == 'Avslutad'">
            <p>
          {{tr.status}}
        </p>
       </vs-button>
            </vs-td>
            <vs-td>
                <p style="float:left;">
              {{ tr.name }}
              </p>
            </vs-td>
            <vs-td >
                <p style="float:left;">
            {{ tr.email }}
            </p>
            </vs-td>
            <vs-td>
            <vs-button @click="active2=!active2">
                Välj
            </vs-button>
            </vs-td>
          </vs-tr>
        </template>
        <template #footer>
          <vs-pagination v-model="page" :length="$vs.getLength($vs.getSearch(users, search), max)"/>
        </template>
      </vs-table>
     </vs-col>
    </vs-row>
    <vs-dialog blur width="850px" not-center v-model="active2">
        <template #header>
          <vs-row>
           <p> <b>Ärende:</b> 4hg23j53h2</p>
          </vs-row>
        </template>
        <vs-row style="text-align:center;">
        <vs-col>
        <div class="con-content">
          <p><b>Status:</b></p>
          <vs-select style="margin:0 auto;" placeholder="Aktiv" v-model="value">
        <vs-option label="Aktiv" style="background-color:green;">
          Aktiv
        </vs-option>
        <vs-option label="Hanteras" style="background-color:orange;">
          Hanteras
        </vs-option>
        <vs-option label="Avslutad" style="background-color:firebrick;">
          Avslutad
        </vs-option>
      </vs-select>
      <p><b>Vad gäller ärendet?</b></p>
      <p>Dataskydd och brott mot IT-säkerhet</p>
      <p><b>Detaljer om ärendet</b></p>
      <p>Skander sålde hemligheter.</p>
      <p><b>När inträffade händelsen?</b></p>
      <p>Igår</p>
      <p><b>Vart inträffade händelsen?</b></p>
      <p>På kontoret</p>
      <vs-row  justify="center">
        <vs-button @click="active2=false" >
              Stäng
            </vs-button>
            <vs-button v-on:click="RouteClick('SafepostBox')" >
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
export default {
  name: 'WhistleHandler',
  methods: {
    RouteClick(route) {
      this.$router.push(route);
    },
  },
  data: () => ({
    active2: false,
    editActive: false,
    edit: null,
    editProp: {},
    search: '',
    allCheck: false,
    page: 1,
    max: 15,
    active: 0,
    value: '',
    selected: [],
    users: [
      {
        status: 'Avslutad',
        name: 'Skander sålde hemligheter',
        email: 'Dataskydd och brott mot IT-säkerhet',
      },
    ],
  }),
};
</script>
