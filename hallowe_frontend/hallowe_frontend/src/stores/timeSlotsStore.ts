import { defineStore } from "pinia";
import { onMounted, ref } from "vue";
import { userService } from '../api/services/participantServices';
import type { TimeSlot } from "../types/interfaces";

export const useTimeSlotsStore = defineStore('timeslotStore', () => {
    const times = ref<TimeSlot[]>([]);

    async function getAllTimeSlots() {
        try {
            const response = await userService.getAll();
            times.value = response.data;
        } catch (error) {
            // Handle registration error
            console.error('Registration failed:', error);
            throw error;
        }
    }

    onMounted(getAllTimeSlots());

  return { times }
})

