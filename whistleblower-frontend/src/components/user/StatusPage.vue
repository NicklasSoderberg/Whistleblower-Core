<template>
<div>
<vs-row justify="center" align="center">
    <div class="ex2">
        <h1>Information om ditt ärende.</h1>
    </div>
</vs-row>

    <vs-row justify="center" align="center">
    <div class="form-body ex1">
        <div class="form-group" >
            <h2>Ärende status</h2>
            <p> {{whistle.currentStatus}}</p>
        </div>

        <div class="form-group" >
            <h2>Vad gäller ärendet?</h2>
            <p>{{whistle.aboutInfo}}</p>
        </div>

        <div class="form-group" >
            <h2>Detaljer om ärendet</h2>
            <p>{{whistle.descriptionInfo}}</p>
        </div>

        <div class="form-group" >
            <h2>Är andra anställda medvetna om detta</h2>
            <p>{{whistle.otherEmployeeInfo}}</p>
        </div>

        <div class="form-group" >
            <h2>Vart inträffa händelsen</h2>
            <p>{{whistle.whereInfo}}</p>
        </div>

        <div class="form-group" >
            <h2>När inträffa händelsen</h2>
            <p>{{whistle.whenInfo}}</p>
        </div>
    </div>
</vs-row>
</div>
</template>

<script>
import whistle from '../../apicalls/whistle';

export default {

  data: () => ({
    isActive: false,
    whistle: {},
  }),
  computed: {
    checkStatus() {
      return this.isActive ? 'Aktiv' : 'Hanteras';
    },
  },
  methods: {
    getWhistle() {
      whistle.getByUserId(this.$store.getters.StateUserToken,
        this.$store.getters.StateUserId).then((response) => {
        this.whistle = response;
      });
      console.log(this.whistle);
    },
  },
  mounted() {
    this.getWhistle();
  },
};
</script>

<style scoped>

div.ex1 {
  text-align-last: left;
  width: 270px;
  margin-top: 25px;
}
div.ex2 {
    text-align-last: center;
}
.form-body {
    display: table;
    margin: auto;
    width: auto;
    box-sizing: border-box;
}
.form-group {
    margin-bottom: 25px;
    width: auto;
}
h2 {
    font-size: 17px;
}
</style>
