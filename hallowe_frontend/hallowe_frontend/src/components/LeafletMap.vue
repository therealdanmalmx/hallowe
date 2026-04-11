
<template>
  <div class="h-[50vh] flex items-center justify-center" v-if="!mapReady">
    <rotate-loader :loading="!mapReady" :color="color" :size="size"></rotate-loader>
  </div>
  <div v-else class="h-[50vh] flex flex-col justify-center pt-8">
     <l-map ref="map" v-model:zoom="zoom" :center="[51.505, -0.09]" style="height: 50vh">
      <l-tile-layer
        url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
        layer-type="base"
        name="OpenStreetMap"
      ></l-tile-layer>
    </l-map>
  </div>
  <div v-if="!locationStore.isLoading">
    <SearchComp />
    <AddNewAddress />
  </div>
</template>

<script>
    import "leaflet/dist/leaflet.css";
    import { LMap, LTileLayer } from "@vue-leaflet/vue-leaflet";
    import { defineComponent, onMounted, ref } from "vue";
    import { useLocationStore } from '../stores/locationStore';
    import { useTimeSlotsStore } from '../stores/timeSlotsStore';
    import { useUserStore } from '../stores/userStore';
    import AddNewAddress from './AddNewAddress.vue';
    import SearchComp from './SearchComp.vue';
    import RotateLoader from 'vue-spinner/src/RotateLoader.vue';

    export default defineComponent({
        name: 'MapView',
        components: {
            LMap,
            LTileLayer,
            AddNewAddress,
            SearchComp,
            RotateLoader
        },

        setup() {

            const zoom = ref(13);
            const mapReady = ref(false);
            const locationStore = useLocationStore();
            const timeSlotsStore = useTimeSlotsStore();
            const userStore = useUserStore();

            onMounted(async () => {
                await import("leaflet");
                mapReady.value = true;
            });

            return { locationStore, timeSlotsStore, userStore, zoom, mapReady }
        }
    })

</script>