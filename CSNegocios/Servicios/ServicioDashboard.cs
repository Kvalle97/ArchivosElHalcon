using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using CSDatos;
using CSNegocios.Servicios.General;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace CSNegocios.Servicios
{
    public class ServicioDashboard : ServicioBase
    {
        public void MostrarSistemasOModulo(LookUpEdit lue)
        {
            strSql = "select Id, NombreAMostrar from SistemaOModulo " +
                     "union all " +
                     "select null, 'NINGUNO'";

            lue.Properties.DataSource = Coneccion.EjecutarTextDataTable(strSql);
            lue.Properties.ValueMember = "Id";
            lue.Properties.DisplayMember = "NombreAMostrar";
            lue.Properties.NullText = "NINGUNO";

            lue.EditValue = null;
        }

        public void Guardar(int? id, string nombre, int? idSistemaOModulo, string xml, bool esSubReporte)
        {
            Coneccion.EjecutarSp("spGuardarDashboard", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("Id", SqlDbType.Int)).Value = RevisarSiEsNuloSql(id);
                cmd.Parameters.Add(new SqlParameter("Xml", SqlDbType.Xml)).Value = XDocument.Parse(xml).CreateReader();
                cmd.Parameters.Add(new SqlParameter("SistemaOModulo", SqlDbType.Int)).Value =
                    RevisarSiEsNuloSql(idSistemaOModulo);
                cmd.Parameters.Add(new SqlParameter("Nombre", SqlDbType.NVarChar)).Value = nombre;
                cmd.Parameters.Add(new SqlParameter("EsSubReporte", SqlDbType.Bit)).Value = esSubReporte;
            });
        }

        public DataTable  ObtenerParametrosHerdados(int idSubDashboard)
        {
            return Coneccion.EjecutarTextDataTable($"select ParamName from SubReportesPorDashboardParameterosHereados sph " +
                                                   $"inner join SubReportesPorDashboard SRPD on sph.Id = SRPD.Id where SRPD.DashboardId = {idSubDashboard};");
        }

        public DataTable DashboardDisponibles()
        {
            strSql = "select Id, NombreAMostrar from Dashboard where EsSubReporte = 0 or EsSubReporte is null;";

            return Coneccion.EjecutarTextTable(strSql);
        }

        public string ObtenerDashboard(int id)
        {
            strSql = $"select Contenido from Dashboard where Id = {id};";

            object ob = Coneccion.ObterResultadoText(strSql);

            return Convert.ToString(ob);
        }

        public void CargarDashboardDisponibles(GridControl gc, GridView gv)
        {
            strSql = "select d.Id, d.NombreAMostrar as Dashboard " +
                     "from Dashboard d " +
                     "         left join SistemaOModulo SOM on d.SistemaOModulo = SOM.Id; ";

            gc.DataSource = Coneccion.EjecutarTextDataTable(strSql);
        }

        public void CargarDashboardDisponibles(LookUpEdit lue)
        {
            strSql = "select d.Id, SOM.NombreAMostrar as Sistema, d.NombreAMostrar as Dashboard " +
                     "from Dashboard d " +
                     "         left join SistemaOModulo SOM on d.SistemaOModulo = SOM.Id " +
                     "where d.EsSubReporte =1; ";

            lue.Properties.DataSource = Coneccion.EjecutarTextDataTable(strSql);
            lue.Properties.ValueMember = "Id";
            lue.Properties.DisplayMember = "Dashboard";
            lue.ItemIndex = 0;
        }

        public string ObtenerNombreDelDashboard(int id)
        {
            return Convert.ToString(
                Coneccion.ObterResultadoText($"select NombreAMostrar from Dashboard where Id = {id}"));
        }

        public DataRow CargarSubReporte(string itemName, int dashboardId)
        {
            strSql =
                $"select SubDashboardId, Param from SubReportesPorDashboard where DashboardId = {dashboardId} " +
                $"and ItemName = '{itemName}';";

            dataTable = Coneccion.EjecutarTextDataTable(strSql);

            return dataTable != null && dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
        }
    }
}