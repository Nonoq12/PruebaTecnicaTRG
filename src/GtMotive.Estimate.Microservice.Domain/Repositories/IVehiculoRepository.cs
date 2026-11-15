using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Repositories
{
    /// <summary>
    /// Interfaz repositorio Vehiculo.
    /// </summary>
    public interface IVehiculoRepository
    {
        /// <summary>
        /// Agregar nuevo vehiculo.
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        Task AgregarVehiculoAsync(Vehiculo vehicle);

        /// <summary>
        /// Obtiene un vehículo por su ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Vehiculo> ObtenerVehiculoPorIdAsync(Guid id);

        /// <summary>
        /// Obtiene la lista de todos los vehículos.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Vehiculo>> ObtenerTodosVehiculosAsync();

        /// <summary>
        /// Obtiene la lista de vehículos disponibles.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Vehiculo>> ObtenerVehiculosDisponiblesAsync();

        /// <summary>
        /// Actualizar un vehiculo.
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        Task ActualizarVehiculoAsync(Vehiculo vehicle);

    }
}
