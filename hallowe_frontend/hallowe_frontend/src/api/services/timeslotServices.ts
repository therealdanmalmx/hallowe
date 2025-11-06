import type { Participant, TimeSlot } from '../../types/interfaces'
import apiClient from '../client'

export const timeService = {
    getAll() {
    return apiClient.get('/TimeSlot')
    },
    getById(id: string | number): Promise<any> {
        return apiClient.get(`/TimeSlot/${id}`)
    },
    create(participant: TimeSlot): Promise<any> {
        return apiClient.post('/TimeSlot', participant)
    },
    update(id: string | number, participant: TimeSlot): Promise<any> {
        return apiClient.put(`/TimeSlot/${id}`, participant)
    },
    delete(id: string | number): Promise<any> {
        return apiClient.delete(`/TimeSlot/${id}`)
    }
}