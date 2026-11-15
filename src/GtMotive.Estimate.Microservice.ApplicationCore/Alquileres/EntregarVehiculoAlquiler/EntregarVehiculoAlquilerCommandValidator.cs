using FluentValidation;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Alquileres.EntregarVehiculoAlquiler
{
    /// <summary>
    /// Clase validadora para el comando de entrega del vehículo del alquiler.
    /// </summary>
    public class EntregarVehiculoAlquilerCommandValidator : AbstractValidator<EntregarVehiculoAlquilerCommandDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntregarVehiculoAlquilerCommandValidator"/> class.
        /// Validador.
        /// </summary>
        public EntregarVehiculoAlquilerCommandValidator()
        {
            RuleFor(x => x.IdAlquiler)
                .NotEmpty().WithMessage("El ID del vehículo es obligatorio.");
        }
    }
}
