import { createRouter, createWebHistory } from "vue-router";

import StartView from "./views/StartView.vue";
import HomeView from "./views/HomeView.vue";

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
