using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Common.Behaviors
{
    /// <summary>
    /// validation behavior for MediatR pipeline. This behavior is responsible for validating the request before passing it to the next handler in the pipeline.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <remarks>
    /// This behavior is responsible for validating the request before passing it to the next handler in the pipeline.
    /// </remarks>
    /// <param name="validators">The validators.</param>
    /// <exception cref="ArgumentNullException">The argument is null.</exception>
    public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators = validators ?? throw new ArgumentNullException(nameof(validators));

        /// <summary>
        /// función que maneja la validación de la solicitud antes de pasarla al siguiente comportamiento en la tubería.
        /// </summary>
        /// <param name="request"> The request.</param>
        /// <param name="next"> The next handler delegate.</param>
        /// <param name="cancellationToken"> The cancellation token.</param>
        /// <returns> The response.</returns>
        /// <exception cref="ValidationException"> The validation exception.</exception>
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // Validaciones requeridas por el analizador estático (CA1062)
            ArgumentNullException.ThrowIfNull(request);
            ArgumentNullException.ThrowIfNull(next);

            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                {
                    throw new ValidationException(failures);
                }
            }

            return await next();
        }
    }
}
