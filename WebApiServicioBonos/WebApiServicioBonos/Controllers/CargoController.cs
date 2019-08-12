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
    public class CargoController : ApiController
    {
        
        public string ListarCargo()
        {
            string sb = "";
            brCargo obrCargo = new brCargo();
            List<beDataColumn> campos = new List<beDataColumn>();
            campos.Add(new beDataColumn { Campo = "ID_Cargo", Titulo = "Id Cargo", Ancho = 10 });
            campos.Add(new beDataColumn { Campo = "NOMBRE_Cargo", Titulo = "Nombre", Ancho = 70 });
            campos.Add(new beDataColumn { Campo = "ESTADO", Titulo = "Estado", Ancho = 20 });
            List<beCargo> lstObeCargo = obrCargo.ListarCargo();
            if (lstObeCargo != null)
            {
                if (lstObeCargo.Count() > 0)
                {
                    sb = (CSV.SerializarCamposLista(lstObeCargo, '|', ';', true, campos));
                }
            }
            return sb;
        }

        

        
        public string GuardarCargo()
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

            //    beCargo obeCargo = new beCargo();
            //    string[] camposCargo = rpta.Split('|');

            //    obeCargo.ID_Cargo = int.Parse(camposCargo[0]);
            //    obeCargo.NOMBRE_Cargo = camposCargo[1].ToString();

            //    brCargo obrCargo = new brCargo();
            //    if (obeCargo.ID_Cargo == 0)
            //    {
            //        int idCargo = obrCargo.AdicionarCargo(obeCargo,obeDatosUsuario.Usuario);
            //        if (idCargo > 0) retorno = "Se Adiciono el Cargo";
            //        else retorno = "No se pudo adicionar el Cargo";
            //    }
            //    else
            //    {
            //        bool exito = obrCargo.ActualizarCargo(obeCargo,obeDatosUsuario.Usuario);
            //        if (exito) retorno = "Se actualizo el Cargo";
            //        else retorno = "No se pudo actualizar el Cargo";
            //    }

            //    sb += ListarCargo() + "¬" + retorno;

            //}
            return sb;
        }

        public string CambioEstado(string Estado, string IdCargo)
        {
            string sb = "";
            string mensaje = "";
            //brCargo obrCargo = new brCargo();
            //beUsuario obeDatosUsuario = new beUsuario();
            //obeDatosUsuario = (HttpContext.Session["usuario"] as beUsuario);
            //bool respuesta = obrCargo.ActualizarEstado(Convert.ToInt32(IdCargo), Estado, obeDatosUsuario.Usuario);
            //if (respuesta) mensaje = "Se logro el cambio de estado con exito.";
            //else mensaje = "No se pudo hacer el cambio de estado.";
            //sb = ListarCargo() + "¬" + mensaje;
            return sb;
        }
    }
}