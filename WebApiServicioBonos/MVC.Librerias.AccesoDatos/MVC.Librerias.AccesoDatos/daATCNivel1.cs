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
    public class daATCNivel1
    {
        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: ListarPais
        /// Función: Enlace con la base de datos y realiza un select a la tabla "PS_PAISES" para 
        ///          consultar los paises existentes
        /// Retorno: Variable "lstObePais" de tipo "List<bePais>"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
        public List<beATCNivel1> ListarATCNivel1(SqlConnection con)
        {
            List<beATCNivel1> lstObeATCNivel1 = new List<beATCNivel1>();
            SqlCommand cmd = new SqlCommand("sp_Consultar_ATCNivel1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader();
            if (drd != null)
            {
                beATCNivel1 obeATCNivel1;
                int posIdATCNivel1 = drd.GetOrdinal("ID_ATC_NIVEL1");
                int posNombre = drd.GetOrdinal("ATC_NIVEL1");
                int posEstado = drd.GetOrdinal("ESTADO");
                while (drd.Read())
                {
                    obeATCNivel1 = new beATCNivel1();
                    obeATCNivel1.ID_ATCNivel1 = drd.GetInt32(posIdATCNivel1);
                    obeATCNivel1.NOMBRE_ATCNivel1 = drd.GetString(posNombre);
                    obeATCNivel1.ESTADO = drd.GetString(posEstado);
                    lstObeATCNivel1.Add(obeATCNivel1);
                }
            }
            drd.Close();
            return lstObeATCNivel1;
        }

        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: AdicionarPais
        /// Función: Enlace con la base de datos y realiza un insert a la tabla "PS_PAISES" para 
        ///          ingresar un pais nuevo
        /// Retorno: Variable "idElemento" de tipo "int"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
        public int AdicionarATCNivel1(SqlConnection con, beATCNivel1 obeATCNivel1, string usuario)
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("sp_Insertar_ATCNivel1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRE", obeATCNivel1.NOMBRE_ATCNivel1);
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
        public bool ActualizarATCNivel1(SqlConnection con, beATCNivel1 obeATCNivel1,string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_Actualizar_ATCNivel1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_ATCNivel1", obeATCNivel1.ID_ATCNivel1);
            cmd.Parameters.AddWithValue("@NOMBRE", obeATCNivel1.NOMBRE_ATCNivel1);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }

        public bool ActualizarEstado(SqlConnection con, int IdATCNivel1, string Estado, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_ActualizarEstado_ATCNivel1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_ATCNIVEL1", IdATCNivel1);
            cmd.Parameters.AddWithValue("@ESTADO", Estado);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }
    }
}
