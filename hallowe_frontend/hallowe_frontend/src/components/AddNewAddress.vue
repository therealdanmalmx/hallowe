<template>
  <div class="flex w-full justify-end" :class="{ 'pt-6': $route.path === '/search' }">
      <RouterLink to="/add-address">
        <button class="flex items-center">
            <div class="pi pi-plus"></div>
            <div class="px-2">Lägg till en ny address</div>
        </button>
      </RouterLink>
  </div>
</template>