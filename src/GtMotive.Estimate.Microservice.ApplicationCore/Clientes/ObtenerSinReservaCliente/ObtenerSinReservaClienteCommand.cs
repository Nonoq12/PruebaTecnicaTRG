using System.Collections.Generic;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Clientes.ObtenerSinReservaCliente
{
    /// <summary>
    /// Consulta para obtener todos los clientes sin reserva.
    /// </summary>
    public record ObtenerSinReservaClienteCommand : IRequest<IEnumerable<ObtenerSinReservaClienteCommandDto>>;
}
