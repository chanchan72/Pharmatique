using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Libreria.EntidadesNegocio
{
    public class beDatosGerente
    {
        public List<beGerente> ListaGerentes { get; set; }
        public List<bePais> ListaPaises { get; set; }
        
        public List<beCiudad> ListaCiudad { get; set; } 
        public List<beDistrito> ListaDistrito { get; set; }
    }
}
