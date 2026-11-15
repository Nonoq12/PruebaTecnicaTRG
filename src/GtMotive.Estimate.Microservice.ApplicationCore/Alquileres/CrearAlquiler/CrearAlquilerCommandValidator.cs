using System;
using FluentValidation;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Alquileres.CrearAlquiler
{
    /// <summary>
    /// Clase validadora para el comando de creación del alquiler.
    /// </summary>
    public class CrearAlquilerCommandValidator : AbstractValidator<CrearAlquilerCommandDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CrearAlquilerCommandValidator"/> class.
        /// Validador.
        /// </summary>
        public CrearAlquilerCommandValidator()
        {
            RuleFor(x => x.IdVehiculo)
                .NotEmpty().WithMessage("El ID del vehículo es obligatorio.");

            RuleFor(x => x.IdCliente)
                .NotEmpty().WithMessage("El ID del cliente es obligatorio.");

            RuleFor(x => x.FechaInicio)
                .NotEmpty().WithMessage("La fecha de inicio es obligatoria.")
                .GreaterThanOrEqualTo(DateTime.Today).WithMessage("La fecha de inicio no puede ser anterior al día de hoy.");

            RuleFor(x => x.FechaFin)
                .NotEmpty().WithMessage("La fecha de finalización es obligatoria.")
                .GreaterThan(x => x.FechaInicio).WithMessage("La fecha de finalización debe ser posterior a la fecha de inicio.");
        }
    }
}
