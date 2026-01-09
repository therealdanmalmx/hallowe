import { defineStore } from "pinia";
import { computed, ref, watch } from "vue";
import { userService } from "../api/services/participantServices";
import type { Participant } from "../types/interfaces";

export const useParticipantStore = defineStore('participantStore', () => {

    const participants = ref<Participant[]>([]);
    const isLoading = ref<boolean>(false);
    const error = ref<string | null>(null);
    const searchText = ref<string>("");

    const mapCenter = ref<{ lat: number; lng: number } | null>(null);
    const mapZoom = ref<number | null>(12);

    const filteredParticipants = computed(() => {

        if (!searchText.value || searchText.value.trim() === '') {
            return participants.value;
        }

        const search = searchText.value.toLowerCase();

        return participants.value.filter(user => {

            const streetName = (user.streetName || '').toLowerCase();
            const postalCode = (user.postalCode || '').replace(/\s/g, '').toLowerCase();
            const city = (user.city || '').toLowerCase();
            const searchNoSpaces = search.replace(/\s/g, '');

            return streetName.includes(search) ||
            postalCode.includes(searchNoSpaces) ||
            city.includes(search);
        });
    });

    watch(filteredParticipants, (newFiltered) => {
        if (newFiltered.length > 0 && searchText.value.trim() !== '') {
            const first = newFiltered[0];
            mapCenter.value = {
                lat: first!.latitude,
                lng: first!.longitude
            };
        }
    });

    function zoomToParticipant(participant: Participant) {
        mapCenter.value = {
            lat: participant.latitude,
            lng: participant.longitude
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
            const response = await userService.getAll();
            participants.value = response.data;
            isLoading.value = false;
        } catch (err) {
            console.error('Failed to fetch participant:', err);
            error.value = "Kunde inte ladda deltagare. Försök igen";
            isLoading.value = false;
            throw error;
        }
    }

    return {
        participants,
        filteredParticipants,
        searchText,
        mapCenter,
        mapZoom,
        error,
        isLoading,
        getAllParticiants,
        zoomToParticipant,
        resetMapView
    }
});