using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Repositories;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Vehiculos.ObtenerTodosVehiculo
{
    /// <summary>
    /// Command handler para listar todos los vehiculos.
    /// </summary>
    /// <param name="vehiculoRepository">The vehicle repository.</param>
    public class ObtenerTodosVehiculoCommandHandler(IVehiculoRepository vehiculoRepository) : IRequestHandler<ObtenerTodosVehiculoCommand, IEnumerable<ObtenerTodosVehiculoCommandDto>>
    {
        private readonly IVehiculoRepository _vehiculoRepository = vehiculoRepository;

        /// <summary>
        /// Handle the command to list all vehicles.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<IEnumerable<ObtenerTodosVehiculoCommandDto>> Handle(ObtenerTodosVehiculoCommand request, CancellationToken cancellationToken)
        {
            var vehiculos = await _vehiculoRepository.ObtenerTodosVehiculosAsync();

            return vehiculos.Select(v => new ObtenerTodosVehiculoCommandDto(
                v));
        }
    }
}
