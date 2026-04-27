export interface Location {
    id?: number
    name: string,
    streetName: string,
    streetNumber: string,
    postalCode: string,
    city: string,
    trickOrTreat: boolean,
    latitude: number,
    longitude: number,
    date: Date,
    startTime: string,
    endTime: string,
    
}

export interface User {
    name: string,
    userName: string,
    email: string,
    phoneNumber: string
}