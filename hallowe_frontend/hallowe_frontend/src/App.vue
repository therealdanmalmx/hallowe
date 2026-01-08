<script setup lang="ts">
  import Navbar from './components/NavbarComp.vue'
  import { RouterView } from 'vue-router'
import ViewSwitch from './components/ViewSwitch.vue';
</script>

<template>
  <div class="py-6">
    <ViewSwitch />
    <RouterView />
    <Navbar />
  </div>
</template>
