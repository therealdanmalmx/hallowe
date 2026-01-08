<script lang="ts">

  import { defineComponent } from 'vue';
  import MapComp from '../components/MapComp.vue';
  import { useParticipantStore } from '../stores/participantsStore';
  import { useTimeSlotsStore } from '../stores/timeSlotsStore';

  export default defineComponent({
    name: 'MapView',
    components: { MapComp },

    setup() {
      const participantStore = useParticipantStore();
      const timeSlotsStore = useTimeSlotsStore();

      return { participantStore, timeSlotsStore }
    }
  })


</script>

<template>
  <h1 class="text-5xl vl-parent">Map Page</h1>
  <div class="p-4 md:p-0">
      <MapComp />
      <div v-if="participantStore.error" class="error-message">{{ participantStore.error }}</div>
      <div v-else-if="timeSlotsStore.error" class="error-message">{{ timeSlotsStore.error }}</div>
  </div>
</template>