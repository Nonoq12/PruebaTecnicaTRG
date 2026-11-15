using System;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{

    /// <summary>
    /// Clase Alquiler
    /// </summary>
    public class Alquiler
    {

        // Propiedades e identidad del Alquiler

        /// <summary>
        /// Id alquiler.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Id del vehiculo.
        /// </summary>
        public Guid IdVehiculo { get; private set; }

        /// <summary>
        /// Id del cliente.
        /// </summary>
        public Guid IdCliente { get; private set; }

        /// <summary>
        /// Fecha de inicio.
        /// </summary>
        public DateTime FechaInicio { get; private set; }

        /// <summary>
        /// Fecha de finalización.
        /// </summary>
        public DateTime FechaFin { get; private set; }

        /// <summary>
        /// Kilometros en la entrega.
        /// </summary>
        public int KmEntrega { get; private set; }

        /// <summary>
        /// Kilometros en la devolución.
        /// </summary>
        public int KmDevolucion { get; private set; }

        /// <summary>
        /// Número de dias del alquiler.
        /// </summary>
        public int DuracionDias { get; private set; }

        /// <summary>
        /// Precio total del alquiler.
        /// </summary>
        public decimal PrecioTotal { get; private set; }

        /// <summary>
        /// Está entregado.
        /// </summary>
        public bool Entregado { get; private set; }

        /// <summary>
        /// Está devuelto.
        /// </summary>
        public bool Devuelto { get; private set; }

        /// <summary>
        /// Vehiculo alquilado.
        /// </summary>
        public Vehiculo Vehiculo { get; private set; }

        /// <summary>
        /// Cliente.
        /// </summary>
        public Cliente Cliente { get; private set; }





        /// <summary>
        /// Initializes a new instance of the <see cref="Alquiler"/> class.
        /// </summary>
        public Alquiler() { }



        /// <summary>
        /// Creación de Alquiler.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vehiculo"></param>
        /// <param name="cliente"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <param name="duracionDias"></param>
        /// <param name="entregado"></param>
        /// <exception cref="ArgumentException"></exception>
        public Alquiler(Guid id, Vehiculo vehiculo, Cliente cliente, DateTime fechaInicio, DateTime fechaFin, int duracionDias, bool entregado)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            Vehiculo = vehiculo ?? throw new ArgumentNullException(nameof(vehiculo));
            IdVehiculo = vehiculo.Id;
            Cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
            IdCliente = cliente.Id;
            FechaInicio = fechaInicio != DateTime.MinValue ? fechaInicio : throw new ArgumentException("La fecha de inicio es obligatoria.", nameof(fechaInicio));
            FechaFin = fechaFin != DateTime.MinValue ? fechaFin : throw new ArgumentException("La fecha de fin es obligatoria.", nameof(fechaFin));
            KmEntrega = vehiculo.KmActuales;
            DuracionDias = duracionDias > 0 ? duracionDias : throw new ArgumentException("La duración en días debe ser mayor que 0.", nameof(duracionDias));
            PrecioTotal = DuracionDias * vehiculo.PrecioPorDiaAlquiler;
            Entregado = entregado;
            Devuelto = false;
            Vehiculo.Alquilar();
        }

        /// <summary>
        /// Entrgar vehiculo.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public void EntregarVehiculo()
        {
            if (Entregado)
            {
                throw new InvalidOperationException("El vehículo ya ha sido entregado.");
            }

            Entregado = true;
        }

        /// <summary>
        /// Devolver vehiculo.
        /// </summary>
        /// <param name="kmDevolucion"></param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void DevolverVehiculo(int kmDevolucion)
        {
            if (!Entregado)
            {
                throw new InvalidOperationException("El vehículo no ha sido entregado.");
            }

            if (kmDevolucion < KmEntrega)
            {
                throw new ArgumentException("Los kilómetros de devolución no pueden ser inferiores a los kilómetros de entrega.", nameof(kmDevolucion));
            }

            KmDevolucion = kmDevolucion;
            Vehiculo.Devolver(kmDevolucion);
            Devuelto = true;
        }

    }
}
