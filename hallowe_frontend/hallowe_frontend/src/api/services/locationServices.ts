import type { Location } from '../../types/interfaces'
import apiClient from '../client'

export const userService = {
    getAll() {
    return apiClient.get('/location')
    },
    getById(id: string | number): Promise<any> {
        return apiClient.get(`/location/${id}`)
    },
    create(participant: Location): Promise<any> {
        return apiClient.post('/location', participant)
    },
    update(id: string | number, participant: Location): Promise<any> {
        return apiClient.put(`/location/${id}`, participant)
    },
    delete(id: string | number): Promise<any> {
        return apiClient.delete(`/location/${id}`)
    }
}