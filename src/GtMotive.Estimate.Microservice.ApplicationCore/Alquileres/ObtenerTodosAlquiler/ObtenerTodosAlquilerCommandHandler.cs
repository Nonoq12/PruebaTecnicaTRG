using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Repositories;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Alquileres.ObtenerTodosAlquiler
{
    /// <summary>
    /// Command handler para listar todos los alquileres.
    /// </summary>
    /// <param name="alquilerRepository">The alquiler repository.</param>
    public class ObtenerTodosAlquilerCommandHandler(IAlquilerRepository alquilerRepository) : IRequestHandler<ObtenerTodosAlquilerCommand, IEnumerable<ObtenerTodosAlquilerCommandDto>>
    {
        private readonly IAlquilerRepository _alquilerRepository = alquilerRepository;

        /// <summary>
        /// Handle the command to list all rents.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<IEnumerable<ObtenerTodosAlquilerCommandDto>> Handle(ObtenerTodosAlquilerCommand request, CancellationToken cancellationToken)
        {
            System.ArgumentNullException.ThrowIfNull(request);
            var alquilers = await _alquilerRepository.ObtenerTodosAlquilersAsync();

            return alquilers.Select(v => new ObtenerTodosAlquilerCommandDto(
                v));
        }
    }
}
