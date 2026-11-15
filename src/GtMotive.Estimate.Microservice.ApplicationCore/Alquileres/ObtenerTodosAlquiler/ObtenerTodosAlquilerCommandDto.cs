using System;
using GtMotive.Estimate.Microservice.Domain.Entities;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Alquileres.ObtenerTodosAlquiler
{
    /// <summary>
    /// DTO para obtener todos los alquileres.
    /// </summary>
    /// <param name="alquiler">The alquiler.</param>
    public class ObtenerTodosAlquilerCommandDto(Alquiler alquiler) : IRequest
    {
        /// <summary>
        /// Gets or sets id alquiler.
        /// </summary>
        public Guid Id { get; set; } = alquiler.Id;

        /// <summary>
        /// Gets or sets id del vehiculo.
        /// </summary>
        public Guid IdVehiculo { get; set; } = alquiler.IdVehiculo;

        /// <summary>
        /// Gets or sets id del cliente.
        /// </summary>
        public Guid IdCliente { get; set; } = alquiler.IdCliente;

        /// <summary>
        /// Gets or sets fecha de inicio.
        /// </summary>
        public DateTime FechaInicio { get; set; } = alquiler.FechaInicio;

        /// <summary>
        /// Gets or sets fecha de finalización.
        /// </summary>
        public DateTime FechaFin { get; set; } = alquiler.FechaFin;

        /// <summary>
        /// Gets or sets kilometros en la entrega.
        /// </summary>
        public int KmEntrega { get; set; } = alquiler.KmEntrega;

        /// <summary>
        /// Gets or sets kilometros en la devolución.
        /// </summary>
        public int KmDevolucion { get; set; } = alquiler.KmDevolucion;

        /// <summary>
        /// Gets or sets número de dias del alquiler.
        /// </summary>
        public int DuracionDias { get; set; } = alquiler.DuracionDias;

        /// <summary>
        /// Gets or sets precio total del alquiler.
        /// </summary>
        public decimal PrecioTotal { get; set; } = alquiler.PrecioTotal;

        /// <summary>
        /// Gets or sets a value indicating whether está entregado.
        /// </summary>
        public bool Entregado { get; set; } = alquiler.Entregado;

        /// <summary>
        /// Gets or sets a value indicating whether está devuelto.
        /// </summary>
        public bool Devuelto { get; set; } = alquiler.Devuelto;
    }
}
