using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace AccesoDatos.Interfaz
{
    public interface IAccesoSQL
    {
        List<Usuarios> GetUsers();

        List<Habitaciones> GetHabitaciones();

        List<Reserva> GetReserva();

        List<Pagos> GetPagos();

        List<Usuarios> ConsultarUsuariosPorID(Usuarios P_Usuario);

        List<Usuarios> ConsultarInicioSesion(Usuarios P_Usuarios);

        List<Habitaciones> ConsultarHabitacionesPorId(Habitaciones P_Habitaciones);

        List<Reserva> ConsultarReservaPorId(Reserva P_Reserva);

        List<Reserva> ConsultarReservaPorIdUsuario(Reserva P_Reserva);

        List<Pagos> ConsultarPagosPorId(Pagos P_Pago);

        List<Usuarios> ConsultarAdministrador(Usuarios P_Usuario);

        List<Pagos> ConsultarVentas(Pagos Ppagos);

        List<Habitaciones> ConsultarHabitacionOcupada(Habitaciones P_Habitaciones);
    }
}
