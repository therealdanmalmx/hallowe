<script setup>
import searchIcon from "../assets/icons/search_icon.png";
import homeIcon from "../assets/icons/house_icon.png";
import addIcon from "../assets/icons/add_icon.png";
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
          <RouterLink to="/home">
            <img :src="homeIcon" alt="Home" />
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

  padding: 0.5rem 0;
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
  width: 50px;
  height: 50px;
  cursor: pointer;
}
</style>
