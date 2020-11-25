<template>
    <vs-row type="flex" justify="center" align="center" >
        <vs-col>
            <h3>Ändra personuppgifter:</h3>
            <form>
                <vs-row type="flex" justify="center" align="center">
                <vs-input label="Namn:" :placeholder=Name >
                </vs-input>
                </vs-row>
                <br>
                 <vs-row type="flex" justify="center" align="center">
                <vs-input label="Email:" :placeholder=Email >
                </vs-input>
                 </vs-row>
                <br>
                 <vs-row type="flex" justify="center" align="center">
                <vs-input label="Telefonnummer:" :placeholder="pNumber" >
                </vs-input>
                 </vs-row>

            </form>
        </vs-col>
    </vs-row>
</template>
<script>
export default {
  name: 'DialogEditLawyer',
  props: {
    Name: String,
    Email: String,
    pNumber: String,

  },
  data: () => ({
  }),
};
</script>
