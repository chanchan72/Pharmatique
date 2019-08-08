using System;

namespace MVC.Librerias.EntidadesNegocio
{
    public class beCursosSucursal
    {
        public int ID_CURSO_SUCURSAL { get; set; }
        public string OBSERVACION { get; set; }
        public int ID_CURSO_OMI { get; set; }
        public int ID_SUCURSAL { get; set; }
        public int ID_ESTADO { get; set; }
        public string DESCRIPCION_CURSO { get; set; }
        public string DESCRIPCION_SUCURSAL { get; set; }
        public string DESCRIPCION_ESTADO { get; set; }
    }
}
