<template>
  <div class="hello">
    <h3>
      Är du säker du vill ta bort {{Name}}?
    </h3>
  </div>
</template>

<script>

export default {
  name: 'DialogDeleteLawyer',
  data: () => ({
  }),
  props: {
    Name: String,
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
