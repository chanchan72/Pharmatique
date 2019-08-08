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
using System.Configuration;
using System.Net.Http.Formatting;
using System.Net.Mail;

namespace WebApiServicioBonos.Controllers
{
    public class CambiarClaveController : ApiController
    {
        private string EncriptarClaves(string clave)
        {
            Encriptar encripataPass = new Encriptar();
            string claveEncriptada = string.Empty;

            claveEncriptada = encripataPass.EncriptarClaveUsuario(clave);

            return claveEncriptada;
        }

        private string DesencriptarClaves(string clave)
        {
            Encriptar encripataPass = new Encriptar();
            string claveDesencriptada = string.Empty;

            claveDesencriptada = encripataPass.DesencriptarClaveUsuario(clave);

            return claveDesencriptada;
        }

        public string CambiarClaveC()
        {
            //string rpta = "";
            //string retorno = "";
            string sb = "";
            //int n = (int)Request.InputStream.Length;
            //if (n > 0)
            //{
            //    io.Stream flujo = Request.InputStream;
            //    io.StreamReader lector = new io.StreamReader(flujo);
            //    rpta = lector.ReadToEnd();

            //    beCambioClave obeCambioClave = new beCambioClave();
            //    string[] camposClave = rpta.Split('|');

            //    obeCambioClave.LOGIN_NAME = camposClave[0].ToString();//  0
            //    //obeCambioClave.PasswordAnterior = camposClave[1].ToString();//1                
            //    //obeCambioClave.PasswordNuevo = camposClave[1].ToString();//2

            //    obeCambioClave.ConfirmarPassword = EncriptarClaves(camposClave[1].ToString());//3                                   

            //    brCambioClave obrCambioClave = new brCambioClave();
            //    //if (obeCambioClave.ID_USUARIO != 0)
            //    //{
            //    bool exito = obrCambioClave.ActualizarClave(obeCambioClave);
            //    if (exito) retorno = "Se actualizo Clave";
            //    else retorno = "No se pudo actualizar Clave";
            //    //}
            //}
            return sb;
        }
    }
}
