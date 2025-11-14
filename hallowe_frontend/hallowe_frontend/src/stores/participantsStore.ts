import { defineStore } from "pinia";
import { onMounted, ref } from "vue";
import { userService } from '../api/services/participantServices';
import type { Participant } from "../types/interfaces";

export const useParticipantStore = defineStore('participantStore', () => {
    const participants = ref<Participant[]>([]);

    async function getAllParticiants() {
        try {
            const response = await userService.getAll();
            participants.value = response.data;
        } catch (error) {
            // Handle registration error
            console.error('Registration failed:', error);
            throw error;
        }
    }

    onMounted(getAllParticiants());

  return { participants }
})

