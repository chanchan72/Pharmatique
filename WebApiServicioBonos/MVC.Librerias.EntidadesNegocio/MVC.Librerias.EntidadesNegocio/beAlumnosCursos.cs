using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Librerias.EntidadesNegocio
{
    public class beAlumnosCursos
    {
        public List<beAlumnos> Alumnos { get; set; }
        public List<beCursosImpartidos> ListaCursos { get; set; }
        public List<beCentrosFormacion> ListaCentrosFormacion { get; set; }
        public List<beCursosSucursal> ListaCursosSucursal { get; set; }
        public List<beInstructor> ListaInstructores { get; set; }
        public List<beSucursal> ListaSucursales { get; set; }
        public List<beSucursalInstructor> ListaSucursalInstructor { get; set; }
        public List<beTipoCurso> ListaTipoCurso { get; set; }
        public List<beCursosOmi> ListaCursoOMI { get; set; }
    }
}
