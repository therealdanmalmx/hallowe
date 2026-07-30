import axios from 'axios'
import type { AxiosInstance } from 'axios'

const httpClient = axios.create({
  baseURL: import.meta.env.VITE_API_URL || 'http://localhost:5168/api',
    withCredentials: true,
    headers: {
      'Content-Type': 'application/json'
    }
});

export function useHttpClient(): AxiosInstance {
  return httpClient
}