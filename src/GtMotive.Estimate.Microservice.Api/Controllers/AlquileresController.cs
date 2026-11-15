using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Alquileres.CrearAlquiler;
using GtMotive.Estimate.Microservice.ApplicationCore.Alquileres.DevolverVehiculoAlquiler;
using GtMotive.Estimate.Microservice.ApplicationCore.Alquileres.EntregarVehiculoAlquiler;
using GtMotive.Estimate.Microservice.ApplicationCore.Alquileres.ObtenerTodosAlquiler;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AlquileresController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        /// <summary>
        /// Crea un nuevo alquiler en el sistema.
        /// </summary>
        /// <param name="command">El comando para crear el alquiler.</param>
        /// <param name="cancellationToken">Token de cancelación para interrumpir la operación asíncrona si es necesario.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPost("New")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Crear([FromBody] CrearAlquilerCommandDto command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return BadRequest();
            }

            var alquilerId = await _mediator.Send(command, cancellationToken);
            return Created(new Uri($"/api/v1/Alquileres/{alquilerId}", UriKind.Relative), alquilerId);
        }

        /// <summary>
        /// Obtiene el listado de todos los alquileres.
        /// </summary>
        /// <param name="cancellationToken">Token de cancelación para interrumpir la operación asíncrona si es necesario.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpGet("All")]
        [ProducesResponseType(typeof(IEnumerable<ObtenerTodosAlquilerCommandDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerTodos(CancellationToken cancellationToken)
        {
            var query = new ObtenerTodosAlquilerCommand();
            var resultado = await _mediator.Send(query, cancellationToken);

            return Ok(resultado);
        }

        /// <summary>
        /// Obtiene el listado de todos los alquilers.
        /// </summary>
        /// <param name="command">El comando para entregar del vehículo del alquiler.</param>
        /// <param name="cancellationToken">Token de cancelación para interrumpir la operación asíncrona si es necesario.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPost("Entregar")]
        [ProducesResponseType(typeof(IEnumerable<EntregarVehiculoAlquilerCommandDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EntregarVehiculo([FromBody] EntregarVehiculoAlquilerCommandDto command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return BadRequest();
            }

            await _mediator.Send(command, cancellationToken);

            return Ok();
        }

        /// <summary>
        /// Obtiene el listado de los alquilers sin reserva.
        /// </summary>
        /// <param name="command">El comando para devolver del vehículo del alquiler.</param>
        /// <param name="cancellationToken">Token de cancelación para interrumpir la operación asíncrona si es necesario.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPost("Devolver")]
        [ProducesResponseType(typeof(IEnumerable<DevolverVehiculoAlquilerCommandDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerSinReserva([FromBody] DevolverVehiculoAlquilerCommandDto command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return BadRequest();
            }

            await _mediator.Send(command, cancellationToken);

            return Ok();
        }
    }
}
