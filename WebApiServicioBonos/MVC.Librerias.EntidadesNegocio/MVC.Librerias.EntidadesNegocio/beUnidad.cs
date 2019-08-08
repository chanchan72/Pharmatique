using System;


namespace MVC.Librerias.EntidadesNegocio
{
    public class beUnidad
    {
        public int ID_UNIDAD { get; set; }
        public string NOMBRE { get; set; }
        public string SIGLA { get; set; }
        public int ID_PADRE { get; set; }
        public int ID_ESTADO { get; set; }
    }
}
