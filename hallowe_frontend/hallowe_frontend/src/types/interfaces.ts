export interface Participant {
    id: number,
    name: string,
    street: string,
    number: string,
    postal: string,
    municipality: '',
    trickOrTreat: boolean,
    date: Date,
    timeFrom: TimeRanges,
    timeTo: TimeRanges,
}