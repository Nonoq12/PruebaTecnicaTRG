using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Vehiculos.CrearVehiculo
{
    /// <summary>
    /// DTO para la creación de vehículos.
    /// </summary>
    public class CrearVehiculoCommandDto : IRequest<Guid>
    {
        /// <summary>
        /// Gets or sets the vehicle brand.
        /// </summary>
        public string Marca { get; set; }

        /// <summary>
        /// Gets or sets the vehicle model.
        /// </summary>
        public string Modelo { get; set; }

        /// <summary>
        /// Gets or sets the vehicle license plate.
        /// </summary>
        public string Matricula { get; set; }

        /// <summary>
        /// Gets or sets the manufacturing date of the vehicle.
        /// </summary>
        public DateTime FechaFabricacion { get; set; }

        /// <summary>
        /// Gets or sets the initial mileage in kilometers.
        /// </summary>
        public int KmIniciales { get; set; }

        /// <summary>
        /// Gets or sets the daily rental price.
        /// </summary>
        public decimal PrecioPorDiaAlquiler { get; set; }
    }
}
