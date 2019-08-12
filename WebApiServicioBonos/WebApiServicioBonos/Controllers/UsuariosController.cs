using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using io = System.IO;
using System.Web;
using System.Web.Mvc;
using MVC.Librerias.EntidadesNegocio;
using General.Librerias.EntidadesNegocio;
using System.Text;
using MVC.Librerias.ReglasNegocio;
using System.Web.Security;
using Genaral.Librerias.CodigoUsuario;
using General.Librerias.Entidades.GestionUsuarios;
using System.Configuration;
using System.Net.Http.Formatting;
using System.Net.Mail;

namespace WebApiServicioBonos.Controllers
{
    public class UsuariosController : ApiController
    {
        private readonly string mail = ConfigurationManager.AppSettings["mail"];
        private readonly string pass = ConfigurationManager.AppSettings["com"];

        string claveN = "";


        public beLogin Index(beLogin obeLogin)
        {
            LoginsController loginsContr = new LoginsController();
            obeLogin.Aplicacion = ConfigurationManager.AppSettings["aplicacion"];

            //validar clave aqui
            if (obeLogin.Password != null)
            {
                Encriptar encriptar = new Encriptar();
                obeLogin.Password = encriptar.EncriptarClaveUsuario(obeLogin.Password);


                if (ModelState.IsValid)
                {
                    beDatosUsuario obeDatosUsuario = new beDatosUsuario();
                    obeDatosUsuario = loginsContr.ValidarExistenciaUsuarioAplicacion(obeLogin.UserName, obeLogin.Password, obeLogin.Aplicacion);
                    if (obeDatosUsuario.Usuario.LOGIN_NAME != null)
                    {
                        string centroUnidad = string.Empty;
                        centroUnidad = obeDatosUsuario.Usuario.NOMBRE_UNIDAD;
                        //HttpContext.Session["usuario"] = obeDatosUsuario;
                        //HttpContext.Session["nombreUsuario"] = obeDatosUsuario.Usuario.NOMBRES + ' ' + obeDatosUsuario.Usuario.APELLIDOS + " ( " + centroUnidad + " )";
                        //return obeDatosUsuario;
                    }
                    else
                        ModelState.AddModelError(string.Empty, "Las credenciales proporcionadas son incorrectas.");
                }
                else
                    ModelState.AddModelError(string.Empty, "El modelo no es valido.");


            }
            return obeLogin;
        }






