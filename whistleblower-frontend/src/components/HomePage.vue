<template>
  <div>
    <vs-row>
      <vs-col
        w="4"
        class="info-text"
        offset="4"
      >
        <h2>
          Så här lämnar du ditt anonyma meddelande
        </h2>

        <p style="margin-top: 30px;">
          Du behöver inte ha bevis för din misstanke, men alla meddelanden ska lämnas i god tro.<br>

          <br>Du rapporterar enkelt och tryggt genom att följa instruktionerna i formuläret.
           När du har skickat
          ditt meddelande får du ett ID och lösenord på skärmen. Spara dem säkert.
           Du är anonym i den fortsatta dialogen.<br>

          <br>Inom 10 dagar kan du läsa en eventuell följdfråga eller ett svar från oss.
        </p>
        <vs-row
          justify="center"
          align="center"
        >
          <vs-button
            success
            @click="redirectToCreateWhistle()"
          >
            Skapa ärende!
          </vs-button>
          <vs-button
            success
            @click="redirectToUserLogin()"
          >
            Följ upp ärendet
          </vs-button>
        </vs-row>

        <h3 style="text-align:center">
          Vi vill göra rätt
        </h3>
        <p>
          Vårt företag strävar efter att upprätthålla ett öppet affärsklimat och en hög affärsetik.
          I vår verksamhet värnar vi om säkerhet och respekt för alla de människor som berörs av vår
          verksamhet. Du har en viktig roll för att vi ska lyckas.
        </p>

        <h3 style="text-align:center">
          Vår visselblåsartjänst
        </h3>
        <p>
         Visselblåsartjänsten ger alla en möjlighet att informera om en misstanke
          om ett allvarligt missförhållande.
          Vår visselblåsartjänst är ett ”early warning system”
           för att minska risker.
          Den är viktig för att värna god bolagsstyrning och
           bevara kundernas och allmänhetens förtroende för oss.
        </p>
        <p>
          I första hand uppmanar vi dig att vända dig till en chef. Om du känner
           att du inte kan vara öppen med din information erbjuder vi en möjlighet att
          anonymt rapportera din farhåga.
        </p>

        <h3 style="text-align:center">
          När kan jag använda visselblåsartjänsten?
        </h3>
        <p>
          Visselblåsartjänsten kan användas för att lämna information om en farhåga om något som
          inte är i linje med våra värderingar och etiska principer, och som allvarligt kan
          påverka vår organisation eller en människas liv eller hälsa.
        </p>

        <h3 style="text-align:center">
          Så här hanteras ditt meddelande
        </h3>
        <p>
          För att trygga din anonymitet hanteras tjänsten av en extern part WhistleB,
          Whistleblowing Centre, <a
            href="https://whistleb.com"
            target="_blank"
          >https://whistleb.com</a>. Kommunikationskanalen är krypterad och lösenordsskyddad.
        </p>

        <p>
          Alla meddelanden behandlas konfidentiellt. Personuppgift som rör lagöverträdelse
           behandlas enbart för nyckelpersoner eller personer i ledande ställning.
        </p>
      </vs-col>
    </vs-row>
  </div>
</template>

<script>
export default {
  name: 'HomePage',
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
