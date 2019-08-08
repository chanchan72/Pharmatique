using System;
namespace General.Librerias.Entidades.GestionUsuarios
{
    public class beUsuariosRolesGestion
    {
        public int ID_ROL { get; set; }
        public string ROL { get; set; }
        public string DESCRIPCION { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public int ID_APLICACION { get; set; }
        public int ID_ESTADO { get; set; }
        public int ID_LOGIN_ROL { get; set; }
        public int ID_LOGIN { get; set; }     
    }
}
