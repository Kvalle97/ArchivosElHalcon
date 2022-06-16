using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSDatos;
using CSNegocios.Modelos;
using CSNegocios.Properties;
using CSNegocios.Servicios.General;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPivotGrid;
using SqlParameter = System.Data.SqlClient.SqlParameter;

namespace CSNegocios.Servicios
{
    public class ServicioRecalcularMovimiento : ServicioBase
    {
        string strsql;
        string Error;
        public void ObtenerEmpresas(LookUpEdit lue)
        {
            dataTable = Coneccion.EjecutarSpDataTable("SpAdmonCargarSucursales");

            lue.Properties.DataSource = dataTable;
            lue.Properties.ValueMember = "IdEmpresa";
            lue.Properties.DisplayMember = "Empresa";
            lue.Properties.ForceInitialize();
            lue.ItemIndex = 0;
        }

        public void ObtenerMov(LookUpEdit lue)
        {

            dataTable = Coneccion.EjecutarSpDataTable("SpAdmonObtenerMov");

            lue.Properties.DataSource = dataTable;
            lue.Properties.ValueMember = "IdTipoMov";
            lue.Properties.DisplayMember = "TipoMov";
            lue.Properties.ForceInitialize();
            lue.ItemIndex = 1;

        }

        public void ObtenerDoc(LookUpEdit lue, int tipomov, int idempresa)
        {
            dataTable = Coneccion.EjecutarSpDataTable("spAdmonObtenerDocumento", cmd =>
             {
                 cmd.Parameters.Add(new SqlParameter("IdTipomov", SqlDbType.Int)).Value = tipomov;
                 cmd.Parameters.Add(new SqlParameter("idEmpresa", SqlDbType.Int)).Value = idempresa;

             });

            lue.Properties.DataSource = dataTable;
            lue.Properties.ValueMember = "IdTipoDoc";
            lue.Properties.DisplayMember = "TipoDoc";
            lue.Properties.ForceInitialize();
            lue.ItemIndex = 0;

        }

        //public DataTable TipoDoc(int tipomov, int idempresa)
        //{


        //    try
        //    {

        //        strsql = ("EXEC spAdmonObtenerDocumento  @idTipomov = '" + tipomov + "'@idEmpresa = '" + idempresa +"'");
        //        DataSet dataSet = new DataSet();
        //        Coneccion.Leer(ref dataSet, strsql, ref Error);
        //        return dataSet.Tables[0];

        //    }
        //    catch
        //    {
        //        throw new Exception(" Error ");
        //    }


        //}


        public void ObtenerProductosDeLaOrden(GridControl gce, GridView gve, ModeloRecalcularMovimiento recalcular)
        {


            gce.DataSource = Coneccion.EjecutarSpDataTable("spAdmonObteneDocumentos_Recalcular", cmd =>
            {
                {
                    cmd.Parameters.Add(new SqlParameter("Desde", SqlDbType.Date)).Value = recalcular.Desde;
                    cmd.Parameters.Add(new SqlParameter("Hasta", SqlDbType.Date)).Value = recalcular.Hasta;
                    cmd.Parameters.Add(new SqlParameter("tipodoc", SqlDbType.Int)).Value = recalcular.IdTipoDoc;
                    cmd.Parameters.Add(new SqlParameter("idEmpresa", SqlDbType.Int)).Value = recalcular.IdEmpresa;
                }
            });

        }
        public int RecalcularMovimiento(int idtipodoc, int nodoc, int periodo)
        {
            return Coneccion.EjecutarSp("spRecalcularMovimientoMCIxDoc", cmd =>
            {
                {
                    cmd.Parameters.Add(new SqlParameter("idtipodoc", SqlDbType.Int)).Value = idtipodoc;
                    cmd.Parameters.Add(new SqlParameter("nodoc", SqlDbType.Int)).Value = nodoc;
                    cmd.Parameters.Add(new SqlParameter("periodo", SqlDbType.Int)).Value = periodo;
                }
            });
        }

        public int ContabilizarDocumento(int idtipodoc, int nodoc)
        {
            return Coneccion.EjecutarSp("sp_Contabilizar_Documento", cmd =>
            {
                {
                    cmd.Parameters.Add(new SqlParameter("idtipodoc", SqlDbType.Int)).Value = idtipodoc;
                    cmd.Parameters.Add(new SqlParameter("nodoc", SqlDbType.Int)).Value = nodoc;
                    cmd.Parameters.Add(new SqlParameter("Sobrescribir", SqlDbType.Bit)).Value = 1;
                }
            });

        }
    }


}


