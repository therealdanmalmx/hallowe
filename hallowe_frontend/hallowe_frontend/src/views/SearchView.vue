<script setup lang="ts">
import SearchComp from '../components/SearchComp.vue';

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
                <tr class="bg-neutral-primary border-b border-[#ff7518]">
                    <th scope="row" class="px-6 py-4 font-medium text-heading whitespace-nowrap">
                        Torstensonsgatan, 53B
                    </th>
                    <td class="px-6 py-4">
                        503 42
                    </td>
                    <td class="px-6 py-4">
                        Borås
                    </td>
                </tr>
                <tr class="bg-neutral-primary border-b border-[#ff7518]">
                    <th scope="row" class="px-6 py-4 font-medium text-heading whitespace-nowrap">
                        Folkungagatan, 23B
                    </th>
                    <td class="px-6 py-4">
                        506 35
                    </td>
                    <td class="px-6 py-4">
                        Borås
                    </td>
                </tr>
                <tr class="bg-neutral-primary">
                    <th scope="row" class="px-6 py-4 font-medium text-heading whitespace-nowrap">
                        Stenbrogatan, 4B
                    </th>
                    <td class="px-6 py-4">
                        431 43
                    </td>
                    <td class="px-6 py-4">
                        Mölndal
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
  </div>


</template>
