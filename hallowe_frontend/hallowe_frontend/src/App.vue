<script setup lang="ts">
  import Navbar from './components/NavbarComp.vue'
  import { RouterView, } from 'vue-router'
</script>

<template>
  <div class="py-10">
    <RouterView />
    <Navbar />
  </div>
</template>
