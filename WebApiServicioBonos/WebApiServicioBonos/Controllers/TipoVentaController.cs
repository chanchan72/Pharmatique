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
    public class TipoVentaController : ApiController
    {
        
        public string ListarTipoVenta()
        {
            string sb = "";
            brTipoVenta obrTipoVenta = new brTipoVenta();
            List<beDataColumn> campos = new List<beDataColumn>();
            campos.Add(new beDataColumn { Campo = "ID_TipoVenta", Titulo = "Id TipoVenta", Ancho = 10 });
            campos.Add(new beDataColumn { Campo = "NOMBRE_TipoVenta", Titulo = "Nombre", Ancho = 70 });
            campos.Add(new beDataColumn { Campo = "ESTADO", Titulo = "Estado", Ancho = 10 });
            //ESTADO
            List<beTipoVenta> lstObeTipoVenta = obrTipoVenta.ListarTipoVenta();
            if (lstObeTipoVenta != null)
            {
                if (lstObeTipoVenta.Count() > 0)
                {
                    sb = (CSV.SerializarCamposLista(lstObeTipoVenta, '|', ';', true, campos));
                }
                else
                {
                    sb = "Id TipoVenta|Nombre|Estado;10|70|20";
                }
            }

            return sb;
        }

       

        
        public string GuardarTipoVenta()
        {
            string rpta = "";
            string retorno = "";
            string sb = "";

            //beUsuario obeDatosUsuario = new beUsuario();
            //obeDatosUsuario = (HttpContext.Session["usuario"] as beUsuario);
            //int n = (int)Request.InputStream.Length;
            if (1 > 0)
            {
                //io.Stream flujo = Request.InputStream;
                //io.StreamReader lector = new io.StreamReader(flujo);
                //rpta = lector.ReadToEnd();

                beTipoVenta obeTipoVenta = new beTipoVenta();
                string[] camposTipoVenta = rpta.Split('|');

                obeTipoVenta.ID_TipoVenta = int.Parse(camposTipoVenta[0]);
                obeTipoVenta.NOMBRE_TipoVenta = camposTipoVenta[1].ToString();
                obeTipoVenta.ESTADO = camposTipoVenta[2].ToString();

                brTipoVenta obrTipoVenta = new brTipoVenta();
                if (obeTipoVenta.ID_TipoVenta == 0)
                {
                    //int idTipoVenta = obrTipoVenta.AdicionarTipoVenta(obeTipoVenta,obeDatosUsuario.Usuario);
                    //if (idTipoVenta > 0) retorno = "Se Adiciono el TipoVenta";
                    //else retorno = "No se pudo adicionar el TipoVenta";
                }
                else
                {
                    //bool exito = obrTipoVenta.ActualizarTipoVenta(obeTipoVenta,obeDatosUsuario.Usuario);
                    //if (exito) retorno = "Se actualizo el TipoVenta";
                    //else retorno = "No se pudo actualizar el TipoVenta";
                }

                sb += ListarTipoVenta() + "¬" + retorno;

            }
            return sb;
        }

        public string CambioEstado(string Estado, string IdTipoVenta)
        {
            string sb = "";
            string mensaje = "";
            brTipoVenta obrTipoVenta = new brTipoVenta();
            //beUsuario obeDatosUsuario = new beUsuario();
            //obeDatosUsuario = (HttpContext.Session["usuario"] as beUsuario);
            //bool respuesta = obrTipoVenta.ActualizarEstado(Convert.ToInt32(IdTipoVenta), Estado, obeDatosUsuario.Usuario);
            //if (respuesta) mensaje = "Se logro el cambio de estado con exito.";
            //else mensaje = "No se pudo hacer el cambio de estado.";
            //sb = ListarTipoVenta() + "¬" + mensaje;
            return sb;
        }
    }
}