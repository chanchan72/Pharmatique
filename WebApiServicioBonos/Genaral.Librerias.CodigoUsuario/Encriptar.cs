using System;
using System.Text;
using MUDE;

namespace Genaral.Librerias.CodigoUsuario
{
    public class Encriptar
    {
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Encriptar()
        {

        }

        /// <summary>
        /// Encripta una clave invocando el metodo EncriptarRijndaelString de la libreria MUDE, y devolviendo dicha 
        /// cadena en una base String de 64.
        /// Autor: Esteban Garzón Guerrero
        /// Fecha: Noviembre 2015
        /// </summary>
        /// <param name="clave">Cadena a encriptar.</param>
        /// <returns>Cadena encriptada con base 64.</returns>
        public string EncriptarClaveUsuario(string clave)
        {
            try
            {
                string claveEncriptada = string.Empty;
                clsEncriptacionSimetrica encriptaSimetrica = new clsEncriptacionSimetrica();

                claveEncriptada = encriptaSimetrica.EncriptarRijndaelString(clave);

                return Convert.ToBase64String(UnicodeEncoding.Unicode.GetBytes(claveEncriptada));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Encripta una clave invocando el metodo EncriptarRijndaelString de la libreria MUDE.
        /// Autor: Esteban Garzón Guerrero
        /// Fecha: Noviembre 2015
        /// </summary>
        /// <param name="clave">Cadena a encriptar.</param>
        /// <returns>Cadena encriptada.</returns>
        public string EncriptarClaveUsuarioHash(string clave)
        {
            try
            {
                string claveEncriptada = string.Empty;
                clsEncriptacionSimetrica encriptaSimetrica = new clsEncriptacionSimetrica();

                claveEncriptada = encriptaSimetrica.EncriptarRijndaelString(clave);

                return claveEncriptada;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Desencripta una clave invocando el metodo DesEncriptarRijndaelString de la libreria MUDE..
        /// Autor: Esteban Garzón Guerrero
        /// Fecha: Noviembre 2015
        /// </summary>
        /// <param name="clave">Cadena a desencriptar.</param>
        /// <returns>Cadena desencriptada.</returns>
        public string DesencriptarClaveUsuario(string clave)
        {
            try
            {
                string claveEncriptada = string.Empty;
                clsEncriptacionSimetrica encriptaSimetrica = new clsEncriptacionSimetrica();

                byte[] data = Convert.FromBase64String(clave);
                string decodedString = Encoding.UTF8.GetString(data);

                claveEncriptada = encriptaSimetrica.DesEncriptarRijndaelString(decodedString);

                return claveEncriptada;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
