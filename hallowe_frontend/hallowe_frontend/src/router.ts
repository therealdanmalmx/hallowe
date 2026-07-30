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
      name: "add-address",
      meta: {
        requiresAuth: true,
      }
    },
    { component: Login, path: "/login", name: "login" },
    { component: Register, path: "/register" },
  ],
});

router.beforeEach(async (to) => {
  const userStore = useUserStore()

  if (userStore.isLoading) {
    await userStore.getUserInfo()
  }

  if (to.meta.requiresAuth && !userStore.isAuthenticated) {
    return { name: 'login' }
  }
});