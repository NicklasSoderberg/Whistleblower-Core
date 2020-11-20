<template>
    <div>
      <vs-navbar leftCollapsed shadow v-model="active">
        <template #left>
          <a onclick="window.open('http://www.omegapoint.se', '_blank')">
          <img src="../assets/omegapoint.png" alt="" height="40" width="95">
          </a>
          <p v-if="Role == 'lawyer'">
            Inloggad: Sven
          </p>
        </template>
        <template v-if="setRole == ''">
           <vs-navbar-item :active="active == 'Home'" id="Home"
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
        </template>
        <template v-else-if="setRole == 'user'">
          <vs-navbar-item :active="active == 'Mitt ärende'" id="Mitt ärende"
           v-on:click="RouteClick('Reportstatus')">
            Mitt ärende
          </vs-navbar-item>
          <vs-navbar-item :active="active == 'SafePostBox'" id="SafePostBox"
          v-on:click="RouteClick('SafepostBox')" icon-after>
            SafePostBox
            <i class='bx bxs-message' ></i>
          </vs-navbar-item>
        </template>
        <template v-else-if="setRole == 'lawyer'">
          <vs-navbar-item :active="active == 'Home'" id="Home"
           v-on:click="RouteClick('/')">
            Mina ärende
          </vs-navbar-item>
        </template>
        <template v-else-if="setRole == 'admin'">
          <vs-navbar-item :active="active == 'Admin'" id="Admin"
           v-on:click="RouteClick('Admin')">
            Ärende
          </vs-navbar-item>
          <vs-navbar-item :active="active == 'Lawyer'" id="Lawyer"
          v-on:click="RouteClick('NewLawyer')">
            Advokater
          </vs-navbar-item>
          <vs-navbar-item :active="active == 'Subject'" id="Subject"
          v-on:click="RouteClick('NewSubject')">
            Ämnen
          </vs-navbar-item>
        </template>
        <template #right>
          <select v-model="setRole">
            <option></option>
            <option>admin</option>
            <option>user</option>
            <option>lawyer</option>
          </select>
          <vs-button flat v-if="setRole != ''" danger relief>Logout</vs-button>
          <vs-button flat v-else v-on:click="RouteClick('Login')">Login</vs-button>
        </template>
      </vs-navbar>
    </div>
  </template>
<script>
export default {
  data: () => ({
    active: 'Home',
    setRole: '',
  }),
  methods: {
    RouteClick(route) {
      this.$router.push(route);
    },
  },
  props: {
    Role: String,
  },
  name: 'Navigation',
};
</script>

<style>

</style>
