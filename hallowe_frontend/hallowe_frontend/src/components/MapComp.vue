<script lang="ts">

  import { GMapInfoWindow, GMapMap, GMapMarker } from '@fawmi/vue-google-maps';
  import { defineComponent, onMounted, ref } from 'vue';
  import RotateLoader from 'vue-spinner/src/RotateLoader.vue';
  import { FetchMap } from '../api/getMap';
  import { useParticipantStore } from '../stores/participantsStore';
  import { useTimeSlotsStore } from '../stores/timeSlotsStore';
  import { getUserCoords, defaultCenter } from '../utils/getUserCoordinates';

  export default defineComponent({
    name: 'MapComponent',
    components: { RotateLoader },

    setup() {

      const color = ref<string>("#FF7518");
      const size = ref('1.25rem');

      const participantStore = useParticipantStore();
      const timeStore = useTimeSlotsStore();
      const data = ref([]);
      const pos = ref({ lat: 0, lng: 0 })
      const zoom = ref<number>(window.innerWidth < 768 ? 10 : 12);
      const openedMarkerID = ref<number>(0);

      const openMarker = (id: number | null) => {
        openedMarkerID.value = id ?? 0;
      }

      onMounted(async () => {
       getUserCoords();
        await FetchMap();
        await participantStore.getAllParticiants();
        await timeStore.getAllTimeSlots();
      });

      return { pos, openedMarkerID, defaultCenter, openMarker, color, size, zoom, data, participantStore, timeStore }
    }
  })

</script>

<template>
  <div class="h-screen flex items-center justify-center" v-if="participantStore.isLoading"><rotate-loader :loading="participantStore.isLoading" :color="color" :size="size"></rotate-loader></div>
  <div v-else class="flex flex-col justify-center py-8">
    <GMapMap
      :center="defaultCenter"
      :zoom="zoom"
      :options="{
      zoomControl: true,
      mapTypeControl: false,
      scaleControl: false,
      streetViewControl: false,
      rotateControl: false,
      fullscreenControl: true,
      disableDefaultUi: false,
      }"
      class="w-full h-[65vh] md:h-[70vh] mx-auto"
    >
      <GMapMarker
          v-for="user in participantStore.participants"
          :key="user.id"
          @click="openMarker(user.id ?? null)"
          place: {
            :location="{lat: user.latitude, lng: user.longitude}"
          }
          :position="{lat: user.latitude, lng: user.longitude}"
        >
          <GMapInfoWindow
            :closeclick="true"
            @closeclick="openMarker(null)"
            :opened="openedMarkerID === user.id"
            >
            <div class="flex flex-col text-left justify-start mt-2">
              <div class="text-black text-base mb-2">
                <p class="font-bold">{{ user.name }}</p>
                <span class="flex flex-col justify-start text-sm">
                  <p>{{ user.streetName }}, {{ user.streetNumber }}</p>
                  <p>{{ user.postalCode }} {{ user.city }}</p>
                </span>
              </div>
              <!-- <div class="border-t border-gray-300 mt-2 pt-2 text-[13px] overflow-hidden whitespace-nowrap text-ellipsis font-['Roboto',Arial]"></div> -->

              <div v-for="time in timeStore.times.filter(t => t.id === user.timeSlotId)">
              <div class="flex flex-col space-y-2">
                  <div class="flex items-center text-lg space-x-2 font-bold">
                    <i class="text-[#ff7518] pi pi-calendar "></i>
                    <p class="text-sm">{{time.date}}</p>
                  </div>
                  <div class="flex items-center text-lg space-x-2 font-bold">
                    <i class="text-[#ff7518] pi pi-clock"></i>
                    <p class="text-sm">{{ time.startTime.slice(0, 5) }} - {{ time.endTime.slice(0, 5) }}</p>
                  </div>
                    <div class="border-t border-gray-300 mt-2 pt-1.5 text-[13px] overflow-hidden whitespace-nowrap text-ellipsis font-['Roboto',Arial]">
                    <a class="googel-maps-links" :href="`https://www.google.com/maps?q=${user.latitude},${user.longitude}&z=15`" target="_blank">Se på Google Maps</a>
                  </div>
                </div>
            </div>
          </div>
          </GMapInfoWindow>
      </GMapMarker>
    </GMapMap>
  </div>
</template>

<style>
  .gm-style .gm-style-iw-c {
    color: black;
    padding: 12px !important;
    border-radius: 8px !important;
    box-shadow: 0 2px 8px rgba(0,0,0,0.15) !important;
  }

  /* Style the close button container */
  .gm-ui-hover-effect {
    width: 16px !important;
    height: 16px !important;
    bottom: 4px !important;
    opacity: 1 !important;
  }

  /* Remove hover effect */
  .gm-ui-hover-effect:hover {
    background-color: transparent !important;
    opacity: 1 !important;
  }

  /* Make the X icon black */
  .gm-ui-hover-effect > span {
    background-color: black !important;
    width: 16px !important;
    height: 16px !important;
    margin: 0 !important;
  }

  /* Alternative: target the button directly */

  .gm-ui-hover-effect {
    background-color: none !important;
    border-color: none !important;

  }

  .gm-style-iw-chr {
    width: 100% !important;
    height: 5px !important;
  }
  .gm-style .gm-style-iw-d {
    overflow: auto !important;
    max-height: none !important;
    padding: 0 !important;
  }
</style>