using System;

namespace MVC.Librerias.EntidadesNegocio
{
    public class beInstructor
    {
        public int ID_INSTRUCTOR { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public string NUMERO_IDENTIFICACION { get; set; }
        public string DESCRIPCION_TIPO_DOCUMENTO { get; set; }  
        public string RESOLUCION { get; set; }
        public DateTime FECHA_REGISTRO { get; set; }
        public string DESCRIPCION_ESTADO { get; set; }
        public int ID_ESTADO { get; set; }
        public int ID_TIPO_DOCUMENTO { get; set; }
    }
}
