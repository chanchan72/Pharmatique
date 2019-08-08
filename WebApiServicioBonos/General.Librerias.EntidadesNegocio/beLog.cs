using System;
namespace General.Librerias.EntidadesNegocio
{
    public class beLog
    {
        public string Usuario { get; set; }
        public string Aplicacion { get; set; }
        public DateTime FechaHora { get; set; }
        public string MensageError { get; set; }
        public string DetalleError { get; set; }
        public string IP_Cliente { get; set; }
    }
}
