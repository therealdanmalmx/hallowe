import { defineStore } from "pinia";
import { ref } from "vue";
import { timeService } from "../api/services/timeslotServices";
import type { TimeSlot } from "../types/interfaces";

export const useTimeSlotsStore = defineStore('timeslotStore', () => {
    const times = ref<TimeSlot[]>([]);
    const isLoading = ref<boolean>(false);
    const error = ref<string | null>(null);

    async function getAllTimeSlots() {
        try {
            isLoading.value = true;
            error.value = null;
            const response = await timeService.getAll();
            times.value = response.data;
        } catch (err) {
            console.error('Fetching time slots failed:', error);
            error.value = "Kunde inte hämta tider. Prova igen."
            throw error;
        }
    }

  return { times, isLoading, error, getAllTimeSlots }
})

