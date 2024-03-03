using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using AccesoDatos;
using System.Data.SqlClient;
using Negocio.Interfaz;
using AccesoDatos.Interfaz;


namespace Negocio
{
    public class Logica : ILogica
    {


        #region atributos

        private readonly IAccesoMongoBD _IAccesoMongoBD;
        private readonly IAccesoSQL _IAccesoSQL;
        #endregion

     
        #region Constructor 
        public Logica(IAccesoSQL IAccesoSQL, IAccesoMongoBD IAccesoMongoBD)
        {
            _IAccesoSQL = IAccesoSQL;
            _IAccesoMongoBD = IAccesoMongoBD;
        }
     

        #endregion

        //Seccion Usuarios
        #region Usuarios
        //metodo para agregar Usuario
        #region Agregar Usuario
        public bool AgregarUsuario(Usuarios P_Entidad)
        {
            try
            {
                AccesoSQL objacceso = new AccesoSQL();

                SqlParameter paramId_Usuario = new SqlParameter
                {
                    ParameterName = "@id_usuario",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = P_Entidad.Id_Usuario
                };
                SqlParameter paramNombre = new SqlParameter
                {
                    ParameterName = "@nombre",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Size = 50,
                    Value = P_Entidad.Nombre
                };
                SqlParameter paramContrasena = new SqlParameter
                {
                    ParameterName = "@contrasena",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Size = 50,
                    Value = P_Entidad.Contrasena
                };
                SqlParameter paramId_perfil = new SqlParameter
                {
                    ParameterName = "@id_perfil",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = P_Entidad.Id_perfil
                };


                SQLPeticiones peticion = new SQLPeticiones
                {
                    ListaParametros = new List<SqlParameter> { paramId_Usuario, paramNombre, paramContrasena, paramId_perfil },
                    Peticion = "EXEC PA_AgregarUsuario @id_usuario, @nombre, @contrasena , @id_perfil"

                };

                return objacceso.Ejecutar_Sentencia(peticion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        //metodo para modificar Usuario
        #region Modificar Usuario
        public bool ModificarUsuario(Usuarios P_Entidad)
        {
            try
            {
                AccesoSQL objacceso = new AccesoSQL();


                SqlParameter paramId_Usuario = new SqlParameter
                {
                    ParameterName = "@id_usuario",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = P_Entidad.Id_Usuario
                };
                SqlParameter paramNombre = new SqlParameter
                {
                    ParameterName = "@nombre",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Size = 50,
                    Value = P_Entidad.Nombre
                };
                SqlParameter paramContrasena = new SqlParameter
                {
                    ParameterName = "@contrasena",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Size = 50,
                    Value = P_Entidad.Contrasena
                };
                SqlParameter paramId_perfil = new SqlParameter
                {
                    ParameterName = "@id_perfil",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = P_Entidad.Id_perfil
                };


                SQLPeticiones peticion = new SQLPeticiones
                {
                    ListaParametros = new List<SqlParameter> { paramId_Usuario, paramNombre, paramContrasena, paramId_perfil },
                    Peticion = "EXEC PA_ModificarUsuario @id_usuario, @nombre, @contrasena , @id_perfil"

                };

                return objacceso.Ejecutar_Sentencia(peticion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        //metoodo para eliminar Usuario
        #region Eliminar Usuario
        public bool EliminarUsuario(Usuarios P_Entidad)
        {
            try
            {
                AccesoSQL objacceso = new AccesoSQL();

                SqlParameter paramIdUsuario = new SqlParameter
                {
                    ParameterName = "@id_usuario",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = P_Entidad.Id_Usuario
                };

                SQLPeticiones peticion = new SQLPeticiones
                {
                    ListaParametros = new List<SqlParameter> { paramIdUsuario },
                    Peticion = "EXEC PA_EliminarUsuario @id_usuario"
                };

                return objacceso.Ejecutar_Sentencia(peticion);
            }
 
            catch (Exception ex)
            {
                throw ex;
            }


            
            
        }
        #endregion

        //metodo para consultar informacion del Usuarios
        #region consultar informacion del Usuarios
        public List<Usuarios> Consultar()
        {
            return _IAccesoSQL.GetUsers();
        }


        //metodo para consultar inicio de sesio
        #region consultar inicio de sesion
        public List<Usuarios> ConsultarInicioSesion(Usuarios P_Usuarios)
        {
            return _IAccesoSQL.ConsultarInicioSesion(P_Usuarios);
        }
        #endregion

        //metodo para consultar usuarios por id
        #region consultar informacion del Usuarios
        public List<Usuarios> ConsultarUsuariosPorID(Usuarios P_Usuario)
        {
            return _IAccesoSQL.ConsultarUsuariosPorID(P_Usuario);
        }
        #endregion
        #endregion
        #endregion

        //metodo para consultar Autenticacion
        #region consultar autenticacion
        public List<Usuarios> ConsultarAdministrador(Usuarios P_Usuario)
        {
            return _IAccesoSQL.ConsultarAdministrador(P_Usuario);
        }
        #endregion

        //sesion habitacion
        #region Habitacion

        #region Consultar Habitacion
        public List<Habitaciones> ConsultarHabitacion()
        {
            return _IAccesoSQL.GetHabitaciones();
        }
        #endregion

        //metodo para consultar habitacion por id
        #region consultar informacion habitacion por ID
        public List<Habitaciones> ConsultarHabitacionesPorId(Habitaciones P_Habitaciones)
        {
            return _IAccesoSQL.ConsultarHabitacionesPorId(P_Habitaciones);
        }

        //metodo para consultar habitacion por estado ocupado
        public List<Habitaciones> ConsultarHabitacionOcupada(Habitaciones P_Habitaciones)
        {
            return _IAccesoSQL.ConsultarHabitacionOcupada(P_Habitaciones);
        }
        #endregion

        #region Agregar habitacion
        public bool AgregarHabitacion(Habitaciones P_Entidad)
        {
            try
            {
                AccesoSQL objacceso = new AccesoSQL();

                SqlParameter paramId_Habitacion = new SqlParameter
                {
                    ParameterName = "@id_habitacion",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = P_Entidad.Id_habitacion
                };
                SqlParameter paramNumero_Habitacion = new SqlParameter
                {
                    ParameterName = "@numero_habitacion",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Size = 50,
                    Value = P_Entidad.Numero_habitacion
                };
                SqlParameter paramTipo_Habitacion = new SqlParameter
                {
                    ParameterName = "@tipo_habitacion",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Size = 50,
                    Value = P_Entidad.Tipo_habitacion
                };
                SqlParameter paramPrecio = new SqlParameter
                {
                    ParameterName = "@precio",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = P_Entidad.Precio
                };
                SqlParameter paramocupada = new SqlParameter
                {
                    ParameterName = "@ocupada",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = P_Entidad.Ocupado
                };

                SQLPeticiones peticion = new SQLPeticiones
                {
                    ListaParametros = new List<SqlParameter> { paramId_Habitacion, paramNumero_Habitacion, paramTipo_Habitacion, paramPrecio, paramocupada},
                    Peticion = "EXEC PA_AgregarHabitaciones @id_habitacion, @numero_habitacion, @tipo_habitacion , @precio , @ocupada"

                };

                return objacceso.Ejecutar_Sentencia(peticion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        //metodo para modificar 
        #region Modificar habitacion
        public bool ModificarHabitacion(Habitaciones P_Entidad)
        {
            try
            {
                AccesoSQL objacceso = new AccesoSQL();


                SqlParameter paramId_Habitacion = new SqlParameter
                {
                    ParameterName = "@id_habitacion",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = P_Entidad.Id_habitacion
                };
                SqlParameter paramNumero_Habitacion = new SqlParameter
                {
                    ParameterName = "@numero_habitacion",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Size = 50,
                    Value = P_Entidad.Numero_habitacion
                };
                SqlParameter paramTipo_Habitacion = new SqlParameter
                {
                    ParameterName = "@tipo_habitacion",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Size = 50,
                    Value = P_Entidad.Tipo_habitacion
                };
                SqlParameter paramPrecio = new SqlParameter
                {
                    ParameterName = "@precio",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = P_Entidad.Precio
                };
                SqlParameter paramocupada = new SqlParameter
                {
                    ParameterName = "@ocupada",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = P_Entidad.Ocupado
                };


                SQLPeticiones peticion = new SQLPeticiones
                {
                    ListaParametros = new List<SqlParameter> { paramId_Habitacion, paramNumero_Habitacion, paramTipo_Habitacion, paramPrecio, paramocupada },
                    Peticion = "EXEC PA_ModificarHabitaciones @id_habitacion, @numero_habitacion, @tipo_habitacion , @precio, @Ocupada "

                };

                return objacceso.Ejecutar_Sentencia(peticion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        //metoodo para eliminar habitacion
        #region Eliminar habitacion
        public bool EliminarHabitacion(Habitaciones P_Entidad)
        {
            try
            {
                AccesoSQL objacceso = new AccesoSQL();
                SqlParameter paramIdUsuario = new SqlParameter
                {
                    ParameterName = "@id_habitacion",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = P_Entidad.Id_habitacion
                };

                SQLPeticiones peticion = new SQLPeticiones
                {
                    ListaParametros = new List<SqlParameter> { paramIdUsuario },
                    Peticion = "EXEC PA_EliminarHabitaciones @id_habitacion"
                };

                return objacceso.Ejecutar_Sentencia(peticion);
            }
            catch (Exception ex )
            {
                Console.WriteLine("no");
                throw ex;
            }
        }
        #endregion

        #endregion
        
        //seccion reservas
        #region Reservas


        //metodo para consultar reserva por id
        #region consultar informacion de la reserva por id
        public List<Reserva> ConsultarReservaPorId(Reserva P_Reserva)
        {
            return _IAccesoSQL.ConsultarReservaPorId(P_Reserva);
        }
        #endregion

        #region consultar informacion de la reserva por id Usuario
        public List<Reserva> ConsultarReservaPorIdUsuario(Reserva P_Reserva)
        {
            return _IAccesoSQL.ConsultarReservaPorIdUsuario(P_Reserva);
        }
        #endregion

        #region Consultar Reserva

        public List<Reserva> ConsultarReserva()
        {
            return _IAccesoSQL.GetReserva();
        }

        #endregion

        #region Agregrar reserva

        public bool AgregarReserva(Reserva P_Entidad)
        {
            try
            {
                AccesoSQL objacceso = new AccesoSQL();

                SqlParameter paramId_Reserva = new SqlParameter
                {
                    ParameterName = "@id_reserva",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = P_Entidad.Id_reserva
                };
                SqlParameter paramId_Habitacion = new SqlParameter
                {
                    ParameterName = "@id_habitacion",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = P_Entidad.Id_habitacion
                };
                SqlParameter paramId_Usuario = new SqlParameter
                {
                    ParameterName = "@id_usuario",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = P_Entidad.Id_usuario
                };
                SqlParameter paramreserva = new SqlParameter
                {
                    ParameterName = "@fecha_inicio",
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Value = P_Entidad.Fecha_inicio
                };
                SqlParameter paramfechafin = new SqlParameter
                {
                    ParameterName = "@fecha_fin",
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Value = P_Entidad.Fecha_fin
                };
                SqlParameter paramestado = new SqlParameter
                {
                    ParameterName = "@estado",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Size = 20,
                    Value = P_Entidad.Estado
                };

                SQLPeticiones peticion = new SQLPeticiones
                {
                    ListaParametros = new List<SqlParameter> { paramId_Reserva, paramId_Habitacion, paramId_Usuario, paramreserva, paramfechafin, paramestado },
                    Peticion = "EXEC PA_AgregarReserva @id_reserva, @id_habitacion, @id_usuario , @fecha_inicio , @fecha_fin, @estado "

                };

                return objacceso.Ejecutar_Sentencia(peticion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Modificar Reserva

        public bool ModificarReserva(Reserva P_Entidad)
        {
            try
            {
                AccesoSQL objacceso = new AccesoSQL();


                SqlParameter paramId_Reserva = new SqlParameter
                {
                    ParameterName = "@id_reserva",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = P_Entidad.Id_reserva
                };
                SqlParameter paramId_Habitacion = new SqlParameter
                {
                    ParameterName = "@id_habitacion",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = P_Entidad.Id_habitacion
                };
                SqlParameter paramFecha_Inicio = new SqlParameter
                {
                    ParameterName = "@fecha_inicio",
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Value = P_Entidad.Fecha_inicio
                };
                SqlParameter paramFecha_Fin = new SqlParameter
                {
                    ParameterName = "@fecha_fin",
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Value = P_Entidad.Fecha_fin
                };
                SqlParameter paramEstado = new SqlParameter
                {
                    ParameterName = "@estado",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Size = 20,
                    Value = P_Entidad.Estado
                };


                SQLPeticiones peticion = new SQLPeticiones
                {
                    ListaParametros = new List<SqlParameter> { paramId_Reserva, paramId_Habitacion, paramFecha_Inicio, paramFecha_Fin, paramEstado },
                    Peticion = "EXEC PA_ModificarReserva @id_reserva, @id_habitacion, @fecha_inicio , @fecha_fin, @estado "

                };

                return objacceso.Ejecutar_Sentencia(peticion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        #endregion

        #region Eliminar Reserva

        public bool EliminarReserva(Reserva P_Entidad)
        {
            try
            {
                AccesoSQL objacceso = new AccesoSQL();
                SqlParameter paramIdReserva = new SqlParameter
                {
                    ParameterName = "@id_reserva",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = P_Entidad.Id_reserva
                };

                SQLPeticiones peticion = new SQLPeticiones
                {
                    ListaParametros = new List<SqlParameter> { paramIdReserva },
                    Peticion = "EXEC PA_EliminarReserva @id_reserva"
                };

                return objacceso.Ejecutar_Sentencia(peticion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        #endregion

        #endregion

        //seccion pagos
        #region Pagos
        //metodo para consultar pagos por id
        #region consultar informacion de los pagos por id
        public List<Pagos> ConsultarPagosPorId(Pagos P_Pago)
        {
            return _IAccesoSQL.ConsultarPagosPorId(P_Pago);
        }
        #endregion

        #region Consultar Pagos

        public List<Pagos> ConsultarPagos()
        {
            return _IAccesoSQL.GetPagos();
        }


        #endregion

        #region Agregar Pagos

        public bool AgregarPagos(Pagos P_Entidad)
        {
            try
            {
                AccesoSQL objacceso = new AccesoSQL();

                SqlParameter paramId_Pagos = new SqlParameter
                {
                    ParameterName = "@id_pago",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = P_Entidad.Id_pago
                };
                SqlParameter paramId_reserva = new SqlParameter
                {
                    ParameterName = "@id_reserva",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = P_Entidad.Id_reserva
                };
                SqlParameter paramMonto = new SqlParameter
                {
                    ParameterName = "@monto",
                    SqlDbType = System.Data.SqlDbType.Decimal,
                    Value = P_Entidad.Monto
                };
                SqlParameter paramFecha_Pago = new SqlParameter
                {
                    ParameterName = "@fecha_inicio",
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Value = P_Entidad.Fecha_pago
                };
                SqlParameter paramDescuento = new SqlParameter
                {
                    ParameterName = "@Descuento",
                    SqlDbType = System.Data.SqlDbType.Decimal,
                    Value = P_Entidad.Descuento
                };
                SqlParameter paramMulta = new SqlParameter
                {
                    ParameterName = "@Multa",
                    SqlDbType = System.Data.SqlDbType.Decimal,
                    Value = P_Entidad.Multa
                };
                SqlParameter paramTotal = new SqlParameter
                {
                    ParameterName = "@Total",
                    SqlDbType = System.Data.SqlDbType.Decimal,
                    Value = P_Entidad.Total
                };

                SQLPeticiones peticion = new SQLPeticiones
                {
                    ListaParametros = new List<SqlParameter> { paramId_Pagos, paramId_reserva, paramMonto, paramFecha_Pago, paramDescuento, paramMulta, paramTotal },
                    Peticion = "EXEC PA_AgregarPago @id_pago, @id_reserva, @monto , @fecha_inicio, @Descuento , @Multa "

                };

                return objacceso.Ejecutar_Sentencia(peticion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Modificar Pagos

        public bool ModificarPagos(Pagos P_Entidad)
        {
            try
            {
                AccesoSQL objacceso = new AccesoSQL();


                SqlParameter paramId_Pagos = new SqlParameter
                {
                    ParameterName = "@id_pago",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = P_Entidad.Id_pago
                };
                SqlParameter paramId_reserva = new SqlParameter
                {
                    ParameterName = "@id_reserva",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = P_Entidad.Id_reserva
                };
                SqlParameter paramMonto = new SqlParameter
                {
                    ParameterName = "@monto",
                    SqlDbType = System.Data.SqlDbType.Decimal,
                    Value = P_Entidad.Monto
                };
                SqlParameter paramFecha_Pago = new SqlParameter
                {
                    ParameterName = "@fecha_inicio",
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Value = P_Entidad.Fecha_pago
                };
                SqlParameter paramDescuento = new SqlParameter
                {
                    ParameterName = "@Descuento",
                    SqlDbType = System.Data.SqlDbType.Decimal,
                    Value = P_Entidad.Descuento
                };
                SqlParameter paramMulta = new SqlParameter
                {
                    ParameterName = "@Multa",
                    SqlDbType = System.Data.SqlDbType.Decimal,
                    Value = P_Entidad.Multa
                };


                SQLPeticiones peticion = new SQLPeticiones
                {
                    ListaParametros = new List<SqlParameter> { paramId_Pagos, paramId_reserva, paramMonto, paramFecha_Pago, paramDescuento, paramMulta },
                    Peticion = "EXEC PA_ModificarPagos @id_pago, @id_reserva, @monto ,  @fecha_inicio, @Descuento, @Multa "

                };

                return objacceso.Ejecutar_Sentencia(peticion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #region Eliminar Pagos

        public bool EliminarPagos(Pagos P_Entidad)
        {
            try
            {
                AccesoSQL objacceso = new AccesoSQL();
                SqlParameter paramIdPagos = new SqlParameter
                {
                    ParameterName = "@id_pago",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = P_Entidad.Id_pago
                };

                SQLPeticiones peticion = new SQLPeticiones
                {
                    ListaParametros = new List<SqlParameter> { paramIdPagos },
                    Peticion = "EXEC PA_EliminarPagos @id_pago"
                };

                return objacceso.Ejecutar_Sentencia(peticion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #endregion

        //seccion reportes
        #region Reportes

        //metodo para agregar reportes
        public string AgregarReportes(Reportes P_Reporte)
        {
            string resultado = "Reporte registrado correctamente";

             _IAccesoMongoBD.Agregar(P_Reporte);

            return resultado;
        }



        //metodo para consultar usuario de tipo usuario
        public List<Reportes> ConsultarReporte()
        {
            return _IAccesoMongoBD.Consultar();
        }

        public Reportes ConsultarPorID(Reportes P_Reporte)
        {
            return _IAccesoMongoBD.ConsultarPorID(P_Reporte);
        }
        #endregion

       
        public List<Pagos> ConsultarMontoTotal(Pagos Ppagos)
        {
            return _IAccesoSQL.ConsultarVentas(Ppagos);
        }

    }
}
