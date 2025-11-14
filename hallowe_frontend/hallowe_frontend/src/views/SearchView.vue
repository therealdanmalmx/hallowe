<script setup lang="ts">
import { onMounted } from 'vue';
import SearchComp from '../components/SearchComp.vue';
import { useParticipantStore } from '../stores/participantsStore';

const participantStore = useParticipantStore();

onMounted(() => {
  participantStore;
})




</script>

<template>
  <div class="px-12">
    <div class="h-calc(100vh_-_40px)">
      <h1 class="text-5xl">search-view</h1>
      <SearchComp />
    </div>

    <div class="relative overflow-x-auto bg-neutral-primary-soft shadow-xs rounded-base border border-[#ff7518]">
        <table class="w-full text-sm text-left rtl:text-right text-body">
            <thead class="text-sm text-body bg-neutral-secondary-soft border-b rounded-base border-[#ff7518]">
                <tr>
                    <th scope="col" class="px-6 py-3 font-medium">
                        Address
                    </th>
                    <th scope="col" class="px-6 py-3 font-medium">
                        Postnummer
                    </th>
                    <th scope="col" class="px-6 py-3 font-medium">
                        Stad
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="user in participantStore.participants" :key="user.id" class="bg-neutral-primary border-b border-[#ff7518]">
                    <th scope="row" class="px-6 py-4 font-medium text-heading whitespace-nowrap">
                        {{user.streetName}}, {{ user.streetNumber }}
                    </th>
                    <td class="px-6 py-4">
                        {{user.postalCode}}
                    </td>
                    <td class="px-6 py-4">
                        {{user.city}}
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
  </div>


</template>
