import { createRouter, createWebHistory } from "vue-router";

import StartView from "./views/StartView.vue";
import MapView from "./views/MapView.vue";
import Search from "./views/SearchView.vue";
import AddNewHouse from "./views/AddNewHouseView.vue";
import Login from "./views/Login.vue";
import Register from "./views/Register.vue";
import { useUserStore } from "./stores/userStore";

export const router = createRouter({
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
    { 
      component: AddNewHouse, 
      path: "/add-address",
      meta: {
        requiresAuth: true,
      }
    },
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


// router.beforeEach(async (to) => {
//     // redirect to login page if not logged in and trying to access a restricted page
//     const publicPages = ['/map'];
//     const authRequired = !publicPages.includes(to.path);
//     const auth = useUserStore();

//     if (authRequired && auth?.authCreds) {
//         return '/login';
//     }
//   });