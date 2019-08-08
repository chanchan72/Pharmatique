using System;
using io = System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using General.Librerias.EntidadesNegocio;
using Genaral.Librerias.CodigoUsuario;
using MVC.Libreria.EntidadesNegocio;
using MVC.Libreria.ReglasNegocio;
using System.Web.Http;

namespace Desarrollo_GDG_Migracion.Controllers
{
    public class CanalController : ApiController
    {
        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: ListarPais
        /// Función: Enviar a la vista los datos serializados de la información de los paises 
        /// Retorno: Variable "sb" de tipo "string"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
        public string ListarCanal()
        {
            string sb = "";
            brCanal obrCanal = new brCanal();
            List<beDataColumn> campos = new List<beDataColumn>();
            campos.Add(new beDataColumn { Campo = "ID_Canal", Titulo = "Id Canal", Ancho = 10 });
            campos.Add(new beDataColumn { Campo = "NOMBRE_Canal", Titulo = "Nombre", Ancho = 70 });
            campos.Add(new beDataColumn { Campo = "ESTADO", Titulo = "Estado", Ancho = 20 });
            List<beCanal> lstObeCanal = obrCanal.ListarCanal();
            if (lstObeCanal != null)
            {
                if (lstObeCanal.Count() > 0)
                {
                    sb = (CSV.SerializarCamposLista(lstObeCanal, '|', ';', true, campos));
                }
            }
            return sb;
        }

        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: GuardarPais
        /// Función: Recibe los datos de la vista, los guarda en un objeto de tipo "bePais" y si el id del pais viene 
        ///          vacio envia a insertar el dato, sino lo envia a actualizar. 
        /// Retorno: Variable "sb" de tipo "string"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>

        public string GuardarCanal()
        {
            string rpta = "";
            string retorno = "";
            string sb = "";
            //beUsuario obeDatosUsuario = new beUsuario();
            //obeDatosUsuario = (HttpContext.Session["usuario"] as beUsuario);
            //int n = (int)Request.InputStream.Length;
            //if (n > 0)
            //{
            //    io.Stream flujo = Request.InputStream;
            //    io.StreamReader lector = new io.StreamReader(flujo);
            //    rpta = lector.ReadToEnd();

            //    beCanal obeCanal = new beCanal();
            //    string[] camposCanal = rpta.Split('|');

            //    obeCanal.ID_Canal = int.Parse(camposCanal[0]);
            //    obeCanal.NOMBRE_Canal = camposCanal[1].ToString();

            //    brCanal obrCanal = new brCanal();
            //    if (obeCanal.ID_Canal == 0)
            //    {
            //        int idCanal = obrCanal.AdicionarCanal(obeCanal,obeDatosUsuario.Usuario);
            //        if (idCanal > 0) retorno = "Se Adiciono el Canal";
            //        else retorno = "No se pudo adicionar el Canal";
            //    }
            //    else
            //    {
            //        bool exito = obrCanal.ActualizarCanal(obeCanal,obeDatosUsuario.Usuario);
            //        if (exito) retorno = "Se actualizo el Canal";
            //        else retorno = "No se pudo actualizar el Canal";
            //    }

            //    sb += ListarCanal() + "¬" + retorno;

            //}
            return sb;
        }

        public string CambioEstado(string Estado, string IdCanal)
        {
            string sb = "";
            string mensaje = "";
            //brCanal obrCanal = new brCanal();
            //beUsuario obeDatosUsuario = new beUsuario();
            //obeDatosUsuario = (HttpContext.Session["usuario"] as beUsuario);
            //bool respuesta = obrCanal.ActualizarEstado(Convert.ToInt32(IdCanal), Estado, obeDatosUsuario.Usuario);
            //if (respuesta) mensaje = "Se logro el cambio de estado con exito.";
            //else mensaje = "No se pudo hacer el cambio de estado.";
            //sb = ListarCanal() + "¬" + mensaje;
            return sb;
        }
    }
}