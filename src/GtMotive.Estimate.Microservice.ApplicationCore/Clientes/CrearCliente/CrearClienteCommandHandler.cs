using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Repositories;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Clientes.CrearCliente
{
    /// <remarks>
    /// Contructor del command handler para la creación de clientes.
    /// </remarks>
    /// <summary>
    /// Initializes a new instance of the <see cref="CrearClienteCommandHandler"/> class.
    /// </summary>
    /// <param name="clienteRepository">The cliente repository.</param>
    public class CrearClienteCommandHandler(IClienteRepository clienteRepository) : IRequestHandler<CrearClienteCommandDto, Guid>
    {
        private readonly IClienteRepository _clienteRepository = clienteRepository;

        /// <summary>
        /// Handle the command to create a new client.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<Guid> Handle(CrearClienteCommandDto request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var vehicle = new Cliente(
                Guid.NewGuid(),
                request.DNI,
                request.Nombre,
                request.Apellidos,
                request.FechaNacimiento,
                request.Email,
                request.Telefono);

            await _clienteRepository.AgregarClienteAsync(vehicle);
            return vehicle.Id;
        }
    }
}
