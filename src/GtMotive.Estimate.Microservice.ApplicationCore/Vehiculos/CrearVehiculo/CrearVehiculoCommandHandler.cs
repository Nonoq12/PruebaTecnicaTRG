using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Repositories;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Vehiculos.CrearVehiculo
{
    /// <remarks>
    /// Contructor del command handler para la creación de vehículos.
    /// </remarks>
    /// <summary>
    /// Initializes a new instance of the <see cref="CrearVehiculoCommandHandler"/> class.
    /// </summary>
    /// <param name="vehicleRepository">The vehicle repository.</param>
    public class CrearVehiculoCommandHandler(IVehiculoRepository vehicleRepository) : IRequestHandler<CrearVehiculoCommandDto, Guid>
    {
        private readonly IVehiculoRepository _vehiculoRepository = vehicleRepository;

        /// <summary>
        /// Handle the command to create a new vehicle.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<Guid> Handle(CrearVehiculoCommandDto request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var vehicle = new Vehiculo(
                Guid.NewGuid(),
                request.Marca,
                request.Modelo,
                request.Matricula,
                request.FechaFabricacion,
                request.KmIniciales,
                request.PrecioPorDiaAlquiler);

            await _vehiculoRepository.AgregarVehiculoAsync(vehicle);

            return vehicle.Id;
        }
    }
}
