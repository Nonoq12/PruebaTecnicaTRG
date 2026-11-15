using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Repositories;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Clientes.ObtenerTodosCliente
{
    /// <summary>
    /// Command handler para listar todos los clientes.
    /// </summary>
    /// <param name="clienteRepository">The cliente repository.</param>
    public class ObtenerTodosClienteCommandHandler(IClienteRepository clienteRepository) : IRequestHandler<ObtenerTodosClienteCommand, IEnumerable<ObtenerTodosClienteCommandDto>>
    {
        private readonly IClienteRepository _clienteRepository = clienteRepository;

        /// <summary>
        /// Handle the command to list all clients.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<IEnumerable<ObtenerTodosClienteCommandDto>> Handle(ObtenerTodosClienteCommand request, CancellationToken cancellationToken)
        {
            var clientes = await _clienteRepository.ObtenerTodosClientesAsync();

            return clientes.Select(v => new ObtenerTodosClienteCommandDto(
                v));
        }
    }
}
