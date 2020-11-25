using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSDatos;
using CSNegocios.Modelos;
using CSNegocios.Servicios.General;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace CSNegocios.Servicios
{
    /// <summary>
    /// Servicio bodegas
    /// </summary>
    public class ServicioBodegas : ServicioBase
    {
        /// <summary>
        /// Mostrar tipo bodega
        /// </summary>
        /// <param name="gc"></param>
        /// <param name="gv"></param>
        public void MostrarTipoBodega(GridControl gc, GridView gv)
        {
            gc.DataSource = null;

            gv.Columns.Clear();

            strSql = "select IdTipoBodega, Descripcion, " +
                     "TB, cast(Activo as bit) as Activo from Tipos_Bodegas;";

            gc.DataSource = Coneccion.EjecutarTextTable(strSql);

            gv.ActiveFilterString = "[Activo] == true";
        }

        public void MostrarTipoBodega(CheckedComboBoxEdit ckCombo)
        {
            ckCombo.Properties.DataSource =
                Coneccion.EjecutarTextDataTable("select IdTipoBodega, Descripcion from Tipos_Bodegas");

            ckCombo.Properties.ValueMember = "IdTipoBodega";
            ckCombo.Properties.DisplayMember = "Descripcion";
            ckCombo.Properties.EditValueType = EditValueTypeCollection.List;
        }

        public void MostrarBodegas(GridControl gc, GridView gv)
        {
            gc.DataSource = null;

            gv.Columns.Clear();

            strSql = "select b.IdBodega, b.Descripción_Bodega as Bodega, e.NombreCorto as Empresa " +
                     "from Bodegas b " +
                     "         inner join Empresas E on b.IdEmpresa = E.IdEmpresa ";

            gc.DataSource = Coneccion.EjecutarTextTable(strSql);
        }

        public void GuardarTipoBodega(int id, string descripcion, string abreviatura, bool activo)
        {
            Coneccion.EjecutarSp("spGuardarTipoBodega", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("Id", SqlDbType.Int)).Value = id;
                cmd.Parameters.Add(new SqlParameter("Des", SqlDbType.NVarChar)).Value = descripcion;
                cmd.Parameters.Add(new SqlParameter("Abrv", SqlDbType.NVarChar)).Value = abreviatura;
                cmd.Parameters.Add(new SqlParameter("Activo", SqlDbType.Int)).Value = activo ? 1 : 0;
            });
        }

        public DataRow CargarInfoBodega(string idBodega)
        {
            dataTable = Coneccion.EjecutarSpDataTable("spObtenerInfoBodega",
                cmd => { cmd.Parameters.Add(new SqlParameter("Idbodega", SqlDbType.NVarChar)).Value = idBodega; });

            return dataTable != null && dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
        }

        public DataTable ObtenerTipoPorBodega(string idBodega)
        {
            return Coneccion.EjecutarTextDataTable(
                "select IdTipoBodega from Control_TipoBodega where IdBodega = @IdBodega",
                cmd => { cmd.Parameters.Add(new SqlParameter("@IdBodega", SqlDbType.NVarChar)).Value = idBodega; });
        }

        public bool VerificarSiYaExiste(string idBodega)
        {
            return Convert.ToInt32(Coneccion.ObterResultadoText(
                       $"select count(*) from Bodegas where IdBodega = '{idBodega}'")) >
                   0;
        }

        public void GuardarBodega(ModeloBodega modeloBodega, DataTable dtTipos, int idLogin)
        {
            Coneccion.EjecutarSp("spGuardarBodega", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("IdBodega", SqlDbType.NVarChar)).Value = modeloBodega.IdBodega;
                cmd.Parameters.Add(new SqlParameter("Descripcion", SqlDbType.NVarChar)).Value =
                    modeloBodega.Descripcion;
                cmd.Parameters.Add(new SqlParameter("Comentarios", SqlDbType.NVarChar)).Value =
                    RevisarSiEsNuloSql(modeloBodega.Comentarios);
                cmd.Parameters.Add(new SqlParameter("CuentaCosto", SqlDbType.NVarChar)).Value =
                    RevisarSiEsNuloSql(modeloBodega.CuentaCosto);
                cmd.Parameters.Add(new SqlParameter("IdSucursal", SqlDbType.TinyInt)).Value = modeloBodega.IdSucursal;
                
                cmd.Parameters.Add(new SqlParameter("IdLogin", SqlDbType.Int)).Value = idLogin;

                cmd.Parameters.Add(new SqlParameter("TiposPermitidos", SqlDbType.Structured)
                        {TypeName = "TablaIdTipoBodega"}).Value =
                    dtTipos;
            });
        }
    }
}