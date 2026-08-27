<template>
    <div class="flex justify-center">
        <button
            type="button"
            class="w-full! h-12! font-semibold! py-2! px-4! rounded-lg! mt-4! shadow-2xl! transition! bg-[#ff1818]! hover:bg-[#c90000]! text-white!"
            @click="visible = true"
        >
            Radera address / konto
        </button>

        <Teleport to="body">
            <div
                v-if="visible"
                class="fixed inset-0 z-50 flex items-center justify-center bg-black/50 backdrop-blur-sm"
            >
                <div
                    class="w-104 max-w-[92vw] rounded-3xl bg-white shadow-2xl overflow-hidden"
                >
                    <div class="flex flex-col items-center text-center px-8 pt-9 pb-8">
                        <div class="flex items-center justify-center w-16 h-16 rounded-full bg-red-50 mb-5">
                            <i class="pi pi-trash text-2xl! text-[#ff1818]"></i>
                        </div>

                        <h2 class="text-xl font-bold text-slate-800 m-0">
                            Radera address / konto
                        </h2>
                        <p class="text-slate-500 text-sm mt-3 mb-0 leading-relaxed">
                            Den här åtgärden kan inte ångras. Din address och ditt konto kommer att tas bort permanent.
                        </p>

                        <div class="flex gap-3 w-full mt-8">
                            <button
                                type="button"
                                class="flex-1! rounded-xl! py-3! font-medium! bg-slate-100! border-none! text-slate-700! hover:bg-slate-200!"
                                @click="visible = false"
                            >
                                Avbryt
                            </button>
                            <button
                                type="button"
                                class="flex-1! rounded-xl! py-3! font-semibold! bg-[#ff1818]! border-none! text-white! shadow-lg! hover:bg-[#c90000]!"
                                @click="deleteLoactionAndUser(), visible = false"
                            >
                                Radera
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </Teleport>
    </div>
</template>

<script setup>
import { ref } from 'vue';
import { locationServices } from '../api/services/locationServices';
import { useUserStore } from "../stores/userStore.ts"
import { storeToRefs } from 'pinia'
import { useRouter } from "vue-router";

const router = useRouter();

const userStore = useUserStore();
const { userId, isAuthenticated } = storeToRefs(userStore);
const { logOutUser } = useUserStore();

const visible = ref(false);

const deleteLoactionAndUser = async () => {
    try {
        const location = await locationServices.delete(userId.value);

        if (!location) {
            return;
        }

        await logOutUser();
        router.push("/map")

    } catch (error) {
        console.error(error);
    }
}

</script>
