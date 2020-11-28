<template>

<body >
  <div class="grid">
          <h3 id="titlepos">Ange användarnamn och lösenord för att logga in</h3>
     <form @submit.prevent="submit">
     <vs-row  justify="center" style="margin-bottom: 5px">
       <div justify="left" align="left">
        <vs-input :state="stateUser" v-model="form.username" :placeholder="userPlaceholder">
          <template #icon>
            <i class='bx bx-user'></i>
          </template>
        </vs-input>
        </div>
        </vs-row>

        <vs-row justify="center" align="center">
        <div justify="center" align="center">
        <vs-input :state="statePass" type="password"
        v-model="form.password" :placeholder="passPlaceholder">
          <template #icon>
            <i class='bx bx-lock-open-alt'></i>
          </template>
          <template #message-danger v-if="false">
            <p>Capslock är på</p>
        </template>
        </vs-input>
        <vs-row justify="center" align="center">
        <vs-button gradient primary type="submit">Logga in</vs-button>
      </vs-row>
      </div>
      </vs-row>
      </form>
  </div>
</body>
</template>

<script>
import { mapActions } from 'vuex';

export default {
  name: 'Login',
  data() {
    return {
      form: {
        username: '',
        password: '',
      },
      active: 0,
      userInput: true,
      passInput: true,
      caps: false,
    };
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
      User.username = this.form.username;
      User.password = this.form.password;
      try {
        await this.LogIn(User);
        this.$router.push('Admin');
        this.showError = false;
      } catch (error) {
        this.showError = true;
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
      } else {
        console.log('no input begin');
        if (this.form.username === '') {
          console.log('no usernamelogin');
          this.userInput = false;
        } else {
          this.userInput = true;
        }

        if (this.form.password === '') {
          console.log('no passwordlogin');
          this.passInput = false;
        } else {
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
}

</style>
