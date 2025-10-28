<script lang="ts">
 import { defineComponent, ref, onMounted } from 'vue'
  import { useLoading } from 'vue-loading-overlay'
  import MapComp from '../components/MapComp.vue'
  import 'vue-loading-overlay/dist/css/index.css'
  
  const mapsApiKey = import.meta.env.VITE_GOOGLE_MAPS_API_KEY


  
  export default defineComponent({
    name: 'MapView',
    components: { MapComp },
    setup() {
      const defaultCenter = { lat: 57.725, lng: 13.162 }
      const zoom = ref(7)

      const loading = useLoading()  
      const errorMessage = ref<string | null>(null)


      const fetchData = async () => {
        loading.show() 
errorMessage.value = null 
        try {
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

      return { defaultCenter, zoom, errorMessage  }
    }
  })
</script>

<template>
  <div>
    <h1>Map Page</h1>
     <div v-if="errorMessage" class="error-message">
      <p>{{ errorMessage }}</p>
    </div>
       <MapComp v-if="!errorMessage" :defaultCenter="defaultCenter" :zoom="zoom" />

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