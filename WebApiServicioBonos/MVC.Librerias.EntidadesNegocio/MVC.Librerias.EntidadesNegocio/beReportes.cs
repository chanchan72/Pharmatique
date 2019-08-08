using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Librerias.EntidadesNegocio
{
    public class beReportes
    {
        //cursoimpartido
        public int ID_CURSO { get; set; }
        public string FECHA_INICIO_CURSO { get; set; }
        public string FECHA_FIN_CURSO { get; set; }
        public int CANTIDAD_ALUMNOS_CURSO { get; set; }
        public string SEDE_CURSO { get; set; }
        public string CERRADO_CURSO { get; set; }
        public string FECHA_REG_CURSO { get; set; }
        public string FECHA_CIERRE_CURSO { get; set; }
        //datosalumnos
        public string NOMBRE_ALUMNO { get; set; }
        public string NUM_IDENTIFICA_ALUMNO { get; set; }
        public string TIPO_DOC_ALUMNO { get; set; }
        public string APROBO_CURSO { get; set; }        
        //cursoomi
        public string DESCRIPCION_CURSO_OMI { get; set; }
        public string EXPIDE_CERTIFICADO_CURSO { get; set; }
        //sucusal
        public string NOMBRE_SUCURSAL { get; set; }
        //centro formacion
        public string NOMBRE_CENTRO_FORMACION { get; set; }
        //instructores
        public string NOMBRES_INSTRUCTOR { get; set; }
        public string NUM_IDENTIFICACION_INSTRUCTOR { get; set; }
    }
}
