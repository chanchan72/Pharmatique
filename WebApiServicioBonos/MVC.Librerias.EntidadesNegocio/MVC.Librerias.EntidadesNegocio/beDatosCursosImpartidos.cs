using System;
using System.Collections.Generic;

namespace MVC.Librerias.EntidadesNegocio
{
    public class beDatosCursosImpartidos
    {       
        public List<beCursosImpartidos> ListaCursosImpartidos { get; set; }
        public List<beCursosAsignados> ListaCursosAsignados { get; set; }
        public List<beInstructorAsignado> ListaInstructorAsignado { get; set; }
        public List<beTipoCurso> ListaTipoCurso { get; set; }
        public beAlumnos DatosAlumno { get; set; } 
    }
}
