using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Entidades
{
    public class SQLPeticiones
    {
        #region Propiedades

        public string Peticion { get; set; }
        public List<SqlParameter> ListaParametros { get; set; }

        #endregion

        #region Constructor        

        public SQLPeticiones()
        {
            Peticion = string.Empty;
            ListaParametros = new List<SqlParameter>();
        }

        #endregion
    }
}
