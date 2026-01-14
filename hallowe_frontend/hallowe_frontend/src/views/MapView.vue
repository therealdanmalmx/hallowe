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
  <div class="py-2">
    <h1 class="text-5xl scary-font text-[#ff7518] text-center">Map Page</h1>
    <div class="p-4 xl:p-0">
        <MapComp />
        <div v-if="participantStore.error" class="error-message">{{ participantStore.error }}</div>
        <div v-else-if="timeSlotsStore.error" class="error-message">{{ timeSlotsStore.error }}</div>
    </div>

  </div>
</template>