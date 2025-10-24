<script lang="ts">
  import { defineComponent, ref, onMounted } from 'vue'
  import MapComp from '../components/MapComp.vue'
  const mapsApiKey = import.meta.env.VITE_GOOGLE_MAPS_API_KEY
  export default defineComponent({
    name: 'MapView',
    components: { MapComp },
    setup() {
      // const searchLocation = ref(null)
      // const userLocation = ref(null)
      const defaultCenter = { lat: 57.725, lng: 13.162 }
      const zoom = ref(7)

      const fetchData = async () => {
        try {
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

      return { defaultCenter, zoom }
    }
  })
</script>

<template>
  <div>
    <h1>Map Page</h1>
    <MapComp :defaultCenter="defaultCenter" :zoom="zoom" />
  </div>
</template>

<!-- :searchLocation="searchLocation"
      :userLocation="userLocation" -->
