import Toast, { type PluginOptions } from "vue-toastification";
import { createPinia } from "pinia";
import { createApp } from "vue";
import App from "./App.vue";
import {router} from "./router";
import "vue-toastification/dist/index.css";
import "./style.css";

const options: PluginOptions = {
    // You can set your default options here
};

createApp(App)
  .use(router)
  .use(createPinia())
  .use(Toast, options)

.mount("#app");