        public string ListadoUsuarios()
        {
            StringBuilder sb = new StringBuilder();
            beDatosUsuario obeDatosUsuario = new beDatosUsuario();
            //obeDatosUsuario = (HttpContext.Session["usuario"] as beDatosUsuario);
            brUsuarios obrUsuarios = new brUsuarios();
            List<beDataColumn> campos = new List<beDataColumn>();
            campos.Add(new beDataColumn { Campo = "ID_LOGIN", Titulo = "Id Login", Ancho = 5 });
            campos.Add(new beDataColumn { Campo = "NOMBRES", Titulo = "Nombre", Ancho = 30 });
            campos.Add(new beDataColumn { Campo = "APELLIDOS", Titulo = "Apellidos", Ancho = 30 });
            campos.Add(new beDataColumn { Campo = "LOGIN_NAME", Titulo = "Usuario", Ancho = 15 });
            campos.Add(new beDataColumn { Campo = "DESCRIPCION_TIPO_ESTADO", Titulo = "Estado", Ancho = 10 });
            campos.Add(new beDataColumn { Campo = "DESCRIPCION_ESTADO_USUARIO", Titulo = "Activo", Ancho = 10 });
            campos.Add(new beDataColumn { Campo = "CORREO", Titulo = "Correo", Ancho = 0 });
            campos.Add(new beDataColumn { Campo = "FECHA_CREACION", Titulo = "Fecha Creacion", Ancho = 0 });
            campos.Add(new beDataColumn { Campo = "FECHA_MODIFICACION", Titulo = "Fecha Modificacion", Ancho = 0 });
            campos.Add(new beDataColumn { Campo = "NUMERO_INTENTOS", Titulo = "Numero Intentos", Ancho = 0 });
            campos.Add(new beDataColumn { Campo = "ID_UNIDAD", Titulo = "Id Unidad", Ancho = 0 });
            campos.Add(new beDataColumn { Campo = "ID_ESTADO", Titulo = "Id Estado", Ancho = 0 });
            campos.Add(new beDataColumn { Campo = "ID_TIPO_ESTADO", Titulo = "Id Tipo Estado", Ancho = 0 });
            campos.Add(new beDataColumn { Campo = "NOMBRE_UNIDAD", Titulo = "Unidad", Ancho = 0 });
            campos.Add(new beDataColumn { Campo = "SIGLA", Titulo = "Sigla", Ancho = 0 });
            campos.Add(new beDataColumn { Campo = "ID_ESTADO_UNIDAD", Titulo = "Id Estado Unidad", Ancho = 0 });
            campos.Add(new beDataColumn { Campo = "DESCRIPCION_ESTADO_UNIDAD", Titulo = "Unidad Activo", Ancho = 40 });
            campos.Add(new beDataColumn { Campo = "ID_PADRE", Titulo = "Id Padre", Ancho = 0 });
            campos.Add(new beDataColumn { Campo = "NOMBRE_UNIDAD_PADRE", Titulo = "Unidad Ordenadora", Ancho = 0 });
            campos.Add(new beDataColumn { Campo = "ID_ESTADO_UNIDAD_PADRE", Titulo = "Id Estado Unidad Padre", Ancho = 0 });
            campos.Add(new beDataColumn { Campo = "DESCRIPCION_ESTADO_UNIDAD_PADRE", Titulo = "Activa Unidad Ordenadora", Ancho = 0 });


            beDatosUsuariosGestion obeDatosUsuariosGestion = obrUsuarios.ListaUsuariosGestion();
            if (obeDatosUsuariosGestion != null)
            {
                if (obeDatosUsuariosGestion.ListaUsuarios != null && obeDatosUsuariosGestion.ListaUsuarios.Count() > 0)
                {
                    sb.Append(CSV.SerializarCamposLista(obeDatosUsuariosGestion.ListaUsuarios, '|', ';', true, campos));
                }
                sb.Append("¬");
                if (obeDatosUsuario.ListaEstado != null && obeDatosUsuario.ListaEstado.Count() > 0)
                {
                    sb.Append(CSV.SerializarLista(obeDatosUsuario.ListaEstado, '|', ';', false));
                }
                sb.Append("¬");
                if (obeDatosUsuariosGestion.ListaRoles != null && obeDatosUsuariosGestion.ListaRoles.Count() > 0)
                {
                    sb.Append(CSV.SerializarLista(obeDatosUsuariosGestion.ListaRoles, '|', ';', false));
                }
                sb.Append("¬");
                if (obeDatosUsuariosGestion.ListaUsuariosRoles != null && obeDatosUsuariosGestion.ListaUsuariosRoles.Count() > 0)
                {
                    sb.Append(CSV.SerializarLista(obeDatosUsuariosGestion.ListaUsuariosRoles, '|', ';', false));
                }
                sb.Append("¬");
                if (obeDatosUsuario.ListaUnidad != null && obeDatosUsuario.ListaUnidad.Count() > 0)
                {
                    sb.Append(CSV.SerializarLista(obeDatosUsuario.ListaUnidad.Where(x => x.ID_ESTADO != 0).ToList(), '|', ';', false));
                }
                sb.Append("¬");
                if (obeDatosUsuario.ListaTipoEstado != null && obeDatosUsuario.ListaTipoEstado.Count() > 0)
                {
                    sb.Append(CSV.SerializarLista(obeDatosUsuario.ListaTipoEstado, '|', ';', false));
                }
                sb.Append("¬");

            }
            return sb.ToString();
        }

