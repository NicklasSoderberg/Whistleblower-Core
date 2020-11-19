<template>
<div>
<vs-row justify="center" align="center">
    <div class="ex2">
        <h1>Information om ditt ärende.</h1>
    </div>
</vs-row>

    <vs-row justify="center" align="center">
    <div class="ex2">
        <h3>Ärende status</h3>
        <p> {{checkStatus}}</p>
        <h3>Vad gäller ärendet?</h3>
        <p>Mutor,korruption & förfalskning</p>
        <h3>Detaljer om ärendet</h3>
        <p>Andre tvättade pengar med företagets ekonomi
        </p>
        <h3>När inträffade händelsen?</h3>
        <p>2020-05-16</p>
        <h3>Vart inträffade händelsen</h3>
        <p>Newton yrkeshögskola i Malmö</p>
    </div>
</vs-row>
</div>
</template>

<script>
export default {
  data: () => ({
    isActive: false,
  }),
  computed: {
    checkStatus() {
      return this.isActive ? 'Aktiv' : 'Hanteras';
    },
  },
};
</script>

<style scoped>

div.ex1 {
  text-align-last: left;
  width: 270px;
}
div.ex2 {
    text-align-last: center;
}
p {
    margin-bottom: 40px;
}
h1 {
    margin-bottom: 40px;
}
</style>
