using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Librerias.EntidadesNegocio
{
    public class beGrafico
    {
        public string CODIGO { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public string CERRADO { get; set; }
        public int ID_CURSO_OMI { get; set; }
        public int ID_CURSOS_IMPARTIDOS { get; set; }

        //"D"."CODIGO","D"."DESCRIPCION","A"."CERRADO","B"."ID_CURSO_OMI","A"."ID_CURSOS_IMPARTIDOS"
    }
}
