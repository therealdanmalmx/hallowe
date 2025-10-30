<script lang="ts">

  import { defineComponent, ref } from 'vue'
  import { useLoadScript, GMapMap, GMapMarker } from '@fawmi/vue-google-maps'

export default defineComponent({

  setup() {
    const pos = ref({ lat: 59.3293, lng: 18.0686 })

    navigator.geolocation.getCurrentPosition(
      (position) => {
        pos.value = {
          lat: position.coords.latitude,
          lng: position.coords.longitude
        }
        console.log({ pos: pos.value })
      },
      (error) => {
        console.error('Error getting location:', error)
      }
    )
    console.log({pos})

    return { pos }
  }

  //   name: 'MapComp',
  //   props: {
  //     // searchLocation: {
  //     //   type: Object,
  //     //   default: null
  //     // },
  //     // userLocation: {
  //     //   type: Object,
  //     //   default: null
  //     // },
  //     defaultCenter: {
  //       type: Object,
  //       default: () => ({ lat: 57.725, lng: 13.162 })
  //     },
  //     zoom: {
  //       type: Number,
  //       default: 7
  //     }
  //   },
  //   setup(props) {
  //     const center = ref(props.defaultCenter)

  //     const mapsApiKey = import.meta.env.VITE_GOOGLE_MAPS_API_KEY
  //     const { isLoaded, loadError } = useLoadScript({
  //       googleMapsApiKey: mapsApiKey
  //     })

  //     const mapOptions = {
  //       mapTypeControl: false,
  //       fullscreenControl: false,
  //       streetViewControl: false
  //     }

  //     // const onMapClick = () => {
  //     //   props.searchLocation = null
  //     // }

  //     return { isLoaded, loadError, center, mapOptions, props }
  //   }
  })
</script>

<template>
  <div class="flex flex-col justify-center py-8">
    <GMapMap
      :center="{ lat: pos.lat, lng: pos.lng }"
      :zoom="13"
    style="width: 90%; height: 80vh; margin: 0 auto;"
    >
      <GMapMarker :position="{lat: pos.lat, lng: pos.lng}" />
    </GMapMap>
  </div>
</template>
