using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Repositories;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Alquileres.CrearAlquiler
{
    /// <remarks>
    /// Contructor del command handler para la creación del alquiler.
    /// </remarks>
    /// <summary>
    /// Adds Use Cases classes.
    /// </summary>
    /// <param name="alquilerRepository">The rent repository.</param>
    /// <param name="vehiculoRepository">The vehicle repository.</param>
    /// <param name="clienteRepository">The client repository.</param>
    public class CrearAlquilerCommandHandler(IAlquilerRepository alquilerRepository, IVehiculoRepository vehiculoRepository, IClienteRepository clienteRepository) : IRequestHandler<CrearAlquilerCommandDto, Guid>
    {
        private readonly IVehiculoRepository _vehiculoRepository = vehiculoRepository;
        private readonly IClienteRepository _clienteRepository = clienteRepository;
        private readonly IAlquilerRepository _alquilerRepository = alquilerRepository;

        /// <summary>
        /// Handle the command to create a new rent.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The response.</returns>
        public async Task<Guid> Handle(CrearAlquilerCommandDto request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var cliente = await _clienteRepository.ObtenerClientePorIdAsync(request.IdCliente) ?? throw new InvalidOperationException("Cliente no encontrado");
            var alquileresSinTerminar = await _alquilerRepository.ObtenerPendientesAlquilersAsync();
            if (alquileresSinTerminar.Any(a => a.IdCliente == cliente.Id))
            {
                throw new InvalidOperationException("El cliente ya tiene alquileres pendientes");
            }

            var vehiculo = await _vehiculoRepository.ObtenerVehiculoPorIdAsync(request.IdVehiculo) ?? throw new InvalidOperationException("Vehículo no encontrado");
            if (vehiculo.Alquilado)
            {
                throw new InvalidOperationException("El vehículo ya está alquilado");
            }

            var totalDiasCalculados = (request.FechaFin.Date - request.FechaInicio.Date).Days > 0 ? (request.FechaFin.Date - request.FechaInicio.Date).Days : 1;

            var alquiler = new Alquiler(
                Guid.NewGuid(),
                vehiculo,
                cliente,
                request.FechaInicio,
                request.FechaFin,
                totalDiasCalculados,
                request.Entregado);

            await _alquilerRepository.AgregarAlquilerAsync(alquiler);
            return alquiler.Id;
        }
    }
}
