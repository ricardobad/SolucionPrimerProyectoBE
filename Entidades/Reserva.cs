using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Reserva
    {
        #region Propiedades
        public int Id_reserva { get; set; }
        public int Id_habitacion { get; set; }
        public int Id_usuario { get; set; }
        public DateTime Fecha_inicio { get; set; }
        public DateTime Fecha_fin { get; set; }
        public string Estado { get; set; }

        #endregion

        #region Constructor

        public Reserva()
        {
            Id_reserva = 0;
            Id_habitacion = 0;
            Id_usuario = 0;
            Fecha_inicio = DateTime.Now;
            Fecha_fin = DateTime.Now;
            Estado = string.Empty;
        }

        #endregion

    }
}


  
  
   
  