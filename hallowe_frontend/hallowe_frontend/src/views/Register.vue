<template>
  <div class="min-h-screen flex items-center justify-center p-4 relative overflow-hidden">
    <div class="w-full max-w-md relative z-10">
      <div class="text-center mb-8">
        <h1 class="text-5xl font-bold text-orange-500 mb-2 drop-shadow-lg" style="text-shadow: 0 0 20px rgba(249, 115, 22, 0.5)">
          Registrera dig
        </h1>
      </div>

      <div class="bg-slate-800/50 backdrop-blur-md border-2 border-orange-500 rounded-lg p-8 shadow-2xl">
        <div class="flex gap-2 mb-8 bg-slate-900/50 p-1 rounded-lg border border-orange-500/30">
          <router-link to="/login" class="flex-1 py-2 px-4 rounded font-semibold transition-all text-orange-400 hover:text-orange-300 text-center">
            Logga in
          </router-link>
          <button class="flex-1 py-2 px-4 rounded font-semibold transition-all bg-orange-500 text-white shadow-lg shadow-orange-500/50">
            Registrera
          </button>
        </div>

        <div class="space-y-4 mb-6">
          <div>
            <label class="block text-orange-400 text-sm font-medium mb-2">Full Name</label>
            <input
              v-model="form.name"
              type="text"
              placeholder="Your name"
              class="w-full px-4 py-3 bg-slate-900/50 border border-orange-500/30 rounded-lg text-white placeholder-slate-500 focus:outline-none focus:border-orange-500 focus:ring-2 focus:ring-orange-500/30 transition-all"
            />
          </div>

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
              </div>
          </div>

          <button @click="handleRegister" class="w-full bg-orange-500 hover:bg-orange-600 text-white font-bold py-3 px-4 rounded-lg transition-all shadow-lg hover:shadow-orange-500/50 hover:shadow-xl mt-6">
            Skapa konto
          </button>
        </div>

        <p class="text-center text-slate-400 text-xs mt-6">
          Genom att fortsätta godkänner du våran <span class="text-[#ff7518]"> <RouterLink to="#">integritetspolicy</RouterLink>  </span>
        </p>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'

const showPassword = ref(false)
const form = ref({ name: '', email: '', password: '' })

const handleRegister = () => console.log('Register attempt', form.value)
</script>