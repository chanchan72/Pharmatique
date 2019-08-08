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
    public class PresentacionController : ApiController
    {
        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: ListarPais
        /// Función: Enviar a la vista los datos serializados de la información de los paises 
        /// Retorno: Variable "sb" de tipo "string"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
        public string ListarPresentacion()
        {
            string sb = "";
            brPresentacion obrPresentacion = new brPresentacion();
            List<beDataColumn> campos = new List<beDataColumn>();
            campos.Add(new beDataColumn { Campo = "ID_Presentacion", Titulo = "Id Presentacion", Ancho = 10 });
            campos.Add(new beDataColumn { Campo = "NOMBRE_Presentacion", Titulo = "Nombre", Ancho = 70 });
            campos.Add(new beDataColumn { Campo = "ESTADO", Titulo = "Estado", Ancho = 20 });
            List<bePresentacion> lstObePresentacion = obrPresentacion.ListarPresentacion();
            if (lstObePresentacion != null)
            {
                if (lstObePresentacion.Count() > 0)
                {
                    sb = (CSV.SerializarCamposLista(lstObePresentacion, '|', ';', true, campos));
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

        
        public string GuardarPresentacion()
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

            //    bePresentacion obePresentacion = new bePresentacion();
            //    string[] camposPresentacion = rpta.Split('|');

            //    obePresentacion.ID_Presentacion = int.Parse(camposPresentacion[0]);
            //    obePresentacion.NOMBRE_Presentacion = camposPresentacion[1].ToString();


            //    brPresentacion obrPresentacion = new brPresentacion();
            //    if (obePresentacion.ID_Presentacion == 0)
            //    {
            //        int idPresentacion = obrPresentacion.AdicionarPresentacion(obePresentacion,obeDatosUsuario.Usuario);
            //        if (idPresentacion > 0) retorno = "Se Adiciono el Presentacion";
            //        else retorno = "No se pudo adicionar el Presentacion";
            //    }
            //    else
            //    {
            //        bool exito = obrPresentacion.ActualizarPresentacion(obePresentacion,obeDatosUsuario.Usuario);
            //        if (exito) retorno = "Se actualizo el Presentacion";
            //        else retorno = "No se pudo actualizar el Presentacion";
            //    }

            //    sb += ListarPresentacion() + "¬" + retorno;

            //}
            return sb;
        }


        public string CambioEstado(string Estado, string IdPresentacion)
        {
            string sb = "";
            string mensaje = "";
            //brPresentacion obrPresentacion = new brPresentacion();
            //beUsuario obeDatosUsuario = new beUsuario();
            //obeDatosUsuario = (HttpContext.Session["usuario"] as beUsuario);
            //bool respuesta = obrPresentacion.ActualizarEstado(Convert.ToInt32(IdPresentacion), Estado, obeDatosUsuario.Usuario);

            //if (respuesta) mensaje = "Se logro el cambio de estado con exito.";
            //else mensaje = "No se pudo hacer el cambio de estado.";


            //sb = ListarPresentacion() + "¬" + mensaje;
            return sb;
        }

        public string GuardarCargueMasivo(beArchivo obeArchivo)
        {
            string retorno = "";
            string mensaje = "";
            brPresentacion obrPresentacion = new brPresentacion();

            byte[] Data = new byte[obeArchivo.FILES_CARGUE[0].ContentLength];
            obeArchivo.FILES_CARGUE[0].InputStream.Read(Data, 0, obeArchivo.FILES_CARGUE[0].ContentLength);


            int idCursoImp = obrPresentacion.CargueMasivo(obeArchivo.CADENA_CARGUE);
            if (idCursoImp > 0) mensaje = "Se logro el cargue masivo con exito.";
            else mensaje = "No se pudo hacer el cargo masivo.";
            retorno = ListarPresentacion() + "¬" + mensaje;
            return retorno;
        }
    }
}