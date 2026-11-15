using System;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{

    /// <summary>
    /// Clase Cliente.
    /// </summary>
    public class Cliente
    {

        // Propiedades e identidad del cliente

        /// <summary>
        /// Id cliente.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// DNI cliente.
        /// </summary>
        public string DNI { get; private set; }

        /// <summary>
        /// Nombre cliente.
        /// </summary>
        public string Nombre { get; private set; }

        /// <summary>
        /// Apellidos cliente.
        /// </summary>
        public string Apellidos { get; private set; }

        /// <summary>
        /// Fecha de nacimiento cliente.
        /// </summary>
        public DateTime FechaNacimiento { get; private set; }

        /// <summary>
        /// Email cliente.
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Teléfono cliente.
        /// </summary>
        public string Telefono { get; private set; }





        /// <summary>
        /// Initializes a new instance of the <see cref="Cliente"/> class.
        /// </summary>
        public Cliente() { }

        /// <summary>
        /// Constructor para inicializar el cliente con sus validaciones básicas.
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="dni">DNI</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellidos">Apellidos</param>
        /// <param name="fechaNacimiento">Fecha de nacimiento</param>
        /// <param name="correo">Correo</param>
        /// <param name="telefono">Teléfono</param>
        /// <exception cref="ArgumentException"></exception>
        public Cliente(Guid id, string dni, string nombre, string apellidos, DateTime fechaNacimiento, string correo, string telefono)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            DNI = !string.IsNullOrWhiteSpace(dni) ? dni : throw new ArgumentException("El DNI es obligatorio.", nameof(dni));
            Nombre = !string.IsNullOrWhiteSpace(nombre) ? nombre : throw new ArgumentException("El nombre es obligatorio.", nameof(nombre));
            Apellidos = !string.IsNullOrWhiteSpace(apellidos) ? apellidos : throw new ArgumentException("Los apellidos son obligatorios.", nameof(apellidos));
            FechaNacimiento = fechaNacimiento != DateTime.MinValue ? fechaNacimiento : throw new ArgumentException("La fecha de nacimiento es obligatoria.", nameof(fechaNacimiento));
            Email = !string.IsNullOrWhiteSpace(correo) ? correo : throw new ArgumentException("El correo es obligatorio.", nameof(correo));
            Telefono = !string.IsNullOrWhiteSpace(telefono) ? telefono : throw new ArgumentException("El teléfono es obligatorio.", nameof(telefono));
        }

    }
}
