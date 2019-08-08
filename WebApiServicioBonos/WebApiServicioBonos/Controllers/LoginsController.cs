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

namespace WebApiServicioBonos.Controllers
{
    public class LoginsController : ApiController
    {
        public beDatosUsuario ValidarExistenciaUsuarioAplicacion(beLogin obeLogin)
        {
            beDatosUsuario obeDatosUsuario = new beDatosUsuario();
            brUsuarios obrUsuarios = new brUsuarios();
            obeDatosUsuario = obrUsuarios.ObtenerListas(obeLogin);
            return obeDatosUsuario;
        }

    }
}
