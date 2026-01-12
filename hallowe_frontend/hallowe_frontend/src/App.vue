<script setup lang="ts">
  import { RouterView } from 'vue-router';
  import ViewSwitch from './components/ViewSwitch.vue';
  import Footer from './components/Footer.vue';
</script>

<template>
  <div class="py-6" v-if="$route.path != '/' && $route.path != '/login' && $route.path != '/register'">
    <ViewSwitch  />
  </div>
  <RouterView />
  <Footer v-if="$route.path != '/' && $route.path != '/login' && $route.path != '/register'" />
</template>
