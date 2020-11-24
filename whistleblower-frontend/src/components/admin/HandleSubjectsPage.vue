<template>
  <div class="hello">
    <vs-row type="flex" justify="center" align="center">
    <h3>
      Ämnen
    </h3>
    </vs-row>
    <vs-row type="flex" justify="center" align="center">
    <TableSubject></TableSubject>
    </vs-row>
    <vs-row type="flex" justify="center" align="center">
    <vs-button flat @click="active=!active">
      Lägg till ämne</vs-button>
    </vs-row>
    <div class="center content-inputs">
    <vs-dialog blur not-close v-model="active">
      <vs-row type="flex" justify="center" align="center">
      <h3>
        Lägg till ämne
      </h3>
      </vs-row>
      <DialogAddSubject id=""></DialogAddSubject>
      <div id="space">
      <vs-row type="flex" justify="center" align="center">
         <vs-button flat @click="active=!active">Avbryt</vs-button>
         <vs-button gradient primary @click="active=!active">
           <i class="bx bxs-user-plus"></i>Lägg till</vs-button>
      </vs-row>
      </div>
    </vs-dialog>
  </div>
  </div>
</template>

<script>
import TableSubject from './TableSubject.vue';
import DialogAddSubject from './DialogAddSubject.vue';

export default {
  components: { TableSubject, DialogAddSubject },
  name: 'HandleSubjectsPage',
  data: () => ({
    active: false,
  }),
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
#space{
  margin-top: 35px;
}
</style>
