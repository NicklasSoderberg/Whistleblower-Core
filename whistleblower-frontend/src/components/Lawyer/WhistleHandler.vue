<template>
  <div >
    <vs-row
          justify="center"
          align="center">
     <vs-col id="columntable">
      <vs-table
      id="table"
        v-model="selected"
        >
        <template #header>
          <vs-input v-model="search" border placeholder="Sök" />
        </template>
        <template #thead>
          <vs-tr>
            <vs-th class="Id" sort @click="users = $vs.sortData($event ,users, 'Id')">
                  Id
              </vs-th>
              <vs-th class="status" sort @click="users = $vs.sortData($event ,users, 'status')">
                  Status
              </vs-th>
            <vs-th class="whistle" sort @click="users = $vs.sortData($event ,users, 'name')">
              Ärende
            </vs-th>
            <vs-th class="type" sort @click="users = $vs.sortData($event ,users, 'email')">
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
            :is-selected="selected == tr"
          >
           <vs-td>
                <p style="float:left;">
              {{ tr.Id }}
              </p>
            </vs-td>
            <vs-td>
           <div v-if="tr.status == 'Aktiv'"
           style="background-color:green; width:80%; border-radius:5%;">
           <h3 style="text-align:center; color:white;">Aktiv</h3>
           </div>
       <div v-else-if="tr.status == 'Hanteras'"
           style="background-color:orange; width:80%; border-radius:5%;">
           <h3 style="text-align:center; color:white;">Hanteras</h3>
           </div>
       <div v-else-if="tr.status == 'Avslutad'"
           style="background-color:red; width:80%; border-radius:5%;">
           <h3 style="text-align:center; color:white;">Avslutad</h3>
           </div>
            </vs-td>
            <vs-td>
                <p style="float:left;">
              {{ tr.name }}
              </p>
            </vs-td>
            <vs-td >
                <p style="float:left;" >
              {{ tr.email }}
            </p>
            </vs-td>
            <vs-td>
            <vs-button @click="SelectWhistle($event,tr),active2=!active2">
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
           <p> <b>Ärende:</b> {{selected.Id}}</p>
          </vs-row>
        </template>
        <vs-row style="text-align:center;">
        <vs-col>
        <div class="con-content">
          <p><b>Status:</b></p>
          <vs-select style="margin:0 auto;"
           v-bind="{placeholder:selected.status}" v-model="value">
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
      <p>{{selected.email}}</p>
      <p><b>Detaljer om ärendet</b></p>
      <p>{{selected.name}}</p>
      <p><b>När inträffade händelsen?</b></p>
      <p>{{selected.when}}</p>
      <p><b>Vart inträffade händelsen?</b></p>
      <p>{{selected.where}}</p>
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
  data: () => ({
    selected: '',
    SelectedWhistle: {
      Id: 0,
      status: '',
      name: '',
      email: '',
      when: '',
      where: '',
    },
    active2: false,
    search: '',
    allCheck: false,
    page: 1,
    max: 15,
    active: 0,
    value: '',
    users: [
      {
        Id: 1,
        status: 'Avslutad',
        name: 'Skander sålde hemligheter',
        email: 'Dataskyddken och brott mot IT-säkerhet',
        when: 'Igår',
        where: 'På kontoret',
      },
      {
        Id: 2,
        status: 'Aktiv',
        name: 'Skddander sålde hemligheter',
        email: 'Dataskyddkebab och brott mot IT-säkerhet',
        when: 'Igår',
        where: 'På kontoret',
      },
      {
        Id: 3,
        status: 'Hanteras',
        name: 'Skander såfflde hemligheter',
        email: 'Dataskyddtest och brott mot IT-säkerhet',
        when: 'Igår',
        where: 'På kontoret',
      },
    ],
  }),
  methods: {
    RouteClick(route) {
      this.$router.push(route);
    },
    // eslint-disable-next-line no-unused-vars
    SelectWhistle(a, whistle) {
      this.selected = whistle;
      console.log(whistle);
    },
  },
};
</script>
<style>
.W100{
  width: 100%;
}
@media (max-width: 900px){
#columntable {
    width: 100%;
}
}
@media(min-width: 901px)
{
  #columntable {
    width: 50%;
}
}
</style>
