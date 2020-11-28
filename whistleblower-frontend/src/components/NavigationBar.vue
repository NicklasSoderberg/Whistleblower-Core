<template>
  <div>
    <vs-navbar leftCollapsed shadow v-model="active">
      <template #left>
        <a onclick="window.open('http://www.omegapoint.se', '_blank')">
          <img src="../assets/omegapoint.png" alt="" height="40" width="95" />
        </a>
      </template>
      <template v-if="userRole == null">
        <vs-navbar-item
          :active="active == 'Home'"
          id="Home"
          v-on:click="RouteClick('/')"
        >
          Om
        </vs-navbar-item>
        <vs-navbar-item
          :active="active == 'Create'"
          id="Create"
          v-on:click="RouteClick('Create')"
        >
          Skapa ärende
        </vs-navbar-item>
        <vs-navbar-item
          :active="active == 'FollowUp'"
          id="FollowUp"
          v-on:click="RouteClick('FollowUp')"
        >
          Följ upp ärende
        </vs-navbar-item>
      </template>
      <template v-else-if="userRole == 'User'">
        <vs-navbar-item
          :active="active == 'Mitt ärende'"
          id="Mitt ärende"
          v-on:click="RouteClick('Reportstatus')"
        >
          Mitt ärende
        </vs-navbar-item>
        <vs-navbar-item
          :active="active == 'SafePostBox'"
          id="SafePostBox"
          v-on:click="RouteClick('SafepostBox')"
          icon-after
        >
          SafePostBox
          <i class="bx bxs-message"></i>
        </vs-navbar-item>
      </template>
      <template v-else-if="userRole == 'Lawyer'">
        <vs-navbar-item
          :active="active == 'Home'"
          id="Home"
          v-on:click="RouteClick('/WhistleHandler')"
        >
          Mina ärende
        </vs-navbar-item>
      </template>
      <template v-else-if="userRole == 'Admin'">
        <vs-navbar-item
          :active="active == 'Admin'"
          id="Admin"
          v-on:click="RouteClick('Admin')"
        >
          Ärende
        </vs-navbar-item>
        <vs-navbar-item
          :active="active == 'Lawyer'"
          id="Lawyer"
          v-on:click="RouteClick('NewLawyer')"
        >
          Advokater
        </vs-navbar-item>
        <vs-navbar-item
          :active="active == 'Subject'"
          id="Subject"
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
        <vs-button flat v-if="isLoggedIn" v-on:click="logout()" danger relief
          >Logout</vs-button
        >
        <vs-button flat v-else v-on:click="RouteClick('Login')"
          >Login</vs-button
        >
      </template>
    </vs-navbar>
  </div>
</template>
<script>
import { mapActions } from 'vuex';

export default {
  data: () => ({
    active: 'Home',
  }),
  computed: {
    isLoggedIn() {
      return this.$store.getters.isAuthenticated;
    },
    userRole() {
      return this.$store.getters.StateUserRole;
    },
  },
  methods: {
    RouteClick(route) {
      this.$router.push(route);
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
</style>
