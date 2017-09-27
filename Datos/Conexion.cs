using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Datos
{
    public class Conexion
    {
        //private LoguedorService logService = new LoguedorService();

        public bool probarConexion(string cadenaConexion)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(cadenaConexion);

                conexion.Open();

                conexion.Close();

                return true;
            }
            catch (Exception ex)
            {
                //logService.loguear(ex.ToString(), "CheloComparer.Servicios", "SqlConexionService", "probarConexion");
                return false;
            }

        }

        public SqlConnection conectar(string cadenaConexion)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(cadenaConexion);

                conexion.Open();

                return conexion;
            }
            catch (Exception ex)
            {
                //TODO Loguear la excepcion
                return null;
                //return false;
                throw ex;
            }
        }

        public void desconectar(string cadenaConexion)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                if (conexion.State == ConnectionState.Open)
                {

                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable executeQuery(string cadenaConexion, string comandoSql)
        {
            SqlCommand comando = new SqlCommand();
            DataTable result = new DataTable();

            try
            {

                SqlConnection conexion = conectar(cadenaConexion);
                //comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = comandoSql;

                result.Load(comando.ExecuteReader());


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                desconectar(cadenaConexion);
            }


            return result;
        }

        public void executeNonQuery(string cadenaConexion, string comandoSql)
        {
            SqlCommand comando = new SqlCommand();
            DataTable result = new DataTable();

            try
            {
                SqlConnection conexion = conectar(cadenaConexion);
                //comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = comandoSql;

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                desconectar(cadenaConexion);
            }

        }
    }
}