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
            strSql = "select IdTipoBodega, Descripcion, " +
                     "TB, cast(Activo as bit) as Activo from Tipos_Bodegas;";

            gc.DataSource = Coneccion.EjecutarTextTable(strSql);

            gv.ActiveFilterString = "[Activo] == true";
        }

        public void MostrarBodegas(GridControl gc, GridView gv)
        {
            strSql = "select b.IdBodega, b.Descripción_Bodega as Bodega, b.IdEmpresa " +
                     "from Bodegas b " +
                     "         inner join Empresas E on b.IdEmpresa = E.IdEmpresa; ";

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
    }
}