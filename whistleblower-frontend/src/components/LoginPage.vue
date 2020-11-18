<template>

<body >
  <div class="grid">
     <vs-row  justify="center" style="margin-bottom: 5px">
        <vs-input v-model="username" placeholder="User name">
          <template class="" #message-danger v-if="username === ''">
            <p>Requried</p>
        </template>
          <template #icon>
            <i class='bx bx-user'></i>
          </template>
        </vs-input>
</vs-row>

<vs-row justify="center" align="center">
  <div justify="left" align="left">
        <vs-input type="password" v-model="password" placeholder="Password" justify="left">
          <template #icon>
            <i class='bx bx-lock-open-alt'></i>
          </template>
          <template #message-danger v-if="username === ''">
            <p v-if="true">Capslock är på</p>
        </template>
        </vs-input>
          </div>
      </vs-row>

<vs-row justify="center" align="center">
        <vs-button class="button-positioning"
        flat
        :active="active == 1"
        @click="active = 1"
      >
        login
      </vs-button>
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
  }),
  methods: {
    login() {
      if (this.input.username !== '' && this.input.password !== '') {
        if (this.input.username === this.$parent.mockAccount.username
         && this.input.password === this.$parent.mockAccount.password) {
          this.$emit('authenticated', true);
          this.$router.replace({ name: 'secure' });
        } else {
          console.log('The username and / or password is incorrect');
        }
      } else {
        console.log('A username and password must be present');
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

</style>
