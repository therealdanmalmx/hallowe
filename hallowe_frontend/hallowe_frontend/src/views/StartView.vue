<script setup lang="ts">
  import FlyingBats from '../components/FlyingBatsComp.vue'
  import '../style.css'
</script>

<template>
  <RouterLink to="/map">
    <div id="start-view">
      <h1 class="text-5xl">HALLO WE</h1>
      <p>Trick or Treat. . .</p>
      <div class="flying-bat-container">
        <FlyingBats />
      </div>
    </div>
  </RouterLink>
</template>

<style lang="css" scoped>

  #start-view {
    background-image: url('../../public/images/mobile_bg.png');
    background-size: cover;
    background-position: top;
    height: 100vh;
    width: 100%;
    position: relative;
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
    text-shadow: 0 0 4px #ff0000;
  }

  p {
    font-family: 'Fredoka', system-ui;
    font-size: 2.5rem;
    font-weight: 600;
    text-align: center;
    margin-top: 1.2rem;
    color: black;
    text-shadow: 0 0 3px #ff0000;
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