        public string ValidarUsuario(string loginName)
        {
            string sb = string.Empty;
            int idApliccion = -1;
            beDatosUsuarioAplicacionesGestion obeDatosUsuarioAplicacionesGestion = new beDatosUsuarioAplicacionesGestion();
            brUsuarios obrUsuarios = new brUsuarios();
            obeDatosUsuarioAplicacionesGestion = obrUsuarios.ValidarUsuario(loginName);

            List<string> campos = new List<string>();
            campos.Add("ID_LOGIN");
            campos.Add("NOMBRES");
            campos.Add("APELLIDOS");
            campos.Add("LOGIN_NAME");
            campos.Add("DESCRIPCION_TIPO_ESTADO");
            campos.Add("DESCRIPCION_ESTADO_USUARIO");
            campos.Add("CORREO");
            campos.Add("FECHA_CREACION");
            campos.Add("FECHA_MODIFICACION");
            campos.Add("NUMERO_INTENTOS");
            campos.Add("ID_UNIDAD");
            campos.Add("ID_ESTADO");
            campos.Add("ID_TIPO_ESTADO");
            campos.Add("NOMBRE_UNIDAD");
            campos.Add("SIGLA");
            campos.Add("ID_ESTADO_UNIDAD");
            campos.Add("DESCRIPCION_ESTADO_UNIDAD");
            campos.Add("ID_PADRE");
            campos.Add("NOMBRE_UNIDAD_PADRE");
            campos.Add("ID_ESTADO_UNIDAD_PADRE");
            campos.Add("DESCRIPCION_ESTADO_UNIDAD_PADRE");
            //campos.Add("OBSERVACIONES");

            if (obeDatosUsuarioAplicacionesGestion.Usuario.ID_LOGIN != 0)
            {
                idApliccion = obeDatosUsuarioAplicacionesGestion.ListaAplicacionesUsuario.Where(x => x.NOMBRE == ConfigurationManager.AppSettings["aplicacion"].ToString()).Select(x => x.ID_APLICACION).SingleOrDefault();
                if (idApliccion == 1)
                {
                    sb = "¬";
                    sb += "Existe";
                }
                else
                {
                    sb = CSV.SerializarObjeto(obeDatosUsuarioAplicacionesGestion.Usuario, '|', campos);
                    sb += "¬";
                    sb += "Otras";
                }
            }
            else
            {
                sb = "¬";
                sb += "No Existe";
            }
            return sb.ToString();
        }

