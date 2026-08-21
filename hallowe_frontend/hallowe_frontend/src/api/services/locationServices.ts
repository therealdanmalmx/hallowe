import type { Location } from '../../types/interfaces'
import {useHttpClient} from '../client'

export const locationServices = {
    getAll() {
        return useHttpClient().get('/location')
    },
    getById(id: string | number): Promise<any> {
        return useHttpClient().get(`/location/${id}`)
    },
    create(participant: Location): Promise<any> {
        return useHttpClient().post('/location', participant)
    },
    update(userId: string, participant: Location): Promise<any> {
        return useHttpClient().put(`/location/${userId}`, participant)
    },
    delete(id: string | number): Promise<any> {
        return useHttpClient().delete(`/location/${id}`)
    }
}