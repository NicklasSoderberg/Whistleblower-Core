<template>
  <div class="hello">
    <form>
      <div id="firstspace">
      <vs-row type="flex" justify="center" align="center">
      <vs-input
        label="Full name"
        v-model="value"
      >
      <template #icon>
      <i class='bx bx-user'></i>
      </template>
      </vs-input>
      </vs-row>
      </div>
      <div id="space">
      <vs-row type="flex" justify="center" align="center">
      <vs-input
        label="Password"
        v-model="value"
      >
      <template #icon>
      <i class='bx bx-lock-open-alt'></i>
      </template>
      </vs-input>
      </vs-row>
      </div>
      <div id="space">
      <vs-row type="flex" justify="center" align="center">
      <vs-input
        label="Email"
        v-model="value"
      >
      <template #icon>
      <i class='bx bx-mail-send'></i>
      </template>
      </vs-input>
      </vs-row>
      </div>
      <div id="space">
      <vs-row type="flex" justify="center" align="center">
      <vs-input
        label="Phonenumber"
        v-model="value"
      >
      <template #icon>
      <i class='bx bx-phone'></i>
      </template>
      </vs-input>
      </vs-row>
      </div>
      <div id="space">
      </div>
    </form>
  </div>
</template>

<script>

export default {
  name: 'DialogAddLawyer',
  data: () => ({
  }),
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
#space{
  margin-top: 25px;
}
#firstspace{
  margin-top: 35px;
}
</style>
