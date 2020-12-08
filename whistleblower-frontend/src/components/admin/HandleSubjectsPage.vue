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
              <vs-row justify="center">
         <div class="error" v-if="SumbitError" >Namnet måste vara ifyllt</div>
      </vs-row>
          </div>
        </div>
        <div id="space">
          <vs-row type="flex" justify="center" align="center">
            <vs-button gradient primary @click="createSubject(subjectName)">
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
import { required } from 'vuelidate/lib/validators';
import TableSubject from './TableSubject.vue';
import subject from '../../apicalls/subject';

export default {
  components: { TableSubject },
  name: 'HandleSubjectsPage',
  data: () => ({
    active: false,
    subjectName: '',
    SumbitError: false,
  }),
  validations: {
    subjectName: {
      required,
    },
  },
  methods: {
    createSubject() {
      if (this.$v.subjectName.required !== false) {
        this.SumbitError = false;
        subject.create(this.$store.getters.StateUserToken, {
          subjectID: 0,
          text: this.subjectName,
          created: null,
          modified: null,
          deleted: null,
          active: true,
        });
        this.active = !this.active;
        this.subjectName = '';
      } else {
        this.SumbitError = true;
      }
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
