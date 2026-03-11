import { ref } from "vue";
import { useLocationStore } from "../stores/locationStore";

export const FetchMap = async () => {
  const data = ref([]);

  const mapsApiKey = import.meta.env.VITE_GOOGLE_MAPS_API_KEY;
  const locationStore = useLocationStore();

  locationStore.isLoading = true;
  locationStore.error = null;

  try {
    const response = await fetch(
      `https://maps.googleapis.com/maps/api/js?key=${mapsApiKey}&libraries=places`
    )
    const map = await response.json()
    data.value = await map.data

    locationStore.isLoading = false;

    // if (response.ok) {

    // } else {
    //   console.error('Error fetching data, Status:', response.statusText)
    //   locationStore.isLoading = false;
    // }
  } catch (err: any) {

    !err.message.includes('w') ? console.error('Error fetching data:', err.message) : null;
    !err.message.includes('w') ? locationStore.error = `Kunde inte ladda kartan. Försök igen senare.` : null;
    locationStore.isLoading = false;
  }
}