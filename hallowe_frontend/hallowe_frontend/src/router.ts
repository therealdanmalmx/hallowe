import { createRouter, createWebHistory } from "vue-router";

import StartView from "./views/StartView.vue";
import MapView from "./views/MapView.vue";
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
      component: MapView,
      path: "/map",
    },
    { component: Search, path: "/search" },
    { component: AddNewHouse, path: "/add-address" },
  ],
  // scrollBehavior(to, from, savedPosition) {
  //   if (savedPosition) {
  //     return savedPosition;
  //   } else {
  //     setTimeout(() => {
  //       window.scrollTo(0, 0);
  //     }, 0);
  //   }
  // },
});
