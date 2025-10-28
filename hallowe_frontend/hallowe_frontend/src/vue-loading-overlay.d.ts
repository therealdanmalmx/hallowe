declare module 'vue-loading-overlay' {
  import { Component } from 'vue'
  const useLoading: () => {
    show: (options?: any) => void
    hide: () => void
  }

  export { useLoading }
}
