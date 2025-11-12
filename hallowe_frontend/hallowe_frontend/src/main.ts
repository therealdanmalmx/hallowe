import { createApp } from "vue";
import "./style.css";
import App from "./App.vue";
import router from "./router";
import VueGoogleMaps from '@fawmi/vue-google-maps'

createApp(App).use(router)

.use(VueGoogleMaps, {
  load: {
    key: import.meta.env.VITE_GOOGLE_MAPS_API_KEY,
    libraries: 'places',
    await: true,
  },
})

.mount("#app");
