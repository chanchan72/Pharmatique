using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Libreria.EntidadesNegocio
{
    public class beGerente
    {
       public int ID_GERENTE_VENTAS { get; set; }
       public int CEDULA_GERENTE_VENTAS { get; set; }
       public string NOMBRE_GERENTE_VENTAS { get; set; }
       public string ESTADO { get; set; }
       public int ID_PAIS { get; set; }
       public string NOMBRE_PAIS { get; set; }
       public int ID_DEPTO { get; set; }
       public string NOMBRE_DEPARTAMENTO { get; set; }
       public int ID_CIUDAD { get; set; }
       public string NOMBRE_CIUDAD { get; set; }
       public int ID_DISTRITO { get; set; }
       public string NOMBRE_DISTRITO { get; set; }
       public string DIRECCION { get; set; }
       public string CORREO { get; set; }
       public string TELEFONO { get; set; }
       public DateTime CUMPLEANOS { get; set; }
       public string HOBBIES { get; set; }
    }
}
