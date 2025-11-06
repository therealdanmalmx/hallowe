export interface Participant {
    id: number
    name: string,
    streetName: string,
    streetNumber: string,
    postalCode: string,
    city: string,
    trickOrTreat: boolean,
    timeSlotId: number,
    timeSlots: {
        date: Date,
        startTime: string,
        endTime: string,
    }
}

export interface TimeSlot {
    id: number
    date: Date,
    startTime: string,
    endTime: string
}