<template>
  <div class="flex w-full items-center justify-center md:justify-end">
    <div class="relative w-30 h-12">
      <!-- Main pill shape -->
      <div class="absolute inset-0 border-2 border-[#ff7518] rounded-full"></div>

      <!-- Center divider -->
      <div class="absolute top-0 bottom-0 left-1/2 w-0.5 bg-[#ff7518] -translate-x-1/2"></div>

      <!-- Left circle -->
         <RouterLink to="/map">
           <div class="absolute top-1/2 left-1/4 -translate-x-1/2 -translate-y-1/2 cursor-pointer" title="se karta">
              <span
                class="pi pi-map-marker hover:text-[#ff7518] transition-colors duration-300 ease-in-out"
                :class="$route.path === '/map' ? 'text-[#ff7518]' : 'text-white'"
                style="font-size: 1.2rem"
              >
            </span>
           </div>
          </RouterLink>

      <!-- Right circle -->

        <RouterLink to="/search">
          <div class="absolute top-1/2 right-1/4 translate-x-1/2 -translate-y-1/2 cursor-pointer" title="se lista">
              <span
                class="pi pi-list hover:text-[#ff7518] transition-colors duration-300 ease-in-out"
                :class="$route.path === '/search' ? 'text-[#ff7518]' : 'text-white'"
                style="font-size: 1.2rem"
              >
            </span>
          </div>
        </RouterLink>
      </div>
      <div class="relative block pl-4" v-if="isAuthenticated">
        <div
          type="button"
          class="flex flex-col items-center justify-center cursor-pointer hover:text-[#ff7518] duration-300 ease-in-out"
          title="logga ut användare"
          @click="toggleDropdown"
        >
          <p class="pi pi-user size-4"></p>
          <p class="text-xs">konto</p>
        </div>

        <div
          v-if="showDropdown"
          class="absolute right-0 top-10 mt-2 min-w-36 z-50 rounded-md border border-[#ff7518] bg-black/95 md:bg-black/0 py-2 shadow-lg"
        >
          <span
            type="button"
            class="block w-full px-4 py-2 text-left text-sm text-white hover:text-[#ff7518] transition-colors duration-300 cursor-pointer"
            @click="handleUserInformation"
          >
            se information
          </span>
          <span
            type="button"
            class="block w-full px-4 py-2 text-left text-sm text-white hover:text-[#ff7518] transition-colors duration-300 cursor-pointer"
            @click="handleLogout"
          >
            logga ut
          </span>
        </div>
      </div>
  </div>
</template>

<script setup lang="ts">
  import { ref } from "vue";
  import { useRouter } from "vue-router";
  import { useUserStore } from "../stores/userStore.ts";
  
  const router = useRouter();

  const { isAuthenticated, logOutUser } = useUserStore();

  const showDropdown = ref(false)

  const toggleDropdown = () => {
    showDropdown.value = !showDropdown.value
  }

  const handleLogout = () => {
    showDropdown.value = false
    logOutUser()
  }
  
  const handleUserInformation = () => {
    showDropdown.value = false
    router.push("/add-address")
  }

  </script>