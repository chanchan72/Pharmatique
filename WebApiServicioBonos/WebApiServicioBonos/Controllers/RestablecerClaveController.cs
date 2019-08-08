using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using MVC.Librerias.EntidadesNegocio;
using MVC.Librerias.ReglasNegocio;
using Genaral.Librerias.CodigoUsuario;
using General.Librerias.EntidadesNegocio;
using System.Net.Mail;

namespace WebApiServicioBonos.Controllers
{
    public class RestablecerClaveController : ApiController
    {
        private readonly string mail = ConfigurationManager.AppSettings["mail"];
        private readonly string pass = ConfigurationManager.AppSettings["com"];

        //
        // GET: /RestablecerClave/
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

        public string RestablecerContraseniaC(beRestablecer obeRestablecer)
        {
            //beRestablecer obeRestablecer = new beRestablecer();
            string sb = "";
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
            var ContraseniaEnc = EncriptarClaves(NuevaPass);//encriptar nueva contraseña
            string usuariow = "";
            obeRestablecer.contrasenia = ContraseniaEnc;
            obeRestablecer.loginname = usuariow;

            brRestablecer obrRestablecer = new brRestablecer();
            bool exito;
            exito = obrRestablecer.RestablecerContrasenia(obeRestablecer);

            if (exito)
            {
                string emailSalida = mail;
                string contraseniaSalida = pass;
                //Response.Write(NuevaPass);//Nueva contraseña.  
                try
                {
                    //Guardar en la base de datos la nueva contraseña,¿ hacer un procedimiento almacenado que realize el update de la contraseña?
                    EmailHTML(obeRestablecer.loginname, emailSalida, contraseniaSalida, obeRestablecer.correo, NuevaPass);// envio del correo
                    string mensajeEnviar = "La contraseña fue enviada a su correo electronico";
                    string mensajeEnviar2 = "";
                    mensajeEnviar2 = mensajeEnviar;
                    //ViewBag.mensaje = mensajeEnviar2;

                }
                catch (Exception)
                {
                    //ViewBag.mensaje = "Fallo en envio del mensaje, Su contraseña es: " + NuevaPass + "Cambiela al iniciar Sesion ";
                }

            }
            else
            {
                string msm = "El E-mail no existe, verifique por favor";
                //string msm2= textos.FormatearTextosConAcentos(msm);
                //ViewBag.mensaje = msm;
            }
            //return View(obeRestablecer);
            return sb;
        }
    }
}
