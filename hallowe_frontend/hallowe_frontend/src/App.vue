<script setup lang="ts">
  import { RouterView } from 'vue-router';
  import ViewSwitch from './components/ViewSwitch.vue';

  const logout = async () => {
    console.log("logged put")
    const loggedOut = await fetch("http://localhost:5168/api/user/logout", {
        method: "POST",
        credentials: "include",
      });

      console.log({loggedOut})
      if (loggedOut.ok)
      {
        window.location.href = '/map'
      }
  }
</script>

<template>
    <div v-if="$route.path != '/' && $route.path != '/login' && $route.path != '/register'" class="py-6 w-11/12 mx-auto">
      <ViewSwitch  />
    </div>
    <div @click="() => logout()">
      Logout
    </div>
    <RouterView />
</template>
