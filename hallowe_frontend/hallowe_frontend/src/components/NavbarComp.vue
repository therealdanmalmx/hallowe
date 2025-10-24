<script setup lang="ts">
  import searchIcon from '../assets/icons/search_icon.png'
  import houseIcon from '../assets/icons/house_icon.png'
  import addIcon from '../assets/icons/add_icon.png'
</script>

<template>
  <nav>
    <div>
      <ul>
        <li>
          <RouterLink to="/search">
            <img :src="searchIcon" alt="search" />
          </RouterLink>
        </li>
        <li>
          <RouterLink to="/map">
            <img :src="houseIcon" alt="map" />
          </RouterLink>
        </li>
        <li>
          <RouterLink to="/add-address">
            <img :src="addIcon" alt="add trick or treathouse" />
          </RouterLink>
        </li>
      </ul>
    </div>
  </nav>
</template>

<style scoped>
  nav {
    position: fixed;
    bottom: 0;
    width: 100%;

    padding: 1rem 0;
  }

  ul {
    display: flex;
    gap: 1rem;
    list-style: none;
    padding: 0;
    margin: 0;
    display: flex;
    justify-content: space-evenly;
  }

  img {
    width: 45px;
    height: 45px;
    cursor: pointer;
  }
</style>
