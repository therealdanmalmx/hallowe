import { defineStore } from "pinia";
import { ref } from "vue";
import { userService } from "../api/services/participantServices";
import type { Participant } from "../types/interfaces";

export const useParticipantStore = defineStore('participantStore', () => {

    const participants = ref<Participant[]>([]);
    const isLoading = ref<boolean>(false);
    const error = ref<string | null>(null);
    const searchText = ref<string>("");

    const search = searchText.value.toLowerCase();
    console.log({search})

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

  return { participants, search, searchText, error, isLoading, getAllParticiants }
})

