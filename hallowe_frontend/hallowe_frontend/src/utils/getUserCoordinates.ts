import { ref } from "vue";

export const defaultCenter = ref<{ lat: number; lng: number }>({ lat: 0, lng: 0 });

export const getUserCoords = () => {
    const pos = ref<{ lat: number; lng: number }>({ lat: 0, lng: 0 });

    navigator.geolocation.getCurrentPosition(
        (position) => {
            pos.value = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };
            defaultCenter.value = { lat: pos.value.lat, lng: pos.value.lng };
        },
        (error) => {
            console.error('Error getting location:', error);
        }
    );
};