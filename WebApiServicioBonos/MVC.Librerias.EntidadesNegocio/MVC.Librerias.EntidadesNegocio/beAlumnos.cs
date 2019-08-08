using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Librerias.EntidadesNegocio
{
    public class beAlumnos
    {
        public int ID_ALUMNOS { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public string NUMERO_IDENTIFICACION { get; set; }
        public int ID_TIPO_DOCUMENTO { get; set; }
        public int ID_CURSO_ALUMNO { get; set; }
        public int ID_CURSOS_IMPARTIDOS { get; set; }
        public int ID_TIPO_CURSO { get; set; }
        public string DESCRIPCION_TIPO_CURSO { get; set; }
        public string APROBO { get; set; }
        public string DESCRIPCION_TIPO_DOCUMENTO { get; set; }
    }
}