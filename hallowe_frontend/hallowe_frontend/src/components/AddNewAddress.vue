<template>
  <div class="flex w-full justify-end" :class="{ 'pt-6': route.path === '/search' }">
      <RouterLink to="/add-address">
        <button v-if="isAuthenticated" class="flex items-center">
            <div class="pi pi-pencil"></div>
            <div class="px-2">Uppdatera address</div>
        </button>
        <button v-else class="flex items-center" @click="sendToAddress()"">
            <div class="pi pi-plus"></div>
            <div class="px-2">Lägg till en ny address</div>
        </button>
      </RouterLink>
  </div>
</template>

<script setup lang="ts">
  import { useRoute } from "vue-router"
  import { useUserStore } from "../stores/userStore.ts"
  import { useToast } from "vue-toastification";
  
  const { isAuthenticated } = useUserStore();
  const route = useRoute();
  const toast = useToast();

  const sendToAddress = () => {
    toast.warning("Du måste ha ett konto för att registrera en address", {timeout: 3000})
  }

</script>