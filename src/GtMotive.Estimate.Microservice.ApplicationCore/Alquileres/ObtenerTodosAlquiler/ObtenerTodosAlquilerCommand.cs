using System.Collections.Generic;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Alquileres.ObtenerTodosAlquiler
{
    /// <summary>
    /// Consulta para obtener todos los vehículos.
    /// </summary>
    public record ObtenerTodosAlquilerCommand : IRequest<IEnumerable<ObtenerTodosAlquilerCommandDto>>;
}
