<script setup lang="ts">
  import { RouterView } from 'vue-router';
  import ViewSwitch from './components/ViewSwitch.vue';
</script>

<template>
    <div v-if="$route.path != '/' && $route.path != '/login' && $route.path != '/register'" class="py-6 w-11/12 mx-auto">
      <ViewSwitch  />
    </div>
    <RouterView />
</template>
