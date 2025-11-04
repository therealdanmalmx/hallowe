<script setup lang="ts">
import { ref, computed } from 'vue'

const year = ref(new Date);

const currentYear = year.value.getFullYear();
console.log(year.value)

const formatDate = (date: Date) => {
  return date.toLocaleDateString()
};

const getDaysAroundOctober31 = (year: number) => {
  const oct31 = new Date(year, 9, 31);

  const twoDaysBefore = new Date(oct31);
  twoDaysBefore.setDate(oct31.getDate() - 2);

  const oneDaysBefore = new Date(oct31);
  oneDaysBefore.setDate(oct31.getDate() - 1);

  const twoDaysAfter = new Date(oct31);
  twoDaysAfter.setDate(oct31.getDate() + 2);

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
  date: null,
  timeFrom: null,
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

      <div class="my-2 text-left">
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

      <div class="my-2 text-left">
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

      <div class="my-2 text-left">
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

      <div class="my-2 text-left">
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

      <div class="my-2 text-left">
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

      <div class="my-4 text-left">
        <label class="block text-sm font-medium text-gray-200 mb-1 pl-2">
          Välj datum runt Halloween {{ currentYear }}
        </label>
        <div class="flex flex-col items-stretch gap-2 mt-2 xl:flex-row xl:justify-between">
          <label class="flex items-center p-2 bg-[#eaeaea] text-black rounded-lg cursor-pointer">
            <input
              type="radio"
              v-model="form.date"
              :value="getDaysAroundOctober31(currentYear).twoDaysBefore"
              class="h-4 w-4 accent-orange-500"
            />
            <span class="ml-2">{{getDaysAroundOctober31(currentYear).twoDaysBefore.getDate()}} / {{getDaysAroundOctober31(currentYear).twoDaysBefore.getMonth() +1}}</span>
          </label>

          <label class="flex items-center p-2 bg-[#eaeaea] text-black rounded-lg cursor-pointer">
            <input
              type="radio"
              v-model="form.date"
              :value="getDaysAroundOctober31(currentYear).oneDaysBefore"
              class="h-4 w-4 accent-orange-500"
            />
            <span class="ml-2">{{getDaysAroundOctober31(currentYear).oneDaysBefore.getDate()}} / {{getDaysAroundOctober31(currentYear).oneDaysBefore.getMonth() + 1}}</span>
          </label>

          <label class="flex items-center p-2 bg-[#eaeaea] text-black rounded-lg cursor-pointer">
            <input
              type="radio"
              v-model="form.date"
              :value="getDaysAroundOctober31(currentYear).oct31"
              class="h-4 w-4 accent-orange-500"
            />
            <span class="ml-2 xl:text-orange-600">{{getDaysAroundOctober31(currentYear).oct31.getDate()}} / {{getDaysAroundOctober31(currentYear).oct31.getMonth() + 1 }}</span>
            <span class="visible xl:hidden ml-1">(Halloween)</span>
          </label>

          <label class="flex items-center p-2 bg-[#eaeaea] text-black rounded-lg cursor-pointer">
            <input
              type="radio"
              v-model="form.date"
              :value="getDaysAroundOctober31(currentYear).oneDaysAfter"
              class="h-4 w-4 accent-orange-500"
            />
            <span class="ml-2">{{getDaysAroundOctober31(currentYear).oneDaysAfter.getDate()}} / {{getDaysAroundOctober31(currentYear).oneDaysAfter.getMonth() + 1}}</span>
          </label>

          <label class="flex items-center p-2 bg-[#eaeaea] text-black rounded-lg cursor-pointer">
            <input
              type="radio"
              v-model="form.date"
              :value="getDaysAroundOctober31(currentYear).twoDaysAfter"
              class="h-4 w-4 accent-orange-500"
            />
            <span class="ml-2">{{getDaysAroundOctober31(currentYear).twoDaysAfter.getDate()}} / {{getDaysAroundOctober31(currentYear).twoDaysAfter.getMonth() + 1}}</span>
          </label>
        </div>
      </div>
      <div class="flex justify-between gap-x-4 ">
        <div class="text-left w-1/2">
          <label for="time" class="mb-4 text-sm font-medium text-gray-900 dark:text-white pl-2 ">Från:</label>
          <input type="time" id="time" class="bg-[#eaeaea] border leading-none border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" min="09:00" max="22:00" value="00:00" required />
        </div>
        <div class="text-left w-1/2">
          <label for="time" class="mb-4 text-sm font-medium text-gray-900 dark:text-white pl-2 ">Till:</label>
          <input type="time" id="time" class="bg-[#eaeaea] border leading-none border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" min="09:00" max="22:00" value="00:00" required />
        </div>
      </div>

      <div class="flex items-center my-4 mt-8">
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
          'w-full font-semibold py-2 px-4 rounded-lg mt-4 shadow-2xl transition',
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
