using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
namespace Negocio.Interfaz
{
    public interface ILogica
    {
        #region Usuarios
        bool AgregarUsuario(Usuarios P_Entidad);
        bool ModificarUsuario(Usuarios P_Entidad);
        bool EliminarUsuario(Usuarios P_Entidad);
        List<Usuarios> Consultar();
        List<Usuarios> ConsultarAdministrador(Usuarios P_Usuario);
        List<Usuarios> ConsultarUsuariosPorID(Usuarios P_Usuario);
        #endregion

        #region Habitaciones
        List<Habitaciones> ConsultarHabitacion();
        bool AgregarHabitacion(Habitaciones P_Entidad);
        bool ModificarHabitacion(Habitaciones P_Entidad);
        bool EliminarHabitacion(Habitaciones P_Entidad);

        List<Habitaciones> ConsultarHabitacionesPorId(Habitaciones P_Habitaciones);

        List<Habitaciones> ConsultarHabitacionOcupada(Habitaciones P_Habitaciones);

        #endregion

        #region Reservas

        List<Reserva> ConsultarReservaPorId(Reserva P_Reserva);
        List<Reserva> ConsultarReservaPorIdUsuario(Reserva P_Reserva);
        List<Usuarios> ConsultarInicioSesion(Usuarios P_Usuarios);
        List<Reserva> ConsultarReserva();
        bool AgregarReserva(Reserva P_Entidad);
        bool ModificarReserva(Reserva P_Entidad);
        bool EliminarReserva(Reserva P_Entidad);

        #endregion

        #region Pagos

        List<Pagos> ConsultarPagosPorId(Pagos P_Pago);
        List<Pagos> ConsultarPagos();
        bool AgregarPagos(Pagos P_Entidad);
        bool ModificarPagos(Pagos P_Entidad);
        bool EliminarPagos(Pagos P_Entidad);

        #endregion


        #region Reportes
        string AgregarReportes(Reportes P_Reporte);

        List<Reportes> ConsultarReporte();

        Reportes ConsultarPorID(Reportes P_Reporte);

        #endregion

        public List<Pagos> ConsultarMontoTotal(Pagos Ppagos);
    }
}
