declare module '@fawmi/vue-google-maps' {
  import { DefineComponent } from 'vue';
  export const useLoadScript: any;
  export const GMapMap: DefineComponent<{}, {}, any>;
  export const GMapMarker: DefineComponent<{}, {}, any>;
}
declare module '*.vue' {
  import { DefineComponent } from 'vue'
  const component: DefineComponent<{}, {}, any>
  export default component
}
