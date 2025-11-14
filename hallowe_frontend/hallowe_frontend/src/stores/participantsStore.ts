import { defineStore } from "pinia";
import { ref } from "vue";
import { userService } from '../api/services/participantServices';
import type { Participant } from "../types/interfaces";

export const useParticipantStore = defineStore('participantStore', () => {
    const participants = ref<Participant[]>([]);
    const isLoading = ref<boolean>(false);
    const error = ref<string | null>(null);


    async function getAllParticiants() {
        try {
            isLoading.value = true;
            error.value = null;
            const response = await userService.getAll();
            participants.value = response.data;
        } catch (err) {
            console.error('Failed to fetch participant:', err);
            error.value = "Kunde inte ladda deltagare";
            throw error;
        }
    }

  return { participants, error, isLoading, getAllParticiants }
})

