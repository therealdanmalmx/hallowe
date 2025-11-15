import { ref } from "vue";
import { useParticipantStore } from "../stores/participantsStore";

export const FetchMap = async () => {
    const data = ref([]);

    const mapsApiKey = import.meta.env.VITE_GOOGLE_MAPS_API_KEY;
          const participantStore = useParticipantStore();


        participantStore.isLoading = true;
        participantStore.error = null;

        try {

          const response = await fetch(
            `https://maps.googleapis.com/maps/api/js?key=${mapsApiKey}&libraries=places`
          )

          if (response.ok) {
            const map = await response.json()
            data.value = map.data

            participantStore.isLoading = false;

          } else {
            console.error('Error fetching data, Status:', response.statusText)
            participantStore.isLoading = false;
          }
        } catch (err: any) {

          !err.message.includes('w') ? console.error('Error fetching data:', err.message) : null;
            !err.message.includes('w') ? participantStore.error = `Kunde inte ladda kartan. Försök igen senare.` : null;
            participantStore.isLoading = false;
        }
      }