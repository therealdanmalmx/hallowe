<script setup lang="ts">
import { ref, computed, watch, onMounted, reactive } from 'vue'
import {storeToRefs} from 'pinia'
import { locationServices } from '../api/services/locationServices';
import { useUserStore } from "../stores/userStore.ts"
import { useLocationStore } from "../stores/locationStore.ts"
import type { Location }  from '../types/interfaces';
import DeleteDialog from '../components/DeleteDialog.vue';

const locationStore = useLocationStore();
const userStore = useUserStore();
const { userId, isAuthenticated } = storeToRefs(userStore);
const { locations } = storeToRefs(locationStore)

let hasLocation = ref<boolean>(false);
let isSubmitting = ref<boolean>(false);
let isDeleting = ref<boolean>(false);
let error = ref<string>("");

const year = ref(new Date);
let currentYear = year.value.getFullYear();
const currentDay = year.value.getDate();
const currentMonth = year.value.getMonth() + 1;

const formatDate = (date: Date): string => {
  const day = date.getDate();
  const month = date.getMonth() + 1;

  const paddedMonth = month.toString().padStart(2, '0');
  const paddedDay = day.toString().padStart(2, '0');

  const currentDate = `${currentYear}-${paddedMonth}-${paddedDay}`;

  return currentDate;
};

const getDayOfTheWeek = (date: Date | string | number) => {
  const day = date instanceof Date ? date : new Date(date)
  if (isNaN(day.getTime())) {
    return ''
  }

  const days = ['Söndag', 'Måndag', 'Tisdag', 'Onsdag', 'Torsdag', 'Fredag', 'Lördag']
  return days[day.getDay()]
}

const chosenDate = computed(() => {
  const date = new Date(form.date)
  return isNaN(date.getTime()) ? null : date
});

const getChosenMonth = (date: Date | string | number) => {
  const month = date instanceof Date ? date : new Date(date)
  if (isNaN(month.getTime())) {
    return ''
  }
  switch (date.getMonth() + 1) {
    case 10:
      return 'Oktober'
    case 11:
      return 'November'
  }
};

if ((currentMonth > 9 && currentDay > 28) && (currentMonth < 11 && currentDay < 3)) {
  currentYear++;
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
};

const getLatLngForAddress = async (streetName: string, streetNumber: string, postalCode: string, city: string): Promise<boolean> => {
  const address = `${streetNumber} ${streetName}, ${postalCode} ${city}`;
  const url = `https://nominatim.openstreetmap.org/search?q=${encodeURIComponent(address)}&format=json&limit=1`;

  try {
    const response = await fetch(url, {
      headers: {
        'Accept-Language': 'en',
        'User-Agent': 'HalloWe/1.0 (danmalmx@gmail.com)' // Nominatim requires this
      }
    });
    const data = await response.json();

    if (data.length > 0) {
      form.latitude = parseFloat(data[0].lat);
      form.longitude = parseFloat(data[0].lon);
      return true;
    } else {
      console.error('Geocoding failed: No results found');
      return false;
    }
  } catch (error) {
    error.value = error;
    console.error('Error fetching geocoding data:', error);
    return false;
  }
};

const form = reactive({
  id: '',
  name: '',
  userId: '',
  streetName: '',
  streetNumber: '',
  postalCode: '',
  city: '',
  trickOrTreat: false,
  latitude: 0,
  longitude: 0,
  date: null as Date | null,
  startTime: '',
  endTime: '',
});

const submitted = ref(false);

onMounted(async () => {
  await locationStore.getAllParticiants()   // ← actually load the data
})


watch(locations, (loc) => {

  if (!isAuthenticated.value || !loc) {
    return
  }

  const userLocation = locations.value.find(l => {
    return l.userId === userId.value
  })

  if (!userLocation) {
    return
  }

  hasLocation.value = true;
  
  form.name = userLocation.name;
  form.userId = userLocation.userId;
  form.streetName = userLocation.streetName;
  form.streetNumber = userLocation.streetNumber;
  form.postalCode = userLocation.postalCode;
  form.city = userLocation.city;
  form.date = userLocation.date;
  form.startTime = userLocation.startTime;
  form.endTime = userLocation.endTime;
  form.trickOrTreat = isAuthenticated ? true : false;
}, { immediate: true, deep: true });

const baseline = ref(null);
const isDirty = computed(() => baseline.value !== form);

const submitForm = async () => {
  
  if (hasLocation.value && !isDirty.value) {
    submitted.value = "Inga ändringar att spara.";
    return;
  }

  isSubmitting.value = true;
  const getCoords = await getLatLngForAddress(form.streetName, form.streetNumber, form.postalCode, form.city);

  if (form.date && getCoords) {
    const participant: Location = {
      userId: hasLocation.value ? form.userId : userId.value,
      name: form.name.trim(),
      streetName: form.streetName.trim(),
      streetNumber: form.streetNumber.trim(),
      postalCode: form.postalCode.trim(),
      latitude: form.latitude,
      longitude: form.longitude,
      city: form.city.trim(),
      trickOrTreat: form.trickOrTreat,
      date: form.date,
      startTime: form.startTime,
      endTime: form.endTime,
    }

    try {
      const location = hasLocation.value ? await locationServices.update(userId.value, participant) : await locationServices.create(participant);

      if (!location) {
        return;
      } 
      baseline.value = form;          // now "clean" again
      submitted.value = `Tack, ${form.name.split(" ")[0]}! Din ${hasLocation.value ? "information" : "adress"} har ${hasLocation .value? "uppdaterats!" : "sparats!"} 🧡`
      isSubmitting.value = false;
      
    } catch (error) {
      error.value = error;
      console.error(error);
    }
  }
}

