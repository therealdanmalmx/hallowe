<script lang="ts">

  import { defineComponent, ref, onMounted } from 'vue'
  import MapComp from '../components/MapComp.vue'
  // import { useLoading } from 'vue-loading-overlay';
  import RotateLoader from 'vue-spinner/src/RotateLoader.vue'
import { userService } from '../api/services/participantServices';

  const mapsApiKey = import.meta.env.VITE_GOOGLE_MAPS_API_KEY;

  interface House {
    name: string,
    city: string
    streetName: string,
    postalCode: string
  }

  export default defineComponent({
    name: 'MapView',
    components: { MapComp, RotateLoader },
    setup() {
      const defaultCenter = { lat: 57.725, lng: 13.162 }
      const zoom = ref(7)
      let isLoading = ref<boolean>(false);
      let data = ref<House[]>([]);
      const color = ref<string>("#FF7518");
      const size = ref('1.25rem');

      // const loading = useLoading()
      const errorMessage = ref<string | null>(null)

      const fetchData = async () => {

        errorMessage.value = null;

        isLoading.value = true;
        // loading.show()
        try {

          userService.getAll();
          // const res = await fetch('http://localhost:5168/api/Participant')
          const response = await fetch(
            `https://maps.googleapis.com/maps/api/js?key=${mapsApiKey}&libraries=places`
          )
          
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

      return { defaultCenter, zoom, data, errorMessage, isLoading, color, size }
    }
  })
</script>

<template>
  <h1 class="text-5xl vl-parent">Map Page</h1>
  <div class="h-screen flex items-center justify-center" v-if="isLoading"><rotate-loader :loading="isLoading" :color="color" :size="size"></rotate-loader></div>
  <div v-else class="py-4">
      <MapComp :defaultCenter="defaultCenter" :zoom="zoom" />
      <div v-for="house in data">
        <p>{{ house.name }} | {{ house.streetName }} | {{ house.postalCode }} | {{ house.city }}</p>
      </div>
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