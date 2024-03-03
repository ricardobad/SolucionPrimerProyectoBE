using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Pagos
    {
        #region Propiedades
        public int Id_pago { get; set; }
        public int Id_reserva { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha_pago { get; set; }
        public DateTime Fecha_Final { get; set; }

        public decimal Descuento { get; set; }

        public decimal Multa { get; set; }

        public decimal Total { get; set; }

        #endregion

        #region Constructor

        public Pagos()
        {
            Id_pago = 0;
            Id_reserva = 0;
            Monto = 0;
            Fecha_pago = DateTime.Now;
            Fecha_Final = DateTime.Now;
            Descuento = 0;
            Multa = 0;
            Total = 0;
        }

        #endregion
    }
}

