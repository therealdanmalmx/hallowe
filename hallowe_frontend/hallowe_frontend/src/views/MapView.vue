<script lang="ts">

  import { defineComponent, ref, onMounted } from 'vue'
  import MapComp from '../components/MapComp.vue'

  const mapsApiKey = import.meta.env.VITE_GOOGLE_MAPS_API_KEY;

  interface House {
    name: string,
    city: string
    streetName: string,
    postalCode: string
  }

  export default defineComponent({
    name: 'MapView',
    components: { MapComp },
    setup() {
      // const searchLocation = ref(null)
      // const userLocation = ref(null)
      const defaultCenter = { lat: 57.725, lng: 13.162 }
      const zoom = ref(7)
      let data = ref<House[]>([]);

      const fetchData = async () => {

        console.log({data})
        try {
          const res = await fetch('http://localhost:5168/api/Participant')
          data.value = await res.json();
          const response = await fetch(
            `https://maps.googleapis.com/maps/api/js?key=${mapsApiKey}&libraries=places`
          )
          if (response.ok) {
            const data = await response.json()
            console.log('Fetched data:', data)
          } else {
            console.error('Error fetching data, Status:', response.statusText)
          }
        } catch (error: any) {
          console.error('Error fetching data:', error.message)
        }
      }

      onMounted(fetchData)

      return { defaultCenter, zoom, data }
    }
  })
</script>

<template>
  <div>
    <h1 class="text-5xl">Map Page</h1>
    <MapComp :defaultCenter="defaultCenter" :zoom="zoom" />
    <div>
      <div v-for="house in data">
        <p>{{ house.name }} | {{ house.streetName }} | {{ house.postalCode }} | {{ house.city }}</p>
      </div>
    </div>
  </div>
</template>

<!-- :searchLocation="searchLocation"
      :userLocation="userLocation" -->
