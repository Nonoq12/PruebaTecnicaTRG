using System;
using FluentValidation;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Clientes.CrearCliente
{
    /// <summary>
    /// Clase validadora para el comando de creación de vehículos.
    /// </summary>
    public class CrearClienteCommandValidator : AbstractValidator<CrearClienteCommandDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CrearClienteCommandValidator"/> class.
        /// Validador.
        /// </summary>
        public CrearClienteCommandValidator()
        {
            // 1. Nombre
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede tener más de 50 caracteres.");

            // 2. Apellidos
            RuleFor(x => x.Apellidos)
                .NotEmpty().WithMessage("Los apellidos son obligatorios.")
                .MaximumLength(100).WithMessage("Los apellidos no pueden tener más de 100 caracteres.");

            // 3. DNI (Formato y letra correctos por módulo 23)
            RuleFor(x => x.DNI)
                .NotEmpty().WithMessage("El DNI es obligatorio.")
                .Must(EsDniValido).WithMessage("El formato o la letra del DNI no es válido.");

            // 4. Fecha de Nacimiento (Mayor de 18 años)
            RuleFor(x => x.FechaNacimiento)
                .NotEmpty().WithMessage("La fecha de nacimiento es obligatoria.")
                .Must(EsMayorDeEdad).WithMessage("El cliente debe ser mayor de 18 años.");

            // 5. Correo Electrónico (Email)
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El correo electrónico es obligatorio.")
                .EmailAddress().WithMessage("El formato del correo electrónico no es válido.");

            // 6. Teléfono (Opcional, pero si se indica, validamos un formato básico de dígitos)
            RuleFor(x => x.Telefono)
                .MaximumLength(15).WithMessage("El teléfono no puede superar los 15 caracteres.")
                .Matches(@"^\+?[0-9\s\-]+$").When(x => !string.IsNullOrEmpty(x.Telefono))
                .WithMessage("El formato del teléfono no es válido.");
        }

        private static bool EsMayorDeEdad(DateTime fechaNacimiento)
        {
            if (fechaNacimiento == default)
            {
                return false;
            }

            var hoy = DateTime.Today;
            var edad = hoy.Year - fechaNacimiento.Year;

            if (fechaNacimiento.Date > hoy.AddYears(-edad))
            {
                edad--;
            }

            return edad >= 18;
        }

        private static bool EsDniValido(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
            {
                return false;
            }

            dni = dni.Trim().ToUpperInvariant();

            // Comprobación directa de longitud (9 caracteres)
            if (dni.Length != 9)
            {
                return false;
            }

            // Verificar que los primeros 8 caracteres son dígitos
            for (var i = 0; i < 8; i++)
            {
                if (!char.IsDigit(dni[i]))
                {
                    return false;
                }
            }

            // Verificar que el último carácter es una letra mayúscula
            if (!char.IsLetter(dni[8]))
            {
                return false;
            }

            var juegoCaracteres = "TRWAGMYFPDXBNJZSQVHLCKE";
            if (!int.TryParse(dni.AsSpan(0, 8), out var dniNumeros))
            {
                return false;
            }

            var letraCalculada = juegoCaracteres[dniNumeros % 23];
            var letraProporcionada = dni[8];

            return letraCalculada == letraProporcionada;
        }
    }
}
