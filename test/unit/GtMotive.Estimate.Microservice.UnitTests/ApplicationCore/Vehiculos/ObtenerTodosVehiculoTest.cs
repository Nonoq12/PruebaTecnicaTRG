using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Vehiculos.ObtenerTodosVehiculo;
using GtMotive.Estimate.Microservice.Domain.Repositories;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.ApplicationCore.Vehiculos
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
            var repositorioMock = new Mock<IVehiculoRepository>();
            repositorioMock.Setup(r => r.ObtenerTodosVehiculosAsync())
                           .ReturnsAsync([]);

            var handler = new ObtenerTodosVehiculoCommandHandler(repositorioMock.Object);
            var query = new ObtenerTodosVehiculoCommand();

            // Act
            var resultado = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(resultado);
            repositorioMock.Verify(r => r.ObtenerTodosVehiculosAsync(), Times.Once);
        }
    }
}
