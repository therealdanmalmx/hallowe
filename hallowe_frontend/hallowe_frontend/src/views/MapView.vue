<script lang="ts">

  import { defineComponent } from 'vue';
  import MapComp from '../components/MapComp.vue';
import { useParticipantStore } from '../stores/participantsStore';
  // import { useLoading } from 'vue-loading-overlay';

  export default defineComponent({
    name: 'MapView',
    components: { MapComp },

    setup() {
      const participantStore = useParticipantStore();

      return { participantStore }
    }
  })


</script>

<template>
  <h1 class="text-5xl vl-parent">Map Page</h1>
  <div class="p-4 space-y-4">
      <MapComp />
      <!-- <div v-if="participantStore.error" class="error-message">{{ participantStore.error }}</div> -->
  </div>
</template>