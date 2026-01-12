<template>
  <div class="min-h-screen flex items-center justify-center p-4 relative overflow-hidden">
    <div class="w-full max-w-md relative z-10">
      <div class="text-center mb-8">
        <h1 class="text-5xl font-bold text-orange-500 mb-2 drop-shadow-lg" style="text-shadow: 0 0 20px rgba(249, 115, 22, 0.5)">
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
            <label class="block text-orange-400 text-sm font-medium mb-2">Email</label>
            <input
              v-model="form.email"
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
              <button @click="showPassword = !showPassword" type="button" class="absolute right-3 top-1/2 -translate-y-1/2 text-orange-400 hover:text-orange-300">
                <svg v-if="!showPassword" class="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 12a3 3 0 11-6 0 3 3 0 016 0z" />
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M2.458 12C3.732 7.943 7.523 5 12 5c4.478 0 8.268 2.943 9.542 7-1.274 4.057-5.064 7-9.542 7-4.477 0-8.268-2.943-9.542-7z" />
                </svg>
                <svg v-else class="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M13.875 18.825A10.05 10.05 0 0112 19c-4.478 0-8.268-2.943-9.543-7a9.97 9.97 0 011.563-4.803m5.596-3.856a3.375 3.375 0 11-4.753 4.753m4.753-4.753L3.596 3.596m16.807 16.807L3.596 3.596m0 0A10.05 10.05 0 1121.659 12" />
                </svg>
              </button>
            </div>
          </div>

          <button @click="handleLogin" class="w-full bg-orange-500 hover:bg-orange-600 text-white font-bold py-3 px-4 rounded-lg transition-all shadow-lg hover:shadow-orange-500/50 hover:shadow-xl mt-6">
            Logga in
          </button>
        </div>

        <div class="relative mb-6">
          <div class="absolute inset-0 flex items-center"><div class="w-full border-t border-orange-500/30"></div></div>
          <div class="relative flex justify-center text-sm"><span class="px-2 bg-slate-800/50 text-orange-400">eller använd:</span></div>
        </div>

        <div class="space-y-3">
          <button @click="handleSocial('Google')" class="w-full flex items-center justify-center gap-3 bg-slate-900/50 hover:bg-slate-800 border border-orange-500/30 hover:border-orange-500 text-white py-3 px-4 rounded-lg transition-all font-medium">
            Google
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'

const showPassword = ref(false)
const form = ref({ email: '', password: '' })

const handleLogin = () => console.log('Login attempt', form.value)
const handleSocial = (provider) => console.log(`${provider} auth`)
</script>