const deleteLocation = () => {
  confirm("Vill du radera både din address och ditt konto?");
  DeleteDialog;
};

const isFormInvalid = computed(() => {
  return (
    form.name.trim() &&
    form.streetName.trim() &&
    form.streetNumber.trim() &&
    form.postalCode &&
    form.city.trim() &&
    form.date &&
    form.startTime &&
    form.endTime
  )
});

const toISODate = (date: Date) => {
  const y = date.getFullYear()
  const m = String(date.getMonth() + 1).padStart(2, '0')
  const d = String(date.getDate()).padStart(2, '0')
  return `${y}-${m}-${d}`
}

//TODO: Lägg till validering för formuläret samt fixa disabled knappen
</script>

<template>
  <div class="flex justify-center min-h-full">
    <form
      @submit.prevent="submitForm"
      class="m-6 p-4 rounded-2xl w-full md:max-w-xl max-w-md backdrop-blur-sm"
    >
      <h1 class="scary-font text-[#ff7518] text-4xl font-bold text-center mb-6">
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
          v-model="form.streetName"
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
          v-model="form.streetNumber"
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
          v-model="form.postalCode"
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
          v-model="form.city"
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
              :value="toISODate(getDaysAroundOctober31(currentYear).twoDaysBefore)"
              class="h-4 w-4 accent-orange-500"
            />
            <span class="ml-2">{{getDaysAroundOctober31(currentYear).twoDaysBefore.getDate()}} / {{getDaysAroundOctober31(currentYear).twoDaysBefore.getMonth() +1}}</span>
          </label>

          <label class="flex items-center p-2 bg-[#eaeaea] text-black rounded-lg cursor-pointer">
            <input
              type="radio"
              v-model="form.date"
              :value="toISODate(getDaysAroundOctober31(currentYear).oneDaysBefore)"
              class="h-4 w-4 accent-orange-500"
            />
            <span class="ml-2">{{getDaysAroundOctober31(currentYear).oneDaysBefore.getDate()}} / {{getDaysAroundOctober31(currentYear).oneDaysBefore.getMonth() + 1}}</span>
          </label>

          <label class="flex items-center p-2 bg-[#eaeaea] text-black rounded-lg cursor-pointer">
            <input
              type="radio"
              v-model="form.date"
              :value="toISODate(getDaysAroundOctober31(currentYear).oct31)"
              class="h-4 w-4 accent-orange-500"
            />
            <span class="ml-2 xl:text-orange-600">{{getDaysAroundOctober31(currentYear).oct31.getDate()}} / {{getDaysAroundOctober31(currentYear).oct31.getMonth() + 1 }}</span>
            <span class="visible xl:hidden ml-1">(Halloween)</span>
          </label>

          <label class="flex items-center p-2 bg-[#eaeaea] text-black rounded-lg cursor-pointer">
            <input
              type="radio"
              v-model="form.date"
              :value="toISODate(getDaysAroundOctober31(currentYear).oneDaysAfter)"
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
          <input v-model="form.startTime" type="time" id="time" class="bg-[#eaeaea] border leading-none border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" min="09:00" max="22:00" value="00:00" required />
        </div>
        <div class="text-left w-1/2">
          <label for="time" class="mb-4 text-sm font-medium text-gray-900 dark:text-white pl-2 ">Till:</label>
          <input v-model="form.endTime" type="time" id="time" class="bg-[#eaeaea] border leading-none border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" min="09:00" max="22:00" value="00:00" required />
        </div>
      </div>

      <div v-if="form.date && form.startTime && form.endTime" class="flex items-center my-4 mt-8 text-sm text-[#FF7518]">
        Du har valt att fira Halloween på {{ getDayOfTheWeek(chosenDate) }} den {{ chosenDate.getDate() }}:e {{ getChosenMonth(chosenDate) }} mellan {{ form.startTime.slice(0, 5) }} och {{ form.endTime.slice(0, 5) }}      </div>
      <div class="flex items-center my-4 mt-8">
        <input
          v-model="form.trickOrTreat"
          id="trickOrTreat"
          type="checkbox"
          class="h-5 w-5 focus:ring-orange-800 border-orange-300 rounded accent-green-500"
        />
        <label for="trickOrTreat" class="ml-2 text-sm text-gray-200">
          Ja, vi välkomnar bus eller godis! 👻
        </label>
      </div>
      <button
        type="submit"
        :disabled="!isFormInvalid"
        :class="[
          'w-full h-12 font-semibold py-2 px-4 rounded-lg mt-4 shadow-2xl transition',
          isFormInvalid
            ? 'bg-gray-300 cursor-not-allowed'
            : 'bg-[#FF7518] hover:bg-[#9AFF6B]'
        ]"
      >
        <i v-if="isSubmitting" class="pi pi-spin pi-spinner-dotted font-bold text-xl"></i>
        <span v-else>{{ hasLocation ? "Uppdatera address" : "Skicka in"}}</span>
      </button>

      <div
        v-if="hasLocation"
        type="submit"
        
      >
        <i v-if="isDeleting" class="pi pi-spin pi-spinner-dotted font-bold text-xl"></i>
        <span v-else><DeleteDialog /></span>
      </div>

      <p v-if="submitted" class="text-green-500 text-center mt-4 font-medium">
        {{ submitted }}
      </p>
      <p v-if="error" class="text-red-500 text-center mt-4 font-medium">
        Din adress kunde inte sparas! Försök igen.
      </p>

    </form>
  </div>
</template>
