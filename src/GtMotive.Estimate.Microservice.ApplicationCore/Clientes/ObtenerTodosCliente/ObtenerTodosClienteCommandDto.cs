using System;
using GtMotive.Estimate.Microservice.Domain.Entities;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Clientes.ObtenerTodosCliente
{
    /// <summary>
    /// DTO para obtener todos los clientes.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ObtenerTodosClienteCommandDto"/> class.
    /// </remarks>
    /// <param name="cliente">The cliente.</param>
    public class ObtenerTodosClienteCommandDto(Cliente cliente) : IRequest
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public Guid Id { get; set; } = cliente.Id;

        /// <summary>
        /// Gets or sets the DNI.
        /// </summary>
        public string DNI { get; set; } = cliente.DNI;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Nombre { get; set; } = cliente.Nombre;

        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        public string Apellidos { get; set; } = cliente.Apellidos;

        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        public DateTime FechaNacimiento { get; set; } = cliente.FechaNacimiento;

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; } = cliente.Email;

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        public string Telefono { get; set; } = cliente.Telefono;
    }
}
