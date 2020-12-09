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
              <vs-input label="Username" id="test1" v-model="username"
              :placeholder= usernameplaceholder>
                <template #icon>
                  <i class="bx bx-user"></i>
                </template>
              </vs-input>
            </vs-row>
          </div>
          <div id="space">
            <vs-row type="flex" justify="center" align="center">
              <vs-input type="password" label="Password" v-model="password"
               :placeholder= passwordplaceholder>
                <template #icon>
                  <i class="bx bx-lock-open-alt"></i>
                </template>
              </vs-input>
            </vs-row>
          </div>
          <div id="space">
            <vs-row type="flex" justify="center" align="center">
              <vs-input label="Förnamn" v-model="firstName" :placeholder= firstNameplaceholder>
                <template #icon>
                  <i class="bx bx-lock-open-alt"></i>
                </template>
              </vs-input>
            </vs-row>
          </div>
          <div id="space">
            <vs-row type="flex" justify="center" align="center">
              <vs-input label="Efternamn" v-model="lastName" :placeholder= lastNameplaceholder>
                <template #icon>
                  <i class="bx bx-lock-open-alt"></i>
                </template>
              </vs-input>
            </vs-row>
          </div>
          <div id="space">
            <vs-row type="flex" justify="center" align="center">
              <vs-input label="Email" v-model="email" :placeholder= emailplaceholder>
                <template #icon>
                  <i class="bx bx-mail-send"></i>
                </template>
              </vs-input>
            </vs-row>
          </div>
          <div id="space">
            <vs-row type="flex" justify="center" align="center">
              <vs-input label="Telefon(Valbar)" v-model="phone" :placeholder = phoneplaceholder>
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
          <vs-button gradient primary @click="createNewLawyer()">
            <i class="bx bxs-user-plus"></i>Lägg till</vs-button
          >
        </vs-row>
      </vs-dialog>
    </div>
  </div>
</template>

<script>
import { required, email } from 'vuelidate/lib/validators';
import lawyer from '../../apicalls/lawyer';
import TableLawyer from './TableLawyer.vue';

export default {
  components: { TableLawyer },
  name: 'HandleLawyersPage',
  data: () => ({
    username: '',
    password: '',
    firstName: '',
    lastName: '',
    email: '',
    phone: '',
    active: false,
    usernameplaceholder: '',
    passwordplaceholder: '',
    firstNameplaceholder: '',
    LastNameplaceholder: '',
    emailplaceholder: '',
    phoneplaceholder: '',
  }),
  validations: {
    username: {
      required,
    },
    password: {
      required,
    },
    firstName: {
      required,
    },
    lastName: {
      required,
    },
    email: {
      required,
      email,
    },
    phone: {
      required,
    },
  },
  methods: {
    async createNewLawyer() {
      if (this.$v.username.required !== false && this.$v.password.required !== false
       && this.$v.firstName.required !== false && this.$v.lastName.required !== false
      && this.$v.email.required !== false && this.$v.email.email !== false
       && this.$v.phone.required !== false) {
        const newlawyer = {
          username: this.username,
          password: this.password,
          firstName: this.firstName,
          lastName: this.lastName,
          email: this.email,
          phone: this.phone,
        };
        await lawyer.create(this.$store.getters.StateUserToken,
          {
            username: newlawyer.username,
            password: newlawyer.password,
            firstName: newlawyer.firstName,
            lastName: newlawyer.lastName,
            email: newlawyer.email,
            phone: newlawyer.phone,
          });
        this.active = !this.active;
        this.username = '';
        this.password = '';
        this.firstName = '';
        this.email = '';
        this.lastName = '';
        this.phone = '';
      } else {
        // eslint-disable-next-line no-lonely-if
        if (this.$v.username.required === false) {
          this.usernameplaceholder = 'Måste vara angiven';
        }
        if (this.$v.password.required === false) {
          this.passwordplaceholder = 'Måste vara angiven';
        }
        if (this.$v.firstName.required === false) {
          this.firstNameplaceholder = 'Måste vara angiven';
        }
        if (this.$v.lastName.required === false) {
          this.lastNameplaceholder = 'Måste vara angiven';
        }
        if (this.$v.email.required === false) {
          this.emailplaceholder = 'Måste vara angiven';
        }
        if (this.$v.email.email === false) {
          this.emailplaceholder = 'Måste vara angiven korrekt';
        }
        if (this.$v.phone.required === false) {
          this.phoneplaceholder = 'Måste vara angiven';
        }
      }
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
