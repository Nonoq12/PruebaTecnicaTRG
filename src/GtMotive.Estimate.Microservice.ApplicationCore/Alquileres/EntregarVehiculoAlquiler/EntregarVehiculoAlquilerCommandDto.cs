using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Alquileres.EntregarVehiculoAlquiler
{
    /// <summary>
    /// DTO para la entrega del vehículo del alquiler.
    /// </summary>
    public class EntregarVehiculoAlquilerCommandDto : IRequest
    {
        /// <summary>
        /// Gets or sets id del alquiler.
        /// </summary>
        public Guid IdAlquiler { get; set; }
    }
}
