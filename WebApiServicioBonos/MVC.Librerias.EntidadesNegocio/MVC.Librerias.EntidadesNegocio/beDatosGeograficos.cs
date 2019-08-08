using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Libreria.EntidadesNegocio
{
    /// <summary>
    /// Autor: Sebastian Mateus Villegas
    /// Nombre de la clase: beDepartamento 
    /// Función: Objeto para contener toda la información relacionada con los datos geograficos para consultas 
    /// Fecha Documentación: 8 de abril de 2019
    /// </summary>
    public class beDatosGeograficos
    {
        public List<bePais> ListaPaises { get; set; }
        
        public List<beCiudad> ListaCiudades { get; set; }

    }
}
