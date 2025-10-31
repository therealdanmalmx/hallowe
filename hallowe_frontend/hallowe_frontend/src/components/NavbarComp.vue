<script setup lang="ts">
  import searchIcon from '../assets/icons/search_icon.png'
  import houseIcon from '../assets/icons/house_icon.png'
  import addIcon from '../assets/icons/add_icon.png'
</script>

<template>
  <nav class="absoute w-full bottom-10 pt-12">
    <div>
      <ul class="flex w-full justify-between items-center">
        <li class="flex-1 flex justify-center size-12 cursor-pointer">
          <RouterLink to="/search">
        <img :src="searchIcon" alt="search" title="Leta efter en adress" />
          </RouterLink>
        </li>
        <li class="flex-1 flex justify-center" >
          <RouterLink to="/map">
        <img :src="houseIcon" alt="map" title="Se anmälda hus"/>
          </RouterLink>
        </li>
        <li class="flex-1 flex justify-center">
          <RouterLink to="/add-address">
        <img :src="addIcon" alt="add trick or treathouse" title="Lägg till ett hus"/>
          </RouterLink>
        </li>
      </ul>
    </div>
  </nav>
</template>