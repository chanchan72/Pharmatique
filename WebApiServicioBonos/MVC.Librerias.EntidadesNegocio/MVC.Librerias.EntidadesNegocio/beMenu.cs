using System;

namespace MVC.Librerias.EntidadesNegocio
{
    public class beMenu
    {
        public int ID_MENU { get; set; }
        public string VISTA { get; set; }
        public string CONTROLADOR { get; set; }
        public string NOMBRE { get; set; }
        public int ID_PADRE { get; set; }
        public int ID_APLICACION { get; set; }
    }
}
