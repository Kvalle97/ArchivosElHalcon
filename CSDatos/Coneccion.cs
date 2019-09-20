using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDatos
{
    /// <summary>
    /// Clase connección. Acciones sql.
    /// </summary>
    public class Coneccion
    {
        private static string user;
        private static string pasword;
        private static string server;
        private static string database;
        private static string cadenaConexion;
        private static bool mostrarErroresEnEstaCapa = false;
        
        private static System.Data.SqlClient.SqlDataAdapter cna;


        private static void MostrarError(Exception e)
        {
            if (mostrarErroresEnEstaCapa)
            {
                string folder = "C:\\HalconLogs\\Importaciones\\";

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                string nombreDelArchivo =
                    folder + "log_" + DateTime.Now.ToFileTime() + ".txt";

                string[] lineas =
                {
                    "Message:" + e.Message,
                    "Source:" + e.Source,
                    "Stack Trace:" + e.StackTrace,
                    "Time:" + DateTime.Now.ToString(CultureInfo.CurrentCulture),
                };

                System.IO.File.WriteAllLines(nombreDelArchivo, lineas);
            }
        }


        private static void MostrarError(SqlException e)
        {
            if (mostrarErroresEnEstaCapa)
            {
                string folder = "C:\\HalconLogs\\Importaciones\\";

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                string nombreDelArchivo =
                    folder + "log_" + DateTime.Now.ToFileTime() + ".txt";

                string[] lineas =
                {
                    "Message:" + e.Message,
                    "Source:" + e.Source,
                    "Stack Trace:" + e.StackTrace,
                    "Procedure:" + e.Procedure,
                    "Line sql procedure error:" + e.LineNumber,
                    "Server: " + e.Server,
                    "Time:" + DateTime.Now.ToString(CultureInfo.CurrentCulture),
                };

                System.IO.File.WriteAllLines(nombreDelArchivo, lineas);
            }
        }

        #region Propiedades

        public string User
        {
            get { return user; }

            set { user = value; }
        }

        public string Pasword
        {
            get { return pasword; }
            set { pasword = value; }
        }

        public string Server
        {
            get { return server; }
            set { server = value; }
        }

        public string Database
        {
            get { return database; }
            set { database = value; }
        }

        public static string CadenaConexion
        {
            get { return cadenaConexion; }
            //set { cadenaConexion = value; }
        }

        #endregion


        #region Constructores

        public Coneccion()
        {
        }

        public static SqlConnection GetSqlConection()
        {
            return new SqlConnection(CadenaConexion);
        }

        public Coneccion(string user, string pas, string server, string database)
        {
            this.User = user;
            this.Pasword = pas;
            this.Server = server;
            this.Database = database;
            EstablecerCadenaConexion(user, pas, server, database);
        }


        public string EstablecerCadenaConexion(string user, string pas, string server, string database)
        {
            try
            {
                cadenaConexion =
                    "Connection Timeout=30;Persist Security Info=False;Server=" + server + ";Database=" + database +
                    ";Password=" + pas + ";User ID=" + user;
                return cadenaConexion;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        #endregion


        #region Métodos

        /// <summary>
        /// Validar connecion
        /// </summary>
        /// <param name="mensajeError"></param>
        /// <returns></returns>
        public bool ValidarConecion(ref string mensajeError)
        {
            using (SqlConnection sqlConexion = new SqlConnection(CadenaConexion))
            {
                try
                {
                    if (sqlConexion.State != ConnectionState.Open)
                    {
                        sqlConexion.Open();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    mensajeError = ex.Message.ToString();

                    sqlConexion.Close();

                    MostrarError(ex);

                    return false;
                }
            }
        }

        /// <summary>
        /// Leer dato SQL
        /// </summary>
        /// <param name="dsResultado"></param>
        /// <param name="sqlQuery"></param>
        /// <param name="mensajeError"></param>
        /// <returns></returns>
        public static bool Leer(ref System.Data.DataSet dsResultado, string sqlQuery, ref string mensajeError)
        {
            bool resultado = false;


            using (SqlConnection cnn = new SqlConnection(CadenaConexion))
            {
                cnn.Open();

                try
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(sqlQuery, cnn /*GetSqlConection()*/))
                    {
                        da.Fill(dsResultado);

                        resultado = true;
                    }

                    return resultado;
                }
                catch (SqlException ex)
                {
                    mensajeError = ex.Message.ToString();
                    cnn.Close();
                    cnn.Dispose();

                    MostrarError(ex);

                    throw;
                }

                //return resultado;
            }
        }

        #endregion

        #region SELECT - UPDATE - DELETE - [EXEC (Para Procedimientos Almacenados)]

        /// <summary>
        ///Ejecutar Consulta 
        /// 
        /// Si el valor que retorna esta funcion es igual a 0 significa que no afecto ningun registro
        /// </summary>
        /// <param name="consultaSql"></param>
        /// <returns></returns>
        public static int EjecutarConsulta(string consultaSql)
        {
            using (SqlConnection cnn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(consultaSql, cnn))
                    {
                        int registrosAfectados;
                        cnn.Open();
                        cmd.CommandTimeout = 0;
                        registrosAfectados = cmd.ExecuteNonQuery();

                        return registrosAfectados;
                    }
                }
                catch (SqlException ex)
                {
                    //mensajeError = ex.Message.ToString();
                    cnn.Close();
                    cnn.Dispose();

                    MostrarError(ex);

                    throw;
                }
            }
        }

        /// <summary>
        /// Ejecutar Consulta escalar
        /// </summary>
        /// <param name="consultaSql"></param>
        /// <param name="mensajeError"></param>
        /// <returns></returns>
        public static int EjecutarConsultaScalar(string consultaSql, ref string mensajeError)
        {
            using (SqlConnection cnn = new SqlConnection(CadenaConexion))
            {
                cnn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand(consultaSql, cnn))
                    {
                        int registrosAfectados;
                        cmd.CommandTimeout = 0;
                        registrosAfectados = Convert.ToInt32(cmd.ExecuteScalar());

                        cnn.Close();
                        cnn.Dispose();
                        return registrosAfectados;
                    }
                }

                catch (SqlException ex)
                {
                    mensajeError = ex.Message.ToString();
                    cnn.Close();
                    cnn.Dispose();

                    MostrarError(ex);

                    throw;
                    //return 0;
                }
            }
        }

        /// <summary>
        /// Ejecutar Consulta V2
        /// </summary>
        /// <param name="consultaSql"></param>
        /// <param name="mensajeError"></param>
        /// <returns></returns>
        public static int EjecutarConsulta_II(string consultaSql, ref string mensajeError)
        {
            using (SqlConnection cnn = new SqlConnection(CadenaConexion))
            {
                cnn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand(consultaSql, cnn))
                    {
                        int registrosAfectados;
                        cmd.CommandTimeout = 0;
                        registrosAfectados = cmd.ExecuteNonQuery();

                        cnn.Close();
                        cnn.Dispose();
                        return registrosAfectados;
                    }
                }

                catch (Exception ex)
                {
                    mensajeError = ex.Message.ToString();
                    cnn.Close();
                    cnn.Dispose();

                    MostrarError(ex);

                    throw;
                    //return 0;                    
                }
            }
        }

        #endregion

        /// <summary>
        /// Llenar Data Set V2
        /// </summary>
        /// <param name="strSQL"></param>
        /// <param name="mensajeError"></param>
        /// <returns></returns>
        public static DataSet LlenarDataSet_II(string strSQL, ref string mensajeError)
        {
            DataSet ds = null;

            ds = new DataSet();

            using (SqlConnection cnn = new SqlConnection(CadenaConexion))
            {
                cnn.Open();

                try
                {
                    using (SqlCommand cmd = new SqlCommand(strSQL, cnn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandTimeout = 0;
                            da.Fill(ds);
                            return ds;
                        }
                    }
                }
                catch (Exception ex)
                {
                    mensajeError = ex.Message.ToString();
                    cnn.Close();
                    cnn.Dispose();

                    MostrarError(ex);

                    throw;
                }
            }
        }

        /// <summary>
        /// Execute Data Set
        /// </summary>
        /// <param name="consultaSql"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string consultaSql)
        {
            DataSet ds = null;

            using (SqlConnection cnn = new SqlConnection(CadenaConexion))
            {
                ds = new DataSet();
                cnn.Open();

                using (SqlCommand cmd = new SqlCommand(consultaSql, cnn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandTimeout = 0;
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
        }

        /// <summary>
        /// Llenar Data Set
        /// </summary>
        /// <param name="strSQL"></param>
        /// <param name="ds"></param>
        public static void LlenarDataSet(string strSQL, ref System.Data.DataSet ds)
        {
            using (SqlConnection cnn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    if ((ds != null))
                        ds = null;
                    ds = new System.Data.DataSet();

                    using (SqlDataAdapter da = new SqlDataAdapter(strSQL, GetSqlConection()))
                    {
                        da.Fill(ds, "A");
                    }
                }
                catch (Exception e)
                {
                    //mensajeError = ex.Message.ToString();
                    cnn.Close();
                    cnn.Dispose();

                    MostrarError(e);

                    throw;
                }
            }
        }

        /// <summary>
        /// Ejecutar SP
        /// </summary>
        /// <param name="nombreDelSp">Nombre del procedimiento</param>
        /// <param name="ejecutarAntes">Delegado para llenar el command</param>
        /// <returns></returns>
        public static int EjecutarSP(string nombreDelSp, Func<SqlCommand, int> ejecutarAntes)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                try
                {
                    sqlConnection.ConnectionString = CadenaConexion;
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.CommandText = nombreDelSp;
                        sqlCommand.CommandTimeout = 0;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Connection = sqlConnection;

                        ejecutarAntes?.Invoke(sqlCommand);

                        return sqlCommand.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    MostrarError(e);
                    throw e;
                }
                catch (Exception e)
                {
                    MostrarError(e);

                    throw e;
                }
                finally
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        public static int EjecutarSPText(string nombreDelSp, Func<SqlCommand, int> ejecutarAntes)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                try
                {
                    sqlConnection.ConnectionString = CadenaConexion;
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.CommandText = nombreDelSp;
                        sqlCommand.CommandTimeout = 0;
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.Connection = sqlConnection;

                        ejecutarAntes?.Invoke(sqlCommand);

                        return sqlCommand.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    MostrarError(e);
                    throw e;
                }
                catch (Exception e)
                {
                    MostrarError(e);

                    throw e;
                }
                finally
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }
        /// <summary>
        /// EJecutar SP DataTable
        /// </summary>
        /// <param name="nombreDelSp">Nombre del procedimiento</param>
        /// <param name="ejecutarAntes">Delegado para llenar el command</param>
        /// <returns></returns>
        public static DataTable EjecutarSpDataTable(string nombreDelSp, Func<SqlCommand, int> ejecutarAntes)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection())
            {
                try
                {
                    sqlConnection.ConnectionString = CadenaConexion;
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.CommandTimeout = 0;
                        sqlCommand.CommandText = nombreDelSp;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Connection = sqlConnection;

                        ejecutarAntes?.Invoke(sqlCommand);

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                        new SqlCommandBuilder(sqlDataAdapter);

                        sqlDataAdapter.Fill(dataTable);

                        return dataTable;
                    }
                }
                catch (SqlException e)
                {
                    MostrarError(e);
                    throw e;
                }
                catch (Exception e)
                {
                    MostrarError(e);
                    throw e;
                }
                finally
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// EJecutar SP Text
        /// </summary>
        /// <param name="nombreDelSp">Nombre del procedimiento</param>
        /// <param name="ejecutarAntes">Delegado para llenar el command</param>
        /// <returns></returns>
        public static DataTable EjecutarTextTable(string nombreDelSp, Func<SqlCommand, int> ejecutarAntes)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection())
            {
                try
                {
                    sqlConnection.ConnectionString = CadenaConexion;
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.CommandTimeout = 0;
                        sqlCommand.CommandText = nombreDelSp;
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.Connection = sqlConnection;

                        ejecutarAntes?.Invoke(sqlCommand);

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                        new SqlCommandBuilder(sqlDataAdapter);

                        sqlDataAdapter.Fill(dataTable);

                        return dataTable;
                    }
                }
                catch (SqlException e)
                {
                    MostrarError(e);
                    throw e;
                }
                catch (Exception e)
                {
                    MostrarError(e);
                    throw e;
                }
                finally
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// Ejecutar Store Procedure.
        /// </summary>
        /// <param name="nombreDelSp"></param>
        /// <param name="ejecutarAntes"></param>
        /// <param name="ejcutarDespues"></param>
        /// <returns></returns>
        public static int EjecutarSP(string nombreDelSp, Func<SqlCommand, int> ejecutarAntes,
            Func<SqlCommand, int> ejcutarDespues)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                try
                {
                    sqlConnection.ConnectionString = CadenaConexion;
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.CommandText = nombreDelSp;
                        sqlCommand.CommandTimeout = 0;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Connection = sqlConnection;

                        ejecutarAntes(sqlCommand);

                        int resultado = sqlCommand.ExecuteNonQuery();

                        ejcutarDespues(sqlCommand);

                        return resultado;
                    }
                }
                catch (SqlException e)
                {
                    MostrarError(e);
                    throw e;
                }
                catch (Exception e)
                {
                    MostrarError(e);
                    throw e;
                }
                finally
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// Obtener resultado del Store Procedure.
        /// </summary>
        /// <param name="nombreDelSp"></param>
        /// <param name="ejecutarAntes"></param>
        /// <returns></returns>
        public static object ObterResultadoSP(string nombreDelSp, Func<SqlCommand, int> ejecutarAntes)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                try
                {
                    sqlConnection.ConnectionString = CadenaConexion;
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.CommandText = nombreDelSp;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Connection = sqlConnection;

                        ejecutarAntes(sqlCommand);

                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                        if (sqlDataReader.HasRows)
                        {
                            sqlDataReader.Read();

                            return sqlDataReader.GetValue(0);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                catch (SqlException e)
                {
                    MostrarError(e);
                    throw e;
                }
                catch (Exception e)
                {
                    MostrarError(e);
                    throw e;
                }
                finally
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// Existe el campo.
        /// </summary>
        /// <param name="campo"></param>
        /// <param name="tabla"></param>
        /// <param name="condicion"></param>
        /// <returns></returns>
        public static bool existe(string campo, string tabla, string condicion)
        {
            using (SqlConnection cnn = new SqlConnection(CadenaConexion))
            {
                cnn.Open();


                int PActual = 0;

                try
                {
                    string sentencia = "SELECT " + campo + " FROM " + tabla + " WHERE " + condicion;

                    using (SqlCommand cmd = new SqlCommand(sentencia, cnn))
                    {
                        cna = new SqlDataAdapter();
                        cna = null;
                        cna = new System.Data.SqlClient.SqlDataAdapter(cmd);
                        SqlCommandBuilder ocommandbuild = new SqlCommandBuilder(cna);

                        DataSet objdataset = new DataSet();
                        cna.Fill(objdataset, tabla);

                        PActual = objdataset.Tables[tabla].Rows.Count;

                        if (PActual != 0)
                        {
                            DataRow ObjDataRow = objdataset.Tables[tabla].Rows[0];
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (SqlException e)
                {
                    //return false;                    
                    //mensajeError = ex.Message.ToString();
                    cnn.Close();
                    cnn.Dispose();

                    MostrarError(e);
                    throw;
                }
            }
        }

        /// <summary>
        /// Ejecutar Consulta escalar.
        /// </summary>
        /// <param name="consultaSql"></param>
        /// <returns></returns>
        public static int EjecutarConsultaScalar(string consultaSql)
        {
            SqlConnection cnn = GetSqlConection();
            cnn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(consultaSql, cnn);
                int registrosAfectados;

                registrosAfectados = Convert.ToInt32(cmd.ExecuteScalar());

                cnn.Close();
                cnn.Dispose();
                return registrosAfectados;
            }
            catch (Exception e)
            {
                cnn.Close();
                cnn.Dispose();

                MostrarError(e);
                throw;
            }
        }

        /// <summary>
        /// Obtener Dato.
        /// </summary>
        /// <param name="campo"></param>
        /// <param name="tabla"></param>
        /// <param name="condicion"></param>
        /// <returns></returns>
        public static object ObtenerDato(string campo, string tabla, string condicion)
        {
            using (SqlConnection cnn = new SqlConnection(CadenaConexion))
            {
                cnn.Open();

                int PActual = 0;
                try
                {
                    object Respuesta = 0;

                    string sentencia = "SELECT " + campo + " FROM " + tabla + " WHERE " + condicion;

                    //SqlCommand cmd = new SqlCommand(sentencia, cnn);                
                    using (SqlCommand cmd = new SqlCommand(sentencia, cnn))
                    {
                        cna = new SqlDataAdapter();
                        cna = null;
                        cna = new System.Data.SqlClient.SqlDataAdapter(cmd);
                        SqlCommandBuilder ocommandbuild = new SqlCommandBuilder(cna);

                        DataSet objdataset = new DataSet();
                        cna.Fill(objdataset, tabla);

                        PActual = objdataset.Tables[tabla].Rows.Count;

                        if (PActual != 0)
                        {
                            DataRow ObjDataRow = objdataset.Tables[tabla].Rows[0];
                            Respuesta = ObjDataRow.ItemArray[0];
                        }
                    }

                    return Respuesta;
                }
                catch (SqlException ex)
                {
                    // return "";               
                    //mensajeError = ex.Message.ToString();
                    cnn.Close();
                    cnn.Dispose();

                    MostrarError(ex);
                    throw;
                }
            }
        }
        /// <summary>
        /// Ejecutar Consulta Imagen.
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="IdLogin"></param>
        /// <returns></returns>
        public static int EjecutarConsulta_Imagen(string ruta, int IdLogin)
        {
            using (SqlConnection cnn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    cnn.Open();

                    MemoryStream ms = new MemoryStream();
                    FileStream fs = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                    ms.SetLength(fs.Length);
                    fs.Read(ms.GetBuffer(), 0, (int) fs.Length);
                    byte[] bytes = ms.GetBuffer();

                    ms.Flush();
                    fs.Close();


                    string nombre_archivo = Path.GetFileName(ruta);

                    string strSQL = "exec Guardar_Mantenimiento_FlotaVehicular @Archivo,@NombreArchivo,@IdLogin";
                    SqlCommand cmd = new SqlCommand(strSQL, cnn);

                    int registrosAfectados;

                    //*********************************                
                    cmd.Parameters.Add("@Archivo", SqlDbType.VarBinary);
                    cmd.Parameters.Add("@NombreArchivo", SqlDbType.NVarChar, 500);
                    cmd.Parameters.Add("@IdLogin", SqlDbType.Int);

                    cmd.Parameters["@Archivo"].Value = bytes; //ms.GetBuffer();
                    cmd.Parameters["@NombreArchivo"].Value = nombre_archivo;
                    cmd.Parameters["@IdLogin"].Value = IdLogin;


                    registrosAfectados = cmd.ExecuteNonQuery();

                    return registrosAfectados;
                }
                catch (SqlException ex)
                {
                    // return "";               
                    //mensajeError = ex.Message.ToString();
                    cnn.Close();
                    cnn.Dispose();

                    MostrarError(ex);
                    throw;
                }
            }
        }

        public static object ObterResultadoText(
            string textoDeConsulta,
            Func<SqlCommand, int> ejecutarAntes)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                try
                {
                    sqlConnection.ConnectionString = Coneccion.CadenaConexion;
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.CommandText = textoDeConsulta;
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.Connection = sqlConnection;
                        int num = ejecutarAntes(sqlCommand);
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                        if (!sqlDataReader.HasRows)
                            return (object)null;
                        sqlDataReader.Read();
                        return sqlDataReader.GetValue(0);
                    }
                }
                catch (SqlException ex)
                {
                    Coneccion.MostrarError(ex);
                    throw ex;
                }
                catch (Exception ex)
                {
                    Coneccion.MostrarError(ex);
                    throw ex;
                }
                finally
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }


    }
}