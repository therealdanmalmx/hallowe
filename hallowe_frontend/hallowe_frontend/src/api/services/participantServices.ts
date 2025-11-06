import type { Participant } from '../../types/interfaces'
import apiClient from '../client'

export const userService = {
    getAll() {
    return apiClient.get('/participant')
    },
    getById(id: string | number): Promise<any> {
        return apiClient.get(`/participant/${id}`)
    },
    create(participant: Participant): Promise<any> {
        return apiClient.post('/participant', participant)
    },
    update(id: string | number, participant: Participant): Promise<any> {
        return apiClient.put(`/participant/${id}`, participant)
    },
    delete(id: string | number): Promise<any> {
        return apiClient.delete(`/participant/${id}`)
    }
}