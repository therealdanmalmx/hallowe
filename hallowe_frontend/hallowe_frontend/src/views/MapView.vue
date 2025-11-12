<script lang="ts">

  import { defineComponent, ref, onMounted } from 'vue'
  import MapComp from '../components/MapComp.vue'
  // import { useLoading } from 'vue-loading-overlay';
  import RotateLoader from 'vue-spinner/src/RotateLoader.vue'
  import { userService } from '../api/services/participantServices';
  import type { Participant, TimeSlot } from '../types/interfaces';
import { timeService } from '../api/services/timeslotServices';

  const mapsApiKey = import.meta.env.VITE_GOOGLE_MAPS_API_KEY;


  export default defineComponent({
    name: 'MapView',
    components: { MapComp, RotateLoader },
    setup() {
      const defaultCenter = { lat: 57.725, lng: 13.162 }
      const zoom = ref(7)
      let isLoading = ref<boolean>(false);
      let data = ref<Participant[]>([]);
      let time = ref<TimeSlot[]>([]);
      const color = ref<string>("#FF7518");
      const size = ref('1.25rem');

      // const loading = useLoading()
      const errorMessage = ref<string | null>(null)

      const fetchData = async () => {

        errorMessage.value = null;

        isLoading.value = true;
        // loading.show()
        try {

          const userResponse = await userService.getAll();
          const timeResponse = await timeService.getAll();

          const response = await fetch(
            `https://maps.googleapis.com/maps/api/js?key=${mapsApiKey}&libraries=places`
          )

          if (userResponse) {
            data.value = await userResponse.data;
            console.log('userResponse', data.value)
          }

          if (timeResponse) {
            time.value = await timeResponse.data;

            userResponse.data.forEach((element: Participant): void => {
              timeResponse.data.find((t: TimeSlot) => t.id === element.id)
            });
          }

          if (response.ok) {
            const mapData = await response.json()
            console.log('Fetched map:', mapData)
            isLoading.value = false;

            // loading.hide();
          } else {
            console.error('Error fetching data, Status:', response.statusText)
            isLoading.value = false;
            // loading.hide()

          }
        } catch (error: any) {
          console.error('Error fetching data:', error.message)
          isLoading.value = false;
          // loading.hide()
            errorMessage.value = `Kunde inte ladda kartan. Försök igen senare.`
        }
      }

      onMounted(fetchData)

      return { defaultCenter, zoom, data, errorMessage, time, isLoading, color, size }
    }
  })
</script>

<template>
  <h1 class="text-5xl vl-parent">Map Page</h1>
  <div class="h-screen flex items-center justify-center" v-if="isLoading"><rotate-loader :loading="isLoading" :color="color" :size="size"></rotate-loader></div>
  <div v-else class="p-4 space-y-4">
      <MapComp :defaultCenter="defaultCenter" :zoom="zoom" />
  </div>
</template>
<!-- :searchLocation="searchLocation"
      :userLocation="userLocation" -->

<style scoped>
  .error-message {
    color: red;
    font-size: 1.2em;
    margin: 20px 0;
    padding: 10px;
    border: 1px solid red;
    background-color: #f8d7da;
  }
</style>