using System;
using System.Data;
using CSDatos;

namespace CSNegocios
{
    /// <summary>
    ///     Clase de usarios, proporcionado en la plantilla base.
    /// </summary>
    public class Usuarios
    {
        private DataSet dataSet = new DataSet();
        private readonly EncriptarInformacion encripta = new EncriptarInformacion();
        private string ErrorGW;


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
        ///     Desencriptar informacion
        /// </summary>
        /// <param name="clave"></param>
        /// <returns></returns>
        public string DesencriptarEncriptarClave(string clave)
        {
            string resp = encripta.Desencriptar(clave);
            return resp;
        }

        //public DataSet Cargar_Usuarios()
        //{
        //    return Coneccion.ExecuteDataSet("exec Flota.dbo.Cargar_Usuarios");
        //}

        /// <summary>
        ///     Guardar usuario
        /// </summary>
        /// <param name="U"></param>
        /// <returns></returns>
        public int Guardar_Usuario(Usuarios U)
        {
            try
            {
                return IdUsuario = Coneccion.EjecutarConsultaScalar(
                    "exec dbo.[Guardar_Usuario] @IdUsuario=" + U.IdUsuario + ",@Usuario='" + U.Usuario + "',@IdNivel=" +
                    U.IdNivel + ",@Nombres='" + U.Nombres + "',@Apellidos='" + U.Apellidos + "',@ventas=" + U.Ventas +
                    ",@inventario=" + U.Inventario + ",@compras=" + U.Compras + ",@produccion=" + U.Produccion +
                    ",@cartera=" + U.Cartera + ",@caja=" + U.Caja + ",@bancos=" + U.Bancos + ",@administracion=" +
                    U.Administracion + ",@proveedores=" + U.Proveedores + ",@proyecto=" + U.Proyecto + ",@telefono='" +
                    U.Telefono + "',@iddescuento=" + U.IdDescuento + ",@IdEmpresaUbicacion=" + U.IdSucursal +
                    ",@Mostrar_CRM=" + U.Mostrar_CRM + ",@PC='" + U.PC + "',@IdLogin=" + U.IdLogin + ",@DescuentoMax=" +
                    U.DescuentoMax + ",@UsuarioSistema='" + U.UsuarioSistema + "' ");
            }
            catch (Exception ex)
            {
                Personalizar.Mensaje_Error = ex.Message;
                throw;
            }
        }

        /// <summary>
        ///     Guardar correo temporal del usuario
        /// </summary>
        /// <param name="U"></param>
        /// <returns></returns>
        public int Guardar_Correo_tmp_Usuario(Usuarios U)
        {
            try
            {
                return IdUsuario = Coneccion.EjecutarConsultaScalar(
                    "exec dbo.[Guardar_tmp_correo] @IdLogin=" + U.IdLogin + ",@Correo='" + U.Correo + "',@Opcion=" +
                    U.Opcion + ",@IdUsuario=" + U.IdUsuario + "");
            }
            catch (Exception ex)
            {
                Personalizar.Mensaje_Error = ex.Message;
                throw;
            }
        }

        /// <summary>
        ///     Guardar sucursal temporal del usario
        /// </summary>
        /// <param name="U"></param>
        /// <returns></returns>
        public int Guardar_Sucursal_tmp_Usuario(Usuarios U)
        {
            try
            {
                return IdUsuario = Coneccion.EjecutarConsultaScalar(
                    "exec dbo.[Guardar_tmp_Sucursal] @IdLogin=" + U.IdLogin + ",@IdEmpresa=" + U.IdSucursal +
                    ",@Opcion=" + U.Opcion + "");
            }
            catch (Exception ex)
            {
                Personalizar.Mensaje_Error = ex.Message;
                throw;
            }
        }


        /// <summary>
        ///     Cargar usarios
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public DataSet Cargar_Usuarios(Usuarios usuario)
        {
            return Coneccion.ExecuteDataSet("exec dbo.Cargar_Usuarios_General @IdSucursal=" + usuario.IdSucursal +
                                            ",@Activo=" + usuario.Activo + "");
        }

        /// <summary>
        ///     Cargar usuario unico
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public DataSet Cargar_Usuarios_Unico(Usuarios usuario)
        {
            return Coneccion.ExecuteDataSet("exec Flota.dbo.Cargar_Usuarios_Unico @Usuario='" + usuario.Usuario + "'");
        }

