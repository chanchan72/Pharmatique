using System;
using System.Collections.Generic;

namespace MVC.Librerias.EntidadesNegocio
{
    public class beCursosAlumnos
    {
        public int ID_CURSO_ALUMNO { get; set; }
        public string APROBO { get; set; }
        public string CODIGO_CERTIFICADO { get; set; }
        public int ID_CURSOS_IMPARTIDOS { get; set; }
        public int ID_ALUMNOS { get; set; }
        public int ID_TIPO_CURSO { get; set; }
    }
}
