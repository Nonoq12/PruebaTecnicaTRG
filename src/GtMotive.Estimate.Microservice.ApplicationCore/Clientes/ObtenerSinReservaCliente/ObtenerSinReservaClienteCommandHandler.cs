using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Repositories;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Clientes.ObtenerSinReservaCliente
{
    /// <summary>
    /// Command handler para listar todos los clientes.
    /// </summary>
    /// <param name="clienteRepository">The cliente repository.</param>
    /// <param name="alquilerRepository">The alquiler repository.</param>
    public class ObtenerSinReservaClienteCommandHandler(IClienteRepository clienteRepository, IAlquilerRepository alquilerRepository) : IRequestHandler<ObtenerSinReservaClienteCommand, IEnumerable<ObtenerSinReservaClienteCommandDto>>
    {
        private readonly IClienteRepository _clienteRepository = clienteRepository;
        private readonly IAlquilerRepository _alquilerRepository = alquilerRepository;

        /// <summary>
        /// Handle the command to list all clients without reservations.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<IEnumerable<ObtenerSinReservaClienteCommandDto>> Handle(ObtenerSinReservaClienteCommand request, CancellationToken cancellationToken)
        {
            var clientes = await _clienteRepository.ObtenerTodosClientesAsync();
            var reservas = await _alquilerRepository.ObtenerPendientesAlquilersAsync();

            var clientesSinReserva = clientes.Where(c => !reservas.Any(r => r.IdCliente == c.Id));

            return clientesSinReserva.Select(v => new ObtenerSinReservaClienteCommandDto(
                v));
        }
    }
}
