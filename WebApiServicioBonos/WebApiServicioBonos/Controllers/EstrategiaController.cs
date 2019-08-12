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
    public class EstrategiaController : ApiController
    {
        
        public string ListarEstrategia()
        {
            string sb = "";
            brEstrategia obrEstrategia = new brEstrategia();
            List<beDataColumn> campos = new List<beDataColumn>();
            campos.Add(new beDataColumn { Campo = "ID_Estrategia", Titulo = "Id Estrategia", Ancho = 10 });
            campos.Add(new beDataColumn { Campo = "NOMBRE_Estrategia", Titulo = "Nombre", Ancho = 70 });
            campos.Add(new beDataColumn { Campo = "ESTADO", Titulo = "Estado", Ancho = 20 });
            List<beEstrategia> lstObeEstrategia = obrEstrategia.ListarEstrategia();
            if (lstObeEstrategia != null)
            {
                if (lstObeEstrategia.Count() > 0)
                {
                    sb = (CSV.SerializarCamposLista(lstObeEstrategia, '|', ';', true, campos));
                }
            }
            return sb;
        }

       
        
        public string GuardarEstrategia()
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

            //    beEstrategia obeEstrategia = new beEstrategia();
            //    string[] camposEstrategia = rpta.Split('|');

            //    obeEstrategia.ID_Estrategia = int.Parse(camposEstrategia[0]);
            //    obeEstrategia.NOMBRE_Estrategia = camposEstrategia[1].ToString();

            //    brEstrategia obrEstrategia = new brEstrategia();
            //    if (obeEstrategia.ID_Estrategia == 0)
            //    {
            //        int idEstrategia = obrEstrategia.AdicionarEstrategia(obeEstrategia,obeDatosUsuario.Usuario);
            //        if (idEstrategia > 0) retorno = "Se Adiciono el Estrategia";
            //        else retorno = "No se pudo adicionar el Estrategia";
            //    }
            //    else
            //    {
            //        bool exito = obrEstrategia.ActualizarEstrategia(obeEstrategia,obeDatosUsuario.Usuario);
            //        if (exito) retorno = "Se actualizo el Estrategia";
            //        else retorno = "No se pudo actualizar el Estrategia";
            //    }

            //    sb += ListarEstrategia() + "¬" + retorno;

            //}
            return sb;
        }

        public string CambioEstado(string Estado, string IdEstrategia)
        {
            string sb = "";
            string mensaje = "";
            //brEstrategia obrEstrategia = new brEstrategia();
            //beUsuario obeDatosUsuario = new beUsuario();
            //obeDatosUsuario = (HttpContext.Session["usuario"] as beUsuario);
            //bool respuesta = obrEstrategia.ActualizarEstado(Convert.ToInt32(IdEstrategia), Estado, obeDatosUsuario.Usuario);

            //if (respuesta) mensaje = "Se logro el cambio de estado con exito.";
            //else mensaje = "No se pudo hacer el cambio de estado.";


            //sb = ListarEstrategia() + "¬" + mensaje;
            return sb;
        }

        public string GuardarCargueMasivo(beArchivo obeArchivo)
        {
            string retorno = "";
            string mensaje = "";
            brEstrategia obrEstrategia = new brEstrategia();

            byte[] Data = new byte[obeArchivo.FILES_CARGUE[0].ContentLength];
            obeArchivo.FILES_CARGUE[0].InputStream.Read(Data, 0, obeArchivo.FILES_CARGUE[0].ContentLength);


            int idCursoImp = obrEstrategia.CargueMasivo(obeArchivo.CADENA_CARGUE);
            if (idCursoImp > 0) mensaje = "Se logro el cargue masivo con exito.";
            else mensaje = "No se pudo hacer el cargo masivo.";
            retorno = ListarEstrategia() + "¬" + mensaje;
            return retorno;
        }
    }
}