using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entidades
{
   public  class Reportes
    {
        #region Propiedades

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id_reporte { get; set; }

        //con este nombre se guarda en la base de datos mongo
        [BsonElement("Reporte")] //se coloca por encima de la propiedad a la que le queremos dar el nombre
        public string Reporte { get; set; }


        #endregion
        //contructor para iniciarlizar las variables
        #region Constructor

        public Reportes()
        {
            Id_reporte = string.Empty;
            Reporte = string.Empty;

        }

        #endregion
    }
}
