<template>
  <div class="min-h-screen flex items-center justify-center p-4 relative overflow-hidden">
    <div class="w-full max-w-md relative z-10">
      <div class="text-center mb-8">
        <h1 class="scary-font text-5xl font-bold text-orange-500 mb-2 drop-shadow-lg" style="text-shadow: 0 0 20px rgba(249, 115, 22, 0.5)">
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

          <button @click="submitForm" class="w-full bg-orange-500 hover:bg-orange-600 text-white font-bold py-3 px-4 rounded-lg transition-all shadow-lg hover:shadow-orange-500/50 hover:shadow-xl mt-6">
            Skapa konto
          </button>
        </div>
                <div class="relative mb-6">
          <div class="absolute inset-0 flex items-center"><div class="w-full border-t border-orange-500/30"></div></div>
          <div class="relative flex justify-center text-sm"><span class="px-2 bg-slate-800/50 text-orange-400">eller använd:</span></div>
        </div>
        <div class="space-y-3">
          <button
            type="button"
            @click.prevent="handleSocial('Google')"
            class="w-full flex items-center justify-center gap-3 bg-slate-900/50 hover:bg-slate-800 border border-orange-500/30 hover:border-orange-500 text-white py-3 px-4 rounded-lg transition-all font-medium"
          >
            <svg class="w-5 h-5" fill="currentColor" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 640 640">
              <path d="M564 325.8C564 467.3 467.1 568 324 568C186.8 568 76 457.2 76 320C76 182.8 186.8 72 324 72C390.8 72 447 96.5 490.3 136.9L422.8 201.8C334.5 116.6 170.3 180.6 170.3 320C170.3 406.5 239.4 476.6 324 476.6C422.2 476.6 459 406.2 464.8 369.7L324 369.7L324 284.4L560.1 284.4C562.4 297.1 564 309.3 564 325.8z"/>
            </svg>
            Google
          </button>

          <button
            type="button"
            @click.prevent="handleSocial('Facebook')"
            class="w-full flex items-center justify-center gap-3 bg-slate-900/50 hover:bg-slate-800 border border-orange-500/30 hover:border-orange-500 text-white py-3 px-4 rounded-lg transition-all font-medium"
          >
            <svg class="w-5 h-5" fill="currentColor" viewBox="0 0 24 24">
              <path d="M24 12.073c0-6.627-5.373-12-12-12s-12 5.373-12 12c0 5.99 4.388 10.954 10.125 11.854v-8.385H7.078v-3.47h3.047V9.43c0-3.007 1.792-4.669 4.533-4.669 1.312 0 2.686.235 2.686.235v2.953H15.83c-1.491 0-1.956.925-1.956 1.874v2.25h3.328l-.532 3.47h-2.796v8.385C19.612 23.027 24 18.062 24 12.073z"/>
            </svg>
            Facebook
          </button>

          <button
            type="button"
            @click.prevent="handleSocial('Instagram')"
            class="w-full flex items-center justify-center gap-3 bg-slate-900/50 hover:bg-slate-800 border border-orange-500/30 hover:border-orange-500 text-white py-3 px-4 rounded-lg transition-all font-medium"
          >
            <svg class="w-5 h-5" fill="currentColor" viewBox="0 0 24 24">
              <path d="M7.75 2A5.75 5.75 0 0 0 2 7.75v8.5A5.75 5.75 0 0 0 7.75 22h8.5A5.75 5.75 0 0 0 22 16.25v-8.5A5.75 5.75 0 0 0 16.25 2h-8.5Zm0 1.5h8.5a4.25 4.25 0 0 1 4.25 4.25v8.5a4.25 4.25 0 0 1-4.25 4.25h-8.5A4.25 4.25 0 0 1 3.5 16.25v-8.5A4.25 4.25 0 0 1 7.75 3.5Zm9.75 1.25a1 1 0 1 0 0 2 1 1 0 0 0 0-2ZM12 6.25A5.75 5.75 0 1 0 17.75 12 5.76 5.76 0 0 0 12 6.25Zm0 1.5A4.25 4.25 0 1 1 7.75 12 4.26 4.26 0 0 1 12 7.75Z"/>
            </svg>
            Instagram
          </button>
          

          <button
            type="button"
            @click.prevent="handleSocial('LinkedIn')"
            class="w-full flex items-center justify-center gap-3 bg-slate-900/50 hover:bg-slate-800 border border-orange-500/30 hover:border-orange-500 text-white py-3 px-4 rounded-lg transition-all font-medium"
          >
            <svg class="w-5 h-5" fill="currentColor" viewBox="0 0 24 24">
              <path d="M20.447 20.452H16.89v-5.569c0-1.328-.027-3.037-1.852-3.037-1.853 0-2.136 1.445-2.136 2.939v5.667H9.345V9h3.414v1.561h.049c.476-.9 1.637-1.85 3.37-1.85 3.601 0 4.267 2.37 4.267 5.455v6.286zM5.337 7.433a2.062 2.062 0 11.001-4.123 2.062 2.062 0 01-.001 4.123zM7.119 20.452H3.556V9h3.563v11.452zM22.225 0H1.771C.792 0 0 .774 0 1.729v20.542C0 23.227.792 24 1.771 24h20.451C23.2 24 24 23.227 24 22.271V1.729C24 .774 23.2 0 22.222 0h.003z"/>
            </svg>
            LinkedIn
          </button>
          
        </div>

        <p class="text-center text-slate-400 text-xs mt-6">
          Genom att fortsätta godkänner du våran <span class="text-[#ff7518]"> <RouterLink to="#">integritetspolicy</RouterLink>  </span>
        </p>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
  import { ref } from 'vue'
  import { userService } from "../api/services/userService"
  import type { User } from "../../types/interfaces";

  const showPassword = ref(false)
  const form = ref({ name: '', email: '', password: '' })

  const handleSocial = (provider) => console.log(`${provider} reg`);


  const submitForm = async () => {
    
    if (!form.value.name || form.value.name === "") {
      console.log("Name is required")
    }

    if (!form.value.email || form.value.email === "") {
      console.log("Email is required")
    }

    if (!form.value.password || form.value.password === "") {
      console.log("Password is required")
    }

    if (form.value.email && form.value.password && form.value.name) {

      const newUSer: User = {
        name: form.value.name.trim(),
        email: form.value.email.trim(),
        password: form.value.password.trim(),
      }

      try {
        const res = userService.register(newUSer);
          console.log({newUSer})
          console.log({res})

        if (res.status === 400) {
          console.log(res.message)
        }
        
      
    } catch (error) {
      console.log("UserService could not be reached", error)
    }
  }
}
</script>