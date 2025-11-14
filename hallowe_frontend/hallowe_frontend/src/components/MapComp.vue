<script lang="ts">

  import { GMapInfoWindow, GMapMap, GMapMarker } from '@fawmi/vue-google-maps';
  import { defineComponent, onMounted, ref } from 'vue';
  import RotateLoader from 'vue-spinner/src/RotateLoader.vue';
  import { useParticipantStore } from '../stores/participantsStore';
  import { useTimeSlotsStore } from '../stores/timeSlotsStore';

  export default defineComponent({
    name: 'MapComponent',
    components: { RotateLoader },

    setup() {

      const mapsApiKey = import.meta.env.VITE_GOOGLE_MAPS_API_KEY;

      const color = ref<string>("#FF7518");
      const size = ref('1.25rem');

      const participantStore = useParticipantStore();
      const timeStore = useTimeSlotsStore();
      const data = ref([]);
      const pos = ref({ lat: 0, lng: 0 })
      const zoom = ref<number>(12);
      const defaultCenter = ref<object>({ lat: 0, lng: 0 })
      const openedMarkerID = ref<number>(0);

      const getUserCoords = () => {
        navigator.geolocation.getCurrentPosition(
          (position) => {
            pos.value = {
              lat: position.coords.latitude,
              lng: position.coords.longitude
            }
            defaultCenter.value = { lat: pos.value.lat, lng: pos.value.lng }
          },
          (error) => {
            console.error('Error getting location:', error)
          }
        );
      };

      const openMarker = (id: number | null) => {
        openedMarkerID.value = id ?? 0;
      }

      const fetchMap = async () => {

        participantStore.isLoading = true;
        participantStore.error = null
        try {

          const response = await fetch(
            `https://maps.googleapis.com/maps/api/js?key=${mapsApiKey}&libraries=places`
          )

          if (response.ok) {
            const map = await response.json()
            data.value = map.data

            participantStore.isLoading = false;

          } else {
            console.error('Error fetching data, Status:', response.statusText)
            participantStore.isLoading = false;
          }
        } catch (error: any) {
            console.error('Error fetching data:', error.message)
            participantStore.isLoading = false;
            participantStore.error = `Kunde inte ladda kartan. Försök igen senare.`
        }
      }

      onMounted(async () => {
        getUserCoords();
        fetchMap();
        await participantStore.getAllParticiants();
        await timeStore.getAllTimeSlots();
      });

      return { pos, defaultCenter, openedMarkerID, openMarker, color, size, zoom, data, participantStore, timeStore }
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
      style="width: 90%; height: 80vh; margin: 0 auto;"
    >
      <GMapMarker
          v-for="user in participantStore.participants"
          :key="user.id"
          @click="openMarker(user.id ?? null)"
          :position="{lat: user.latitude, lng: user.longitude}"
        >
          <GMapInfoWindow
            :closeclick="true"
            @closeclick="openMarker(null)"
            :opened="openedMarkerID === user.id"
            >
            <div class="flex flex-col justify-start mt-2">
              <div class="text-black text-base mb-2">
                <p class="font-bold">{{ user.name }}</p>
                <span class="flex flex-col text-left justify-start text-sm">
                  <p>{{ user.streetName }}, {{ user.streetNumber }}</p>
                  <p>{{ user.postalCode }} {{ user.city }}</p>
                </span>
              </div>
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