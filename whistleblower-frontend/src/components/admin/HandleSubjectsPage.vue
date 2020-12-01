<template>
  <div class="hello">
    <vs-row type="flex" justify="center" align="center">
      <h3>Ämnen</h3>
    </vs-row>
    <vs-row type="flex" justify="center" align="center">
      <TableSubject :key="active"></TableSubject>
    </vs-row>
    <vs-row type="flex" justify="center" align="center">
      <vs-button flat @click="active = !active"> Lägg till ämne</vs-button>
    </vs-row>
    <div class="center content-inputs">
      <vs-dialog blur not-close v-model="active">
        <vs-row type="flex" justify="center" align="center">
          <h3>Lägg till ämne</h3>
        </vs-row>
        <div class="hello">
          <div id="firstspace">
            <vs-row type="flex" justify="center" align="center">
              <vs-input label="Visningsnamn" v-model="subjectName"> </vs-input>
            </vs-row>
          </div>
        </div>
        <div id="space">
          <vs-row type="flex" justify="center" align="center">
            <vs-button gradient primary @click="createSubject(subjectName), active = !active">
              Lägg till</vs-button
            >
            <vs-button flat @click="active = !active">Avbryt</vs-button>
          </vs-row>
        </div>
      </vs-dialog>
    </div>
  </div>
</template>

<script>
import TableSubject from './TableSubject.vue';
import subject from '../../apicalls/subject';

export default {
  components: { TableSubject },
  name: 'HandleSubjectsPage',
  data: () => ({
    active: false,
    subjectName: '',
  }),
  methods: {
    createSubject() {
      subject.create(this.$store.getters.StateUserToken, {
        subjectID: 0,
        text: this.subjectName,
        created: null,
        modified: null,
        deleted: null,
        active: true,
      });
      this.subjectName = '';
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
#space {
  margin-top: 25px;
}
</style>
