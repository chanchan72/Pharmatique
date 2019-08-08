using System;
using System.Collections.Generic;

namespace MVC.Librerias.EntidadesNegocio
{
    public class beDatosCursosSucursal
    {
        public List<beCursosSucursal> ListaCursosSucursal { get; set; }
        public List<beCentrosFormacion> ListaCentro { get; set; }
        public List<beSucursal> ListaSucursal { get; set; }
        public List<beCursosOmi> ListaCursosOmi { get; set; }
    }
}
