using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using AccesoDatos.Interfaz;

namespace AccesoDatos
{
    public class AccesoSQL : IAccesoSQL
    {
        #region Atributos
        //conexion a base de datos

        private readonly string CadenaConexionSQLA = @"Data Source = desktop-rb\SQL2019_DEV; Initial Catalog=Hotel; Persist Security Info=true; user id=sa; password=123456;";
        private SqlConnection objconexion;
        #endregion

        //para desencriptar la cadena de conexion
        #region Constructor

        public AccesoSQL()
        {
            try
            {
                objconexion = new SqlConnection(CadenaConexionSQLA);
                Abrir();
            }
            catch (SqlException exSQL)
            {
                throw exSQL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Cerrar();
            }
        }

        #endregion

        #region Metodos 

        #region Privado
        // metodo para abrir y cerrar la conexion con base de datos
        private void Abrir()
        {
            if (objconexion.State == System.Data.ConnectionState.Closed)
                objconexion.Open();
        }

        private void Cerrar()
        {
            if (objconexion.State == System.Data.ConnectionState.Open)
                objconexion.Close();
        }
        #endregion
        #endregion

        //consultas
        #region Publicos

        //ejecutar la peticion
        #region ejecutar sentencia

        public bool Ejecutar_Sentencia(SQLPeticiones P_Entidad)
        {
            try
            {

                SqlCommand cmd = new SqlCommand
                {
                    CommandType = System.Data.CommandType.Text,
                    Connection = objconexion,
                    CommandText = P_Entidad.Peticion
                };

                if (P_Entidad.ListaParametros.Count() > 0)
                    cmd.Parameters.AddRange(P_Entidad.ListaParametros.ToArray());

                Abrir();

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Cerrar();
            }
        }

        #endregion

        //consulta Login
        #region consultar Inicio de sesion

