using System.Collections.Generic;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Vehiculos.ObtenerDisponiblesVehiculo
{
    /// <summary>
    /// Consulta para obtener los vehículos disponibles.
    /// </summary>
    public record ObtenerDisponiblesVehiculoCommand : IRequest<IEnumerable<ObtenerDisponiblesVehiculoCommandDto>>;
}
