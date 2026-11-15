using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Repositories;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Alquileres.EntregarVehiculoAlquiler
{
    /// <remarks>
    /// Contructor del command handler para la entrega del vehículo del alquiler.
    /// </remarks>
    /// <summary>
    /// Adds Use Cases classes.
    /// </summary>
    /// <param name="alquilerRepository">The rent repository.</param>
    public class EntregarVehiculoAlquilerCommandHandler(IAlquilerRepository alquilerRepository) : IRequestHandler<EntregarVehiculoAlquilerCommandDto>
    {
        private readonly IAlquilerRepository _alquilerRepository = alquilerRepository;

        /// <summary>
        /// Handle the command to provide rental vehicle.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The response.</returns>
        public async Task Handle(EntregarVehiculoAlquilerCommandDto request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var alquiler = await _alquilerRepository.ObtenerAlquilerPorIdAsync(request.IdAlquiler) ?? throw new InvalidOperationException("Alquiler no encontrado");
            alquiler.EntregarVehiculo();

            await _alquilerRepository.ActualizarAlquilerAsync(alquiler);
        }
    }
}
