import { defineStore } from "pinia";
import { computed, ref, watch } from "vue";
import { locationServices } from "../api/services/locationServices";
import type { Location } from "../types/interfaces";

export const useLocationStore = defineStore('locationStore', () => {

    const locations = ref<Location[]>([]);
    const isLoading = ref<boolean>(false);
    const error = ref<string | null>(null);
    const searchText = ref<string>("");

    const mapCenter = ref<{ lat: number; lng: number } | null>(null);
    const mapZoom = ref<number | null>(12);

    const filteredLocations = computed(() => {

        if (!searchText.value || searchText.value.trim() === '') {
            return locations.value;
        }

        const search = searchText.value.toLowerCase();

        return locations.value.filter(user => {

            const streetName = (user.streetName || '').toLowerCase();
            const postalCode = (user.postalCode || '').replace(/\s/g, '').toLowerCase();
            const city = (user.city || '').toLowerCase();
            const searchNoSpaces = search.replace(/\s/g, '');

            return streetName.includes(search) ||
            postalCode.includes(searchNoSpaces) ||
            city.includes(search);
        });
    });

    watch(filteredLocations, (newFiltered) => {
        if (newFiltered.length > 0 && searchText.value.trim() !== '') {
            const first = newFiltered[0];
            mapCenter.value = {
                lat: first!.latitude,
                lng: first!.longitude
            };
        }
    });

    function zoomToLocation(Location: Location) {
        mapCenter.value = {
            lat: Location.latitude,
            lng: Location.longitude
        };
    }

    function resetMapView() {
        mapCenter.value = null;
        mapZoom.value = null;
    }

    async function getAllParticiants() {
        isLoading.value = true;
        try {
            error.value = null;
            const response = await locationServices.getAll();
            locations.value = response.data;
            isLoading.value = false;
        } catch (err) {
            console.error('Failed to fetch Location:', err);
            error.value = "Kunde inte ladda deltagare. Försök igen";
            isLoading.value = false;
            throw error;
        }
    }

    return {
        locations,
        filteredLocations,
        searchText,
        mapCenter,
        mapZoom,
        error,
        isLoading,
        getAllParticiants,
        zoomToLocation,
        resetMapView
    }
});