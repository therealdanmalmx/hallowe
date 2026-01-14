<script setup lang="ts">
  import FlyingBats from '../components/FlyingBatsComp.vue';
import '../style.css';
</script>

<template>
  <div class="bg-[url(../../images/mobile_bg.webp)] bg-cover bg-no-repeat bg-position-[center_bottom] bg-fixed text-center h-screen w-screen overflow-hidden">
    <div class="flex flex-col items-center justify-around lg:justify-center w-full h-dvh gap-8">
      <h1 class="scary-font text-[#ff7518] text-shadow-[#ff0000] text-[4rem]">HALLO WE</h1>
      <p class="secondary-font max-w-10/12 mx-auto lg:max-w-1/3 text-3xl font-semibold text-center text-black text-shadow-[0_0_6px_#ff0000]">Din spöklika adressbok för säsongen. Hitta ställen som är öppna för bus eller godis under Halloween, eller bjud in till dina egna spökliga äventyr!</p>
      <FlyingBats />
      <RouterLink to="/map">
        <button class="scary-font text-slate-800 text-xl">Fortsätt, om du vågar...</button>
      </RouterLink>
    </div>
  </div>
</template>