<template>
  <div class="hello">
    <form>
      <div id="firstspace">
      <vs-row type="flex" justify="center" align="center">
      <vs-input
        label="Subject name"
        v-model="value"
      >
      </vs-input>
      </vs-row>
      </div>
    </form>
  </div>
</template>

<script>

export default {
  name: 'DialogAddSubject',
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
