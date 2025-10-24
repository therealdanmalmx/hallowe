<script setup lang="ts">
import { ref } from "vue";

const form = ref({
  name: "",
  street: "",
  number: "",
  postal: "",
  municipality: "",
  trickOrTreat: false,
});

const submitted = ref(false);

function submitForm() {
  console.log("Formulärdata:", form.value);
  submitted.value = true;
}
</script>

<template>
  <div
    class="flex justify-center items-center min-h-screen bg-gradient-to-b from-orange-200 to-orange-500"
  >
    <form
      @submit.prevent="submitForm"
      class="bg-white/90 p-8 rounded-2xl shadow-2xl w-full max-w-md backdrop-blur-sm"
    >
      <h1 class="text-3xl font-bold text-center text-orange-700 mb-6">
        Hallo We 🕸️
      </h1>

      <div class="mb-4">
        <label for="name" class="block text-sm font-medium text-gray-700 mb-1">
          Namn
        </label>
        <input
          v-model="form.name"
          id="name"
          type="text"
          required
          class="w-full p-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-orange-400 focus:outline-none"
        />
      </div>

      <div class="mb-4">
        <label
          for="street"
          class="block text-sm font-medium text-gray-700 mb-1"
        >
          Gata
        </label>
        <input
          v-model="form.street"
          id="street"
          type="text"
          required
          class="w-full p-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-orange-400 focus:outline-none"
        />
      </div>

      <div class="mb-4">
        <label
          for="number"
          class="block text-sm font-medium text-gray-700 mb-1"
        >
          Nummer
        </label>
        <input
          v-model="form.number"
          id="number"
          type="text"
          required
          class="w-full p-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-orange-400 focus:outline-none"
        />
      </div>

      <div class="mb-4">
        <label
          for="postal"
          class="block text-sm font-medium text-gray-700 mb-1"
        >
          Postadress
        </label>
        <input
          v-model="form.postal"
          id="postal"
          type="text"
          required
          class="w-full p-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-orange-400 focus:outline-none"
        />
      </div>

      <div class="mb-4">
        <label
          for="municipality"
          class="block text-sm font-medium text-gray-700 mb-1"
        >
          Kommun
        </label>
        <input
          v-model="form.municipality"
          id="municipality"
          type="text"
          required
          class="w-full p-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-orange-400 focus:outline-none"
        />
      </div>

      <div class="flex items-center mb-6">
        <input
          v-model="form.trickOrTreat"
          id="trickOrTreat"
          type="checkbox"
          class="h-5 w-5 text-orange-500 focus:ring-orange-400 border-gray-300 rounded"
        />
        <label for="trickOrTreat" class="ml-2 text-sm text-gray-700">
          Ja, folk får komma och säga bus eller godis 🎃
        </label>
      </div>

      <button
        type="submit"
        class="w-full bg-orange-600 text-white font-semibold py-2 px-4 rounded-lg hover:bg-orange-700 transition"
      >
        Skicka in
      </button>

      <p v-if="submitted" class="text-green-700 text-center mt-4 font-medium">
        Tack, {{ form.name }}! Din adress har sparats! 🧡
      </p>
    </form>
  </div>
</template>
