<template>

<body >
  <div class="grid">
          <h3 id="titlepos">Ange användarnamn och lösenord för att logga in</h3>
     <form @submit.prevent="submit">
     <vs-row  justify="center" style="margin-bottom: 5px">
       <div justify="left" align="left" :class="{ 'form-group--error': $v.username.$error }">
        <vs-input :state="stateUser" v-model="username"
        v-model.trim="$v.username.$model"
        :placeholder="userPlaceholder">
          <template #icon>
            <i class='bx bx-user'></i>
          </template>
        </vs-input>
        </div>
        </vs-row>
      <vs-row justify="center">
         <div class="error" v-if="!$v.username.required" >Användarnamnet måste vara ifyllt</div>
      </vs-row>
        <vs-row justify="center" align="center">
        <div justify="center" align="center" :class="{ 'form-group--error': $v.password.$error }">
        <vs-input :state="statePass" type="password"
        v-model="password" :placeholder="passPlaceholder"
        v-model.trim="$v.password.$model"
        >
          <template #icon>
            <i class='bx bx-lock-open-alt'></i>
          </template>
          <template #message-danger v-if="wrongLogin">
            <p>ID och lösenord stämmer inte.</p>
        </template>
        </vs-input>
          </div>
      </vs-row>
        <vs-row justify="center">
         <div class="error" v-if="!$v.password.required" >Lösenordet måste vara ifyllt</div>
      </vs-row>
        <vs-row justify="center">
        <div class="error" v-if="submitStatus === 'ERROR'"><p>Fälten måste vara ifyllda</p></div>
      </vs-row>
        <vs-row justify="center" align="center">
        <vs-button gradient primary type="submit">Logga in</vs-button>
      </vs-row>
      </form>

  </div>
</body>
</template>

<script>
import { mapActions } from 'vuex';
import { required } from 'vuelidate/lib/validators';

// eslint-disable-next-line no-undef
export default {
  name: 'Login',
  data() {
    return {
      username: '',
      password: '',
      submitStatus: null,
      active: 0,
      userInput: true,
      passInput: true,
      caps: false,
      wrongLogin: false,
    };
  },
  validations: {
    username: {
      required,
    },
    password: {
      required,
    },
  },
  computed: {
    stateUser() {
      return this.userInput ? 'dark' : 'danger';
    },
    statePass() {
      return this.passInput ? 'dark' : 'danger';
    },
    passPlaceholder() {
      return this.passInput ? 'Lösenord' : 'Måste anges';
    },
    userPlaceholder() {
      return this.userInput ? 'Användarnamn' : 'Måste anges';
    },
  },
  methods: {
    ...mapActions(['LogIn']),
    async submit() {
      const User = { username: '', password: '' };
      User.username = this.username;
      User.password = this.password;
      console.log(this.$v.$invalid);
      this.$v.$touch();
      if (this.$v.$invalid) {
        this.submitStatus = 'ERROR';
      } else {
        try {
          this.submitStatus = 'PENDING';
          setTimeout(() => {
            this.submitStatus = 'OK';
          }, 500);
          await this.LogIn(User);
          switch (this.$store.getters.StateUserRole) {
            case 'Admin':
              this.$router.push('admin');
              break;
            case 'Lawyer':
              this.$router.push('whistlehandler');
              break;
            case 'User':
              this.$router.push('reportstatus');
              break;
            default:
              break;
          }
          this.showError = false;
        } catch (error) {
          this.showError = true;
        }
      }
    },
    checkCapsLock() {
      const input = document.getElementById('username');

      input.addEventListener('keyup', (event) => {
        if (event.getModifierState('CapsLock')) {
          this.caps = true;
        } else {
          this.caps = false;
        }
      });
    },
    login() {
      if (this.form.username !== '' && this.form.password !== '') {
        this.passInput = true;
        this.userInput = true;
        if (this.username === 'WhistleMock' && this.password === 'Test123') {
          this.$router.push('ReportStatus');
        } else {
          this.wrongLogin = true;
        }
      } else {
        console.log('no input begin');
        if (this.form.username === '') {
          console.log('no usernamelogin');
          this.userInput = false;
        } else {
          this.wrongLogin = false;
          this.userInput = true;
        }

        if (this.form.password === '') {
          console.log('no passwordlogin');
          this.passInput = false;
        } else {
          this.wrongLogin = false;
          this.passInput = true;
        }
      }
    },
  },
};
</script >

<style scoped>
.button-positioning {
  right: 8%;
  display: block;
}
#titlepos {
  margin-top: 170px;
  text-align: center;
}

</style>
