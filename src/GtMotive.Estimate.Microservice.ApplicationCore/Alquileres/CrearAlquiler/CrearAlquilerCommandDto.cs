using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Alquileres.CrearAlquiler
{
    /// <summary>
    /// DTO para la creación del alquiler.
    /// </summary>
    public class CrearAlquilerCommandDto : IRequest<Guid>
    {
        /// <summary>
        /// Gets or sets id del vehiculo.
        /// </summary>
        public Guid IdVehiculo { get; set; }

        /// <summary>
        /// Gets or sets id del cliente.
        /// </summary>
        public Guid IdCliente { get; set; }

        /// <summary>
        /// Gets or sets fecha de inicio.
        /// </summary>
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Gets or sets fecha de finalización.
        /// </summary>
        public DateTime FechaFin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether está entregado.
        /// </summary>
        public bool Entregado { get; set; }
    }
}