        public List<Usuarios> ConsultarInicioSesion(Usuarios P_Usuarios)
        {
            List<Usuarios> usuarios = new List<Usuarios>();

            {
                objconexion.Open();

                using (SqlCommand command = new SqlCommand("PA_Autenticacion", objconexion))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros del procedimiento almacenado
                    command.Parameters.AddWithValue("@id_usuario", P_Usuarios.Id_Usuario);
                    command.Parameters.AddWithValue("@contrasena", P_Usuarios.Contrasena);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            P_Usuarios.Id_Usuario = (int)reader["id_usuario"];
                            P_Usuarios.Contrasena = (string)reader["contraseña"];
                            P_Usuarios.Id_perfil = (int)reader["id_perfil"];

                            usuarios.Add(P_Usuarios);

                        }
                        else
                        {
                            Console.WriteLine("No se encontró ningún Usuario");
                        }
                    }
                }
            }

            return usuarios;
        }
        #endregion
        //consulta informacion de Usuraios
        #region consultar informacion Usuarios

        public List<Usuarios> GetUsers()
        {
            List<Usuarios> users = new List<Usuarios>();

            
            {
                objconexion.Open();

                string query = "SELECT * FROM Usuarios";

                using (SqlCommand command = new SqlCommand(query, objconexion))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuarios usuarios = new Usuarios();
                            usuarios.Id_Usuario = (int)reader["id_usuario"];
                            usuarios.Nombre = (string)reader["nombre"];
                            usuarios.Contrasena = (string)reader["contraseña"];
                            usuarios.Id_perfil = (int)reader["id_perfil"];

                            users.Add(usuarios);
                        }
                    }
                }
            }

            return users;
        }
        #endregion

        //consultar usuarios por id
        #region consultar informacion Usuarios por id

        public List<Usuarios> ConsultarUsuariosPorID(Usuarios P_Usuario)
        {
            List<Usuarios> users = new List<Usuarios>();
            

        
            {
                objconexion.Open();

                using (SqlCommand command = new SqlCommand("PA_ConsultarUsuario", objconexion))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros del procedimiento almacenado
                    command.Parameters.AddWithValue("@id_usuario", P_Usuario.Id_Usuario );

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            P_Usuario.Id_Usuario = (int)reader["id_usuario"];
                            P_Usuario.Nombre = (string)reader["nombre"];
                            P_Usuario.Contrasena = (string)reader["contraseña"];
                            P_Usuario.Id_perfil = (int)reader["id_perfil"];

                            users.Add(P_Usuario);
                          
                        }
                        else
                        {
                            Console.WriteLine("No se encontró ningún usuario con el ID especificado.");
                        }
                    }
                    }
                }

                return users;

    
        }
        #endregion

        //consultar autenticacion administradores
        #region consultar Autenticacion para administradores

        public List<Usuarios> ConsultarAdministrador(Usuarios P_Usuario)
        {
            List<Usuarios> users = new List<Usuarios>();



            {
                objconexion.Open();

                using (SqlCommand command = new SqlCommand("PA_Autenticacion", objconexion))
                {
                    command.CommandType = CommandType.StoredProcedure;
                  
                    // Parámetros del procedimiento almacenado
                    command.Parameters.AddWithValue("@id_usuario", P_Usuario.Id_Usuario );
                    command.Parameters.AddWithValue("@contrasena", P_Usuario.Contrasena);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            P_Usuario.Id_Usuario = (int)reader["id_usuario"];
                            P_Usuario.Contrasena = (string)reader["contraseña"];
                            P_Usuario.Id_perfil = (int)reader["id_perfil"];

                            users.Add(P_Usuario);

                        }
                        else
                        {
                            Console.WriteLine("No se encontró ningún usuario con el ID especificado.");
                        }
                    }
                }
            }

            return users;


        }
        #endregion

        //consulta informacion de habitaciones
        #region consultar informacion habitaciones

        public List<Habitaciones> GetHabitaciones()
        {
            List<Habitaciones> habitaciones = new List<Habitaciones>();

            {
                objconexion.Open();

                string query = "SELECT * FROM Habitaciones";

                using (SqlCommand command = new SqlCommand(query, objconexion))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Habitaciones habitacion = new Habitaciones();
                            habitacion.Id_habitacion = (int)reader["id_habitacion"];
                            habitacion.Numero_habitacion = (string)reader["numero_habitacion"];
                            habitacion.Tipo_habitacion = (string)reader["tipo_habitacion"];
                            habitacion.Precio = (int)reader["Precio"];
                            habitacion.Ocupado = (bool)reader["ocupada"];

                            habitaciones.Add(habitacion);
                        }
                    }
                }
            }

            return habitaciones;
        }
        #endregion

        //consulta informacion de habitaciones por ID
        #region consultar informacion habitaciones por id

        public List<Habitaciones> ConsultarHabitacionesPorId(Habitaciones P_Habitaciones)
        {
            List<Habitaciones> habitaciones = new List<Habitaciones>();

            {
                objconexion.Open();

                using (SqlCommand command = new SqlCommand("PA_ConsultarHabitaciones", objconexion))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros del procedimiento almacenado
                    command.Parameters.AddWithValue("@id_habitacion", P_Habitaciones.Id_habitacion);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            P_Habitaciones.Id_habitacion = (int)reader["id_habitacion"];
                            P_Habitaciones.Numero_habitacion = (string)reader["numero_habitacion"];
                            P_Habitaciones.Tipo_habitacion = (string)reader["tipo_habitacion"];
                            P_Habitaciones.Precio = (int)reader["Precio"];
                            P_Habitaciones.Ocupado = (bool)reader["ocupada"];


                            habitaciones.Add(P_Habitaciones);

                        }
                        else
                        {
                            Console.WriteLine("No se encontró ningúna habitacion con el ID especificado.");
                        }
                    }
                }
            }

            return habitaciones;
        }
        #endregion

        #region consultar informacion habitaciones por estado Ocupadp

        public List<Habitaciones> ConsultarHabitacionOcupada(Habitaciones P_Habitaciones)
        {
            List<Habitaciones> habitaciones = new List<Habitaciones>();

            {
                objconexion.Open();

                using (SqlCommand command = new SqlCommand("ConsultarHabitacionesPorOcupado", objconexion))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros del procedimiento almacenado
                    command.Parameters.AddWithValue("@ocupada", P_Habitaciones.Ocupado);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Habitaciones habitacion = new Habitaciones();

                            habitacion.Id_habitacion = (int)reader["id_habitacion"];
                            habitacion.Numero_habitacion = (string)reader["numero_habitacion"];
                            habitacion.Tipo_habitacion = (string)reader["tipo_habitacion"];
                            habitacion.Precio = (int)reader["Precio"];
                            habitacion.Ocupado = (bool)reader["ocupada"];


                            habitaciones.Add(habitacion);

                        }
                        
                    }
                }
            }

            return habitaciones;
        }
        #endregion

        //consulta informacion de reservas
        #region consultar informacion reserva

        public List<Reserva> GetReserva()
        {
            List<Reserva> reserva = new List<Reserva>();

            {
                objconexion.Open();

                string query = "SELECT * FROM Reservas";

                using (SqlCommand command = new SqlCommand(query, objconexion))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Reserva reservas = new Reserva();
                            reservas.Id_reserva = (int)reader["id_reserva"];
                            reservas.Id_habitacion = (int)reader["id_habitacion"];
                            reservas.Id_usuario = (int)reader["id_usuario"];
                            reservas.Fecha_inicio = (DateTime)reader["fecha_inicio"];
                            reservas.Fecha_fin = (DateTime)reader["fecha_fin"];
                            reservas.Estado = (string)reader["estado"];

                            reserva.Add(reservas);
                        }
                    }
                }
            }

            return reserva;
        }
        #endregion

        //consulta informacion de reservas por id
        #region consultar informacion reserva por Id

        public List<Reserva> ConsultarReservaPorId(Reserva P_Reserva)
        {
            List<Reserva> reserva = new List<Reserva>();

            {
                objconexion.Open();

                using (SqlCommand command = new SqlCommand("PA_ConsultarReserva", objconexion))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros del procedimiento almacenado
                    command.Parameters.AddWithValue("@id_reserva", P_Reserva.Id_reserva);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            P_Reserva.Id_reserva = (int)reader["id_reserva"];
                            P_Reserva.Id_habitacion = (int)reader["id_habitacion"];
                            P_Reserva.Id_usuario = (int)reader["id_usuario"];
                            P_Reserva.Fecha_inicio = (DateTime)reader["fecha_inicio"];
                            P_Reserva.Fecha_fin = (DateTime)reader["fecha_fin"];
                            P_Reserva.Estado = (string)reader["estado"];

                            reserva.Add(P_Reserva);

                        }
                        else
                        {
                            Console.WriteLine("No se encontró ningúna habitacion con el ID especificado.");
                        }
                    }
                }
            }

            return reserva;
        }
        #endregion

        //consulta informacion de reservas por id Usuario
        #region consultar informacion reserva por Id Usuario

        public List<Reserva> ConsultarReservaPorIdUsuario(Reserva P_Reserva)
        {
            List<Reserva> reserva = new List<Reserva>();

            {
                objconexion.Open();

                using (SqlCommand command = new SqlCommand("PA_ConsultarReservaPorIdUsuario", objconexion))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros del procedimiento almacenado
                    command.Parameters.AddWithValue("@id_usuario", P_Reserva.Id_usuario);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            P_Reserva.Id_reserva = (int)reader["id_reserva"];
                            P_Reserva.Id_habitacion = (int)reader["id_habitacion"];
                            P_Reserva.Id_usuario = (int)reader["id_usuario"];
                            P_Reserva.Fecha_inicio = (DateTime)reader["fecha_inicio"];
                            P_Reserva.Fecha_fin = (DateTime)reader["fecha_fin"];
                            P_Reserva.Estado = (string)reader["estado"];

                            reserva.Add(P_Reserva);

                        }
                        else
                        {
                            Console.WriteLine("No se encontró ningúna habitacion con el ID especificado.");
                        }
                    }
                }
            }

            return reserva;
        }
        #endregion

        //consulta informacion de Pagos
        #region Consultar informacion de Pagos

        public List<Pagos> GetPagos()
        {
            List<Pagos> pagos = new List<Pagos>();

            {
                objconexion.Open();

                string query = "SELECT * FROM Pagos";

                using (SqlCommand command = new SqlCommand(query, objconexion))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pagos pago = new Pagos();
                            pago.Id_pago = (int)reader["id_pago"];
                            pago.Id_reserva = (int)reader["id_reserva"];
                            pago.Monto = (decimal)reader["monto"];
                            pago.Fecha_pago = (DateTime)reader["fecha_pago"];
                            pago.Descuento = (decimal)reader["Descuento"];
                            pago.Multa = (decimal)reader["Multa"];
                            pago.Total = (decimal)reader["Total"];

                            pagos.Add(pago);
                        }
                    }
                }
            }

            return pagos;
        }

        #endregion

        //consulta informacion de pagos por id
        #region Consultar informacion de Pagos por id

        public List<Pagos> ConsultarPagosPorId(Pagos P_Pago)
        {
            List<Pagos> pagos = new List<Pagos>();

            {
                objconexion.Open();

                using (SqlCommand command = new SqlCommand("PA_ConsultarPagos", objconexion))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros del procedimiento almacenado
                    command.Parameters.AddWithValue("@id_pago", P_Pago.Id_pago);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            P_Pago.Id_pago = (int)reader["id_pago"];
                            P_Pago.Id_reserva = (int)reader["id_reserva"];
                            P_Pago.Monto = (decimal)reader["monto"];
                            P_Pago.Fecha_pago = (DateTime)reader["fecha_pago"];
                            P_Pago.Descuento = (decimal)reader["Descuento"];
                            P_Pago.Multa = (decimal)reader["Multa"];
                            P_Pago.Total = (decimal)reader["Total"];


                            pagos.Add(P_Pago);

                        }
                        else
                        {
                            Console.WriteLine("No se encontró ningúna habitacion con el ID especificado.");
                        }
                    }
                }
            }

            return pagos;
        }

        #endregion
        #endregion



        //consulta total ventas
        #region consultar total ventas

        public List<Pagos> ConsultarVentas(Pagos Ppagos)
        {
            List<Pagos> Pagos = new List<Pagos>();

            {
                objconexion.Open();

                using (SqlCommand command = new SqlCommand("ObtenerTotalGenerado", objconexion))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros del procedimiento almacenado
                    command.Parameters.AddWithValue("@fechaInicio", Ppagos.Fecha_pago);
                    command.Parameters.AddWithValue("@fechaFin", Ppagos.Fecha_Final);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Ppagos.Total = (decimal)reader["total_generado"];

                            Pagos.Add(Ppagos);

                        }
                        else
                        {
                            Console.WriteLine("No se encontró ningún Usuario");
                        }
                    }
                }
            }

            return Pagos;
        }
        #endregion
    }
}
