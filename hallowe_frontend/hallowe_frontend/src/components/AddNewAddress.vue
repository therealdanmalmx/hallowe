<template>
  <div class="flex w-full justify-end" :class="{ 'pt-6': route.path === '/search' }">
      <RouterLink to="/add-address" class="text-slate-200!">
        <button v-if="isAuthenticated && userHasLocation()" class="flex items-center">
            <div class="pi pi-pencil"></div>
            <div class="px-2">Uppdatera address</div>
        </button>
        <button v-else-if="isAuthenticated && !userHasLocation()" class="flex items-center" @click="goToAddress()">
            <div class="pi pi-plus"></div>
            <div class="px-2">Lägg till en ny address</div>
        </button>
        <button v-else class="flex items-center" @click="sendToAddress()">
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
  import { useLocationStore } from "../stores/locationStore.ts";
import { router } from "../router.ts";
  
  const { isAuthenticated, userId } = useUserStore();
  const { locations } = useLocationStore();

  const userHasLocation = () => {
    return !!locations.find((l) => l.userId === userId);
  }

  const route = useRoute();
  const toast = useToast();

  const goToAddress = () => {
    router.push("/add-address")
  }

  const sendToAddress = () => {
    toast.info("Du måste vara inloggad för att lägga till en address", {timeout: 3000})
  }

</script>