        /// <summary>
        ///     Get like usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public DataSet GetLikeUsuario(Usuarios usuario)
        {
            return Coneccion.ExecuteDataSet("exec dbo.List_Like_Usuario @filter='" + usuario.Descripcion_Usuario +
                                            "',@startIndex=" + usuario.startIndex + ",@endIndex=" + usuario.endIndex +
                                            ",@IdSucursal=" + usuario.IdEmpresaUbicacion + ",@Activo=" +
                                            usuario.Activo + "");
        }

        /// <summary>
        ///     Actualizar password
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public DataSet Actualizar_Password(Usuarios usuario)
        {
            return Coneccion.ExecuteDataSet("exec Flota.dbo.Actualizar_Password @Usuario='" + usuario.Usuario +
                                            "',@Password='" + EncriptarClave(usuario.Password) + "',@Opcion=" +
                                            usuario.Opcion + "");
        }

        /// <summary>
        ///     Actualizar usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public DataSet Actualizar_Usuario(Usuarios usuario)
        {
            return Coneccion.ExecuteDataSet("exec Flota.dbo.Actualizar_usuario @UsuarioOriginal='" +
                                            usuario.UsuarioOriginal + "',@Usuario='" + usuario.Usuario +
                                            "',@Nombres='" + usuario.Nombres + "',@Apellidos='" + usuario.Apellidos +
                                            "',@Id_Nivel_Usuario='" + usuario.Area + "',@IdEmpresaUbicacion=" +
                                            usuario.IdEmpresaUbicacion + "");
        }

        /// <summary>
        ///     Temporal usarios
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DataSet Tmp_Usuarios(Usuarios u)
        {
            return Coneccion.ExecuteDataSet("exec dbo.Guardar_tmp_Usuarios @IdUsuario=" + u.IdUsuario + ",@IdLogin=" +
                                            u.IdLogin + ",@Opcion=" + u.Opcion + ",@SMOWNERID='" + u.SMOWNERID +
                                            "',@IdAcceso=" + u.IdAcceso + ",@EditarOtrasCuentas=" +
                                            u.EditarOtrasCuentas + "");
        }

        /// <summary>
        ///     Cargar temporal usarios
        /// </summary>
        /// <param name="U"></param>
        /// <returns></returns>
        public DataSet Cargar_Tmp_Usuarios(Usuarios U)
        {
            return Coneccion.ExecuteDataSet("exec dbo.[Guardar_tmp_Sucursal] @IdLogin=" + U.IdLogin + ",@IdEmpresa=" +
                                            U.IdSucursal + ",@Opcion=" + U.Opcion + ",@Usuario='" + U.Usuario + "'");
        }


        //public int Eliminar_tmp_Correo(Usuarios u)
        //{            
        //    try
        //    {
        //        return IDCorreo = Coneccion.EjecutarConsultaScalar("exec dbo.Guardar_tmp_correo @IdLogin=" + u.IdLogin + ",");

        //    }
        //    catch (Exception ex)
        //    {                
        //        Personalizar.Mensaje_Error = ex.Message;
        //        throw;
        //    }
        //}

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
            catch (Exception)
            {
                return dataSet.Tables[0];
                //throw ex;
            }
        }

        /// <summary>
        ///     Cargar usuarios temporal
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DataSet CargarUsuariosSucursal(Usuarios u)
        {
            return Coneccion.ExecuteDataSet("exec dbo.Cargar_Usuarios_Sucursal @IdSucursal=" + u.IdSucursal + "");
        }

        /// <summary>
        ///     Cargar usarios reporte
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DataSet CargarUsuariosReporte(Usuarios u)
        {
            return Coneccion.ExecuteDataSet("exec dbo.Cargar_Usuarios_Reporte @IdSucursal=" + u.IdSucursal + "");
        }

        /// <summary>
        ///     Cargar correos usuarios
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public DataSet Cargar_Correos_Usuarios(Usuarios u)
        {
            return Coneccion.ExecuteDataSet("exec dbo.Cargar_Correos_Usuario @IdUsuario=" + u.IdUsuario +
                                            ",@Usuario='" + u.Usuario + "'");
        }

