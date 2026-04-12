import type { TimeSlot } from '../../types/interfaces'
import apiClient from '../client'

export const timeService = {
    getAll() {
    return apiClient.get('/timeslot')
    },
    getById(id: string | number): Promise<any> {
        return apiClient.get(`/timeslot/${id}`)
    },
    create(participant: TimeSlot): Promise<any> {
        return apiClient.post('/timeslot', participant)
    },
    update(id: string | number, participant: TimeSlot): Promise<any> {
        return apiClient.put(`/timeslot/${id}`, participant)
    },
    delete(id: string | number): Promise<any> {
        return apiClient.delete(`/timeslot/${id}`)
    }
}