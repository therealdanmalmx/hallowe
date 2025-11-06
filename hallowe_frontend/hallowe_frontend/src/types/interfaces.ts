export interface Participant {
    name: string,
    streetName: string,
    streetNumber: string,
    postalCode: string,
    city: string,
    trickOrTreat: boolean,
    timeSlots: {
        date: Date,
        startTime: string,
        endTime: string,
    }
}