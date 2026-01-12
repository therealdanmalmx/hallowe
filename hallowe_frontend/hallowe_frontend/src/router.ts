import { createRouter, createWebHistory } from "vue-router";

import StartView from "./views/StartView.vue";
import MapView from "./views/MapView.vue";
import Search from "./views/SearchView.vue";
import AddNewHouse from "./views/AddNewHouseView.vue";
import Login from "./views/Login.vue";
import Register from "./views/Register.vue";

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
    { component: Login, path: "/login" },
    { component: Register, path: "/register" },
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
