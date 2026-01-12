<script setup lang="ts">
  import FlyingBats from '../components/FlyingBatsComp.vue'
  import '../style.css'
</script>

<template>
  <div id="start-view">
    <h1 class="text-5xl">HALLO WE</h1>
    <!-- <p>Trick or Treat. . .</p> -->
    <p class="mx-auto rounded-xl max-w-10/12 lg:max-w-1/3 text-3xl text-black font-[Henny-Penny]">Din spöklika adressbok för säsongen. Hitta ställen som är öppna för trick-or-treat under Halloween, eller bjud in till dina egna spökliga äventyr.</p>
    <div class="flying-bat-container">
      <FlyingBats />
    </div>
    <RouterLink to="/map">
      <button class="fixed left-1/2 -translate-x-1/2 bottom-10">Fortsätt, om du vågar...</button>
    </RouterLink>
    </div>
    <div>
    </div>
</template>

<style lang="css" scoped>

  #start-view {
    background-image: url('../../images/mobile_bg.png');
    background-size: cover;
    background-position: top;
    height: 100vh;
    width: 100%;
  }
  h1,
  p {
    position: relative;
    z-index: 10;
  }

  .flying-bat-container {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    /* z-index: 1; */
  }

  /* den med lite lättsam stil*/
  h1 {
    font-family: 'Henny Penny', system-ui;
    color: #ff7518;
    font-size: 4rem;
    text-align: center;
    padding-top: 39vh;
    text-shadow: 0 0 px #ff0000;
  }

  p {
    font-family: 'Fredoka', system-ui;
    font-weight: 600;
    text-align: center;
    margin-top: 1.2rem;
    color: black;
    text-shadow: 0 0 2px #ff0000;
    /* text-shadow: 0 0 4px #000000; */
  }

  /* den som ser lite läskig ut */
  /* h1 {
    font-family: "Rubik Wet Paint", system-ui;
  font-size: 4rem;
  text-align: center;
  padding-top: 38vh;
  color: #ff7518;
} */

  /* h1 {
  font-family: "Rubik Vinyl", system-ui;
  font-size: 4rem;
  color: #ff7518;
  padding-top: 4vh;
} */
</style>
