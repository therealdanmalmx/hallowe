import axios from 'axios'

const apiClient = axios.create({
  baseURL: import.meta.env.VITE_API_URL || 'http://localhost:5168/api',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      }
})

// Add interceptors for auth, error handling, etc.
// apiClient.interceptors.request.use(config => {
//   const token = localStorage.getItem('token')
//   if (token) {
//     config.headers.Authorization = `Bearer ${token}`
//   }
//   return config
// })

export default apiClient