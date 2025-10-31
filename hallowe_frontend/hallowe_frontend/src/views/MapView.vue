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
      const defaultCenter = { lat: 57.725, lng: 13.162 }
      const zoom = ref(7)
      let data = ref<House[]>([]);

      const loading = useLoading()  
      const errorMessage = ref<string | null>(null)


      const fetchData = async () => {

        console.log({data})
        loading.show() 
errorMessage.value = null 
        try {
          const res = await fetch('http://localhost:5168/api/Participant')
          data.value = await res.json();
          const response = await fetch(
            `https://maps.googleapis.com/maps/api/js?key=${mapsApiKey}&libraries=places`
          )

          if (response.ok) {
            const data = await response.json()
            console.log('Fetched data:', data)
            loading.hide()  
          } else {
            console.error('Error fetching data, Status:', response.statusText)
            loading.hide() 
          }
        } catch (error: any) {
          console.error('Error fetching data:', error.message)
          loading.hide() 
            errorMessage.value = `Kunde inte ladda kartan. Försök igen senare.` 
      
        }
      }

      onMounted(fetchData)

      return { defaultCenter, zoom, data, errorMessage }
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