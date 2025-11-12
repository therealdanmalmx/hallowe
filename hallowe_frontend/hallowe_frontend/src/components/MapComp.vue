<script lang="ts">

  import { GMapMap, GMapMarker, GMapInfoWindow } from '@fawmi/vue-google-maps';
  import { defineComponent, ref, onMounted } from 'vue';
  import { userService } from '../api/services/participantServices';
  import { type TimeSlot, type Participant } from '../types/interfaces';
import { timeService } from '../api/services/timeslotServices';

  export default defineComponent({

    setup() {

      let participants = ref<Participant[]>([]);
      let times = ref<TimeSlot[]>([]);
      const pos = ref({ lat: 0, lng: 0 })
      const zoom = ref<number>(12);
      const defaultCenter = ref<object>({ lat: 0, lng: 0 })
      const openedMarkerID = ref<number>(0);

      navigator.geolocation.getCurrentPosition(
        (position) => {
          pos.value = {
            lat: position.coords.latitude,
            lng: position.coords.longitude
          }
          defaultCenter.value = {lat: pos.value.lat, lng: pos.value.lng}
        },
        (error) => {
          console.error('Error getting location:', error)
        }
      )

      const openMarker = (id: number | null) => {
        console.log({id})
        openedMarkerID.value = id ?? 0;
      }

      const fetchAllParticipants = async () => {
        const userResponse = await userService.getAll();
        const timeResponse = await timeService.getAll();


        if (userResponse) {
          participants.value = await userResponse.data;
        }

        if (timeResponse) {
          times.value = await timeResponse.data;
        }
      }

      onMounted(fetchAllParticipants);

      return { pos, defaultCenter, openedMarkerID, times, openMarker, zoom, participants }
    }
  })

</script>

<template>
  <div class="flex flex-col justify-center py-8">
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
          v-for="user in participants"
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
              <div v-for="slot in times.filter(t => t.id === user.timeSlotId)">
              <div class="flex flex-col space-y-2">
                  <div class="flex items-center text-lg space-x-2 font-bold">
                    <i class="text-[#ff7518] pi pi-calendar "></i>
                    <p class="text-sm">{{slot.date}}</p>
                  </div>
                  <div class="flex items-center text-lg space-x-2 font-bold">
                    <i class="text-[#ff7518] pi pi-clock"></i>
                    <p class="text-sm">{{ slot.startTime.slice(0, 5) }} - {{ slot.endTime.slice(0, 5) }}</p>
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