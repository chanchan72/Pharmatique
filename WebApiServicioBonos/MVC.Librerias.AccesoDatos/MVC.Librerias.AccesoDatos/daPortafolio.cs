using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Libreria.EntidadesNegocio;
using System.Data.SqlClient;
using System.Data;

namespace MVC.Libreria.AccesoDatos
{
    public class daPortafolio
    {
        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: ListarPais
        /// Función: Enlace con la base de datos y realiza un select a la tabla "PS_PAISES" para 
        ///          consultar los paises existentes
        /// Retorno: Variable "lstObePais" de tipo "List<bePais>"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
        public List<bePortafolio> ListarPortafolio(SqlConnection con)
        {
            List<bePortafolio> lstObePortafolio = new List<bePortafolio>();
            SqlCommand cmd = new SqlCommand("sp_Consultar_Portafolio", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader();
            if (drd != null)
            {
                bePortafolio obePortafolio;
                int posIdPortafolio = drd.GetOrdinal("ID_Portafolio");
                int posNombre = drd.GetOrdinal("Portafolio");
                int posEstado = drd.GetOrdinal("ESTADO");
                while (drd.Read())
                {
                    obePortafolio = new bePortafolio();
                    obePortafolio.ID_Portafolio = drd.GetInt32(posIdPortafolio);
                    obePortafolio.NOMBRE_Portafolio = drd.GetString(posNombre);
                    obePortafolio.ESTADO = drd.GetString(posEstado);
                    lstObePortafolio.Add(obePortafolio);
                }
            }
            drd.Close();
            return lstObePortafolio;
        }

        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: AdicionarPais
        /// Función: Enlace con la base de datos y realiza un insert a la tabla "PS_PAISES" para 
        ///          ingresar un pais nuevo
        /// Retorno: Variable "idElemento" de tipo "int"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
        public int AdicionarPortafolio(SqlConnection con, bePortafolio obePortafolio, string usuario)
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("sp_Insertar_Portafolio", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRE", obePortafolio.NOMBRE_Portafolio);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            if (nRegistros > 0)
            {
                idElemento = nRegistros;
            }
            return idElemento;
        }

        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: AdicionarPais
        /// Función: Enlace con la base de datos y realiza un update a la tabla "PS_PAISES" para 
        ///          actualizar un pais que este en la tabla
        /// Retorno: Variable "exito" de tipo "bool"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
        public bool ActualizarPortafolio(SqlConnection con, bePortafolio obePortafolio, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_Actualizar_Portafolio", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_Portafolio", obePortafolio.ID_Portafolio);
            cmd.Parameters.AddWithValue("@NOMBRE", obePortafolio.NOMBRE_Portafolio);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }

        public bool ActualizarEstado(SqlConnection con, int IdPortafolio, string Estado, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_ActualizarEstado_Portafolio", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_PORTAFOLIO", IdPortafolio);
            cmd.Parameters.AddWithValue("@ESTADO", Estado);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }
    }
}
