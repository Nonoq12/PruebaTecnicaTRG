using System;
using GtMotive.Estimate.Microservice.Domain.Entities;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Clientes.ObtenerSinReservaCliente
{
    /// <summary>
    /// DTO para obtener todos los clientes sin reserva.
    /// </summary>
    /// <param name="cliente">El cliente del cual se obtendrán los datos.</param>
    public class ObtenerSinReservaClienteCommandDto(Cliente cliente) : IRequest
    {
        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        public Guid Id { get; set; } = cliente.Id;

        /// <summary>
        /// Gets or sets the client DNI.
        /// </summary>
        public string DNI { get; set; } = cliente.DNI;

        /// <summary>
        /// Gets or sets the client name.
        /// </summary>
        public string Nombre { get; set; } = cliente.Nombre;

        /// <summary>
        /// Gets or sets the client surnames.
        /// </summary>
        public string Apellidos { get; set; } = cliente.Apellidos;

        /// <summary>
        /// Gets or sets the client birth date.
        /// </summary>
        public DateTime FechaNacimiento { get; set; } = cliente.FechaNacimiento;

        /// <summary>
        /// Gets or sets the client email.
        /// </summary>
        public string Email { get; set; } = cliente.Email;

        /// <summary>
        /// Gets or sets the client phone number.
        /// </summary>
        public string Telefono { get; set; } = cliente.Telefono;
    }
}
