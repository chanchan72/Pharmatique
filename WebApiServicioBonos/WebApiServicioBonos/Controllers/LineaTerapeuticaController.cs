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
    public class LineaTerapeuticaController : ApiController
    {
      
        public string ListarLineaTerapeutica()
        {
            string sb = "";
            brLineaTerapeutica obrLineaTerapeutica = new brLineaTerapeutica();
            List<beDataColumn> campos = new List<beDataColumn>();
            campos.Add(new beDataColumn { Campo = "ID_LineaTerapeutica", Titulo = "Id LineaTerapeutica", Ancho = 10 });
            campos.Add(new beDataColumn { Campo = "NOMBRE_LineaTerapeutica", Titulo = "Nombre", Ancho = 70 });
            campos.Add(new beDataColumn { Campo = "ESTADO", Titulo = "Estado", Ancho = 20 });
            List<beLineaTerapeutica> lstObeLineaTerapeutica = obrLineaTerapeutica.ListarLineaTerapeutica();
            if (lstObeLineaTerapeutica != null)
            {
                if (lstObeLineaTerapeutica.Count() > 0)
                {
                    sb = (CSV.SerializarCamposLista(lstObeLineaTerapeutica, '|', ';', true, campos));
                }
            }
            return sb;
        }

       

        public string GuardarLineaTerapeutica()
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

            //    beLineaTerapeutica obeLineaTerapeutica = new beLineaTerapeutica();
            //    string[] camposLineaTerapeutica = rpta.Split('|');

            //    obeLineaTerapeutica.ID_LineaTerapeutica = int.Parse(camposLineaTerapeutica[0]);
            //    obeLineaTerapeutica.NOMBRE_LineaTerapeutica = camposLineaTerapeutica[1].ToString();

            //    brLineaTerapeutica obrLineaTerapeutica = new brLineaTerapeutica();
            //    if (obeLineaTerapeutica.ID_LineaTerapeutica == 0)
            //    {
            //        int idLineaTerapeutica = obrLineaTerapeutica.AdicionarLineaTerapeutica(obeLineaTerapeutica,obeDatosUsuario.Usuario);
            //        if (idLineaTerapeutica > 0) retorno = "Se Adiciono el LineaTerapeutica";
            //        else retorno = "No se pudo adicionar el LineaTerapeutica";
            //    }
            //    else
            //    {
            //        bool exito = obrLineaTerapeutica.ActualizarLineaTerapeutica(obeLineaTerapeutica,obeDatosUsuario.Usuario);
            //        if (exito) retorno = "Se actualizo el LineaTerapeutica";
            //        else retorno = "No se pudo actualizar el LineaTerapeutica";
            //    }

            //    sb += ListarLineaTerapeutica() + "¬" + retorno;

            //}
            return sb;
        }

        public string CambioEstado(string Estado, string IdLineaTerapeutica)
        {
            string sb = "";
            string mensaje = "";
            //brLineaTerapeutica obrLineaTerapeutica = new brLineaTerapeutica();
            //beUsuario obeDatosUsuario = new beUsuario();
            //obeDatosUsuario = (HttpContext.Session["usuario"] as beUsuario);
            //bool respuesta = obrLineaTerapeutica.ActualizarEstado(Convert.ToInt32(IdLineaTerapeutica), Estado, obeDatosUsuario.Usuario);
            //if (respuesta) mensaje = "Se logro el cambio de estado con exito.";
            //else mensaje = "No se pudo hacer el cambio de estado.";
            //sb = ListarLineaTerapeutica() + "¬" + mensaje;
            return sb;
        }
    }
}