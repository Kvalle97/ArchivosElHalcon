using System;
using System.Data;
using System.Data.SqlClient;
using CSDatos;
using CSNegocios.Modelos;
using CSNegocios.Servicios.General;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace CSNegocios.Servicios
{
    /// <summary>
    ///     Servicio Usuarioss
    /// </summary>
    public class ServicioUsuarios : ServicioBase
    {
        /// <summary>
        ///     Cargar usuarios
        /// </summary>
        /// <param name="gc"></param>
        /// <param name="gv"></param>
        public void CargarUsuarios(GridControl gc, GridView gv)
        {
            gc.DataSource = Coneccion.EjecutarSpDataTable("spObtenerTodosLosUsuarios", null);

            if (gc.DataSource != null)
            {
                gv.ActiveFilterString = "[Activo] == true";
                gv.Columns["IdUsuario"].Visible = false;
            }
        }

        /// <summary>
        ///     Cargar Niveles
        /// </summary>
        /// <param name="lue"></param>
        public void CargarNiveles(LookUpEdit lue)
        {
            lue.Properties.DataSource =
                Coneccion.EjecutarTextTable(
                    "select format(IDNIVEL, 'D2') as IdNivel, NIVEL from NIVELES order by IDNIVEL", null);

            lue.Properties.ValueMember = "IdNivel";
            lue.Properties.DisplayMember = "NIVEL";

            lue.Properties.ForceInitialize();

            lue.ItemIndex = 0;
        }

        /// <summary>
        /// Carga reporte usuario
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <param name="mostrarInactivo"></param>
        /// <returns></returns>
        public DataTable CargarReporteUsuario(int idEmpresa, bool mostrarInactivo)
        {
            return Coneccion.EjecutarSpDataTable("spReporteUsuarios", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("idEmpresa", SqlDbType.Int)).Value = idEmpresa;
                cmd.Parameters.Add(new SqlParameter("mostrarInactivo", SqlDbType.Bit)).Value = mostrarInactivo;
            });
        }

        /// <summary>
        /// Obtener usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public DataRow ObtenerUsuario(int idUsuario)
        {
            dataTable = Coneccion.EjecutarTextTable("select * from Usuarios where IdUsuario = @Id",
                cmd => { cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = idUsuario; });

            if (dataTable == null || dataTable.Rows.Count <= 0) return null;
            else return dataTable.Rows[0];
        }

        /// <summary>
        /// Muestra los roles disponibles
        /// </summary>
        /// <param name="ckcb">Checked combobox</param>
        public void CargarRoles(CheckedComboBoxEdit ckcb)
        {
            ckcb.Properties.DataSource = Coneccion.EjecutarTextTable(
                "select Id,Nombre from Rol;", null);

            ckcb.Properties.DisplayMember = "Nombre";
            ckcb.Properties.ValueMember = "Id";
            ckcb.Properties.EditValueType = EditValueTypeCollection.List;
        }


        /// <summary>
        /// Muestra sucursales
        /// </summary>
        /// <param name="ckcb">Checked combobox</param>
        public void CargarSucursales(CheckedComboBoxEdit ckcb)
        {
            ckcb.Properties.DataSource = Coneccion.EjecutarTextTable(
                "select cast(IdEmpresa as int) IdEmpresa, Empresa from Empresas;", null);

            ckcb.Properties.DisplayMember = "Empresa";
            ckcb.Properties.ValueMember = "IdEmpresa";
            ckcb.Properties.EditValueType = EditValueTypeCollection.List;
        }

        /// <summary>
        /// Muestra los correos del usuario
        /// </summary>
        /// <param name="ckcb">Checked combobox</param>
        /// <param name="idUsuario"></param>
        public void CargarCorreosDeUsuario(CheckedComboBoxEdit ckcb, int idUsuario)
        {
            ckcb.Properties.DataSource = Coneccion.EjecutarTextTable(
                "select IDCorreo, Correo from Usuarios_Correos where IdUsuario = @Id;",
                cmd => { cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = idUsuario; });

            ckcb.Properties.DisplayMember = "Correo";
            ckcb.Properties.ValueMember = "IDCorreo";
            ckcb.Properties.EditValueType = EditValueTypeCollection.List;
        }

        /// <summary>
        /// Obtener accesos de usario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public DataTable ObtenerAccesosDeUsuario(int idUsuario)
        {
            return Coneccion.EjecutarSpDataTable("spObtenerAccesosSegunUsuario",
                cmd => { cmd.Parameters.Add(new SqlParameter("idUsuario", SqlDbType.Int)).Value = idUsuario; });
        }

        /// <summary>
        /// Obtener descuento maximo del usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public decimal ObtenerDescuentoMaximoDelUsuario(int idUsuario)
        {
            return Convert.ToDecimal(Coneccion.ObterResultadoText(
                "select max(DescuentoMax) as DescuentoMax from dbo.Usuarios_Empresas where IdUsuario=@Id",
                cmd => { cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = idUsuario; }));
        }


        /// <summary>
        ///     Cargar Niveles
        /// </summary>
        /// <param name="lue"></param>
        public void CargarTipoDescuento(LookUpEdit lue)
        {
            strSql = "select cast(Id as int) as Id, Descripcion from TiposDeDescuento;";

            lue.Properties.DataSource =
                Coneccion.EjecutarTextTable(
                    strSql, null);

            lue.Properties.ValueMember = "Id";
            lue.Properties.DisplayMember = "Descripcion";

            lue.Properties.ForceInitialize();

            lue.ItemIndex = 0;
        }

        /// <summary>
        /// Carga los correos en el data table
        /// </summary>
        /// <param name="gc"></param>
        /// <param name="gv"></param>
        /// <param name="idUsuario"></param>
        public void CargarCorreos(GridControl gc, GridView gv, int idUsuario)
        {
            strSql = $"select IDCorreo,Correo from Usuarios_Correos where IdUsuario = {idUsuario};";

            gc.DataSource = Coneccion.EjecutarTextTable(strSql, null);

            gv.Columns["Correo"].ColumnEdit = new RepositoryItemTextEdit()
            {
                Mask =
                {
                    MaskType = MaskType.RegEx,
                    EditMask = "(\\w|[\\.\\-])+@(\\w|[\\-]+\\.)*(\\w|[\\-]){2,63}\\.[a-zA-Z+\\.]{2,20}"
                }
            };
            gv.Columns["IDCorreo"].Visible = false;
        }

        /// <summary>
        /// Obtiene las sucursales asociadas
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public DataTable ObtenerSucursalesAsociadas(int idUsuario)
        {
            strSql =
                $"select cast(IdEmpresa as int) as IdEmpresa from Usuarios_Empresas where IdUsuario = {idUsuario};";

            return Coneccion.EjecutarTextTable(strSql);
        }

        /// <summary>
        /// Obtiene los roles asociados al usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public DataTable ObtenerRolesAsociados(int idUsuario)
        {
            strSql = $"select IdRol from UsuarioRol where IdUsuario = {idUsuario};";

            return Coneccion.EjecutarTextTable(strSql);
        }

        /// <summary>
        /// Borra el correo segun el id
        /// </summary>
        /// <param name="idCorreo"></param>
        public void BorrarCorreo(int idCorreo)
        {
            strSql = $"delete Usuarios_Correos where IDCorreo = {idCorreo}";

            Coneccion.EjecutarSpText(strSql);
        }

        /// <summary>
        /// Usuario Esta siendo usado ?
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public bool UsuarioEstaSiendoUsado(string usuario, int idUsuario)
        {
            strSql =
                "select count(*) from Usuarios where IdUsuario != @IdUsuario and UPPER(Usuario) = UPPER(@Usuario);";

            return Convert.ToBoolean(
                Coneccion.ObterResultadoText(strSql, cmd =>
                {
                    cmd.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.Int)).Value = idUsuario;
                    cmd.Parameters.Add(new SqlParameter("Usuario", SqlDbType.NVarChar)).Value = usuario;
                })
            );
        }

        public void GuardarUsuario(ModeloUsuario modeloUsuario)
        {
            Coneccion.EjecutarSp("spGuardarUsuarioAdministracionNuevo",
                cmd =>
                {
                    cmd.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.Int)).Value = modeloUsuario.IdUsuario;
                    cmd.Parameters.Add(new SqlParameter("Usuario", SqlDbType.NVarChar)).Value = modeloUsuario.Usuario;
                    cmd.Parameters.Add(new SqlParameter("Nombres", SqlDbType.NVarChar)).Value = modeloUsuario.Nombres;
                    cmd.Parameters.Add(new SqlParameter("Apellidos", SqlDbType.NVarChar)).Value =
                        RevisarSiEsNuloSql(modeloUsuario.Apellidos);
                    cmd.Parameters.Add(new SqlParameter("IdNivel", SqlDbType.TinyInt)).Value = modeloUsuario.IdNivel;
                    cmd.Parameters.Add(new SqlParameter("Telefono", SqlDbType.NVarChar)).Value =
                        RevisarSiEsNuloSql(modeloUsuario.Telefono);
                    
                    if (modeloUsuario.IdEmpresaUbicacion < 0)
                    {
                        cmd.Parameters.Add(new SqlParameter("IdEmpresaUbicacion", SqlDbType.Int)).Value =
                            DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("IdEmpresaUbicacion", SqlDbType.Int)).Value =
                            modeloUsuario.IdEmpresaUbicacion;
                    }

                    cmd.Parameters.Add(new SqlParameter("Activo", SqlDbType.Int)).Value = modeloUsuario.Activo;
                    cmd.Parameters.Add(new SqlParameter("IdDescuento", SqlDbType.TinyInt)).Value =
                        modeloUsuario.IdDescuento;
                    cmd.Parameters.Add(new SqlParameter("Ventas", SqlDbType.Bit)).Value = modeloUsuario.Ventas;
                    cmd.Parameters.Add(new SqlParameter("Inventario", SqlDbType.Bit)).Value = modeloUsuario.Inventario;
                    cmd.Parameters.Add(new SqlParameter("Compras", SqlDbType.Bit)).Value = modeloUsuario.Compras;
                    cmd.Parameters.Add(new SqlParameter("Produccion", SqlDbType.Bit)).Value = modeloUsuario.Produccion;
                    cmd.Parameters.Add(new SqlParameter("Cartera", SqlDbType.Bit)).Value = modeloUsuario.Cartera;
                    cmd.Parameters.Add(new SqlParameter("Caja", SqlDbType.Bit)).Value = modeloUsuario.Caja;
                    cmd.Parameters.Add(new SqlParameter("Bancos", SqlDbType.Bit)).Value = modeloUsuario.Bancos;
                    cmd.Parameters.Add(new SqlParameter("Administracion", SqlDbType.Bit)).Value =
                        modeloUsuario.Administracion;
                    cmd.Parameters.Add(new SqlParameter("Proveedores", SqlDbType.Bit)).Value =
                        modeloUsuario.Proveedores;
                    cmd.Parameters.Add(new SqlParameter("Proyecto", SqlDbType.Bit)).Value = modeloUsuario.Proyecto;
                });
        }

        public DataRow ObtenerUltimoUsuario()
        {
            strSql = "select top (1) * from Usuarios order by FechaCreado desc;";
            dataTable = Coneccion.EjecutarTextTable(strSql);

            if (dataTable == null || dataTable.Rows.Count <= 0) return null;
            else return dataTable.Rows[0];
        }

        public string ObtenerCorreo(int idCorreo)
        {
            return Convert.ToString(
                Coneccion.ObterResultadoText("select Correo from Usuarios_Correos where IDCorreo = @Id;",
                    cmd => { cmd.Parameters.Add(new SqlParameter("Id", SqlDbType.Int)).Value = idCorreo; }));
        }

        public void CambiarContraUsuario(int idUsuario, string contrasenia, bool temporal)
        {
            Coneccion.EjecutarSp("spCambiarContraDeUsuario",
                cmd =>
                {
                    cmd.Parameters.Add(new SqlParameter("Contrasenia", SqlDbType.NVarChar)).Value = contrasenia;
                    cmd.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.Int)).Value = idUsuario;
                    cmd.Parameters.Add(new SqlParameter("Temporal", SqlDbType.Bit)).Value = temporal;
                });
        }

        public void GuardarCorreoUsuario(int idCorreo, string correo, int idUsuario)
        {
            Coneccion.EjecutarSp("spGuardarCorreoUsuario", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("IdCorreo", SqlDbType.Int)).Value = idCorreo;
                cmd.Parameters.Add(new SqlParameter("Correo", SqlDbType.NVarChar)).Value = correo;
                cmd.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.Int)).Value = idUsuario;
            });
        }

        public void GuardarSucursal(int idUsuario, string usuario, int idEmpresa)
        {
            Coneccion.EjecutarSp("spGuardarSucuarsalesAsociadas", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.Int)).Value = idUsuario;
                cmd.Parameters.Add(new SqlParameter("IdEmpresa", SqlDbType.TinyInt)).Value = idEmpresa;
                cmd.Parameters.Add(new SqlParameter("Usuario", SqlDbType.NVarChar)).Value = usuario;
            });
        }

        public void GuardarRol(int idUsuario, int idRol)
        {
            Coneccion.EjecutarSp("spGuardarRolesAsociados", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("IdRol", SqlDbType.Int)).Value = idRol;
                cmd.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.Int)).Value = idUsuario;
            });
        }

        public void EliminarSucursalesAsociadas(int idUsuario)
        {
            Coneccion.EjecutarSpText($"delete Usuarios_Empresas where IdUsuario = {idUsuario}");
        }

        public void EliminarRolesAsociados(int idUsuario)
        {
            Coneccion.EjecutarSpText($"delete UsuarioRol where IdUsuario = {idUsuario}");
        }
    }
}