using System;
using System.Collections.Generic;

namespace MVC.Librerias.EntidadesNegocio
{
    public class beDatosIntructores
    {
        public List<beInstructor> ListaInstructores { get; set; }
        public List<beSucursal> ListaSucursales { get; set; }
        public List<beSucursalInstructor> ListaSucursalesInstructores { get; set; }
    }
}
