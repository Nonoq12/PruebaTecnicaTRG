using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Controllers;
using GtMotive.Estimate.Microservice.ApplicationCore.Vehiculos.ObtenerTodosVehiculo;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.Api.Vehiculos
{
    /// <summary>
    /// Clase para los tests de ObtenerTodosVehiculo.
    /// </summary>
    public class ObtenerTodosVehiculoTest
    {
        /// <summary>
        /// Test que retorna la lista de vehiculos.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Fact]
        public async Task DeberiaRetornarListaDeVehiculos()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();

            // 1. Creamos un objeto Vehiculo ficticio para dárselo al constructor del DTO que ya tienes
            var vehiculoPrueba = new Domain.Entities.Vehiculo(Guid.NewGuid(), "Toyota", "Corolla", "1234ABC", DateTime.Now, 0, 10);

            // (Ajusta los parámetros del constructor de Vehiculo según cómo lo tengas definido en tu dominio)
            mediatorMock.Setup(m => m.Send(It.IsAny<ObtenerTodosVehiculoCommand>(), It.IsAny<CancellationToken>()))
                        .ReturnsAsync(
                        [
                            new ObtenerTodosVehiculoCommandDto(vehiculoPrueba)
                        ]);

            var controller = new VehiculosController(mediatorMock.Object);

            // Act
            var resultado = await controller.ObtenerTodos(CancellationToken.None);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(resultado);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            mediatorMock.Verify(m => m.Send(It.IsAny<ObtenerTodosVehiculoCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
