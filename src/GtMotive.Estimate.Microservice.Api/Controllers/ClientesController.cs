using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Clientes.CrearCliente;
using GtMotive.Estimate.Microservice.ApplicationCore.Clientes.ObtenerSinReservaCliente;
using GtMotive.Estimate.Microservice.ApplicationCore.Clientes.ObtenerTodosCliente;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClientesController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        /// <summary>
        /// Crea un nuevo cliente en el sistema.
        /// </summary>
        /// <param name="command">El comando para crear el cliente.</param>
        /// <param name="cancellationToken">Token de cancelación para interrumpir la operación asíncrona si es necesario.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPost("New")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Crear([FromBody] CrearClienteCommandDto command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return BadRequest();
            }

            var clienteId = await _mediator.Send(command, cancellationToken);
            return Created(new Uri($"/api/v1/Clientes/{clienteId}", UriKind.Relative), clienteId);
        }

        /// <summary>
        /// Obtiene el listado de todos los clientes.
        /// </summary>
        /// <param name="cancellationToken">Token de cancelación para interrumpir la operación asíncrona si es necesario.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpGet("All")]
        [ProducesResponseType(typeof(IEnumerable<ObtenerTodosClienteCommandDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerTodos(CancellationToken cancellationToken)
        {
            var query = new ObtenerTodosClienteCommand();
            var resultado = await _mediator.Send(query, cancellationToken);

            return Ok(resultado);
        }

        /// <summary>
        /// Obtiene el listado de los clientes sin reserva.
        /// </summary>
        /// <param name="cancellationToken">Token de cancelación para interrumpir la operación asíncrona si es necesario.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpGet("SinReserva")]
        [ProducesResponseType(typeof(IEnumerable<ObtenerSinReservaClienteCommandDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerSinReserva(CancellationToken cancellationToken)
        {
            var query = new ObtenerSinReservaClienteCommand();
            var resultado = await _mediator.Send(query, cancellationToken);

            return Ok(resultado);
        }
    }
}
