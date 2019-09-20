using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CSDatos;
using System.Data;


namespace CSNegocios
{
    /// <summary>
    /// Clase de operaciones globales con sql.
    /// </summary>
    public static class OperacionesGlobal
    {
        private static string ErrorGW;
        private static decimal tc;


        /// <summary>
        /// Intento de conectar
        /// </summary>
        /// <param name="direccion"></param>
        /// <param name="bd"></param>
        /// <param name="login"></param>
        /// <param name="pswd"></param>
        /// <param name="timeout"></param>
        public static void IntentarConectar(string direccion, string bd, string login, string pswd, int timeout)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=" + direccion + ";Initial Catalog=" + bd + ";User ID=" + login +
                              ";Password=" + pswd + "; Connection Timeout=35";
            cnn = new SqlConnection(connetionString);
            SqlExtensions.QuickOpen(cnn, timeout);
        }

        /// <summary>
        /// Obtener Tasa proyectada
        /// </summary>
        /// <returns></returns>
        public static decimal ObtenerTcProyectada()
        {
            try
            {
                decimal value = 0;

                DataTable dt = Coneccion.EjecutarSpDataTable("spObtenerTasaDeCambioProyectada", null);

                if (dt.Rows.Count > 0)
                {
                    return Convert.ToDecimal(dt.Rows[0]["Monto"]);
                }

                return value;
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Obtener Tasa
        /// </summary>
        /// <returns></returns>
        public static decimal Obtener_TC()
        {
            try
            {
                DataSet ds = new DataSet();

                Coneccion.Leer(ref ds, "SELECT ISNULL(DBO.FX_OBTENER_TC(GETDATE()),0) AS TC", ref ErrorGW);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.IsDBNull(ds.Tables[0].Rows[0][0]))
                    {
                        return 1;
                    }
                    else
                    {
                        tc = Convert.ToDecimal((ds.Tables[0].Rows[0][0].ToString()));
                        return tc;
                    }
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception ex)
            {
                Personalizar.Mensaje_Error = ex.ToString();
                throw;
            }
        }

        /// <summary>
        /// Obtener Nombre de la empresa
        /// </summary>
        /// <returns></returns>
        public static string ObtenerNombreEmpresa()
        {
            return OperacionesGlobal.strGet_String("exec halcon.dbo.spObtenerNombreEmpresa", "El Halcón");
        }

        /// <summary>
        /// Cargar Data Set
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns></returns>
        public static DataSet CargarDS(string consulta)
        {
            return Coneccion.ExecuteDataSet(consulta);
        }

        /// <summary>
        /// Num Get Int
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public static int numGet_Int(string strSQL)
        {
            try
            {
                DataSet ds = new DataSet();
                Coneccion.Leer(ref ds, strSQL, ref ErrorGW);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.IsDBNull(ds.Tables[0].Rows[0][0]))
                    {
                        return 0;
                    }
                    else
                    {
                        return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                    }
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Personalizar.Mensaje_Error = ex.ToString();
                throw;
            }
        }

        /// <summary>
        /// Str Get String
        /// </summary>
        /// <param name="strSQL"></param>
        /// <param name="strDefault"></param>
        /// <returns></returns>
        public static string strGet_String(string strSQL, string strDefault)
        {
            try
            {
                string functionReturnValue = "";
                DataSet ds = new DataSet();

                Coneccion.Leer(ref ds, strSQL, ref ErrorGW);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.IsDBNull(ds.Tables[0].Rows[0][0]))
                    {
                        functionReturnValue = "";
                    }
                    else
                    {
                        functionReturnValue = Convert.ToString((ds.Tables[0].Rows[0][0].ToString()));
                    }
                }
                else
                {
                    functionReturnValue = "";
                }

                return functionReturnValue;
            }
            catch (Exception ex)
            {
                Personalizar.Mensaje_Error = ex.ToString();
                throw;
            }
        }

        /// <summary>
        /// Ejecutar Consulta
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns></returns>
        public static int EjecutarConsulta(string consulta)
        {
            return Coneccion.EjecutarConsulta(consulta);
        }

        /// <summary>
        /// Tasa de cambio
        /// </summary>
        public static decimal Tc
        {
            get { return tc; }
            set { tc = value; }
        }
    }
}