import type { User } from '../../types/interfaces'
import { useHttpClient } from '../client'

export const userService = {
    getAll() {
        return useHttpClient().get('/user/users')
    },
    getById(id: string | number): Promise<any> {
        return useHttpClient().get(`/user/${id}`)
    },
    register(user: User): Promise<any> {
        return useHttpClient().post('/user/register', user)
    },
    login(user: User): Promise<any> {
        return useHttpClient().post('/user/login', user)
    },
logout() {
    return useHttpClient().post('/user/logout')
},
    update(id: string | number, user: User): Promise<any> {
        return useHttpClient().put(`/user/${id}`, user)
    },
    delete(id: string | number): Promise<any> {
        return useHttpClient().delete(`/user/${id}`)
    }
}