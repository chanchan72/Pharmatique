using System;
namespace MVC.Librerias.EntidadesNegocio
{
    public class beUsuario
    {
        public int ID_LOGIN { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public string LOGIN_NAME { get; set; }
        public string PASSWORD { get; set; }
        public string CORREO { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public DateTime FECHA_MODIFICACION { get; set; }
        public int NUMERO_INTENTOS { get; set; }
        public int ID_UNIDAD { get; set; }
        public int ID_ESTADO { get; set; }
        public string DESCRIPCION_ESTADO_USUARIO { get; set; }
        public int ID_TIPO_ESTADO { get; set; }
        public string DESCRIPCION_TIPO_ESTADO { get; set; }
        public string NOMBRE_UNIDAD { get; set; }
        public string SIGLA { get; set; }
        public int ID_ESTADO_UNIDAD { get; set; }
        public string DESCRIPCION_ESTADO_UNIDAD { get; set; }
        public int ID_PADRE { get; set; }
        public string NOMBRE_UNIDAD_PADRE { get; set; }
        public int ID_ESTADO_UNIDAD_PADRE { get; set; }
        public string DESCRIPCION_ESTADO_UNIDAD_PADRE { get; set; }
        public int ID_USUARIO_REGISTRO { get; set; }
    }
}
