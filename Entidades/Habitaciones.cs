using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Habitaciones
    {
        #region Propiedades
        public int Id_habitacion { get; set; }
        public string Numero_habitacion { get; set; }
        public string Tipo_habitacion { get; set; }
        public int Precio { get; set; }
        public bool Ocupado { get; set; }

        #endregion

        #region Constructor

        public Habitaciones()
        {
            Id_habitacion = 0;
            Numero_habitacion = string.Empty;
            Tipo_habitacion = string.Empty;
            Precio = 0;
            Ocupado = false;
        }

        #endregion
    }
}
