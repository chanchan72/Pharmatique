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
    public class EntidadController : ApiController
    {
        
        public string ListarEntidad()
        {
            string sb = "";
            brEntidad obrEntidad = new brEntidad();
            List<beDataColumn> campos = new List<beDataColumn>();
            campos.Add(new beDataColumn { Campo = "ID_Entidad", Titulo = "Id Entidad", Ancho = 10 });
            campos.Add(new beDataColumn { Campo = "NOMBRE_Entidad", Titulo = "Nombre", Ancho = 70 });
            campos.Add(new beDataColumn { Campo = "ESTADO", Titulo = "Estado", Ancho = 20 });
            List<beEntidad> lstObeEntidad = obrEntidad.ListarEntidad();
            if (lstObeEntidad != null)
            {
                if (lstObeEntidad.Count() > 0)
                {
                    sb = (CSV.SerializarCamposLista(lstObeEntidad, '|', ';', true, campos));
                }
                else
                {
                    sb = "Id Entidad|Nombre|Estado;10|70|20";
                }
            }

            return sb;
        }

        

        
        public string GuardarEntidad()
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

            //    beEntidad obeEntidad = new beEntidad();
            //    string[] camposEntidad = rpta.Split('|');

            //    obeEntidad.ID_Entidad = int.Parse(camposEntidad[0]);
            //    obeEntidad.NOMBRE_Entidad = camposEntidad[1].ToString();

            //    brEntidad obrEntidad = new brEntidad();
            //    if (obeEntidad.ID_Entidad == 0)
            //    {
            //        int idEntidad = obrEntidad.AdicionarEntidad(obeEntidad,obeDatosUsuario.Usuario);
            //        if (idEntidad > 0) retorno = "Se Adiciono el Entidad";
            //        else retorno = "No se pudo adicionar el Entidad";
            //    }
            //    else
            //    {
            //        bool exito = obrEntidad.ActualizarEntidad(obeEntidad,obeDatosUsuario.Usuario);
            //        if (exito) retorno = "Se actualizo el Entidad";
            //        else retorno = "No se pudo actualizar el Entidad";
            //    }

            //    sb += ListarEntidad() + "¬" + retorno;

            //}
            return sb;
        }

        public string CambioEstado(string Estado, string IdEntidad)
        {
            string sb = "";
            string mensaje = "";
            brEntidad obrEntidad = new brEntidad();
            //beUsuario obeDatosUsuario = new beUsuario();
            //obeDatosUsuario = (HttpContext.Session["usuario"] as beUsuario);
            //bool respuesta = obrEntidad.ActualizarEstado(Convert.ToInt32(IdEntidad), Estado, obeDatosUsuario.Usuario);

            //if (respuesta) mensaje = "Se logro el cambio de estado con exito.";
            //else mensaje = "No se pudo hacer el cambio de estado.";


            //sb = ListarEntidad() + "¬" + mensaje;
            return sb;
        }

        public string GuardarCargueMasivo(beArchivo obeArchivo)
        {
            string retorno = "";
            string mensaje = "";
            brEntidad obrEntidad = new brEntidad();

            byte[] Data = new byte[obeArchivo.FILES_CARGUE[0].ContentLength];
            obeArchivo.FILES_CARGUE[0].InputStream.Read(Data, 0, obeArchivo.FILES_CARGUE[0].ContentLength);


            int idCursoImp = obrEntidad.CargueMasivo(obeArchivo.CADENA_CARGUE);
            if (idCursoImp > 0) mensaje = "Se logro el cargue masivo con exito.";
            else mensaje = "No se pudo hacer el cargo masivo.";
            retorno = ListarEntidad() + "¬" + mensaje;
            return retorno;
        }
    }
}