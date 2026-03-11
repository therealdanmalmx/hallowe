import type { User } from '../../types/interfaces'
import apiClient from '../client'

export const userService = {
    getAll() {
    return apiClient.get('/userservice')
    },
    getById(id: string | number): Promise<any> {
        return apiClient.get(`/userservice/${id}`)
    },
    create(user: User): Promise<any> {
        return apiClient.post('/userservice', user)
    },
    update(id: string | number, user: User): Promise<any> {
        return apiClient.put(`/userservice/${id}`, user)
    },
    delete(id: string | number): Promise<any> {
        return apiClient.delete(`/userservice/${id}`)
    }
}