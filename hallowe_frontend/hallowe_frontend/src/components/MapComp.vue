<script lang="ts">

  import { GMapMap, GMapMarker } from '@fawmi/vue-google-maps';
  import { defineComponent, ref, onMounted } from 'vue';
  import { userService } from '../api/services/participantServices';
  import type { Participant } from '../types/interfaces';

  export default defineComponent({

    setup() {

      let participants = ref<Participant[]>([]);
      const pos = ref({ lat: 0, lng: 0 })
      const zoom = ref<number>(12);

      const fetchAllParticipants = async () => {
        const userResponse = await userService.getAll();

        if (userResponse) {
          participants.value = await userResponse.data;
        }
      }

      navigator.geolocation.getCurrentPosition(
        (position) => {
          pos.value = {
            lat: position.coords.latitude,
            lng: position.coords.longitude
          }
        },
        (error) => {
          console.error('Error getting location:', error)
        }
      )

      onMounted(fetchAllParticipants);

      return { pos, zoom, participants }
    }
  })

</script>

<template>
  <div class="flex flex-col justify-center py-8">
    <GMapMap
      :center="{ lat: pos.lat, lng: pos.lng }"
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
        :key="user.id"
        v-for="user in participants"
         :clickable="true"
        :position="{lat: user.latitude, lng: user.longitude}"
      />
    </GMapMap>
  </div>
</template>
