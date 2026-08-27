export interface Location {
    id?: number
    userId: string;
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
    id?: string,
    userName: string,
    password: string,
    email?: string,
    name?: string,
    phoneNumber?: string
}