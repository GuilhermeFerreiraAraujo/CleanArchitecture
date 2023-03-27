
import * as services from './BaseService'
import * as Endpoints from '../constants/Endpoints'

export function Login( data) {
    return services.Post(Endpoints.UserEndpoints.Login, data)
}
