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
    /// <summary>
    /// Autor: Sebastian Mateus Villegas
    /// Nombre de la clase: PaisController 
    /// Función: Establece comunicacion con el javascript "jsPais.js" para el paso de datos a la vista 
    /// Fecha Documentación: 5 de abril de 2019
    /// </summary>
    public class PaisController : ApiController
    {
        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: ListarPais
        /// Función: Enviar a la vista los datos serializados de la información de los paises 
        /// Retorno: Variable "sb" de tipo "string"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
        public string ListarPais()
        {
            string sb = "";
            brPais obrPais = new brPais();
            List<beDataColumn> campos = new List<beDataColumn>();
            campos.Add(new beDataColumn { Campo = "ID_PAIS", Titulo = "Id Pais", Ancho = 10 });
            campos.Add(new beDataColumn { Campo = "NOMBRE_PAIS", Titulo = "Nombre", Ancho = 70 });
            campos.Add(new beDataColumn { Campo = "ESTADO", Titulo = "Estado", Ancho = 20 });
            List<bePais> lstObePais = obrPais.ListarPais();
            if (lstObePais != null)
            {
                if (lstObePais.Count() > 0)
                {
                    sb = (CSV.SerializarCamposLista(lstObePais, '|', ';', true, campos));
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

        
        public string GuardarPais()
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

            //    bePais obePais = new bePais();
            //    string[] camposPais = rpta.Split('|');

            //    obePais.ID_PAIS = int.Parse(camposPais[0]);
            //    obePais.NOMBRE_PAIS = camposPais[1].ToString();

            //    brPais obrPais = new brPais();
            //    if (obePais.ID_PAIS == 0)
            //    {
            //        int idPais = obrPais.AdicionarPais(obePais, obeDatosUsuario.Usuario);
            //        if (idPais > 0) retorno = "Se Adiciono el País";
            //        else retorno = "No se pudo adicionar el País";
            //    }
            //    else
            //    {
            //        bool exito = obrPais.ActualizarPais(obePais, obeDatosUsuario.Usuario);
            //        if (exito) retorno = "Se actualizo el país";
            //        else retorno = "No se pudo actualizar el País";
            //    }
              
            //        sb += ListarPais()+ "¬" + retorno;
                
            //}
            return sb;
        }

        //CambioEstado
        public string CambioEstado(string Estado,string IdPais)
        {
            string sb= "";
            string mensaje = "";
            //brPais obrPais = new brPais();
            //beUsuario obeDatosUsuario = new beUsuario();
            //obeDatosUsuario = (HttpContext.Session["usuario"] as beUsuario);
            //bool respuesta = obrPais.ActualizarEstado(Convert.ToInt32(IdPais),Estado,obeDatosUsuario.Usuario);

            //if (respuesta) mensaje = "Se logro el cambio de estado con exito.";
            //else mensaje = "No se pudo hacer el cambio de estado.";


            //sb = ListarPais() + "¬" + mensaje;
            return sb;
        }

        public string GuardarCargueMasivo(beArchivo obeArchivo)
        {
            string retorno = "";
            string mensaje = "";
            brPais obrPais = new brPais();

            byte[] Data = new byte[obeArchivo.FILES_CARGUE[0].ContentLength];
            obeArchivo.FILES_CARGUE[0].InputStream.Read(Data, 0, obeArchivo.FILES_CARGUE[0].ContentLength);
         

            int idCursoImp = obrPais.CargueMasivo(obeArchivo.CADENA_CARGUE);
            if (idCursoImp > 0) mensaje = "Se logro el cargue masivo con exito.";
            else mensaje = "No se pudo hacer el cargo masivo.";
            retorno = ListarPais() + "¬" + mensaje;
            return retorno;
        }
    }
}