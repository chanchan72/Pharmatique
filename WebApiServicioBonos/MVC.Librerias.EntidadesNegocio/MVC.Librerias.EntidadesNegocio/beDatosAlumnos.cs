using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Librerias.EntidadesNegocio
{
    public class beDatosAlumnos
    {
        public List<beAlumnos> ListaAlumnos { get; set; }
        public List<beTipoCurso> ListabeTipoCurso { get; set; }
        public List<beTipoDocumento> ListaTipoDoc { get; set; }

    }
}
