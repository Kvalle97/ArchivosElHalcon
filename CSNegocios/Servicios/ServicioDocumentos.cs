using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSDatos;
using CSNegocios.Servicios.General;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace CSNegocios.Servicios
{
    public class ServicioDocumentos : ServicioBase
    {
        public void CargarTipoMovs(GridControl gc, GridView gv)
        {
            gc.DataSource = Coneccion.EjecutarTextTable("select IdTipoMov,TipoMov from TipoMov;");

            gv.Columns["IdTipoMov"].Width = 20;
        }

        public void CargarTipoDocs(GridControl gc, GridView gv)
        {
            gc.DataSource = Coneccion.EjecutarTextTable("select IdTipoDoc, IdTipoMov,TipoDoc from TipoDoc;");

            gv.Columns["IdTipoMov"].Width = 20;
            gv.Columns["IdTipoDoc"].Width = 20;
        }

        public void CargarCuentasDelDoc(GridControl gc, GridControl gv, int idDoc, int idMov)
        {
            strSql =
                "select SubTotal_D,Descuento_D,IVA_D,Retenciones_D," +
                "Total_D,SubTotal_H,Descuento_H,IVA_H,Retenciones_H," +
                "Total_H,Cuenta_D,Otras_D,Otras_H,Costos_D,Costos_H,Cuenta1_D," +
                "Cuenta2_D, Cuenta3_D from TipoDoc " +
                "where IdTipoDoc = @IdDoc and IdTipoMov = @IdMov";

            gc.DataSource = Coneccion.EjecutarTextTable(strSql, cmd =>
                {
                    cmd.Parameters.Add(new SqlParameter("IdDoc", SqlDbType.Int)).Value = idDoc;
                    cmd.Parameters.Add(new SqlParameter("IdMov", SqlDbType.Int)).Value = idMov;
                });
        }
    }
}