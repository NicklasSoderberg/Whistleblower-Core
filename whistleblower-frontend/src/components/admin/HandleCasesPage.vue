<template>
  <div class="hello">
    <vs-row type="flex" justify="center" align="center">
    <h3>
      Ärende
    </h3>
    </vs-row>
    <vs-row type="flex" justify="center" align="center">
    <TableWhistle></TableWhistle>
    </vs-row>
  </div>
</template>

<script>
import TableWhistle from './TableWhistle.vue';

export default {
  name: 'HandleCasesPage',
  components: { TableWhistle },
  data: () => ({
  }),
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
