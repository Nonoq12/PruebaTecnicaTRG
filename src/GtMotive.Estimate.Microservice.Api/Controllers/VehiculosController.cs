using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Vehiculos.CrearVehiculo;
using GtMotive.Estimate.Microservice.ApplicationCore.Vehiculos.ObtenerDisponiblesVehiculo;
using GtMotive.Estimate.Microservice.ApplicationCore.Vehiculos.ObtenerTodosVehiculo;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VehiculosController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        /// <summary>
        /// Crea un nuevo vehículo en el sistema.
        /// </summary>
        /// <param name="command">El comando para crear el vehículo.</param>
        /// <param name="cancellationToken">Token de cancelación para interrumpir la operación asíncrona si es necesario.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPost("New")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Crear([FromBody] CrearVehiculoCommandDto command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return BadRequest();
            }

            var vehicleId = await _mediator.Send(command, cancellationToken);
            return Created(new Uri($"/api/v1/Vehiculos/{vehicleId}", UriKind.Relative), vehicleId);
        }

        /// <summary>
        /// Obtiene el listado de todos los vehículos registrados.
        /// </summary>
        /// <param name="cancellationToken">Token de cancelación para interrumpir la operación asíncrona si es necesario.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpGet("All")]
        [ProducesResponseType(typeof(IEnumerable<ObtenerTodosVehiculoCommandDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerTodos(CancellationToken cancellationToken)
        {
            var query = new ObtenerTodosVehiculoCommand();
            var resultado = await _mediator.Send(query, cancellationToken);

            return Ok(resultado);
        }

        /// <summary>
        /// Obtiene el listado de los vehículos disponibles.
        /// </summary>
        /// <param name="cancellationToken">Token de cancelación para interrumpir la operación asíncrona si es necesario.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpGet("Disponibles")]
        [ProducesResponseType(typeof(IEnumerable<ObtenerDisponiblesVehiculoCommandDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerDisponibles(CancellationToken cancellationToken)
        {
            var query = new ObtenerDisponiblesVehiculoCommand();
            var resultado = await _mediator.Send(query, cancellationToken);

            return Ok(resultado);
        }
    }
}
