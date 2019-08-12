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
    public class MarcaController : ApiController
    {
        
        public string ListarMarca()
        {
            string sb = "";
            brMarca obrMarca = new brMarca();
            List<beDataColumn> campos = new List<beDataColumn>();
            campos.Add(new beDataColumn { Campo = "ID_Marca", Titulo = "Id Marca", Ancho = 10 });
            campos.Add(new beDataColumn { Campo = "NOMBRE_Marca", Titulo = "Nombre", Ancho = 70 });
            campos.Add(new beDataColumn { Campo = "ESTADO", Titulo = "Estado", Ancho = 20 });
            List<beMarca> lstObeMarca = obrMarca.ListarMarca();
            if (lstObeMarca != null)
            {
                if (lstObeMarca.Count() > 0)
                {
                    sb = (CSV.SerializarCamposLista(lstObeMarca, '|', ';', true, campos));
                }
            }
            return sb;
        }

        

       
        public string GuardarMarca()
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

            //    beMarca obeMarca = new beMarca();
            //    string[] camposMarca = rpta.Split('|');

            //    obeMarca.ID_Marca = int.Parse(camposMarca[0]);
            //    obeMarca.NOMBRE_Marca = camposMarca[1].ToString();

            //    brMarca obrMarca = new brMarca();
            //    if (obeMarca.ID_Marca == 0)
            //    {
            //        int idMarca = obrMarca.AdicionarMarca(obeMarca,obeDatosUsuario.Usuario);
            //        if (idMarca > 0) retorno = "Se Adiciono el Marca";
            //        else retorno = "No se pudo adicionar el Marca";
            //    }
            //    else
            //    {
            //        bool exito = obrMarca.ActualizarMarca(obeMarca,obeDatosUsuario.Usuario);
            //        if (exito) retorno = "Se actualizo el Marca";
            //        else retorno = "No se pudo actualizar el Marca";
            //    }

            //    sb += ListarMarca() + "¬" + retorno;

            //}
            return sb;
        }

        public string CambioEstado(string Estado, string IdMarca)
        {
            string sb = "";
            string mensaje = "";
            //brMarca obrMarca = new brMarca();
            //beUsuario obeDatosUsuario = new beUsuario();
            //obeDatosUsuario = (HttpContext.Session["usuario"] as beUsuario);
            //bool respuesta = obrMarca.ActualizarEstado(Convert.ToInt32(IdMarca), Estado, obeDatosUsuario.Usuario);

            //if (respuesta) mensaje = "Se logro el cambio de estado con exito.";
            //else mensaje = "No se pudo hacer el cambio de estado.";


            //sb = ListarMarca() + "¬" + mensaje;
            return sb;
        }


        public string GuardarCargueMasivo(beArchivo obeArchivo)
        {
            string retorno = "";
            string mensaje = "";
            brMarca obrMarca = new brMarca();

            byte[] Data = new byte[obeArchivo.FILES_CARGUE[0].ContentLength];
            obeArchivo.FILES_CARGUE[0].InputStream.Read(Data, 0, obeArchivo.FILES_CARGUE[0].ContentLength);


            int idCursoImp = obrMarca.CargueMasivo(obeArchivo.CADENA_CARGUE);
            if (idCursoImp > 0) mensaje = "Se logro el cargue masivo con exito.";
            else mensaje = "No se pudo hacer el cargo masivo.";
            retorno = ListarMarca() + "¬" + mensaje;
            return retorno;
        }

    }
}