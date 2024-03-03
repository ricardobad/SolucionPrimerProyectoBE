using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades;
using Negocio.Interfaz;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/Hotel")]
    public class HotelController : Controller
    {

        #region Atributos

        private readonly ILogica _ilogica;
     
        #endregion

        #region Constructor

        public HotelController(ILogica ilogica)
        {
            _ilogica = ilogica;
        }

     
        #endregion

        public IActionResult Index()
        {
            return View();
        }

        #region Usuarios

        #region Agregar Usuarios
        //para agregar
        [HttpPost]
        [Route(nameof(Agregar))]
        public bool Agregar(Usuarios P_Usuarios)
        {
            if (P_Usuarios.Id_Usuario == 0)
            {
                Console.WriteLine(" Ingrese un id");
                return false;
            }
            else
            {
                return _ilogica.AgregarUsuario(P_Usuarios);
            }
        
        }

        #endregion

        #region Eliminar Usuarios
        //para eliminar
        [HttpDelete]
        [Route(nameof(EliminarUsuario))]
        public bool EliminarUsuario([FromHeader] int pUsuario)
        {
            return _ilogica.EliminarUsuario(new Usuarios { Id_Usuario = pUsuario });
        }

        #endregion

        #region Consultar todos los usuarios

        //para consultar
        [HttpGet]
        [Route(nameof(ConsultarTodosUsuarios))]
        public IEnumerable<Usuarios> ConsultarTodosUsuarios()
        {
            return _ilogica.Consultar();
        }

        #endregion

        #region Consultar usuarios por ID
        //para consultar
        [HttpGet]
        [Route(nameof(ConsultarUsuariosPorID))]
        public IEnumerable<Usuarios> ConsultarUsuariosPorID([FromHeader] int pUsuario)
        {
            return _ilogica.ConsultarUsuariosPorID(new Usuarios { Id_Usuario = pUsuario });
        }

        #endregion

        #region consultar Inicio Sesion para consultar
        [HttpGet]
        [Route(nameof(ConsultarInicioSesion))]
        public IEnumerable<Usuarios> ConsultarInicioSesion([FromHeader] int pUsuario, [FromHeader] string pOtro)
        {
            return _ilogica.ConsultarInicioSesion(new Usuarios { Id_Usuario = pUsuario, Contrasena = pOtro });
        }

        #endregion
        #region Consultar autenticacion
        //para consultar
        [HttpGet]
        [Route(nameof(ConsultarAdministrador))]
        public IEnumerable<Usuarios> ConsultarAdministrador([FromHeader] int pUsuario, [FromHeader] string pUsuarios)
        {
            return _ilogica.ConsultarAdministrador(new Usuarios { Id_Usuario = pUsuario , Contrasena = pUsuarios});
        }

        #endregion

        #region Modificar Usuarios

        //para modificar
        [HttpPut]
        [Route(nameof(ModificarUsuario))]
        public bool ModificarUsuario([FromHeader] int pUsuario, [FromBody] Usuarios P_Usuario)
        {
            return _ilogica.ModificarUsuario(new Usuarios
            {
                Id_Usuario = pUsuario,
                Nombre = P_Usuario.Nombre,
                Contrasena = P_Usuario.Contrasena,
                Id_perfil = P_Usuario.Id_perfil
            });
        }

        #endregion

        #endregion

        #region habitaciones

        #region Consultar todas las habitaciones
        //para consultar
        [HttpGet]
        [Route(nameof(ConsultarTodasHabitaciones))]
        public IEnumerable<Habitaciones> ConsultarTodasHabitaciones()
        {
            return _ilogica.ConsultarHabitacion();
        }

        #endregion

        #region Consultar por habitaciones por Id

        //para consultar
        [HttpGet]
        [Route(nameof(ConsultarHabitacionesPorId))]
        public IEnumerable<Habitaciones> ConsultarHabitacionesPorId([FromHeader] int P_Habitacion)
        {
            return _ilogica.ConsultarHabitacionesPorId(new Habitaciones { Id_habitacion = P_Habitacion});
        }

        #endregion

        #region Consultar habitaciones por estado ocupado

        //para consultar
        [HttpGet]
        [Route(nameof(ConsultarHabitacionOcupada))]
        public IEnumerable<Habitaciones> ConsultarHabitacionOcupada([FromHeader] bool P_Habitaciones)
        {
            return _ilogica.ConsultarHabitacionOcupada(new Habitaciones { Ocupado = P_Habitaciones });
        }

        #endregion

        #region Agregar Habitacion

        //para agregar
        [HttpPost]
        [Route(nameof(AgregarHabitacion))]
        public bool AgregarHabitacion(Habitaciones P_Habitacion)
        {
            return _ilogica.AgregarHabitacion(P_Habitacion);
        }

        #endregion

        #region Modificar habitacion
        //para modificar
        [HttpPut]
        [Route(nameof(ModificarHabitacion))]
        public bool ModificarHabitacion([FromHeader] int pHabitacion, [FromBody] Habitaciones P_Habitacion)
        {
            return _ilogica.ModificarHabitacion(new Habitaciones
            {
                Id_habitacion = pHabitacion,
                Numero_habitacion = P_Habitacion.Numero_habitacion,
                Tipo_habitacion = P_Habitacion.Tipo_habitacion,
                Precio = P_Habitacion.Precio,
                Ocupado = P_Habitacion.Ocupado

            }) ;
        }

        #endregion

        #region Eliminar Habitacion

        //para eliminar
        [HttpDelete]
        [Route(nameof(EliminarHabitacion))]
        public bool EliminarHabitacion([FromHeader] int pHabitacion)
        {
            return _ilogica.EliminarHabitacion(new Habitaciones { Id_habitacion = pHabitacion });
        }

        #endregion

        #endregion

        #region Reservas

        #region Consultar todas las reservas
        //para consultar
        [HttpGet]
        [Route(nameof(ConsultarTodasLasReservas))]
        public IEnumerable<Reserva> ConsultarTodasLasReservas()
        {
            return _ilogica.ConsultarReserva();
        }

        #endregion

        #region consultar reservas por id
        //para consultar
        [HttpGet]
        [Route(nameof(ConsultarReservaPorId))]
        public IEnumerable<Reserva> ConsultarReservaPorId([FromHeader] int P_Reserva)
        {
            return _ilogica.ConsultarReservaPorId(new Reserva { Id_reserva = P_Reserva });
        }

        #endregion

        #region consultar reservas por id Usuario
        //para consultar
        [HttpGet]
        [Route(nameof(ConsultarReservaPorIdUsuario))]
        public IEnumerable<Reserva> ConsultarReservaPorIdUsuario([FromHeader] int P_Reserva)
        {
            return _ilogica.ConsultarReservaPorIdUsuario(new Reserva { Id_usuario = P_Reserva });
        }

        #endregion

        #region Agregar Reserva
        //para agregar
        [HttpPost]
        [Route(nameof(AgregarReserva))]
        public bool AgregarReserva(Reserva P_Reserva)
        {
            return _ilogica.AgregarReserva(P_Reserva);
        }


        #endregion

        #region modificar reserva
        //para modificar
        [HttpPut]
        [Route(nameof(ModificarReserva))]
        public bool ModificarReserva([FromHeader] int pReserva, [FromBody] Reserva P_Reserva)
        {
            return _ilogica.ModificarReserva(new Reserva
            {
                Id_reserva = pReserva,
                Id_habitacion = P_Reserva.Id_habitacion,
                Fecha_inicio = P_Reserva.Fecha_inicio,
                Fecha_fin = P_Reserva.Fecha_fin,
                Estado = P_Reserva.Estado

            });
        }

        #endregion

        #region eliminar reserva

        //para eliminar
        [HttpDelete]
        [Route(nameof(EliminarReserva))]
        public bool EliminarReserva([FromHeader] int pReserva)
        {
            return _ilogica.EliminarReserva(new Reserva { Id_reserva = pReserva });
        }

        #endregion

        #endregion

        #region Pagos

        #region consultar todos los pagos
        //para consultar
        [HttpGet]
        [Route(nameof(ConsultarTodosLosPagos))]
        public IEnumerable<Pagos> ConsultarTodosLosPagos()
        {
            return _ilogica.ConsultarPagos();
        }
        #endregion

        #region consultar pagos por id
        //para consultar
        [HttpGet]
        [Route(nameof(ConsultarPagosPorId))]
        public IEnumerable<Pagos> ConsultarPagosPorId([FromHeader] int P_Pago)
        {
            return _ilogica.ConsultarPagosPorId(new Pagos { Id_pago = P_Pago });
        }
        #endregion

        #region agregar pagos
        //para agregar
        [HttpPost]
        [Route(nameof(AgregarPagos))]
        public bool AgregarPagos(Pagos P_Pagos)
        {
            return _ilogica.AgregarPagos(P_Pagos);
        }
        #endregion

        #region Modificar pagos

        //para modificar
        [HttpPut]
        [Route(nameof(ModificarPagos))]
        public bool ModificarPagos([FromHeader] int pPagos, [FromBody] Pagos P_Pagos)
        {
            return _ilogica.ModificarPagos(new Pagos
            {
                Id_pago = pPagos,
                Id_reserva = P_Pagos.Id_reserva,
                Monto = P_Pagos.Monto,
                Descuento = P_Pagos.Descuento,
                Multa = P_Pagos.Multa,
                Fecha_pago = P_Pagos.Fecha_pago

            });
        }
        #endregion

        #region Eliminar Pagos
        //para eliminar
        [HttpDelete]
        [Route(nameof(EliminarPagos))]
        public bool EliminarPagos([FromHeader] int pPagos)
        {
            return _ilogica.EliminarPagos(new Pagos { Id_pago = pPagos });
        }
        #endregion

        #endregion

        #region Reportes 

        //para agregar
        [HttpPost]
        [Route(nameof(AgregarReporte))]
        public string AgregarReporte(Reportes P_Reporte)
        {
            return _ilogica.AgregarReportes(P_Reporte);
        }

        //para consultar
        [HttpGet]
        [Route(nameof(ConsultarTodosReportes))]
        public IEnumerable<Reportes> ConsultarTodosReportes()
        {
            return _ilogica.ConsultarReporte();
        }

        //para consultar
        [HttpGet]
        [Route(nameof(ConsultarReportesPorID))]
        public Reportes ConsultarReportesPorID([FromHeader] string pReporte)
        {
            return _ilogica.ConsultarPorID(new Reportes { Id_reporte = pReporte });
        }
        #endregion

        #region consultar ventas
        [HttpGet]
        [Route(nameof(ConsultarVenta))]
        public IEnumerable<Pagos> ConsultarVenta([FromHeader] DateTime FechaInicio, [FromHeader] DateTime FechaFin)
        {
            return _ilogica.ConsultarMontoTotal(new Pagos { Fecha_pago = FechaInicio, Fecha_Final = FechaFin });
        }

        #endregion

    }
}
