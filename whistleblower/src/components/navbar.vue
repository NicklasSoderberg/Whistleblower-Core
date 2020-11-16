<template>
  <div class="center examplex">
    <vs-navbar
      v-model="active"
      center-collapsed
    >
      <template #left>
        <img
          src="/logo2.png"
          alt=""
        >
      </template>
      <vs-navbar-item
        id="guide"
        :active="active == 'guide'"
      >
        Guide
      </vs-navbar-item>
      <vs-navbar-item
        id="docs"
        :active="active == 'docs'"
      >
        Documents
      </vs-navbar-item>
      <vs-navbar-item
        id="components"
        :active="active == 'components'"
      >
        Components
      </vs-navbar-item>
      <vs-navbar-item
        id="license"
        :active="active == 'license'"
      >
        license
      </vs-navbar-item>
      <template #right>
        <vs-button flat>
          Login
        </vs-button>
        <vs-button>Get Started</vs-button>
      </template>
    </vs-navbar>
    <div class="square">
      <div class="child">
        child 1
      </div>
      <div class="child">
        child 2
      </div>
      <div class="child">
        child 3
      </div>
    </div>
  </div>
</template>
  <script>
  export default {
    name: 'Navbar',
    data:() => ({
      active: 'guide'
    })
  }
  </script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
