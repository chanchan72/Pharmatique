using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MVC.Libreria.EntidadesNegocio
{
    public class beArchivo
    {
        public string CADENA_CARGUE { get; set; }
        public HttpPostedFileBase[] FILES_CARGUE { get; set; }
    }
}
