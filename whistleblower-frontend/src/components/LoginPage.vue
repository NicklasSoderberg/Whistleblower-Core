<template>

<body >
  <div class="grid">
          <h3>Ange användarnamn och lösenord för att logga in</h3>
     <vs-row  justify="center" style="margin-bottom: 5px">
       <div justify="left" align="left">
        <vs-input :state="stateUser" v-model="username" :placeholder="userPlaceholder">
          <template #icon>
            <i class='bx bx-user'></i>
          </template>
        </vs-input>
       </div>
</vs-row>

<vs-row justify="center" align="center">
  <div justify="left" align="left">
       <vs-input :state="statePass" type="password"
        v-model="password" :placeholder="passPlaceholder">
          <template #icon>
            <i class='bx bx-lock-open-alt'></i>
          </template>
          <template #message-danger v-if="false">
            <p>Capslock är på</p>
        </template>
        </vs-input>

        <vs-row>
        <vs-button gradient primary @click="this.login">Logga in</vs-button>
        </vs-row>
  </div>

      </vs-row>

  </div>
</body>
</template>

<script>
export default {
  data: () => ({
    username: '',
    password: '',
    active: 0,
    userInput: true,
    passInput: true,
    caps: false,
  }),
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
    checkCapsLock() {
      console.log('caps metod');
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
      console.log('begin');
      if (this.username !== '' && this.password !== '') {
        this.passInput = true;
        this.userInput = true;
      } else {
        console.log('no input begin');
        if (this.username === '') {
          console.log('no usernamelogin');
          this.userInput = false;
        } else {
          this.userInput = true;
        }

        if (this.password === '') {
          console.log('no passwordlogin');
          this.passInput = false;
        } else {
          this.passInput = true;
        }
      }
    },
  },
};
</script>

<style>
.button-positioning {
  right: 8%;
  display: block;
}
h3 {
  margin-top: 170px;
}

</style>
