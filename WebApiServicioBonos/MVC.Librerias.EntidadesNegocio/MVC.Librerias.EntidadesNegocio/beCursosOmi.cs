using System;

namespace MVC.Librerias.EntidadesNegocio
{
    public class beCursosOmi
    {
        public int ID_CURSO_OMI { get; set; }
        public string DESCRIPCION { get; set; }
        public string DESCRIPCION_INGLES { get; set; }
        public string CODIGO { get; set; }
        public int INTENSIDAD_HORARIA { get; set; }
        public string REGLA { get; set; }
        public int ANEOS_VIGENCIA { get; set; }
        public int ID_ESTADO { get; set; }
        public string DESCRIPCION_ESTADO_CURSO_OMI { get; set; }
        public string SECCION { get; set; }
        public int EXPIDE_CERTIFICADO { get; set; }
    }
}
