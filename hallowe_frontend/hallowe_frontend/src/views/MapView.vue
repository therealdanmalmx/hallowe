<script lang="ts">

  import { defineComponent } from 'vue';

  import MapComp from '../components/MapComp.vue';
  import { useLocationStore } from '../stores/locationStore';
  import { useTimeSlotsStore } from '../stores/timeSlotsStore';
  import { useUserStore } from '../stores/userStore';
  import LeafletMap from '../components/LeafletMap.vue';

  export default defineComponent({
    name: 'MapView',
    components: { MapComp, LeafletMap },

    setup() {

      const locationStore = useLocationStore();
      const timeSlotsStore = useTimeSlotsStore();
      const userStore = useUserStore();

      return { locationStore, timeSlotsStore, userStore }
    }
  })



</script>

<template>
  <div class="w-full lg:w-11/12 mx-auto">
    <h1 class="text-5xl scary-font text-[#ff7518] text-center">Map Page</h1>
    <div class="p-4 xl:p-2">
        <!-- <MapComp /> -->
        <LeafletMap />
        <div v-if="locationStore.error" class="error-message">{{ locationStore.error }}</div>
        <div v-else-if="timeSlotsStore.error" class="error-message">{{ timeSlotsStore.error }}</div>
    </div>

  </div>
</template>