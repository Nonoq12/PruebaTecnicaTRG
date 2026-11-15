using FluentValidation;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Alquileres.DevolverVehiculoAlquiler
{
    /// <summary>
    /// Clase validadora para el comando de devolución del vehículo del alquiler.
    /// </summary>
    public class DevolverVehiculoAlquilerCommandValidator : AbstractValidator<DevolverVehiculoAlquilerCommandDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DevolverVehiculoAlquilerCommandValidator"/> class.
        /// Validador.
        /// </summary>
        public DevolverVehiculoAlquilerCommandValidator()
        {
            RuleFor(x => x.IdAlquiler)
                .NotEmpty().WithMessage("El ID del vehículo es obligatorio.");

            RuleFor(x => x.KmDevolucion)
                .GreaterThan(0).WithMessage("Los kilómetros de devolución deben ser mayores que cero.");
        }
    }
}
