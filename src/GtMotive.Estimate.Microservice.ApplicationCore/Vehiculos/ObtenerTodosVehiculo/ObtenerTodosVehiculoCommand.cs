using System.Collections.Generic;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Vehiculos.ObtenerTodosVehiculo
{
    /// <summary>
    /// Consulta para obtener todos los vehículos.
    /// </summary>
    public record ObtenerTodosVehiculoCommand : IRequest<IEnumerable<ObtenerTodosVehiculoCommandDto>>;
}
