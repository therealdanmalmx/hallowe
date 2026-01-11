<script setup lang="ts">
  import { RouterView } from 'vue-router';
  import ViewSwitch from './components/ViewSwitch.vue';
</script>

<template>
  <div class="py-6" v-if="$route.path != '/' && $route.path != '/login'">
    <ViewSwitch  />
  </div>
  <RouterView />
</template>
