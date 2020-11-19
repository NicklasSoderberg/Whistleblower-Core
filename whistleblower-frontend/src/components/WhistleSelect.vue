<template>
    <vs-row justify="center" align="center">
        <vs-col w="6">
        <h2>Ärende:</h2>
        <p>4hg23j53h2</p>
        <p><b>Status:</b></p>
          <vs-select style="margin:0 auto;" placeholder="Select" v-model="value">
        <vs-option label="Aktiv" value="1">
          Aktiv
        </vs-option>
        <vs-option label="Hanteras" value="2">
          Hanteras
        </vs-option>
        <vs-option label="Avslutad" value="3">
          Avslutad
        </vs-option>
      </vs-select>
      <p><b>Vad gäller ärendet?</b></p>
      <p>Dataskydd och brott mot IT-säkerhet</p>
      <p><b>Detaljer om ärendet</b></p>
      <p>Skander sålde hemligheter.</p>
      <p><b>När inträffade händelsen?</b></p>
      <p>Igår</p>
      <p><b>Vart inträffade händelsen?</b></p>
      <p>På kontoret</p>
      <vs-row justify="center">
          <vs-button v-on:click="RouteClick('whistlehandler')">Öppna Safebox</vs-button>
      </vs-row>
        </vs-col>
    </vs-row>
</template>
<script>
export default {
  name: 'WhistleSelect',
  data: () => ({
    value: '',
  }),
  methods: {
    RouteClick(route) {
      this.$router.push(route);
    },
  },
};
</script>
<style>

</style>
