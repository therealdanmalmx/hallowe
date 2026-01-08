<script lang="ts">
  import { computed, defineComponent, onMounted, ref, watch } from 'vue';
  import SearchComp from '../components/SearchComp.vue';
  import { useParticipantStore } from '../stores/participantsStore';
  import RotateLoader from 'vue-spinner/src/RotateLoader.vue';
import { storeToRefs } from 'pinia';


  export default defineComponent({
    name: 'SearchView',
    components: { SearchComp, RotateLoader},

    setup() {

      const color = ref<string>("#FF7518");
      const size = ref('1.25rem');
      const participantStore = useParticipantStore();

      const { filteredParticipants, searchText, isLoading, error } = storeToRefs(participantStore);

      console.log({ filteredParticipants });

      const sortedAndFilteredParticipants = computed(() => {
        return filteredParticipants.value.sort((a: any, b: any) =>
        a.city.localeCompare(b.city)
      );
    });

      onMounted(async () => {
        await participantStore.getAllParticiants();
        console.log('First participant:', participantStore.participants[0]);
        console.log('All keys:', Object.keys(participantStore.participants[0] || {}));
      });

      return { sortedAndFilteredParticipants, searchText, isLoading, error, participantStore, color, size }
    }
  })

</script>

<template>
  <div class="h-screen flex items-center justify-center" v-if="isLoading"><rotate-loader :loading="isLoading" :color="color" :size="size"></rotate-loader></div>
  <div v-else class="px-4 md:px-0">
    <div class="h-calc(100vh_-_40px)">
      <h1 class="text-5xl">List Page</h1>
      <SearchComp />
    </div>

    <div class="relative overflow-x-auto bg-neutral-primary-soft shadow-xs rounded-base border border-[#ff7518]">
        <table class="w-full text-sm text-left rtl:text-right text-body">
            <thead class="text-sm text-body bg-neutral-secondary-soft border-b rounded-base border-[#ff7518]">
                <tr>
                    <th scope="col" class="h px-6 py-3 font-bold">
                        Address
                    </th>
                    <th scope="col" class="hidden sm:block px-6 py-3 font-bold">
                        Postnummer
                    </th>
                    <th scope="col" class="px-6 py-3 font-bold">
                        Stad
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr
                  v-for="user in sortedAndFilteredParticipants"
                  :key="user.id"
                  class="bg-neutral-primary border-b border-[#ff7518]"
                >
                  <th scope="row" class="px-6 py-4 font-medium text-heading whitespace-nowrap">
                    {{user.streetName}}, {{ user.streetNumber }}
                  </th>
                  <td class="hidden sm:block px-6 py-4">
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
