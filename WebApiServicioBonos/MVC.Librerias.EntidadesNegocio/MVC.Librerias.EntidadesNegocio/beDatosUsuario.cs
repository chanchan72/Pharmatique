using System;
using System.Collections.Generic;

namespace MVC.Librerias.EntidadesNegocio
{
    public class beDatosUsuario
    {
        public beUsuario Usuario { get; set; }
        public List<beRol> ListaRol { get; set; }
        public List<beMenu> ListaMenu { get; set; }
        public List<beEstado> ListaEstado { get; set; }
        public List<beTipoEstado> ListaTipoEstado { get; set; }
        public List<beUnidad> ListaUnidad { get; set; }
        public List<beDepartamento> ListaDepartamento { get; set; }
        public List<beMunicipio> ListaMunicipio { get; set; }
        public List<beTipoDocumento> ListaTipoDocumento { get; set; }

    }
}
