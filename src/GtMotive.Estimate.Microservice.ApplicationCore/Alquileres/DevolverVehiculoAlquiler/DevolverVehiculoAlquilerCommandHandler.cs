using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Repositories;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Alquileres.DevolverVehiculoAlquiler
{
    /// <remarks>
    /// Contructor del command handler para la creación de alquiler.
    /// </remarks>
    /// <summary>
    /// Adds Use Cases classes.
    /// </summary>
    /// <param name="alquilerRepository">The rent repository.</param>
    /// <param name="vehiculoRepository">The vehicle repository.</param>
    public class DevolverVehiculoAlquilerCommandHandler(IAlquilerRepository alquilerRepository, IVehiculoRepository vehiculoRepository) : IRequestHandler<DevolverVehiculoAlquilerCommandDto>
    {
        private readonly IAlquilerRepository _alquilerRepository = alquilerRepository;
        private readonly IVehiculoRepository _vehiculoRepository = vehiculoRepository;

        /// <summary>
        /// Handle the command to return rental vehicle.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The response.</returns>
        public async Task Handle(DevolverVehiculoAlquilerCommandDto request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var alquiler = await _alquilerRepository.ObtenerAlquilerPorIdAsync(request.IdAlquiler) ?? throw new InvalidOperationException("Alquiler no encontrado");

            if (alquiler.KmEntrega >= request.KmDevolucion)
            {
                throw new InvalidOperationException("Los kilómetros de devolución no pueden ser menores o iguales a los kilómetros de entrega.");
            }

            var vehiculo = alquiler.Vehiculo ?? throw new InvalidOperationException("Vehículo no encontrado");

            alquiler.DevolverVehiculo(request.KmDevolucion);

            await _vehiculoRepository.ActualizarVehiculoAsync(vehiculo);
            await _alquilerRepository.ActualizarAlquilerAsync(alquiler);
        }
    }
}
