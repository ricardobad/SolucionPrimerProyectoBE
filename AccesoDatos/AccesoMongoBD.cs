using AccesoDatos.Interfaz;
using Entidades;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccesoDatos
{

    public class AccesoMongoBD : IAccesoMongoBD
    {
        #region Atributos

        //crear string de conexion
        //private readonly string CadenaConexion = @"mongodb+srv://gfft3553:checha2023@cluster0.lz3frbv.mongodb.net/Seguridad?retryWrites=true&w=majority";
        private readonly string CadenaConexion = @"mongodb+srv://test:Test1234@cluster0.nzjknk8.mongodb.net/?retryWrites=true&w=majority";

        //@"mongodb://localhost:27017/";



        //crear instancia para conectar a base de datos
        private MongoClient InstanciaBD;
        private IMongoDatabase BaseDatos;

        //crear constante con el nombre de la base de datos
        private const string NombreBD = "Seguridad";
        #endregion

        #region Metodos

        #region Privados 

        private void EstablecerConexion()
        {
            try
            {
                //inicializar variables de base de datos y conexion
                InstanciaBD = new MongoClient(CadenaConexion);
                BaseDatos = InstanciaBD.GetDatabase(NombreBD);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region publicos

        //metodo para agregar un usuario a mongoBD
        //return true = correcto false= error
        public bool Agregar(Reportes P_Reporte)
        {
            bool resultado = false;
            try
            {
                EstablecerConexion();

                //se crea un objeto conexion que tendra la informacion de la coleccion que se indique.
                var Coleccion = BaseDatos.GetCollection<Reportes>("Reporte");
                //se ejecuta el metodo que guarda el objeto usuario en base de datos.
                Coleccion.InsertOne(P_Reporte);
                resultado = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (InstanciaBD != null)
                    InstanciaBD = null;
                if (BaseDatos != null)
                    BaseDatos = null;
            }
            return resultado;
        }

       

        //metodo para consultar los usuarios registrados en base de datos
        //return entidad lista de tipo usuario
        public List<Reportes> Consultar()
        {

            try
            {
                EstablecerConexion();

                //se crea un objeto conexion que tendra la informacion de la coleccion que se indique.
                var Coleccion = BaseDatos.GetCollection<Reportes>("Reporte");
                //se ejecuta el metodo que guarda el objeto usuario en base de datos.
                // d = funciones especificas que se tienen a disposicion para buscar en una base de datos.
                List<Reportes> lista = Coleccion.Find(d => true).ToList();
                //para ordernar alfabeticamente
                return lista.OrderBy(x => x.Id_reporte).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (InstanciaBD != null)
                    InstanciaBD = null;
                if (BaseDatos != null)
                    BaseDatos = null;
            }
        }


        //metodo para obtener la informacion usuarios de un usuario por ID
        //return entidad lista de tipo usuario
        public Reportes ConsultarPorID(Reportes P_Reporte)
        {

            try
            {
                EstablecerConexion();

                //se crea un objeto conexion que tendra la informacion de la coleccion que se indique.
                var Coleccion = BaseDatos.GetCollection<Reportes>("Reporte");
                //se ejecuta el metodo que guarda el objeto usuario en base de datos.
                // d = funciones especificas que se tienen a disposicion para buscar en una base de datos.
                return Coleccion.Find(d => d.Id_reporte == P_Reporte.Id_reporte).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (InstanciaBD != null)
                    InstanciaBD = null;
                if (BaseDatos != null)
                    BaseDatos = null;
            }
        }
        #endregion

        #endregion
    }
}