        /// <summary>
        ///     Operaciones generales
        /// </summary>
        /// <param name="sqlQuery"></param>
        /// <returns></returns>
        public int OperacionesGenerales(string sqlQuery)
        {
            try
            {
                //this.dataSet = new DataSet();

                Coneccion.EjecutarConsulta(sqlQuery);

                //return dataSet.Tables[0];
                return 1;
            }
            catch (Exception ex)
            {
                Personalizar.Mensaje_Error = ex.ToString();
                throw;
            }
        }

        #region propiedades

        /// <summary>
        ///     Nombres del usuario
        /// </summary>
        public string Nombres { get; set; }

        /// <summary>
        ///     Apellidos
        /// </summary>
        public string Apellidos { get; set; }

        /// <summary>
        ///     Usuario
        /// </summary>
        public string Usuario { get; set; }

        /// <summary>
        ///     Usuario del sistema
        /// </summary>
        public string UsuarioSistema { get; set; }

        /// <summary>
        ///     Usuario original
        /// </summary>
        public string UsuarioOriginal { get; set; }

        /// <summary>
        ///     IdEmpresa ubicacion
        /// </summary>
        public int IdEmpresaUbicacion { get; set; }

        /// <summary>
        ///     Contraseña
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        ///     Opción
        /// </summary>
        public int Opcion { get; set; }

        /// <summary>
        ///     Área
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        ///     Id Usario
        /// </summary>
        public int IdUsuario { get; set; }

        /// <summary>
        ///     Id Login
        /// </summary>
        public int IdLogin { get; set; }

        /// <summary>
        ///     SMOWNERID
        /// </summary>
        public string SMOWNERID { get; set; }

        /// <summary>
        ///     Id Acceso
        /// </summary>
        public int IdAcceso { get; set; }

        /// <summary>
        ///     Id correo
        /// </summary>
        public int IDCorreo { get; set; }

        /// <summary>
        ///     Editar otras cuentas
        /// </summary>
        public int EditarOtrasCuentas { get; set; }

        /// <summary>
        ///     Id sucursal
        /// </summary>
        public int IdSucursal { get; set; }

        /// <summary>
        ///     Id nivel
        /// </summary>
        public int IdNivel { get; set; }

        /// <summary>
        ///     Ventas ?
        /// </summary>
        public bool Ventas { get; set; }

        /// <summary>
        ///     Inventario ?
        /// </summary>
        public bool Inventario { get; set; }

        /// <summary>
        ///     Compras ?
        /// </summary>
        public bool Compras { get; set; }

        /// <summary>
        ///     Produccion ?
        /// </summary>
        public bool Produccion { get; set; }

        /// <summary>
        ///     Cartera ?
        /// </summary>
        public bool Cartera { get; set; }

        /// <summary>
        ///     Caja ?
        /// </summary>
        public bool Caja { get; set; }

        /// <summary>
        ///     Bancos ?
        /// </summary>
        public bool Bancos { get; set; }

        /// <summary>
        ///     Administración ?
        /// </summary>
        public bool Administracion { get; set; }

        /// <summary>
        ///     Proveedores ?
        /// </summary>
        public bool Proveedores { get; set; }

        /// <summary>
        ///     Proyecto >
        /// </summary>
        public bool Proyecto { get; set; }

        /// <summary>
        ///     Telefono
        /// </summary>
        public string Telefono { get; set; }

        /// <summary>
        ///     Id descuento
        /// </summary>
        public int IdDescuento { get; set; }

        /// <summary>
        ///     Mostrar crm
        /// </summary>
        public int Mostrar_CRM { get; set; }

        /// <summary>
        ///     Computadora
        /// </summary>
        public string PC { get; set; }

        /// <summary>
        ///     Descripcion del  usario
        /// </summary>
        public string Descripcion_Usuario { get; set; }

        /// <summary>
        ///     Index inicial
        /// </summary>
        public int startIndex { get; set; }

        /// <summary>
        ///     Index final
        /// </summary>
        public int endIndex { get; set; }

        /// <summary>
        ///     Correo
        /// </summary>
        public string Correo { get; set; }

        /// <summary>
        ///     Activo
        /// </summary>
        public int Activo { get; set; }

        /// <summary>
        ///     Descuento máximo
        /// </summary>
        public int DescuentoMax { get; set; }

        #endregion
    }
}