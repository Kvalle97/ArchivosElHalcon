using System;
using System.Data;
using System.Data.SqlClient;
using CSDatos;
using CSNegocios.Servicios.General;
using DevExpress.XtraEditors;
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
    }
}