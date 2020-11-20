<template>
  <div>
      <vs-table v-model="selected" striped>
        <template #header>
          <vs-input v-model="search" border placeholder="Search" />
        </template>
        <template #thead>
          <vs-tr>
            <vs-th sort @click="users = $vs.sortData($event ,users, 'name')">
              Fullname
            </vs-th>
            <vs-th sort @click="users = $vs.sortData($event ,users, 'email')">
              Email
            </vs-th>
            <vs-th sort @click="users = $vs.sortData($event ,users, 'phonenumber')">
              Phonenumber
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
              {{ tr.name }}
            </vs-td>
            <vs-td>
            {{ tr.email }}
            </vs-td>
            <vs-td>
            {{ tr.phonenumber }}
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
          <vs-pagination v-model="page" :length="$vs.getLength(users, max)" />
        </template>
      </vs-table>
      <vs-dialog blur not-close v-model="active">
        <DialogDelete :Name=selected.name></DialogDelete>
        <vs-row type="flex" justify="center" align="center">
         <vs-button flat @click="active=!active">Avbryt</vs-button>
         <vs-button gradient primary @click="active=!active">
           <i class="bx bxs-user-plus"></i>Ta bort</vs-button>
        </vs-row>
      </vs-dialog>
    </div>
</template>

<script>
import DialogDelete from './DialogDelete.vue';

export default {
  components: { DialogDelete },
  name: 'TableLawyer',
  data: () => ({
    selected: { name: '' },
    active: false,
    search: '',
    page: 1,
    max: 10,
    users: [
      {
        id: 1,
        name: 'Leanne Graham',
        username: 'Bret',
        email: 'Sincere@april.biz',
        phonenumber: 'hildegard.org',
      },
      {
        id: 2,
        name: 'Ervin Howell',
        username: 'Antonette',
        email: 'Shanna@melissa.tv',
        phonenumber: 'anastasia.net',
      },
      {
        id: 3,
        name: 'Clementine Bauch',
        username: 'Samantha',
        email: 'Nathan@yesenia.net',
        phonenumber: 'ramiro.info',
      },
      {
        id: 4,
        name: 'Patricia Lebsack',
        username: 'Karianne',
        email: 'Julianne.OConner@kory.org',
        phonenumber: 'kale.biz',
      },
      {
        id: 5,
        name: 'Chelsey Dietrich',
        username: 'Kamren',
        email: 'Lucio_Hettinger@annie.ca',
        phonenumber: 'demarco.info',
      },
      {
        id: 6,
        name: 'Mrs. Dennis Schulist',
        username: 'Leopoldo_Corkery',
        email: 'Karley_Dach@jasper.info',
        phonenumber: 'ola.org',
      },
      {
        id: 7,
        name: 'Kurtis Weissnat',
        username: 'Elwyn.Skiles',
        email: 'Telly.Hoeger@billy.biz',
        phonenumber: 'elvis.io',
      },
      {
        id: 8,
        name: 'Nicholas Runolfsdottir V',
        username: 'Maxime_Nienow',
        email: 'Sherwood@rosamond.me',
        phonenumber: 'jacynthe.com',
      },
      {
        id: 9,
        name: 'Glenna Reichert',
        username: 'Delphine',
        email: 'Chaim_McDermott@dana.io',
        phonenumber: 'conrad.com',
      },
      {
        id: 10,
        name: 'Clementina DuBuque',
        username: 'Moriah.Stanton',
        email: 'Rey.Padberg@karina.biz',
        phonenumber: 'ambrose.net',
      },
      {
        id: 3,
        name: 'Clementine Bauch',
        username: 'Samantha',
        email: 'Nathan@yesenia.net',
        phonenumber: 'ramiro.info',
      },
      {
        id: 4,
        name: 'Patricia Lebsack',
        username: 'Karianne',
        email: 'Julianne.OConner@kory.org',
        phonenumber: 'kale.biz',
      },
      {
        id: 5,
        name: 'Chelsey Dietrich',
        username: 'Kamren',
        email: 'Lucio_Hettinger@annie.ca',
        phonenumber: 'demarco.info',
      },
      {
        id: 6,
        name: 'Mrs. Dennis Schulist',
        username: 'Leopoldo_Corkery',
        email: 'Karley_Dach@jasper.info',
        phonenumber: 'ola.org',
      },
      {
        id: 7,
        name: 'Kurtis Weissnat',
        username: 'Elwyn.Skiles',
        email: 'Telly.Hoeger@billy.biz',
        phonenumber: 'elvis.io',
      },
      {
        id: 8,
        name: 'Nicholas Runolfsdottir V',
        username: 'Maxime_Nienow',
        email: 'Sherwood@rosamond.me',
        phonenumber: 'jacynthe.com',
      },
      {
        id: 9,
        name: 'Glenna Reichert',
        username: 'Delphine',
        email: 'Chaim_McDermott@dana.io',
        phonenumber: 'conrad.com',
      },
      {
        id: 10,
        name: 'Clementina DuBuque',
        username: 'Moriah.Stanton',
        email: 'Rey.Padberg@karina.biz',
        phonenumber: 'ambrose.net',
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
