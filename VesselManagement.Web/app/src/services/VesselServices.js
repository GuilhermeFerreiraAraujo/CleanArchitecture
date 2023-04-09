import * as services from './BaseService'
import * as Endpoints from '../constants/Endpoints'

export function GetVessels() {
  return services.Get(Endpoints.VesselEndpoints.GetVessels)
}
