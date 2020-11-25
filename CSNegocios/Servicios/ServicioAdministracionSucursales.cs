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
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace CSNegocios.Servicios
{
    public class ServicioAdministracionSucursales : ServicioBase
    {
        public void CargarSucursales(GridControl gc)
        {
            gc.DataSource = Coneccion.EjecutarTextDataTable("select IdEmpresa, Empresa, NombreCorto from Empresas;");
        }

        public void CargarTipoDeSucursales(LookUpEdit lue)
        {
            lue.Properties.DataSource = Coneccion.EjecutarTextDataTable("select ID, TipoSucursal from TipoSucursal");
            lue.Properties.ValueMember = "ID";
            lue.Properties.DisplayMember = "TipoSucursal";
            lue.ItemIndex = 0;
        }

        public void CargarCuentaEmpresa(GridControl gc, GridView gv, int idEmpresa)
        {
            gc.DataSource = Coneccion.EjecutarSpDataTable("spMostrarCuentasDeEmpresa",
                cmd => { cmd.Parameters.Add(new SqlParameter("IdEmpresa", SqlDbType.Int)).Value = idEmpresa; });

            gv.Columns["Cuenta"].OptionsColumn.AllowEdit = false;
        }


        public DataRow CargarInfoSucursal(int sucursal)
        {
            dataTable = Coneccion.EjecutarSpDataTable("spObtenerInfoSucursal",
                cmd => { cmd.Parameters.Add(new SqlParameter("IdSucursal", SqlDbType.Int)).Value = sucursal; });

            return dataTable != null && dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
        }

        public void ActualizarAtributoNoListado(string columnName, string value, int idSucursal)
        {
            strSql = $"update Empresas set [{columnName}] = @Val where IdEmpresa = @IdSuc";

            Coneccion.EjecutarSpText(strSql, cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("@IdSuc", SqlDbType.Int)).Value = idSucursal;
                cmd.Parameters.Add(new SqlParameter("@ColumName", SqlDbType.NVarChar)).Value = columnName;
                cmd.Parameters.Add(new SqlParameter("@Val", SqlDbType.NVarChar)).Value = RevisarSiEsNuloSql(value);
            });
        }

        public int ExisteElIdSucursal(int idSucursal)
        {
            strSql = $"select count(*) from Empresas where IdEmpresa = {idSucursal}";

            return Convert.ToInt32(Coneccion.ObterResultadoText(strSql));
        }

        public void GuardarSucursal(ModeloSucursal mSucursal, int idLogin)
        {
            Coneccion.EjecutarSp("spGuardarSucursal", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("IdEmpresa", SqlDbType.Int)).Value = mSucursal.IdSucursal;
                cmd.Parameters.Add(new SqlParameter("Sucursal", SqlDbType.NVarChar)).Value = mSucursal.Sucursal;
                cmd.Parameters.Add(new SqlParameter("Slogan", SqlDbType.NVarChar)).Value = mSucursal.Slogan;
                cmd.Parameters.Add(new SqlParameter("Direccion", SqlDbType.NVarChar)).Value = mSucursal.Direccion;
                cmd.Parameters.Add(new SqlParameter("TipoSucursal", SqlDbType.Int)).Value = mSucursal.TipoSucursal;
                cmd.Parameters.Add(new SqlParameter("Oficina", SqlDbType.NVarChar)).Value = mSucursal.Oficina;
                cmd.Parameters.Add(new SqlParameter("Telefonos", SqlDbType.NVarChar)).Value = mSucursal.Telefonos;
                cmd.Parameters.Add(new SqlParameter("Fax", SqlDbType.NVarChar)).Value = mSucursal.Fax;
                cmd.Parameters.Add(new SqlParameter("Email", SqlDbType.NVarChar)).Value = mSucursal.Email;
                cmd.Parameters.Add(new SqlParameter("WebSite", SqlDbType.NVarChar)).Value = mSucursal.WebSite;
                cmd.Parameters.Add(new SqlParameter("Iva", SqlDbType.Float)).Value = mSucursal.Iva;
                cmd.Parameters.Add(new SqlParameter("IdLogin", SqlDbType.Int)).Value = idLogin;
                cmd.Parameters.Add(new SqlParameter("Nombre", SqlDbType.NVarChar)).Value = mSucursal.Nombre;
                cmd.Parameters.Add(new SqlParameter("NombreCorto", SqlDbType.NVarChar)).Value = mSucursal.NombreCorto;

            });
        }
    }
}