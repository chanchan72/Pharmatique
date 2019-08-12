using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using io = System.IO;
using System.Web;
using System.Web.Mvc;
using MVC.Librerias.EntidadesNegocio;
using General.Librerias.EntidadesNegocio;
using System.Text;
using MVC.Librerias.ReglasNegocio;
using System.Web.Security;
using Genaral.Librerias.CodigoUsuario;
using General.Librerias.Entidades.GestionUsuarios;

namespace WebApiServicioBonos.Controllers
{
    public class LoginsController : ApiController
    {
        public beDatosUsuario ValidarExistenciaUsuarioAplicacion(string LOGIN_NAME, string PASSWORD, string Aplicacion)
        {
            beLogin obeLogin = new beLogin();
            Encriptar encriptar = new Encriptar();
            obeLogin.UserName = LOGIN_NAME;
            obeLogin.Password = encriptar.EncriptarClaveUsuario(PASSWORD); 
            obeLogin.Aplicacion = Aplicacion;
            beDatosUsuario obeDatosUsuario = new beDatosUsuario();
            brUsuarios obrUsuarios = new brUsuarios();
            obeDatosUsuario = obrUsuarios.ObtenerListas(obeLogin);
            return obeDatosUsuario;
        }

    }
}
