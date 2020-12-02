<template>
  <div class="hello" id="first">
    <vs-row type="flex" justify="center" align="center">
      <h3>Advokater</h3>
    </vs-row>
    <vs-row type="flex" justify="center" align="center">
      <TableLawyer :key="active"></TableLawyer>
    </vs-row>
    <vs-row type="flex" justify="center" align="center">
      <vs-button flat @click="active = !active"> Lägg till Advokat</vs-button>
    </vs-row>
    <div class="center content-inputs">
      <vs-dialog blur not-close v-model="active">
        <vs-row type="flex" justify="center" align="center">
          <h3>Lägg till advokat</h3>
        </vs-row>
        <form>
          <div id="firstspace">
            <vs-row type="flex" justify="center" align="center">
              <vs-input label="Username" v-model="newLawyer.username">
                <template #icon>
                  <i class="bx bx-user"></i>
                </template>
              </vs-input>
            </vs-row>
          </div>
          <div id="space">
            <vs-row type="flex" justify="center" align="center">
              <vs-input type="password" label="Password" v-model="newLawyer.password">
                <template #icon>
                  <i class="bx bx-lock-open-alt"></i>
                </template>
              </vs-input>
            </vs-row>
          </div>
          <div id="space">
            <vs-row type="flex" justify="center" align="center">
              <vs-input label="Förnamn" v-model="newLawyer.firstName">
                <template #icon>
                  <i class="bx bx-lock-open-alt"></i>
                </template>
              </vs-input>
            </vs-row>
          </div>
          <div id="space">
            <vs-row type="flex" justify="center" align="center">
              <vs-input label="Efternamn" v-model="newLawyer.lastName">
                <template #icon>
                  <i class="bx bx-lock-open-alt"></i>
                </template>
              </vs-input>
            </vs-row>
          </div>
          <div id="space">
            <vs-row type="flex" justify="center" align="center">
              <vs-input label="Email" v-model="newLawyer.email">
                <template #icon>
                  <i class="bx bx-mail-send"></i>
                </template>
              </vs-input>
            </vs-row>
          </div>
          <div id="space">
            <vs-row type="flex" justify="center" align="center">
              <vs-input label="Telefon" v-model="newLawyer.phone">
                <template #icon>
                  <i class="bx bx-phone"></i>
                </template>
              </vs-input>
            </vs-row>
          </div>
          <div id="space"></div>
        </form>
        <vs-row type="flex" justify="center" align="center">
          <vs-button flat @click="active = !active">Avbryt</vs-button>
          <vs-button gradient primary @click="createNewLawyer(), active = !active">
            <i class="bx bxs-user-plus"></i>Lägg till</vs-button
          >
        </vs-row>
      </vs-dialog>
    </div>
  </div>
</template>

<script>
import lawyer from '../../apicalls/lawyer';
import TableLawyer from './TableLawyer.vue';

export default {
  components: { TableLawyer },
  name: 'HandleLawyersPage',
  data: () => ({
    newLawyer: {
      username: '',
      password: '',
      firstName: '',
      lastName: '',
      email: '',
      phone: '',
    },
    active: false,
  }),
  methods: {
    async createNewLawyer() {
      await lawyer.create(this.$store.getters.StateUserToken,
        {
          username: this.newLawyer.username,
          password: this.newLawyer.password,
          firstName: this.newLawyer.firstName,
          lastName: this.newLawyer.lastName,
          email: this.newLawyer.email,
          phone: this.newLawyer.phone,
        });
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
#first {
  margin-top: 50px;
}
</style>
