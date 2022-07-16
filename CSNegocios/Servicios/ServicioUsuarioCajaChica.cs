using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSDatos;
using CSNegocios.Modelos;
using CSNegocios.Servicios.General;
using DevExpress.Utils;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using static DevExpress.Xpo.Helpers.CommandChannelHelper;

namespace CSNegocios.Servicios
{
    public class ServicioUsuarioCajaChica : ServicioBase
    {
        string SqlQuery;
        string Mensaje_Error;

        public void ObtenerEmpresa(LookUpEdit lue)
        {


            dataTable = Coneccion.EjecutarSpDataTable("SpInvCargarSucursales");
            lue.Properties.DataSource = dataTable;
            lue.Properties.ValueMember = "IdEmpresa";
            lue.Properties.DisplayMember = "Empresa";
            lue.ItemIndex = 1;


        }

        public void ObtenerGastos(CheckedComboBoxEdit ckcb)
        {
            dataTable = Coneccion.EjecutarSpDataTable("SpCajacargarGastos");

            ckcb.Properties.DataSource = dataTable;
            ckcb.Properties.ValueMember = "IdGastoSucursal";
            ckcb.Properties.DisplayMember = "NombreGasto";
            ckcb.Properties.EditValueType = EditValueTypeCollection.List;

        }

        public void ObtenerCajaChica(LookUpEdit lue)
        {


            dataTable = Coneccion.EjecutarSpDataTable("SpCajaCargarcajaschicas");

            lue.Properties.DataSource = dataTable;
            lue.Properties.ValueMember = "IdCajaChica";
            lue.Properties.DisplayMember = "DescripcionCajaChica";
            lue.Properties.ForceInitialize();

        }


        public DataTable ObtenerUsuarioporEmpresa(int Idsucursal)
        {
            try
            {
                SqlQuery = ("EXEC SpCajaCargarUsuarioporEmpresa @IdEmpresa= " + Idsucursal + "");
                DataSet dataSet = new DataSet();
                Coneccion.Leer(ref dataSet, SqlQuery, ref errorGw);
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                Mensaje_Error = ex.ToString();
                throw;

            }
        }

        public int Obtenerultimacaja()
        {
            return Convert.ToInt32(Coneccion.ObterResultadoText("SELECT  TOP 1(IdCajaChica)  FROM CajasChicas ORDER BY IdCajaChica DESC;"));
        }

        public void Guardarcajachica(string descripcion, string usuario, string computadora, int activo, int idempresa)
        {
            Coneccion.EjecutarSp("spGuardarCajaChica", cmd =>
            {

                cmd.Parameters.Add(new SqlParameter("Descripcion", SqlDbType.NVarChar)).Value = descripcion;
                cmd.Parameters.Add(new SqlParameter("Usuario", SqlDbType.NVarChar)).Value = usuario;
                cmd.Parameters.Add(new SqlParameter("Computadora", SqlDbType.NVarChar)).Value = computadora;
                cmd.Parameters.Add(new SqlParameter("Activo", SqlDbType.Bit)).Value = activo;
                cmd.Parameters.Add(new SqlParameter("IdEmpresa", SqlDbType.Int)).Value = idempresa;


            });

        }

        public void GuardarGasto(int idcajachica, int gasto, string usuario, string computadora)
        {
            Coneccion.EjecutarSp("spGuardarGastosCajaChica", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("IdCajaChica", SqlDbType.Int)).Value = idcajachica;
                cmd.Parameters.Add(new SqlParameter("GastoSucursal", SqlDbType.Int)).Value = gasto;
                cmd.Parameters.Add(new SqlParameter("Usuario", SqlDbType.NVarChar)).Value = usuario;
                cmd.Parameters.Add(new SqlParameter("Computadora", SqlDbType.NVarChar)).Value = computadora;

            });

        }

        //cargar caja en data
        public void Obtenercajas(GridControl gce, GridView gve)
        {
            gce.DataSource = Coneccion.EjecutarSpDataTable("spCajaObtenerCajas");

        }


        //Cargar Usuario y sus cajas

        public void ObtenerUsuarios(GridControl gce, GridView gve)
        {
            gce.DataSource = Coneccion.EjecutarSpDataTable("spCargarUsuariowithcajas");

        }


        public DataTable Obtenergastoscajas(int Idcaja)
        {
            try
            {
                SqlQuery = ("EXEC spCargarGastosCaja @idcaja= " + Idcaja + "");
                DataSet dataSet = new DataSet();
                Coneccion.Leer(ref dataSet, SqlQuery, ref errorGw);
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                Mensaje_Error = ex.ToString();
                throw;

            }
        }

        public void GuardarUsuario(int idcajachica, int idusuario, string usuario, string computadora, int activo)
        {
            Coneccion.EjecutarSp("spGuardarUsuarioCajaChica", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("idcajachica", SqlDbType.Int)).Value = idcajachica;
                cmd.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.Int)).Value = idusuario;
                cmd.Parameters.Add(new SqlParameter("Usuario", SqlDbType.NVarChar)).Value = usuario;
                cmd.Parameters.Add(new SqlParameter("Computadora", SqlDbType.NVarChar)).Value = computadora;
                cmd.Parameters.Add(new SqlParameter("Activo", SqlDbType.Bit)).Value = activo;


            });

        }

    }
}
