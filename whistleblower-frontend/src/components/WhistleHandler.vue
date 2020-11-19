<template>
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
            <vs-button v-on:click="RouteClick('WhistleSelect')">
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
  </template>

<script>
export default {
  name: 'WhistleSelect',
  data: () => ({
    value: '',
  }),
  methods: {
    RouteClick(route) {
      this.$router.push(route);
    },
  },
};
</script>

<style>

</style>
<script>
export default {
      data:() => ({
        editActive: false,
        edit: null,
        editProp: {},
        search: '',
        allCheck: false,
        page: 1,
        max: 15,
        active: 0,
        selected: [],
        users: [
          {
            "status": "Avslutad",
            "name": "Skander sålde hemligheter",
            "email": "Dataskydd och brott mot IT-säkerhet",
          },
           {
            "status": "Aktiv",
            "name": "Skanders sålde hemligheter",
            "email": "Dataskydd och brott mot IT-säkerhet",
          },
           {
            "status": "Aktiv",
            "name": "Skanders sålde hemligheter",
            "email": "Dataskydd och brott mot IT-säkerhet",
          },
           {
            "status": "Aktiv",
            "name": "Skanders sålde hemligheter",
            "email": "Dataskydd och brott mot IT-säkerhet",
          },
           {
            "status": "Aktiv",
            "name": "Skanders sålde hemligheter",
            "email": "Dataskydd och brott mot IT-säkerhet",
          },
           {
            "status": "Aktiv",
            "name": "Skanders sålde hemligheter",
            "email": "Dataskydd och brott mot IT-säkerhet",
          },
           {
            "status": "Aktiv",
            "name": "Skanders sålde hemligheter",
            "email": "Dataskydd och brott mot IT-säkerhet",
          },
           {
            "status": "Aktiv",
            "name": "Skanders sålde hemligheter",
            "email": "Dataskydd och brott mot IT-säkerhet",
          },
           {
            "status": "Aktiv",
            "name": "Skanders sålde hemligheter",
            "email": "Dataskydd och brott mot IT-säkerhet",
          },
           {
            "status": "Aktiv",
            "name": "Skanders sålde hemligheter",
            "email": "Dataskydd och brott mot IT-säkerhet",
          },
           {
            "status": "Aktiv",
            "name": "Skanders sålde hemligheter",
            "email": "Dataskydd och brott mot IT-säkerhet",
          },
           {
            "status": "Aktiv",
            "name": "Skanders sålde hemligheter",
            "email": "Dataskydd och brott mot IT-säkerhet",
          },
           {
            "status": "Aktiv",
            "name": "Skanders sålde hemligheter",
            "email": "Dataskydd och brott mot IT-säkerhet",
          },
           {
            "status": "Aktiv",
            "name": "Skanders sålde hemligheter",
            "email": "Dataskydd och brott mot IT-säkerhet",
          },
           {
            "status": "Aktiv",
            "name": "Skanders sålde hemligheter",
            "email": "Dataskydd och brott mot IT-säkerhet",
          },
           {
            "status": "Aktiv",
            "name": "Skanders sålde hemligheter",
            "email": "Dataskydd och brott mot IT-säkerhet",
          },
           {
            "status": "Aktiv",
            "name": "Skanders sålde hemligheter",
            "email": "Dataskydd och brott mot IT-säkerhet",
          },
           {
            "status": "Aktiv",
            "name": "Skanders sålde hemligheter",
            "email": "Dataskydd och brott mot IT-säkerhet",
          },
           {
            "status": "Aktiv",
            "name": "Skanders sålde hemligheter",
            "email": "Dataskydd och brott mot IT-säkerhet",
          }
        ]
      })
    }
</script>
