<template>
  <div>
    <vs-navbar leftCollapsed shadow v-model="curRoute">
      <template #left>
        <a onclick="window.open('http://www.omegapoint.se', '_blank')">
          <img src="../assets/omegapoint.png" alt="" height="40" width="95" />
        </a>
      </template>
      <template v-if="userRole == null">
        <vs-navbar-item
          :active="curRoute == 'HomePage'"
          id="HomePage"
          v-on:click="RouteClick('/')"
        >
          Om
        </vs-navbar-item>
        <vs-navbar-item
          :active="curRoute == 'Create'"
          id="Create"
          v-on:click="RouteClick('Create')"
        >
          Skapa ärende
        </vs-navbar-item>
        <vs-navbar-item
          :active="curRoute == 'FollowUp'"
          id="FollowUp"
          v-on:click="RouteClick('Login')"
        >
          Följ upp ärende
        </vs-navbar-item>
      </template>
      <template v-else-if="userRole == 'User'">
        <vs-navbar-item
          :active="curRoute == 'Mitt ärende'"
          id="Mitt ärende"
          v-on:click="RouteClick('Reportstatus')"
        >
          Mitt ärende
        </vs-navbar-item>
        <vs-navbar-item
          :active="curRoute == 'SafePostBox'"
          id="SafePostBox"
          v-on:click="RouteClick('SafepostBox')"
          icon-after
        >
          SafePostBox
          <i class="bx bxs-message"
          v-if="whistle.lastSender == 0"></i>
        </vs-navbar-item>
      </template>
      <template v-else-if="userRole == 'Lawyer'">
        <vs-navbar-item
          :active="curRoute == 'Home'"
          id="Home"
          v-on:click="RouteClick('/WhistleHandler')"
          v-if="checkMessages === -1"
        >
          Mina ärende
        </vs-navbar-item>

      </template>
      <template v-else-if="userRole == 'Admin'">
        <vs-navbar-item
          :active="curRoute== 'AdminPage'"
          id="AdminPage"
          v-on:click="RouteClick('Admin')"
        >
          Ärende
        </vs-navbar-item>
        <vs-navbar-item
          :active="curRoute == 'AdminNewLawyer'"
          id="AdminNewLawyer"
          v-on:click="RouteClick('NewLawyer')"
        >
          Advokater
        </vs-navbar-item>
        <vs-navbar-item
          :active="curRoute == 'AdminNewSubject'"
          id="AdminNewSubject"
          v-on:click="RouteClick('NewSubject')"
        >
          Ämnen
        </vs-navbar-item>
      </template>
      <template #right>
        <span v-if="isLoggedIn">
          <p>Auth: Logged in</p>
        </span>
        <span v-else>
          <p>Auth: Not logged in</p>
        </span>
        <vs-navbar-item
          :active="curRoute == 'Login'"
          id="Login"
        >
        <vs-button flat v-if="isLoggedIn" v-on:click="logout()" danger relief
          >Logout</vs-button
        >
        <vs-button flat v-else v-on:click="RouteClick('Login')"
          >Login</vs-button
        >
        </vs-navbar-item>
      </template>
    </vs-navbar>
  </div>
</template>

<script>
import { mapActions } from 'vuex';
import whistleApi from '../apicalls/whistle';

export default {
  data: () => ({
    newMessage: true,
    curRoute: '',
    whistle: {},
    disable: false,
  }),
  computed: {
    isLoggedIn() {
      return this.$store.getters.isAuthenticated;
    },
    userRole() {
      return this.$store.getters.StateUserRole;
    },
  },
  async mounted() {
    this.interval = setInterval(() => this.checkCurrentRoute(), 1000);
  },
  methods: {
    async getWhistle() {
      await whistleApi.getByUserId(this.$store.getters.StateUserToken,
        this.$store.getters.StateUserId).then((response) => {
        this.whistle = response;
      });
    },
    RouteClick(route) {
      this.$router.push(route);
      this.curRoute = this.$route.name;
    },
    async checkCurrentRoute() {
      if (this.userRole === 'User') {
        await this.getWhistle();
      }
    },
    ...mapActions(['LogOut']),
    async LogOutUser() {
      try {
        await this.LogOut();
        this.$router.push('/');
        this.showError = false;
      } catch (error) {
        this.showError = true;
      }
    },
    async logout() {
      await this.$store.dispatch('LogOut');
      this.$router.push('Login');
    },
  },
  name: 'Navigation',
};
</script>

<style>
.msgicon {
  color: rgb(212, 52, 52)
}
</style>
