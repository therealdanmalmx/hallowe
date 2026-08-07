<template>
  <div class="flex w-full justify-end" :class="{ 'pt-6': $route.path === '/search' }">
      <RouterLink to="/add-address">
        <button v-if="isAuthenticated" class="flex items-center">
            <div class="pi pi-pencil"></div>
            <div class="px-2">Uppdatera address</div>
        </button>
        <button v-else class="flex items-center">
            <div class="pi pi-plus"></div>
            <div class="px-2">Lägg till en ny address</div>
        </button>
      </RouterLink>
  </div>
</template>

<script setup lang="ts">
  import { useUserStore } from "../stores/userStore.ts"

  const { isAuthenticated } = useUserStore();
</script>