<script setup lang="ts">
import { ref, computed } from 'vue'

const year = ref(new Date().getFullYear)

function getDaysAroundOctober31(year: number) {
  // Create date for October 31st
  const oct31 = new Date(year, 9, 31); // Month is 0-indexed, so 9 = October

  // Get 2 days before
  const twoDaysBefore = new Date(oct31);
  twoDaysBefore.setDate(oct31.getDate() - 2);

  // Get 1 days before
  const oneDaysBefore = new Date(oct31);
  oneDaysBefore.setDate(oct31.getDate() - 1);

  // Get 2 days after
  const twoDaysAfter = new Date(oct31);
  twoDaysAfter.setDate(oct31.getDate() + 2);

  // Get 1 days after
  const oneDaysAfter = new Date(oct31);
  oneDaysAfter.setDate(oct31.getDate() + 1);

  return {
    twoDaysBefore,
    oneDaysBefore,
    oct31,
    oneDaysAfter,
    twoDaysAfter,
  };
}

const form = ref({
  name: '',
  street: '',
  number: '',
  postal: '',
  municipality: '',
  trickOrTreat: false,
  date: Date,
})

const submitted = ref(false)

function submitForm() {
  console.log('Namn:', form.value.name, 'godkänner att man kommer till dem: ', form.value.trickOrTreat)
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
  <div class="flex justify-center min-h-full">
    <form
      @submit.prevent="submitForm"
      class="m-6 p-4 rounded-2xl w-full md:max-w-xl max-w-md backdrop-blur-sm"
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

      <div class="m-4 text-left">
        <label class="block text-sm font-medium text-gray-200 mb-1 pl-2">
          Välj datum runt Halloween
        </label>
        <div class="flex gap-2 mt-2">
          <label class="flex items-center p-2 bg-[#eaeaea] text-black rounded-lg cursor-pointer">
            <input
              type="radio"
              v-model="form.date"
              :value="getDaysAroundOctober31(2025).twoDaysBefore"
              class="h-4 w-4 accent-orange-500"
            />
            <span class="ml-2">{{getDaysAroundOctober31(2025).twoDaysBefore.getDate()}} / {{getDaysAroundOctober31(2025).twoDaysBefore.getMonth() +1}}</span>
          </label>

          <label class="flex items-center p-2 bg-[#eaeaea] text-black rounded-lg cursor-pointer">
            <input
              type="radio"
              v-model="form.date"
              :value="getDaysAroundOctober31(2025).oneDaysBefore"
              class="h-4 w-4 accent-orange-500"
            />
            <span class="ml-2">{{getDaysAroundOctober31(2025).oneDaysBefore.getDate()}} / {{getDaysAroundOctober31(2025).oneDaysBefore.getMonth() + 1}}</span>
          </label>

          <label class="flex items-center p-2 bg-[#eaeaea] text-black rounded-lg cursor-pointer">
            <input
              type="radio"
              v-model="form.date"
              :value="getDaysAroundOctober31(2025).oct31"
              class="h-4 w-4 accent-orange-500"
            />
            <span class="ml-2">{{getDaysAroundOctober31(2025).oct31.getDate()}} / {{getDaysAroundOctober31(2025).oct31.getMonth() + 1}}</span>
          </label>

          <label class="flex items-center p-2 bg-[#eaeaea] text-black rounded-lg cursor-pointer">
            <input
              type="radio"
              v-model="form.date"
              :value="getDaysAroundOctober31(2025).oneDaysAfter"
              class="h-4 w-4 accent-orange-500"
            />
            <span class="ml-2">{{getDaysAroundOctober31(2025).oneDaysAfter.getDate()}} / {{getDaysAroundOctober31(2025).oneDaysAfter.getMonth() + 1}}</span>
          </label>

          <label class="flex items-center p-2 bg-[#eaeaea] text-black rounded-lg cursor-pointer">
            <input
              type="radio"
              v-model="form.date"
              :value="getDaysAroundOctober31(2025).twoDaysAfter"
              class="h-4 w-4 accent-orange-500"
            />
            <span class="ml-2">{{getDaysAroundOctober31(2025).twoDaysAfter.getDate()}} / {{getDaysAroundOctober31(2025).twoDaysAfter.getMonth() + 1}}</span>
          </label>
        </div>

        <p v-if="form.date" class="text-gray-200 text-sm mt-3 pl-2">
          Valt datum: {{ form.date }}
        </p>
      </div>
    </form>
  </div>
</template>
