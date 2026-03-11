import type { User } from '../../types/interfaces'
import apiClient from '../client'

export const userService = {
    getAll() {
    return apiClient.get('/user')
    },
    getById(id: string | number): Promise<any> {
        return apiClient.get(`/user/${id}`)
    },
    create(user: User): Promise<any> {
        return apiClient.post('/user', user)
    },
    update(id: string | number, user: User): Promise<any> {
        return apiClient.put(`/user/${id}`, user)
    },
    delete(id: string | number): Promise<any> {
        return apiClient.delete(`/user/${id}`)
    }
}