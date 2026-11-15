using System.Collections.Generic;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Clientes.ObtenerTodosCliente
{
    /// <summary>
    /// Consulta para obtener todos los clientes.
    /// </summary>
    public record ObtenerTodosClienteCommand : IRequest<IEnumerable<ObtenerTodosClienteCommandDto>>;
}