        public string GrabarUsuario(string texto)
        {
            //StringBuilder sb = new StringBuilder();
            string sb = "";

            string rpta = "";
            string retorno = "";

            int n = (int)texto.Length;
            if (n > 0)
            {
                //io.Stream flujo = Request.InputStream;
                //io.StreamReader lector = new io.StreamReader(flujo);
                rpta = texto;

                string[] cadenaUsuario = rpta.Split('¬');
                string[] camposUsuario = cadenaUsuario[0].Split('|');
                string[] camposRolesAsignados = cadenaUsuario[1].Split('|');

                beDatosUsuario obeDatosUsuario = new beDatosUsuario();
               // obeDatosUsuario = (HttpContext.Session["usuario"] as beDatosUsuario);
                string[] datos = rpta.Split('¬');
                string[] camposUs = datos[0].Split('|');

                ////// ENVIAR CONTRASEÑA

                //ViewBag.mensaje = null;
                Random obj = new Random();//Creamos la instancia del objeto Random
                string Caracteres = "abcdefghijkmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789*+-/_"; //Caracteres que incluirá cada nueva combinación obtenida.
                int longitud = Caracteres.Length;
                char letra;
                int longitudnuevacadena = 7;//Obtenemos el numero de caracteres o la longitud de los posibles caracteres
                string NuevaPass = "";//Declaramos una nueva variable la cual contendrá la nueva combinación

                for (int i = 0; i < longitudnuevacadena; i++)//Ciclo for para tomar el carácter según el método Next de la variable con los caracteres posibles y así ir obteniendo uno a la vez e ir concatenándole a la cadena de salida el nuevo carácter obtenido.
                {
                    letra = Caracteres[obj.Next(longitud)];
                    NuevaPass += letra.ToString();
                }

                var ContraseniaEnc = EncriptarClaves(camposUsuario[3]);//encriptar nueva contraseña
                                                                       //obeRestablecer.contrasenia = ContraseniaEnc;
                                                                       // obeRestablecer.loginname = usuariow;

                //////
                beUsuarioGestion obeUsuarioGestion = new beUsuarioGestion();
                obeUsuarioGestion.ID_LOGIN = int.Parse(camposUsuario[0]);
                obeUsuarioGestion.NOMBRES = camposUsuario[1];
                obeUsuarioGestion.APELLIDOS = camposUsuario[2];
                obeUsuarioGestion.LOGIN_NAME = camposUsuario[3];
                obeUsuarioGestion.PASSWORD = ContraseniaEnc;
                obeUsuarioGestion.CORREO = camposUsuario[4];
                obeUsuarioGestion.FECHA_CREACION = DateTime.Parse(camposUsuario[5]);
                obeUsuarioGestion.FECHA_MODIFICACION = DateTime.Now;
                obeUsuarioGestion.NUMERO_INTENTOS = int.Parse(camposUsuario[7]);
                obeUsuarioGestion.ID_ESTADO = int.Parse(camposUsuario[8]);
                obeUsuarioGestion.ID_UNIDAD = int.Parse(camposUsuario[9]);
                obeUsuarioGestion.ID_TIPO_ESTADO = int.Parse(camposUsuario[10]);
                obeUsuarioGestion.ID_SUCURSAL = int.Parse(camposUsuario[11]);
                //obeUsuarioGestion.OBSERVACIONES = camposUsuario[4];

                obeUsuarioGestion.ID_USUARIO_REGISTRO = obeDatosUsuario.Usuario.ID_LOGIN;
                var CorreoEnvio = camposUsuario[4];

                brUsuarios obrUsuarios = new brUsuarios();
                if (obeUsuarioGestion.ID_LOGIN == 0)
                {
                    int idUsuario = obrUsuarios.AdicionarUsuario(obeUsuarioGestion, datos[1].ToString());
                    if (idUsuario > 0) retorno = "Se Adiciono Usuario: " + idUsuario;
                    else retorno = "No se pudo adicionar Usuario";
                    //obeUsuarioGestion.PASSWORD = "generar pass";
                    //obeUsuarioGestion.NUMERO_INTENTOS = 0;
                    //int idCentro = obrUsuarios.AdicionarCentro(obeUsuarioGestion);
                    //if (idCentro > 0) retorno = "Se Adiciono el Centro de Formación con id: " + idCentro;
                    //else retorno = "No se pudo adicionar el Centro de Formación";

                    //Response.Write(NuevaPass);//Nueva contraseña.  
                    //try
                    //{
                    //    //Guardar en la base de datos la nueva contraseña,¿ hacer un procedimiento almacenado que realize el update de la contraseña?
                    //   // EmailHTML(obeUsuarioGestion.LOGIN_NAME, CorreoEnvio, NuevaPass);// envio del correo
                    //    string mensajeEnviar = "La contraseña fue enviada a su correo electronico";
                    //    string mensajeEnviar2 = "";
                    //    mensajeEnviar2 = mensajeEnviar;
                    //    ViewBag.mensaje = mensajeEnviar2;
                    //    string mensaje1 = mensajeEnviar2;
                    //}
                    //catch (Exception)
                    //{
                    //    ViewBag.mensaje = "Fallo en envio del mensaje, Su contraseña es: " + NuevaPass + "Cambiela al iniciar Sesion ";
                    //}

                }
                else
                {
                    bool exito = obrUsuarios.ActualizarUsuario(obeUsuarioGestion, datos[1].ToString());
                    if (exito) retorno = "Se actualizo el Usuario";
                    else retorno = "No se pudo actualizar el Usuario";
                    //obeUsuarioGestion.NUMERO_INTENTOS = int.Parse(camposUsuario[7]);
                    //bool exito = obrUsuarios.ActualizarCentro(obeCentrosFormacion);
                    //if (exito) retorno = "Se actualizo el Centro de Formación";
                    //else retorno = "No se pudo actualizar el Centro de Formación";
                }

                sb = ListadoUsuarios();
                sb += "¬";
                sb += retorno;
            }
            return sb.ToString();
        }

