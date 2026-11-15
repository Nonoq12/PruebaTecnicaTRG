using System;
using FluentValidation;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Vehiculos.CrearVehiculo
{
    /// <summary>
    /// Clase validadora para el comando de creación de vehículos.
    /// </summary>
    public class CrearVehiculoCommandValidator : AbstractValidator<CrearVehiculoCommandDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CrearVehiculoCommandValidator"/> class.
        /// Validador.
        /// </summary>
        public CrearVehiculoCommandValidator()
        {
            RuleFor(v => v.Marca)
                .NotEmpty().WithMessage("La marca es obligatoria.")
                .MaximumLength(50).WithMessage("La marca no puede superar los 50 caracteres.");

            RuleFor(v => v.Modelo)
                .NotEmpty().WithMessage("El modelo es obligatorio.")
                .MaximumLength(50).WithMessage("El modelo no puede superar los 50 caracteres.");

            RuleFor(v => v.Matricula)
                .NotEmpty().WithMessage("La matrícula es obligatoria.")
                .Matches(@"^\d{4}[A-Z]{3}$").WithMessage("El formato de la matrícula no es válido.");

            RuleFor(v => v.FechaFabricacion)
                .NotEmpty().WithMessage("La fecha de fabricación es obligatoria.")
                .GreaterThanOrEqualTo(DateTime.Today.AddYears(-5))
                .WithMessage("La fecha de fabricación no puede ser superior a 5 años de antigüedad.");

            RuleFor(v => v.KmIniciales)
                .GreaterThanOrEqualTo(0).WithMessage("Los kilómetros iniciales no pueden ser negativos.");

            RuleFor(v => v.PrecioPorDiaAlquiler)
                .GreaterThan(0).WithMessage("El precio por día de alquiler debe ser mayor a cero.");
        }
    }
}
