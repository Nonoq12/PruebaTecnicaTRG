using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Controllers;
using GtMotive.Estimate.Microservice.ApplicationCore.Vehiculos.CrearVehiculo;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.ControllerTest
{
    /// <summary>
    /// Tests controlador Vehiculo.
    /// </summary>
    public class VehiculoControllerTest
    {
        /// <summary>
        /// Test CrearVehiculoConDatosValidosRetornaCreated.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Fact]
        public async Task CrearVehiculoConDatosValidosRetornaCreated()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<CrearVehiculoCommandDto>(), default))
                        .ReturnsAsync(Guid.NewGuid());

            var controller = new VehiculosController(mediatorMock.Object);
            var comando = new CrearVehiculoCommandDto
            {
                Marca = "Toyota",
                Modelo = "Corolla",
                Matricula = "1234ABC",
                FechaFabricacion = DateTime.Now,
                KmIniciales = 0,
                PrecioPorDiaAlquiler = 10
            };

            // Act
            var resultado = await controller.Crear(comando, default);

            // Assert
            var createdResult = Assert.IsType<CreatedResult>(resultado);
            Assert.Equal(StatusCodes.Status201Created, createdResult.StatusCode);
        }
    }
}
