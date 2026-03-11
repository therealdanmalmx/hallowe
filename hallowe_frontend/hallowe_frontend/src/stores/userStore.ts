import { defineStore } from "pinia";
import { ref } from "vue";
import { userService } from "../api/services/locationServices";
import type { User } from "../types/interfaces";

export const useUserStore = defineStore('userStore', () => {
    const users = ref<User[]>([]);
    const isLoading = ref<boolean>(false);
    const error = ref<string | null>(null);

    async function getAllUsers() {
        try {
            isLoading.value = true;
            error.value = null;
            const response = await userService.getAll();
            users.value = response.data;
        } catch (err) {
            console.error('Fetching time slots failed:', error);
            error.value = "Kunde inte hämta kunder. Försök igen."
            throw error;
        }
    }

    return { users, isLoading, error, getAllUsers }
})

