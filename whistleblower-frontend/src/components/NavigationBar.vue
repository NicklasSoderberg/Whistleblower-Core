<template>
    <div>
      <vs-navbar center-collapsed shadow="true" centerCollapsed="true" v-model="active">
        <template #left>
          <a onclick="window.open('http://www.omegapoint.se', '_blank')">
          <img src="../assets/omegapoint.png" alt="" height="40" width="95">
          </a>
        </template>
        <vs-navbar-item :active="active == 'HomePage'" id="HomePage"
        v-on:click="RouteClick('/')">
          Om
        </vs-navbar-item>
        <vs-navbar-item :active="active == 'Create'" id="Create"
        v-on:click="RouteClick('Create')">
          Skapa ärende
        </vs-navbar-item>
        <vs-navbar-item :active="active == 'FollowUp'" id="FollowUp"
        v-on:click="RouteClick('FollowUp')">
          Följ upp ärende
        </vs-navbar-item>
        <template #right>
          <vs-button flat v-if="LoggedIn" >Logout</vs-button>
          <vs-button flat v-else v-on:click="RouteClick('Login')">Login</vs-button>
        </template>
      </vs-navbar>
    </div>
  </template>
<script>
export default {
  methods: {
    RouteClick(route) {
      this.$router.push(route);
    },
  },
  props: {
    LoggedIn: Boolean,
  },
  name: 'Navigation',
  data: () => ({
    active: 'Home',
  }),
};
</script>

<style>
</style>
