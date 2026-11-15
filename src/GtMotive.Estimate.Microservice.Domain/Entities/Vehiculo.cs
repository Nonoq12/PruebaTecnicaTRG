using System;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{

    /// <summary>
    /// Clase vehiculo.
    /// </summary>
    public class Vehiculo
    {
        // Propiedades e identidad del vehículo

        /// <summary>
        /// Id vehiculo.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Marca vehiculo.
        /// </summary>
        public string Marca { get; private set; }

        /// <summary>
        /// Modelo vehiculo.
        /// </summary>
        public string Modelo { get; private set; }

        /// <summary>
        /// Matricula vehiculo.
        /// </summary>
        public string Matricula { get; private set; }

        /// <summary>
        /// Año de fabricación vehiculo.
        /// </summary>
        public DateTime FechaFabricacion { get; private set; }

        /// <summary>
        /// Gets the vehicle's initial mileage in kilometers.
        /// </summary>
        public int KmIniciales { get; private set; }

        /// <summary>
        /// Kilometros actuales.
        /// </summary>
        public int KmActuales { get; private set; }

        /// <summary>
        /// Precio del alquiler por dia.
        /// </summary>
        public decimal PrecioPorDiaAlquiler { get; private set; }

        /// <summary>
        /// Indicador de si el vehículo está alquilado.
        /// </summary>
        public bool Alquilado { get; private set; }




        /// <summary>
        /// Initializes a new instance of the <see cref="Vehiculo"/> class.
        /// </summary>
        public Vehiculo() { }

        /// <summary>
        /// Constructor para inicializar el vehículo con sus validaciones básicas.
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="marca">Marca</param>
        /// <param name="modelo">Modelo</param>
        /// <param name="matricula">Matrícula</param>
        /// <param name="fechaFabricacion">Fecha de fabricación</param>
        /// <param name="kmIniciales">Kilómetros iniciales</param>
        /// <param name="precioPorDiaAlquiler">Precio por día de alquiler</param>
        /// <exception cref="ArgumentException"></exception>
        public Vehiculo(Guid id, string marca, string modelo, string matricula, DateTime fechaFabricacion, int kmIniciales, decimal precioPorDiaAlquiler)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            Marca = !string.IsNullOrWhiteSpace(marca) ? marca : throw new ArgumentException("La marca es obligatoria.", nameof(marca));
            Modelo = !string.IsNullOrWhiteSpace(modelo) ? modelo : throw new ArgumentException("El modelo es obligatorio.", nameof(modelo));
            Matricula = !string.IsNullOrWhiteSpace(matricula) ? matricula : throw new ArgumentException("La matrícula es obligatoria.", nameof(matricula));
            FechaFabricacion = fechaFabricacion >= DateTime.Now.AddYears(-5) ? fechaFabricacion : throw new ArgumentException("La fecha de fabricación no puede ser superior a 5 años.", nameof(fechaFabricacion));
            KmIniciales = !int.IsNegative(kmIniciales) ? kmIniciales : throw new ArgumentException("Los kilometros iniciales no pueden ser inferior a 0.", nameof(kmIniciales));
            KmActuales = !int.IsNegative(kmIniciales) ? kmIniciales : throw new ArgumentException("Los kilometros iniciales no pueden ser inferior a 0.", nameof(kmIniciales));
            Alquilado = false;
            PrecioPorDiaAlquiler = !decimal.IsNegative(precioPorDiaAlquiler) && precioPorDiaAlquiler > 0 ? precioPorDiaAlquiler : throw new ArgumentException("El precio por día de alquiler no puede ser inferior o igual a 0.", nameof(precioPorDiaAlquiler));
        }

        /// <summary>
        /// Marcar como alquilado
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public void Alquilar()
        {
            if (Alquilado)
            {
                throw new InvalidOperationException("El vehículo ya está alquilado.");
            }

            Alquilado = true;
        }

        /// <summary>
        /// Devolver el vehículo.
        /// </summary>
        /// <param name="km">Kilómetros</param>
        /// <exception cref="InvalidOperationException"></exception>
        public void Devolver(int km)
        {
            if (!Alquilado)
            {
                throw new InvalidOperationException("El vehículo no está alquilado.");
            }

            if (km < KmIniciales)
            {
                throw new ArgumentException("Los kilometros actuales no pueden ser inferior a los kilometros iniciales.", nameof(km));
            }

            ActualizarKmActuales(km);
            Alquilado = false;
        }

        /// <summary>
        /// Actualiza los kilometros Actuales
        /// </summary>
        /// <param name="km"></param>
        /// <exception cref="ArgumentException"></exception>
        private void ActualizarKmActuales(int km)
        {
            if (km < KmActuales)
            {
                throw new ArgumentException("Los kilometros actuales no pueden ser inferior a los kilometros actuales.", nameof(km));
            }
            KmActuales = km;
        }

        /// <summary>
        /// Actualizar precio alquiler.
        /// </summary>
        /// <param name="nuevoPrecio"></param>
        /// <exception cref="ArgumentException"></exception>
        public void ActualizarPrecioPorDiaAlquiler(decimal nuevoPrecio)
        {
            if (nuevoPrecio <= 0)
            {
                throw new ArgumentException("El precio por día de alquiler debe ser mayor que 0.", nameof(nuevoPrecio));
            }

            PrecioPorDiaAlquiler = nuevoPrecio;
        }

    }

}
