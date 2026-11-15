using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Clientes.CrearCliente
{
    /// <summary>
    /// DTO para la creación de clientes.
    /// </summary>
    public class CrearClienteCommandDto : IRequest<Guid>
    {
        /// <summary>
        /// Gets or sets the DNI.
        /// </summary>
        public string DNI { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets the surnames.
        /// </summary>
        public string Apellidos { get; set; }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        public DateTime FechaNacimiento { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        public string Telefono { get; set; }
    }
}
