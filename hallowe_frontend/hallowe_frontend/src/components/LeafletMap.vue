
<template>
  <div class="h-[60vh] flex items-center justify-center" v-if="!mapReady">
    <rotate-loader :loading="!mapReady" :color="color" :size="size"></rotate-loader>
  </div>
  <div v-else class="h-[55vh] flex flex-col justify-center pt-8">
    <l-map
      :zoom="currentZoom"
      :center="currentCenter"
    >
      <l-tile-layer
        url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
        layer-type="base"
        name="OpenStreetMap"
      ></l-tile-layer>
      <l-marker
          v-for="user in locationStore.filteredLocations"
          :key="user.id"
          @click="openMarker(user.id ?? null)"
          :lat-lng="[user.latitude, user.longitude]" >
        <l-icon
            :icon-size="[30, 30]"
            :icon-anchor="[15, 15]"
            icon-url="/public/images/pumpkin.webp"
        ></l-icon>
        <l-popup>
          <div class="flex flex-col text-left justify-start">
            <div class="text-black text-base">
              <p class="font-bold">{{ user.name }}</p>
              <span class="flex flex-col justify-start text-sm">
                <p>{{ user.streetName }}, {{ user.streetNumber }}</p>
                <p>{{ user.postalCode }} {{ user.city }}</p>
              </span>
            </div>

            <div v-for="user in locationStore.filteredLocations">
              <div class="flex flex-col space-y-2 mt-4">
                <div class="flex items-center text-lg space-x-2 font-bold">
                  <i class="text-[#ff7518] pi pi-calendar "></i>
                  <p class="text-sm">{{user.date}}</p>
                </div>
                <div class="flex items-center text-lg space-x-2 font-bold">
                  <i class="text-[#ff7518] pi pi-clock"></i>
                  <p class="text-sm">{{ user.startTime.slice(0, 5) }} - {{ user.endTime.slice(0, 5) }}</p>
                </div>
                <!-- <div class="border-t border-gray-300 mt-2 pt-1.5 text-[13px] overflow-hidden whitespace-nowrap text-ellipsis font-['Roboto',Arial]">
                  <a class="googel-maps-links" :href="`https://www.google.com/maps?q=${user.latitude},${user.longitude}&z=15`" target="_blank">Se på Google Maps</a>
                </div> -->
              </div>
            </div>
          </div>
        </l-popup>
      </l-marker>
    </l-map>
  </div>
  <div v-if="!locationStore.isLoading">
    <SearchComp />
    <AddNewAddress />
  </div>
</template>

<script lang="ts">
    import "leaflet/dist/leaflet.css";
    import { LMap, LMarker, LPopup, LTileLayer, LIcon } from "@vue-leaflet/vue-leaflet";
    import { computed, defineComponent, onMounted, ref } from "vue";
    import { useLocationStore } from '../stores/locationStore';
    import { useUserStore } from '../stores/userStore';
    import AddNewAddress from './AddNewAddress.vue';
    import SearchComp from './SearchComp.vue';
    import { getUserCoords, defaultCenter } from '../utils/getUserCoordinates';
    import RotateLoader from 'vue-spinner/src/RotateLoader.vue';

    export default defineComponent({
      name: 'MapView',
      components: {
          LMap,
          LTileLayer,
          LMarker,
          LIcon,
          LPopup,
          AddNewAddress,
          SearchComp,
          RotateLoader
      },

      setup() {

        const zoom = ref(15);
        const openedMarkerID = ref<number>(0);
        const mapReady = ref<boolean>(false);
        const color = ref<string>("#FF7518");
        const size = ref<string>('1.25rem');
        const baseZoom = ref<number>(window.innerWidth < 768 ? 4 : 6);
        const locationStore = useLocationStore();
        const userStore = useUserStore();

        onMounted(async () => {
          getUserCoords();
          await import("leaflet");
          await locationStore.getAllParticiants();
          mapReady.value = true;
        });

        const openMarker = (id: number | null) => {
          openedMarkerID.value = id ?? 0;
        }

        const currentCenter = computed((): [number, number] => {
          const center = locationStore.mapCenter || defaultCenter.value;
          return [center.lat, center.lng];
        });

        const currentZoom = computed(() => {
          return locationStore.mapZoom || baseZoom.value;
        });

        return {
          locationStore,
          userStore,
          zoom,
          mapReady,
          openedMarkerID,
          openMarker,
          color,
          size,
          currentCenter,
          currentZoom
        }
      }
    })
</script>

<style>
  .leaflet-popup-content p {
    margin: 0;
  }
</style>