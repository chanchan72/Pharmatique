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
    public class MoleculaController : ApiController
    {
        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: ListarPais
        /// Función: Enviar a la vista los datos serializados de la información de los paises 
        /// Retorno: Variable "sb" de tipo "string"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
        public string ListarMolecula()
        {
            string sb = "";
            brMolecula obrMolecula = new brMolecula();
            List<beDataColumn> campos = new List<beDataColumn>();
            campos.Add(new beDataColumn { Campo = "ID_Molecula", Titulo = "Id Molecula", Ancho = 10 });
            campos.Add(new beDataColumn { Campo = "NOMBRE_Molecula", Titulo = "Nombre", Ancho = 70 });
            campos.Add(new beDataColumn { Campo = "ESTADO", Titulo = "Estado", Ancho = 20 });
            List<beMolecula> lstObeMolecula = obrMolecula.ListarMolecula();
            if (lstObeMolecula != null)
            {
                if (lstObeMolecula.Count() > 0)
                {
                    sb = (CSV.SerializarCamposLista(lstObeMolecula, '|', ';', true, campos));
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

       
        public string GuardarMolecula()
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

            //    beMolecula obeMolecula = new beMolecula();
            //    string[] camposMolecula = rpta.Split('|');

            //    obeMolecula.ID_Molecula = int.Parse(camposMolecula[0]);
            //    obeMolecula.NOMBRE_Molecula = camposMolecula[1].ToString();

            //    brMolecula obrMolecula = new brMolecula();
            //    if (obeMolecula.ID_Molecula == 0)
            //    {
            //        int idMolecula = obrMolecula.AdicionarMolecula(obeMolecula, obeDatosUsuario.Usuario);
            //        if (idMolecula > 0) retorno = "Se Adiciono el Molecula";
            //        else retorno = "No se pudo adicionar el Molecula";
            //    }
            //    else
            //    {
            //        bool exito = obrMolecula.ActualizarMolecula(obeMolecula, obeDatosUsuario.Usuario);
            //        if (exito) retorno = "Se actualizo el Molecula";
            //        else retorno = "No se pudo actualizar el Molecula";
            //    }

            //    sb += ListarMolecula() + "¬" + retorno;

            //}
            return sb;
        }

        public string CambioEstado(string Estado, string IdMolecula)
        {
            string sb = "";
            string mensaje = "";
            //brMolecula obrMolecula = new brMolecula();
            //beUsuario obeDatosUsuario = new beUsuario();
            //obeDatosUsuario = (HttpContext.Session["usuario"] as beUsuario);
            //bool respuesta = obrMolecula.ActualizarEstado(Convert.ToInt32(IdMolecula), Estado, obeDatosUsuario.Usuario);

            //if (respuesta) mensaje = "Se logro el cambio de estado con exito.";
            //else mensaje = "No se pudo hacer el cambio de estado.";


            //sb = ListarMolecula() + "¬" + mensaje;
            return sb;
        }


        public string GuardarCargueMasivo(beArchivo obeArchivo)
        {
            string retorno = "";
            string mensaje = "";
            brMolecula obrMolecula = new brMolecula();

            byte[] Data = new byte[obeArchivo.FILES_CARGUE[0].ContentLength];
            obeArchivo.FILES_CARGUE[0].InputStream.Read(Data, 0, obeArchivo.FILES_CARGUE[0].ContentLength);


            int idCursoImp = obrMolecula.CargueMasivo(obeArchivo.CADENA_CARGUE);
            if (idCursoImp > 0) mensaje = "Se logro el cargue masivo con exito.";
            else mensaje = "No se pudo hacer el cargo masivo.";
            retorno = ListarMolecula() + "¬" + mensaje;
            return retorno;
        }
    }
}