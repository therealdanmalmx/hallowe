<template>
  <div class="min-h-screen flex items-center justify-center p-4 relative overflow-hidden">
    <div class="w-full max-w-md relative z-10">
      <div class="text-center mb-8">
        <h1 class="scary-font text-5xl font-bold text-orange-500 mb-2 drop-shadow-lg" style="text-shadow: 0 0 20px rgba(249, 115, 22, 0.5)">
          Välkommen
        </h1>
      </div>

      <div class="bg-slate-800/50 backdrop-blur-md border-2 border-orange-500 rounded-lg p-8 shadow-2xl">
        <div class="flex gap-2 mb-8 bg-slate-900/50 p-1 rounded-lg border border-orange-500/30">
          <button class="flex-1 py-2 px-4 rounded font-semibold transition-all bg-orange-500 text-white shadow-lg shadow-orange-500/50">
            Logga in
          </button>
          <router-link to="/register" class="flex-1 py-2 px-4 rounded font-semibold transition-all text-orange-400 hover:text-orange-300 text-center">
            Registrera
          </router-link>
        </div>

        <div class="space-y-4 mb-6">
          <div>
            <label class="block text-orange-400 text-sm font-medium mb-2">User name</label>
            <input
              v-model="form.userName"
              type="email"
              placeholder="your@email.com"
              class="w-full px-4 py-3 bg-slate-900/50 border border-orange-500/30 rounded-lg text-white placeholder-slate-500 focus:outline-none focus:border-orange-500 focus:ring-2 focus:ring-orange-500/30 transition-all"
              required
            />
          </div>

          <div>
            <label class="block text-orange-400 text-sm font-medium mb-2">Lösenord</label>
            <div class="relative">
              <input
                v-model="form.password"
                :type="showPassword ? 'text' : 'password'"
                placeholder="••••••••"
                class="w-full px-4 py-3 bg-slate-900/50 border border-orange-500/30 rounded-lg text-white placeholder-slate-500 focus:outline-none focus:border-orange-500 focus:ring-2 focus:ring-orange-500/30 transition-all pr-10"
                required
              />
              <button @click="showPassword = !showPassword" type="button" class="absolute right-3 top-1/2 -translate-y-1/2 text-slate-200">
                <svg v-if="showPassword" class="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 12a3 3 0 11-6 0 3 3 0 016 0z" />
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M2.458 12C3.732 7.943 7.523 5 12 5c4.478 0 8.268 2.943 9.542 7-1.274 4.057-5.064 7-9.542 7-4.477 0-8.268-2.943-9.542-7z" />
                </svg>
                <svg v-else class="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 12a3 3 0 11-6 0 3 3 0 016 0z" />
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M2.458 12C3.732 7.943 7.523 5 12 5c4.478 0 8.268 2.943 9.542 7-1.274 4.057-5.064 7-9.542 7-4.477 0-8.268-2.943-9.542-7z" />
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M3 3l18 18" />
                </svg>
              </button>
            </div>
          </div>

          <button @click.prevent="submitForm()" class="w-full bg-orange-500 hover:bg-orange-600 text-white font-bold py-3 px-4 rounded-lg transition-all shadow-lg hover:shadow-orange-500/50 hover:shadow-xl mt-6">
            Logga in
          </button>
        </div>

        <div class="relative mb-6">
          <div class="absolute inset-0 flex items-center"><div class="w-full border-t border-orange-500/30"></div></div>
          <div class="relative flex justify-center text-sm"><span class="px-2 bg-slate-800/50 text-orange-400">eller använd:</span></div>
        </div>

        <div class="flex items-center justify-between">
          <button
            type="button"
            @click.prevent="googleAuth"
            title="Logga in med Google"
          >
          <svg class="size-10 cursor-pointer" viewBox="0 0 128 128">
            <path fill="none" d="M44.59 4.21a63.28 63.28 0 004.33 120.9 67.6 67.6 0 0032.36.35 57.13 57.13 0 0025.9-13.46 57.44 57.44 0 0016-26.26 74.33 74.33 0 001.61-33.58H65.27v24.69h34.47a29.72 29.72 0 01-12.66 19.52 36.16 36.16 0 01-13.93 5.5 41.29 41.29 0 01-15.1 0A37.16 37.16 0 0144 95.74a39.3 39.3 0 01-14.5-19.42 38.31 38.31 0 010-24.63 39.25 39.25 0 019.18-14.91A37.17 37.17 0 0176.13 27a34.28 34.28 0 0113.64 8q5.83-5.8 11.64-11.63c2-2.09 4.18-4.08 6.15-6.22A61.22 61.22 0 0087.2 4.59a64 64 0 00-42.61-.38z"></path><path fill="#e33629" d="M44.59 4.21a64 64 0 0142.61.37 61.22 61.22 0 0120.35 12.62c-2 2.14-4.11 4.14-6.15 6.22Q95.58 29.23 89.77 35a34.28 34.28 0 00-13.64-8 37.17 37.17 0 00-37.46 9.74 39.25 39.25 0 00-9.18 14.91L8.76 35.6A63.53 63.53 0 0144.59 4.21z"></path><path fill="#f8bd00" d="M3.26 51.5a62.93 62.93 0 015.5-15.9l20.73 16.09a38.31 38.31 0 000 24.63q-10.36 8-20.73 16.08a63.33 63.33 0 01-5.5-40.9z"></path><path fill="#587dbd" d="M65.27 52.15h59.52a74.33 74.33 0 01-1.61 33.58 57.44 57.44 0 01-16 26.26c-6.69-5.22-13.41-10.4-20.1-15.62a29.72 29.72 0 0012.66-19.54H65.27c-.01-8.22 0-16.45 0-24.68z"></path><path fill="#319f43" d="M8.75 92.4q10.37-8 20.73-16.08A39.3 39.3 0 0044 95.74a37.16 37.16 0 0014.08 6.08 41.29 41.29 0 0015.1 0 36.16 36.16 0 0013.93-5.5c6.69 5.22 13.41 10.4 20.1 15.62a57.13 57.13 0 01-25.9 13.47 67.6 67.6 0 01-32.36-.35 63 63 0 01-23-11.59A63.73 63.73 0 018.75 92.4z"></path>
          </svg>
            <!-- <svg class="w-5 h-5" fill="currentColor" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 640 640">
              <path d="M564 325.8C564 467.3 467.1 568 324 568C186.8 568 76 457.2 76 320C76 182.8 186.8 72 324 72C390.8 72 447 96.5 490.3 136.9L422.8 201.8C334.5 116.6 170.3 180.6 170.3 320C170.3 406.5 239.4 476.6 324 476.6C422.2 476.6 459 406.2 464.8 369.7L324 369.7L324 284.4L560.1 284.4C562.4 297.1 564 309.3 564 325.8z"/>
            </svg>
            Google -->
          </button>

          <button
            type="button"
            @click.prevent="facebookAuth"
            title="Logga in med Facebook"
          >
          <svg class="size-10 cursor-pointer" viewBox="0 0 128 128">
            <rect fill="#3d5a98" x="4.83" y="4.83" width="118.35" height="118.35" rx="6.53" ry="6.53"></rect><path fill="#fff" d="M86.48 123.17V77.34h15.38l2.3-17.86H86.48v-11.4c0-5.17 1.44-8.7 8.85-8.7h9.46v-16A126.56 126.56 0 0091 22.7c-13.62 0-23 8.3-23 23.61v13.17H52.62v17.86H68v45.83z"></path>
          </svg>
            <!-- <svg class="w-5 h-5" fill="currentColor" viewBox="0 0 24 24">
              <path d="M24 12.073c0-6.627-5.373-12-12-12s-12 5.373-12 12c0 5.99 4.388 10.954 10.125 11.854v-8.385H7.078v-3.47h3.047V9.43c0-3.007 1.792-4.669 4.533-4.669 1.312 0 2.686.235 2.686.235v2.953H15.83c-1.491 0-1.956.925-1.956 1.874v2.25h3.328l-.532 3.47h-2.796v8.385C19.612 23.027 24 18.062 24 12.073z"/>
            </svg> -->
          </button>

          <button
            type="button"
            @click.prevent="() => handleSocial('X')"
            title="Logga in med X"
          >
            <svg class="size-10 cursor-pointer" viewBox="0 0 128 128">
              <path d="M75.916 54.2 122.542 0h-11.05L71.008 47.06 38.672 0H1.376l48.898 71.164L1.376 128h11.05L55.18 78.303 89.328 128h37.296L75.913 54.2ZM60.782 71.79l-4.955-7.086-39.42-56.386h16.972L65.19 53.824l4.954 7.086 41.353 59.15h-16.97L60.782 71.793Z" fill="#000" style="stroke-width:.104373"></path>
            </svg>
          </button>

          <button
            type="button"
            @click.prevent="() => handleSocial('LinkedIn')"
            title="Logga in med LinkedIn"
          >
            <svg class="size-10 cursor-pointer" viewBox="0 0 128 128">
              <path fill="#0076b2" d="M116 3H12a8.91 8.91 0 00-9 8.8v104.42a8.91 8.91 0 009 8.78h104a8.93 8.93 0 009-8.81V11.77A8.93 8.93 0 00116 3z"></path><path fill="#fff" d="M21.06 48.73h18.11V107H21.06zm9.06-29a10.5 10.5 0 11-10.5 10.49 10.5 10.5 0 0110.5-10.49M50.53 48.73h17.36v8h.24c2.42-4.58 8.32-9.41 17.13-9.41C103.6 47.28 107 59.35 107 75v32H88.89V78.65c0-6.75-.12-15.44-9.41-15.44s-10.87 7.36-10.87 15V107H50.53z"></path>
            </svg>
          </button>          
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
  import { ref } from 'vue';
  import { router } from "../router";
  import { useUserStore } from "../stores/userStore.ts";
  import type { User } from '../types/interfaces.ts';
  import { useToast } from "vue-toastification";

  const toast = useToast();
  const showPassword = ref(false);
  const submitted = ref(false);
  const isSubmitting = ref(true);
  const form = ref({ userName: '', password: '' })
  const {login} = useUserStore();

  const handleSocial = (provider: string) => console.log(`${provider} auth`);
  
  const googleAuth = () => {
    window.location.href = 'http://localhost:5168/api/user/google'
  }

  const facebookAuth = () => {
    window.location.href = 'http://localhost:5168/api/user/facebook'
  }

  const submitForm = async () => {
    if (!form.value.userName || !form.value.password) {
      console.log("Username and password are required")
      return
    }

    isSubmitting.value = true
    submitted.value = false

    const user: User = {
      userName: form.value.userName.trim(),
      email: form.value.userName.trim(),
      password: form.value.password.trim(),
    }

    const ok = await login(user)

    isSubmitting.value = false

    if (ok) {
      router.push('/add-address')
    } else {
      toast.error("Du kunde inte loggas in. Prova igen.", {timeout: 3000});
      submitted.value = true
    }
  }
</script>