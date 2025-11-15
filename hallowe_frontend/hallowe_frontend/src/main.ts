import VueGoogleMaps from '@fawmi/vue-google-maps';
import { createPinia } from "pinia";
import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import "./style.css";

createApp(App)
  .use(router)
  .use(createPinia())
  .use(VueGoogleMaps, {
    load: {
      key: import.meta.env.VITE_GOOGLE_MAPS_API_KEY,
      libraries: 'places',
      await: true,
    },
  })

.mount("#app");
