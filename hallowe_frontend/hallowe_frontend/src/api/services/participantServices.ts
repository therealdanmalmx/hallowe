import type { Participant } from '../../types/interfaces'
import apiClient from '../client'

export const userService = {
    getAll() {
    return apiClient.get('/Participant')
    },
    getById(id: string | number): Promise<any> {
        return apiClient.get(`/Participant/${id}`)
    },
    create(participant: Participant): Promise<any> {
        return apiClient.post('/Participant', participant)
    },
    update(id: string | number, participant: Participant): Promise<any> {
        return apiClient.put(`/Participant/${id}`, participant)
    },
    delete(id: string | number): Promise<any> {
        return apiClient.delete(`/Participant/${id}`)
    }
}