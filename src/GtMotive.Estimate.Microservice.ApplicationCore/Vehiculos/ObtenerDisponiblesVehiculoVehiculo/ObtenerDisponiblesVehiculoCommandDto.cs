using System;
using GtMotive.Estimate.Microservice.Domain.Entities;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Vehiculos.ObtenerDisponiblesVehiculo
{
    /// <summary>
    /// DTO para obtener los vehículos disponibles.
    /// </summary>
    /// <param name="vehiculo">The vehicle.</param>
    public class ObtenerDisponiblesVehiculoCommandDto(Vehiculo vehiculo) : IRequest
    {
        /// <summary>
        /// Gets or sets id vehiculo.
        /// </summary>
        public Guid Id { get; set; } = vehiculo.Id;

        /// <summary>
        /// Gets or sets marca vehiculo.
        /// </summary>
        public string Marca { get; set; } = vehiculo.Marca;

        /// <summary>
        /// Gets or sets modelo vehiculo.
        /// </summary>
        public string Modelo { get; set; } = vehiculo.Modelo;

        /// <summary>
        /// Gets or sets matricula vehiculo.
        /// </summary>
        public string Matricula { get; set; } = vehiculo.Matricula;

        /// <summary>
        /// Gets or sets año de fabricación vehiculo.
        /// </summary>
        public DateTime FechaFabricacion { get; set; } = vehiculo.FechaFabricacion;

        /// <summary>
        /// Gets or sets the vehicle's initial mileage in kilometers.
        /// </summary>
        public int KmIniciales { get; set; } = vehiculo.KmIniciales;

        /// <summary>
        /// Gets or sets kilometros actuales.
        /// </summary>
        public int KmActuales { get; set; } = vehiculo.KmActuales;

        /// <summary>
        /// Gets or sets Precio del alquiler por dia.
        /// </summary>
        public decimal PrecioPorDiaAlquiler { get; set; } = vehiculo.PrecioPorDiaAlquiler;
    }
}
