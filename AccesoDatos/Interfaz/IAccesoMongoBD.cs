using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace AccesoDatos.Interfaz
{
    public interface IAccesoMongoBD
    {
        bool Agregar(Reportes P_Reporte);

        List<Reportes> Consultar();
        Reportes ConsultarPorID(Reportes P_Reporte);
    }
}
