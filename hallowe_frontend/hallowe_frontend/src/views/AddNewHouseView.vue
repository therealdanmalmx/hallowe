<script setup lang="ts">
  import { ref, computed } from 'vue'

  const form = ref({
    name: '',
    street: '',
    number: '',
    postal: '',
    municipality: '',
    trickOrTreat: false
  })

  const submitted = ref(false)

  function submitForm() {
    console.log('Formulärdata:', form.value)
    submitted.value = true
  }

  const isFormInvalid = computed(() => {
    return (
      form.value.name &&
      form.value.street &&
      form.value.number &&
      form.value.postal &&
      form.value.municipality
    )
  })
  //TODO: Lägg till validering för formuläret samt fixa disabled knappen
</script>

<template>
  <div class="flex justify-center min-h-screen">
    <form
      @submit.prevent="submitForm"
      class="m-6 p-4 rounded-2xl w-full max-w-md backdrop-blur-sm"
    >
      <h1 class="text-4xl font-bold text-center text-orange-700 mb-6">
        Hallo We 🕸️
      </h1>

      <div class="m-4 text-left">
        <label
          for="name"
          class="block text-sm font-medium text-gray-200 pl-2 mb-1"
        >
          Namn
        </label>
        <input
          v-model="form.name"
          id="name"
          type="text"
          required
          class="w-full bg-[#eaeaea] text-black p-2 border border-gray-800 rounded-lg focus:ring-2 focus:ring-orange-400 focus:outline-none"
        />
      </div>

      <div class="m-4 text-left">
        <label
          for="street"
          class="block text-sm font-medium text-gray-200 mb-1 pl-2"
        >
          Gata
        </label>
        <input
          v-model="form.street"
          id="street"
          type="text"
          required
          class="w-full bg-[#eaeaea] text-black p-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-orange-400 focus:outline-none"
        />
      </div>

      <div class="m-4 text-left">
        <label
          for="number"
          class="block text-sm font-medium text-gray-200 mb-1 pl-2"
        >
          Nummer
        </label>
        <input
          v-model="form.number"
          id="number"
          type="text"
          required
          class="w-full bg-[#eaeaea] text-black p-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-orange-400 focus:outline-none"
        />
      </div>

      <div class="m-4 text-left">
        <label
          for="postal"
          class="block text-sm font-medium text-gray-200 mb-1 pl-2"
        >
          Postadress
        </label>
        <input
          v-model="form.postal"
          id="postal"
          type="text"
          required
          class="w-full bg-[#eaeaea] text-black p-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-orange-400 focus:outline-none"
        />
      </div>

      <div class="m-4 text-left">
        <label
          for="municipality"
          class="block text-sm font-medium text-gray-200 mb-1 pl-2"
        >
          Kommun
        </label>
        <input
          v-model="form.municipality"
          id="municipality"
          type="text"
          required
          class="w-full p-2 bg-[#eaeaea] text-black border border-gray-300 rounded-lg focus:ring-2 focus:ring-orange-400 focus:outline-none"
        />
      </div>

      <div class="flex items-center m-5">
        <input
          v-model="form.trickOrTreat"
          id="trickOrTreat"
          type="checkbox"
          class="h-5 w-5 focus:ring-orange-800 border-orange-300 rounded accent-green-500"
        />
        <label for="trickOrTreat" class="ml-2 text-sm text-gray-200">
          Ja, vi välkomnar Bus eller Godis! 👻
        </label>
      </div>

      <button
        type="submit"
        :disabled="!isFormInvalid"
        :class="[
          'w-full font-semibold py-2 px-4 rounded-lg mt-12 shadow-2xl transition',
          isFormInvalid
            ? 'bg-gray-300 cursor-not-allowed'
            : 'bg-[#FF7518] hover:bg-[#9AFF6B]'
        ]"
      >
        Skicka in
      </button>

      <p v-if="submitted" class="text-green-500 text-center mt-4 font-medium">
        Tack, {{ form.name }}! Din adress har sparats! 🧡
      </p>
    </form>
  </div>
</template>
