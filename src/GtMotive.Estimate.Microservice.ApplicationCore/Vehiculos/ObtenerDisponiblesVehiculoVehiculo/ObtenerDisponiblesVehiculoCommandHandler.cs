using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Repositories;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Vehiculos.ObtenerDisponiblesVehiculo
{
    /// <summary>
    /// Command handler para listar todos los vehiculos.
    /// </summary>
    /// <param name="vehiculoRepository">The vehicle repository.</param>
    public class ObtenerDisponiblesVehiculoCommandHandler(IVehiculoRepository vehiculoRepository) : IRequestHandler<ObtenerDisponiblesVehiculoCommand, IEnumerable<ObtenerDisponiblesVehiculoCommandDto>>
    {
        private readonly IVehiculoRepository _vehiculoRepository = vehiculoRepository;

        /// <summary>
        /// Handle the command to list available vehicles.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<IEnumerable<ObtenerDisponiblesVehiculoCommandDto>> Handle(ObtenerDisponiblesVehiculoCommand request, CancellationToken cancellationToken)
        {
            var vehiculos = await _vehiculoRepository.ObtenerVehiculosDisponiblesAsync();

            return vehiculos.Select(v => new ObtenerDisponiblesVehiculoCommandDto(
                v));
        }
    }
}
