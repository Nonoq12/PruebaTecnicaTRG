using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Alquileres.DevolverVehiculoAlquiler
{
    /// <summary>
    /// DTO para la entrega del vehículo del alquiler.
    /// </summary>
    public class DevolverVehiculoAlquilerCommandDto : IRequest
    {
        /// <summary>
        /// Gets or sets id del alquiler.
        /// </summary>
        public Guid IdAlquiler { get; set; }

        /// <summary>
        /// Gets or sets kilometros en la devolución.
        /// </summary>
        public int KmDevolucion { get; set; }
    }
}
