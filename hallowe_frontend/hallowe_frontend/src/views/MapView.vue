<script lang="ts">

  import { defineComponent } from 'vue';

  import { useLocationStore } from '../stores/locationStore';
  import { useUserStore } from '../stores/userStore';
  import LeafletMap from '../components/LeafletMap.vue';

  export default defineComponent({
    name: 'MapView',
    components: { LeafletMap },

    setup() {

      const locationStore = useLocationStore();
      const userStore = useUserStore();

      return { locationStore, userStore }
    }
  })



</script>

<template>
  <div class="w-full lg:w-11/12 mx-auto">
    <h1 class="text-5xl scary-font text-[#ff7518] text-center">Karta</h1>
    <div class="p-4 md:p-0">
        <LeafletMap />
        <div v-if="locationStore.error" class="error-message">{{ locationStore.error }}</div>
    </div>

  </div>
</template>