<template>
    <div>
      <vs-navbar center-collapsed shadow centerCollapsed v-model="active">
        <template #left>
          <a onclick="window.open('http://www.omegapoint.se', '_blank')">
          <img src="../assets/omegapoint.png" alt="" height="40" width="95">
          </a>
          <p id="NameBatch" v-if="Role == 'lawyer'">
            Inloggad: Sven
          </p>
        </template>
        <template v-if="Role == ''">
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
        <template v-else-if="Role == 'user'">
        </template>
        <template v-else-if="Role == 'lawyer'">
          <vs-navbar-item :active="active == 'Home'" id="Home"
           v-on:click="RouteClick('/')">
            Mina ärende
          </vs-navbar-item>
        </template>
        <template v-else-if="Role == 'admin'">
          <vs-navbar-item :active="active == 'Home'" id="Home"
           v-on:click="RouteClick('/')">
            Ärende
          </vs-navbar-item>
          <vs-navbar-item :active="active == 'CreateLawyer'" id="Lawyer"
          v-on:click="RouteClick('/')">
            Lägg till Advokat
          </vs-navbar-item>
          <vs-navbar-item :active="active == 'CreateSubject'" id="Subject"
          v-on:click="RouteClick('/')">
            Lägg till ämne
          </vs-navbar-item>
        </template>
        <template #right>
          <vs-button flat v-if="Role != ''" >Logout</vs-button>
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
    Role: String,
  },
  name: 'Navigation',
  data: () => ({
    active: 'Home',
  }),
};
</script>

<style>
  #NameBatch{
    margin-left: 50px;
  }
</style>
