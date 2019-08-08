using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MVC.Librerias.EntidadesNegocio
{
    public class beReportesAdmin
    {
        public int ID_CURSOS_IMPARTIDOS{ get; set; }
        public DateTime FECHA_INICIO { get; set; }
        public DateTime FECHA_FIN { get; set; }
        public int CANTIDAD_ALUMNOS { get; set; }
        public string CERRADO { get; set; }
        public string NOMBRE_INSTRUCTOR { get; set; }
        public string NOMBRE_CENTRO_FORMACION { get; set; }
        public string NOMBRE_SUCURSAL { get; set; }
        public string DESCRIPCION { get; set; }
        public string DESCRIPCION_INGLES { get; set; }
        public int INTENSIDAD_HORARIA { get; set; }
        public DateTime FECHA_CIERRE { get; set; }
            

        public List<beCentrosFormacion> ListaCentrosFormacion { get; set; }
        public List<beSucursal> ListaSucursales { get; set; }
        public List<beCursosOmi> ListaCursoOMI { get; set; }
        public List<beCursosSucursal> ListaCursosSucursal { get; set; } 
        public List<beInstructor> ListaInstructores { get; set; }
        public List<beSucursalInstructor> ListaSucursalInstructor { get; set; }
        public List<beTipoCurso> ListaTipoCurso { get; set; }
        public List<beTipoDocumento> ListaDocumento { get; set; }

    }
}
