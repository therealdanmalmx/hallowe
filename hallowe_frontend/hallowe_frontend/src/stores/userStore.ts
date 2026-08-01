
import { ref, computed } from 'vue'
import { defineStore } from 'pinia'
import type { User } from '../types/interfaces'
import { userService } from "../api/services/userService"
import { useHttpClient } from '../api/client'

export const useUserStore = defineStore('userStore', () => {
  const user = ref<User | null | undefined>(undefined)
  const isLoading = computed(() => user.value === undefined)
  const isAuthenticated = computed(() => !!user.value)

  async function getUserInfo(): Promise<boolean> {
    try {
      const { data } = await useHttpClient().get<User>('/user/me', {
        headers: { 'X-Requested-With': 'XMLHttpRequest' }
      })

      console.log('api/user returned:', data)

      if (typeof data === 'object' && data !== null && typeof data.userName === 'string' && data.userName !== '') {
        user.value = data
        return true
      }

      user.value = null
      return false
    } catch {
      user.value = null
      return false
    }
  };

  async function login(credentials: User): Promise<boolean> {
    
    try {
      await userService.login(credentials)
      // Cookie is now set by the browser automatically (from Set-Cookie on this response).
      // Fetch the user to populate the store:
      // return await getUserInfo();
    } catch(err) {
      console.log('login POST failed', err)
      return false
    }
    
    const ok = await getUserInfo();
    
    if (!ok) {
      console.log('login OK but getUserInfo failed — cookie not being sent?')
    }
    
    return ok  
  }
  
async function logOutUser(): Promise<boolean> {
  try {
    await userService.logout()
    return true
  } catch (error) {
    console.error(error)
    return false
  } finally {
    window.location.href = "/map"
  }
}

  function register(): void {
    window.location.href = '/register'
  }

  return {
    user,
    isAuthenticated,
    isLoading,
    getUserInfo,
    login,
    register,
    logOutUser,
  }
});