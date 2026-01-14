<template>
  <div class="flex w-full justify-center md:justify-end">
    <div class="relative w-30 h-12">
      <!-- Main pill shape -->
      <div class="absolute inset-0 border-2 border-[#ff7518] rounded-full"></div>

      <!-- Center divider -->
      <div class="absolute top-0 bottom-0 left-1/2 w-0.5 bg-[#ff7518] -translate-x-1/2"></div>

      <!-- Left circle -->
         <RouterLink to="/map">
           <div class="absolute top-1/2 left-1/4 -translate-x-1/2 -translate-y-1/2 cursor-pointer" title="map page">
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
          <div class="absolute top-1/2 right-1/4 translate-x-1/2 -translate-y-1/2 cursor-pointer" title="list page">
              <span
                class="pi pi-list hover:text-[#ff7518] transition-colors duration-300 ease-in-out"
                :class="$route.path === '/search' ? 'text-[#ff7518]' : 'text-white'"
                style="font-size: 1.2rem"
              >
            </span>
          </div>
        </RouterLink>
    </div>
  </div>
</template>