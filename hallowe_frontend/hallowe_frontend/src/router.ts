import { createRouter, createWebHistory } from "vue-router";

import StartView from "./views/StartView.vue";
import HomeView from "./views/HomeView.vue";
import Search from "./views/SearchView.vue";
import AddNewHouse from "./views/AddNewHouseView.vue";

export default createRouter({
  history: createWebHistory(),
  routes: [
    {
      component: StartView,
      path: "/",
    },
    {
      component: HomeView,
      path: "/home",
    },
    { component: Search, path: "/search" },
    { component: AddNewHouse, path: "/add-address" },
  ],
  scrollBehavior(to, from, savedPosition) {
    if (savedPosition) {
      return savedPosition;
    } else {
      setTimeout(() => {
        window.scrollTo(0, 0);
      }, 0);
    }
  },
});
