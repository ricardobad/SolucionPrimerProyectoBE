using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Usuarios
    {

        #region Propiedades

        public  int Id_Usuario { get ; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public int Id_perfil { get; set; }

        #endregion


        #region Constructor 

        public Usuarios()
        {
            Id_Usuario = 0;
            Nombre = string.Empty;
            Contrasena = string.Empty;
            Id_perfil = 0;
        }


        #endregion
    }
}
