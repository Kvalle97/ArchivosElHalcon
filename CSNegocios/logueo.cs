﻿using System;
using System.Data;
using System.Data.SqlClient;
using CSDatos;

namespace CSNegocios
{
    /// <summary>
    ///     Clase que permite el acceso al sistema
    /// </summary>
    public class Logueo
    {
        private readonly Coneccion conexion;
        private DataSet dataSet = new DataSet();
        private readonly EncriptarInformacion encripta = new EncriptarInformacion();
        private string ErrorGW;

        /// <summary>
        ///     Validar Logueo
        /// </summary>
        /// <returns></returns>
        public bool ValidarLogueo()
        {
            try
            {
                if (conexion.ValidarConecion(ref ErrorGW))
                    return true;
                Personalizar.Mensaje_Error = ErrorGW;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///     Obtener Id Login
        /// </summary>
        /// <param name="srt"></param>
        /// <returns></returns>
        public DataTable ObtenerIDLogin(string srt)
        {
            try
            {
                string sqlQuery =
                    "SELECT isnull(MAX(IDLOGIN),0), getdate() as Fecha FROM LOGINS WHERE pc = host_name() and ENTRADA = '" +
                    srt + "' ";

                dataSet = new DataSet();

                Coneccion.Leer(ref dataSet, sqlQuery, ref ErrorGW);

                return dataSet.Tables[0];
            }
            catch (Exception)
            {
                return dataSet.Tables[0];
            }
        }

        /// <summary>
        ///     Cargar
        /// </summary>
        /// <param name="sqlQuery"></param>
        /// <returns></returns>
        public DataTable Cargar(string sqlQuery)
        {
            try
            {
                dataSet = new DataSet();

                Coneccion.Leer(ref dataSet, sqlQuery, ref ErrorGW);

                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                Personalizar.Mensaje_Error = ex.ToString();
                return dataSet.Tables[0];
                // throw ex;
            }
        }

        /// <summary>
        ///     Ejecutar Id Login
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="srt"></param>
        /// <returns></returns>
        public int EjecutarIDLogin(string usuario, string srt)
        {
            int resultado;

            try
            {
                resultado = Coneccion.EjecutarConsulta("exec SP_LOGIN @Usuario='" + usuario + "', @fEntrada='" + srt +
                                                       "'");

                return resultado;
            }
            catch (Exception)
            {
                return 0;
            }
        }


        #region Propiedades

        /// <summary>
        ///     Usuario
        /// </summary>
        public string User { get; set; }

        /// <summary>
        ///     Contraseña
        /// </summary>
        public string Pas { get; set; }

        /// <summary>
        ///     Base de datos.
        /// </summary>
        public string Database { get; set; }

        /// <summary>
        ///     Servidor
        /// </summary>
        public string Server { get; set; }

        //private int _idlogin;

        /// <summary>
        ///     Id Login
        /// </summary>
        public int IdLogin { get; set; }


        /// <summary>
        ///     Verificacion
        /// </summary>
        public int Verifica { get; set; }

        /// <summary>
        ///     Validrar Verifacion
        /// </summary>
        public string ValidarVerificacion { get; set; }

        /// <summary>
        ///     Correo de validacion
        /// </summary>
        public string CorreoValidacion { get; set; }

        /// <summary>
        ///     Fecha Verificacion
        /// </summary>
        public string FechaVerificacion { get; set; }


        /// <summary>
        ///     Computadora
        /// </summary>
        public string PC { get; set; }

        #endregion

        #region Contructor

        /// <summary>
        ///     Desencriptar Clave
        /// </summary>
        /// <param name="clave"></param>
        /// <returns></returns>
        public string DesencriptarEncriptarClave(string clave)
        {
            string resp = encripta.Desencriptar(clave);
            return resp;
        }

        /// <summary>
        ///     Encriptar clave
        /// </summary>
        /// <param name="clave"></param>
        /// <returns></returns>
        public string EncriptarClave(string clave)
        {
            string resp = encripta.Encriptar(clave);
            return resp;
        }

        /// <summary>
        ///     Obtener password
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public object ObtenerPassword(Logueo l)
        {
            try
            {
                object resp = "";

                resp = Coneccion.ObtenerDato("PasswordUsuario", "Halcon.dbo.Usuarios", "Usuario='" + l.User + "'");
                return DesencriptarEncriptarClave(resp.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///     Obtener Correo
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public string ObtenerCorreo(Logueo l)
        {
            try
            {
                object ob = Coneccion.ObterResultadoSP("spObtenerCorreoDeUsuario", cmd =>
                {
                    cmd.Parameters.Add(new SqlParameter("Usuario", SqlDbType.NVarChar)).Value = l.User;

                    return 0;
                });

                if (ob == null)
                    return null;
                if (ob == DBNull.Value)
                    return null;
                return Convert.ToString(ob);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///     Validar usuario
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public bool ValidarUsuario(Logueo l)
        {
            try
            {
                bool resp = false;

                resp = Coneccion.existe("Usuario", "Halcon.dbo.Usuarios", "Usuario='" + l.User + "'");
                return resp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///     Recuperacion password
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        public DataSet RecuperacionPassword(Logueo L)
        {
            return Coneccion.ExecuteDataSet("exec Flota.dbo.Guardar_Recuperacion_Password @Usuario='" + L.User +
                                            "',@Verifica=" + L.Verifica + ",@ValidarVerificacion='" +
                                            L.ValidarVerificacion + "',@CorreoValidacion='" + L.CorreoValidacion +
                                            "',@PC_Verifica='" + L.PC + "'");
        }

        /// <summary>
        ///     Obtener Recuperacion De Password
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        public DataSet ObtenerRecuperacionPassword(Logueo L)
        {
            return Coneccion.ExecuteDataSet("exec Flota.dbo.Obtener_Recuperacion_Password @Usuario='" + L.User + "'");
        }

        /// <summary>
        ///     Contructor de la clase
        /// </summary>
        public Logueo()
        {
        }

        /// <summary>
        ///     Constructor de la clase
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pas"></param>
        /// <param name="server"></param>
        /// <param name="database"></param>
        public Logueo(string user, string pas, string server, string database)
        {
            User = user;
            Pas = pas;
            Server = server;
            Database = database;

            conexion = new Coneccion(User, Pas, Server, Database);
        }

        #endregion
    }
}