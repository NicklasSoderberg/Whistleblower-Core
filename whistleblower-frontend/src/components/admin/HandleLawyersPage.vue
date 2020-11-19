<template>
  <div class="hello">
    <vs-row type="flex" justify="center" align="center">
    <TableLawyer></TableLawyer>
    </vs-row>
    <vs-row type="flex" justify="center" align="center">
    <vs-button flat @click="active=!active">
      Lägg till Advokat</vs-button>
    </vs-row>
    <div class="center content-inputs">
    <vs-dialog blur not-close v-model="active">
      <vs-row type="flex" justify="center" align="center">
      <h3>
        Lägg till advokat
      </h3>
      </vs-row>
      <DialogAddLawyer></DialogAddLawyer>
      <vs-row type="flex" justify="center" align="center">
         <vs-button flat @click="active=!active">Avbryt</vs-button>
         <vs-button gradient primary @click="active=!active">
           <i class="bx bxs-user-plus"></i>Lägg till</vs-button>
      </vs-row>
    </vs-dialog>
    </div>
  </div>
</template>

<script>
import DialogAddLawyer from './DialogAddLawyer.vue';
import TableLawyer from './TableLawyer.vue';

export default {
  components: { DialogAddLawyer, TableLawyer },
  name: 'HandleLawyersPage',
  data: () => ({
    active: false,
  }),
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