        public void EmailHTML(string user, string emailDestino, string contraseniaNueva)
        {
            string asunto = "Contraseña de ingreso al Aplicativo Salidas de Campo";
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add(emailDestino);
            string emailSalida = mail;
            string contraseniaSalida = pass;

            msg.From = new MailAddress(emailSalida, "Aplicativo Salidas de campo", System.Text.Encoding.UTF8);
            msg.Subject = asunto;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = string.Format("<BODY> Señor usuario,</br>Cordial saludo.</br></br> El usuario y contraseña asignada para el Aplicativo Salidas de campo es:</br>Usuario:  <b style='color:#FF0000;'>{0}  </b></br>Contraseña:  <b style='color:#FF0000;'>{1}</b></br> </b>Nota: Se sugiere cambiar la contraseña al ingresar al Aplicativo. </br> </br>  UDIT Universidad Central </br> Universidad Central de Colombia   </br> Direccion tal . Bogotá D.C. </br>  ☎ 3333333  </br> </br> </b>✉ El contenido de este e-mail y/o sus anexos es de carácter confidencial y para uso exclusivo de la persona natural o jurídica, a la que se encuentra dirigido. Si usted no es su destinatario intencional, por favor, reenvíenoslo de inmediato y elimine el correo</BODY>", user, contraseniaNueva);
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Priority = System.Net.Mail.MailPriority.High;
            //msg.CC.Add("correo@misena.edu.co"); enviar con copia
            //msg.Bcc.Add("correo@misena.edu.co"); enviar con copia oculta
            //msg.Attachments.Add(new Attachment(listArchivos.SelectedValue.ToString())); al mensaje se le pueden enviar archivos adjuntos

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("smateusv@ucentral.edu.co", "espejismos351");
            client.Port = 587;
            //client.Port = 465;
            //client.Port = 25;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true; // permite que vaya a traves del ssl obligatorio Dimar.mil.co encriptado

            try
            {
                client.Send(msg);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private string EncriptarClaves(string clave)
        {
            Encriptar encripataPass = new Encriptar();
            string claveEncriptada = string.Empty;

            claveEncriptada = encripataPass.EncriptarClaveUsuario(clave);

            return claveEncriptada;
        }

        private string DesencriptarClaves(string clave)
        {
            Encriptar encripataPass = new Encriptar();
            string claveDesencriptada = string.Empty;

            claveDesencriptada = encripataPass.DesencriptarClaveUsuario(clave);

            return claveDesencriptada;
        }

        public void EmailHTML(string user, string emailSalida, string contraseniaSalida, string emailDestino, string contraseniaNueva)
        {
            string asunto = "Recuperacion de contraseña Aplicativo Centros de Formación";
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add(emailDestino);



            msg.From = new MailAddress(emailSalida, "Aplicativo Centros de Formación", System.Text.Encoding.UTF8);
            msg.Subject = asunto;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = string.Format("<BODY> Señor usuario,</br>Cordial saludo.</br></br> el usuario y contraseña asignada para el Aplicativo Centros de Formación es:</br></br>Usuario: <b style='color:#FF0000;'>{0}</b></br>Contraseña: <b style='color:#FF0000;'>{1}</b>  </br> </br> </b>Nota: Se sugiere cambiar la contraseña al ingresar al Aplicativo. </br> </br> </b> Sistemas de Información – Grupo de Informática y Comunicaciones </br> Min defensa- Armada Nacional -Dirección General Marítima   </br> ⚓ Carrera 54 No. 26-50 CAN. Bogotá D.C. </br>  ☎ 220 0490  </br> </br> </b>✉ El contenido de este e-mail y/o sus anexos es de carácter confidencial y para uso exclusivo de la persona natural o jurídica, a la que se encuentra dirigido. Si usted no es su destinatario intencional, por favor, reenvíenoslo de inmediato y elimine el documento y sus anexos.</BODY>", user, contraseniaNueva);
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Priority = System.Net.Mail.MailPriority.High;
            //msg.CC.Add("correo@misena.edu.co"); enviar con copia
            //msg.Bcc.Add("correo@misena.edu.co"); enviar con copia oculta
            //msg.Attachments.Add(new Attachment(listArchivos.SelectedValue.ToString())); al mensaje se le pueden enviar archivos adjuntos

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(emailSalida, contraseniaSalida);
            //client.Port = 587;
            //client.Port = 465;
            client.Port = 25;
            client.Host = "mail.dimar.mil.co";
            client.EnableSsl = true; // permite que vaya a traves del ssl obligatorio Dimar.mil.co encriptado

            try
            {
                client.Send(msg);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        //[ValidateAntiForgeryToken]
        //public ActionResult RestablecerContrasenia(beRestablecer obeRestablecer)
        //{
        //    //ViewBag.mensaje = null;
        //    Random obj = new Random();//Creamos la instancia del objeto Random
        //    string Caracteres = "abcdefghijkmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789*+-/_"; //Caracteres que incluirá cada nueva combinación obtenida.
        //    int longitud = Caracteres.Length;
        //    char letra;
        //    int longitudnuevacadena = 7;//Obtenemos el numero de caracteres o la longitud de los posibles caracteres
        //    string NuevaPass = "";//Declaramos una nueva variable la cual contendrá la nueva combinación

        //    for (int i = 0; i < longitudnuevacadena; i++)//Ciclo for para tomar el carácter según el método Next de la variable con los caracteres posibles y así ir obteniendo uno a la vez e ir concatenándole a la cadena de salida el nuevo carácter obtenido.
        //    {
        //        letra = Caracteres[obj.Next(longitud)];
        //        NuevaPass += letra.ToString();
        //    }

        //    var ContraseniaEnc = EncriptarClaves(NuevaPass);//encriptar nueva contraseña
        //    string usuariow = "";
        //    obeRestablecer.contrasenia = ContraseniaEnc;
        //    obeRestablecer.loginname = usuariow;

        //    brRestablecer obrRestablecer = new brRestablecer();
        //    bool exito;
        //    exito = obrRestablecer.RestablecerContrasenia(obeRestablecer);

        //    if (exito)
        //    {
        //        string emailSalida = mail;
        //        string contraseniaSalida = pass;
        //        //Response.Write(NuevaPass);//Nueva contraseña.  
        //        try
        //        {
        //            //Guardar en la base de datos la nueva contraseña,¿ hacer un procedimiento almacenado que realize el update de la contraseña?
        //            EmailHTML(obeRestablecer.loginname, emailSalida, contraseniaSalida, obeRestablecer.correo, NuevaPass);// envio del correo
        //            string mensajeEnviar = "La contraseña fue enviada a su correo electronico";
        //            string mensajeEnviar2 = "";
        //            mensajeEnviar2 = mensajeEnviar;
        //            //ViewBag.mensaje = mensajeEnviar2;

        //        }
        //        catch (Exception)
        //        {
        //           // ViewBag.mensaje = "Fallo en envio del mensaje, Su contraseña es: " + NuevaPass + "Cambiela al iniciar Sesion ";
        //        }

        //    }
        //    else
        //    {
        //        string msm = "El E-mail no existe, verifique por favor";
        //        //string msm2= textos.FormatearTextosConAcentos(msm);
        //        ViewBag.mensaje = msm;
        //    }
        //    return View(obeRestablecer);
        //}

    }
}
