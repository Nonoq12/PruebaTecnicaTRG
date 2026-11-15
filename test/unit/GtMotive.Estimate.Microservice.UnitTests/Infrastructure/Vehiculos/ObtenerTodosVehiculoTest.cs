using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.Repositories;
using MongoDB.Driver;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.Infrastructure.Vehiculos
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
            var cursorMock = new Mock<IAsyncCursor<Vehiculo>>();
            cursorMock.Setup(_ => _.Current).Returns(
            [
                new Vehiculo(Guid.NewGuid(), "Seat", "Ibiza", "1234ABC", DateTime.Now, 0, 10)
            ]);
            cursorMock
                .SetupSequence(_ => _.MoveNextAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(true)
                .ReturnsAsync(false);

            var collectionMock = new Mock<IMongoCollection<Vehiculo>>();
            collectionMock
                .Setup(c => c.FindAsync(
                    It.IsAny<FilterDefinition<Vehiculo>>(),
                    It.IsAny<FindOptions<Vehiculo, Vehiculo>>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(cursorMock.Object);

            var databaseMock = new Mock<IMongoDatabase>();
            databaseMock
                .Setup(db => db.GetCollection<Vehiculo>(It.IsAny<string>(), It.IsAny<MongoCollectionSettings>()))
                .Returns(collectionMock.Object);

            var repositorio = new VehiculoRepository(databaseMock.Object);

            // Act
            var resultado = await repositorio.ObtenerTodosVehiculosAsync();

            // Assert
            Assert.NotNull(resultado);
            Assert.Contains(resultado, v => v.Marca == "Seat");
        }
    }
}
