using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSNegocios;
using CSPresentacion.Sistema.Utilidades;
using DevExpress.DashboardCommon;
using DevExpress.DataAccess;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace CSPresentacion.Sistema.Administracion
{
    public partial class FrmDashboardViewer : XtraForm
    {
        public FrmDashboardViewer()
        {
            InitializeComponent();
        }

        private void FrmDashboardViewer_Load(object sender, EventArgs e)
        {
        }

        private void ArreglarDs()
        {
            try
            {
                DashboardSqlDataSource ds = (DashboardSqlDataSource) dashboardViewer1.Dashboard.DataSources[0];

                this.dashboardViewer1.Dashboard.DataSources.Clear();
                this.dashboardViewer1.DataSourceOptions.Reset();

                DashboardSqlDataSource dsItem = new DashboardSqlDataSource("Origen de datos SQL 1",
                    new MsSqlConnectionParameters(OperacionesGlobal.Server, OperacionesGlobal.DataBase,
                        OperacionesGlobal.User, OperacionesGlobal.Pasword, MsSqlAuthorizationType.SqlServer))
                {
                    DataProcessingMode = DataProcessingMode.Server,
                    ComponentName = this.dashboardViewer1.Name
                };


                //dsItem.Queries.AddRange(ds.Queries);

                //dsItem.ConnectionOptions.CommandTimeout = Int32.MaxValue;

                dsItem.Queries.Add(new StoredProcQuery("spMetasxVendedorconMargenComisiones",
                    "spMetasxVendedorconMargenComisiones",
                    new List<QueryParameter>()
                    {
                        new QueryParameter("@año", typeof(DevExpress.DataAccess.Expression),
                            new DevExpress.DataAccess.Expression("?Año", typeof(int))),
                        new QueryParameter("@mes", typeof(DevExpress.DataAccess.Expression),
                            new DevExpress.DataAccess.Expression("?Mes", typeof(byte)))
                    }));

                //dsItem.ClearRows();
                dsItem.RebuildResultSchema();
                dsItem.Fill();

                this.dashboardViewer1.Dashboard.DataSources.Add(dsItem);

                foreach (var dashboardItem in this.dashboardViewer1.Dashboard.Items)
                {
                    DataDashboardItem data = (DataDashboardItem) dashboardItem;
                    data.DataSource = dsItem;
                }


                //var d = this.dashboardViewer1.Dashboard.DataSources[0];

                //if (d is DevExpress.DataAccess.Sql.SqlDataSource @sqlCon)
                //{
                //    @sqlCon = new SqlDataConnection(new SqlDataSource("Coneccion",
                //        new SqlServerConnectionParametersBase(OperacionesGlobal.Server, OperacionesGlobal.DataBase,
                //            OperacionesGlobal.User, OperacionesGlobal.Pasword)));
                //}
                //else
                //{
                //    UIHelper.AlertarDeError("Data source no soportado");
                //}
            }
            catch (Exception e)
            {
                UIHelper.MostrarError(e);
            }
        }

        private void FrmDashboardViewer_Shown(object sender, EventArgs e)
        {
            var op = new OpenFileDialog();

            if (op.ShowDialog() == DialogResult.OK)
            {
                //dashboardViewer1.DataSourceOptions.ObjectDataSourceLoadingBehavior = DocumentLoadingBehavior.LoadAsIs;
                this.dashboardViewer1.LoadDashboard(op.FileName);

                //ArreglarDs();
            }
        }

        private void DashboardOnConfigureDataConnection(object sender, DashboardConfigureDataConnectionEventArgs e)
        {
            //if (e.ConnectionParameters is MsSqlConnectionParameters @msSqlConnectionParameters)
            //{
            //    //@msSqlConnectionParameters.DatabaseName = OperacionesGlobal.DataBase;
            //    @msSqlConnectionParameters.ServerName = OperacionesGlobal.Server;
            //    @msSqlConnectionParameters.UserName = OperacionesGlobal.User;
            //    @msSqlConnectionParameters.AuthorizationType = MsSqlAuthorizationType.SqlServer;
            //    @msSqlConnectionParameters.Password = OperacionesGlobal.Pasword;
            //}

            //foreach (var dashboardItem in this.dashboardViewer1.Dashboard.Items)
            //{
            //    DataDashboardItem data = (DataDashboardItem) dashboardItem;
            //    data.DataSource = this.dashboardViewer1.Dashboard.DataSources[0];
            //}
        }

        private void dashboardViewer1_DashboardChanged(object sender, EventArgs e)
        {
            //dashboardViewer1.ReloadDataAsync();

            //foreach (var dsDashboardDataSource in
            //    dashboardViewer1.Dashboard.DataSources)
            //{
            //    if (dsDashboardDataSource is SqlDataSource @ds)
            //    {
            //        WaitDialogForm wait = new WaitDialogForm("Por favor espere...", "Cargando datos");

            //        wait.Show();

            //        ds.FillAsync()
            //            .GetAwaiter().OnCompleted(() =>
            //            {
            //                dashboardViewer1.ReloadDataAsync();

            //                wait.Close();
            //            });
            //    }
            //}

            //dashboardViewer1.Dashboard.ConfigureDataConnection += DashboardOnConfigureDataConnection;
        }

        private void dashboardViewer1_ConfigureDataConnection(object sender,
            DashboardConfigureDataConnectionEventArgs e)
        {
            //if (e.ConnectionParameters is MsSqlConnectionParameters @msSqlConnectionParameters)
            //{ 
            //    //@msSqlConnectionParameters.DatabaseName = OperacionesGlobal.DataBase;
            //    @msSqlConnectionParameters.ServerName = OperacionesGlobal.Server;
            //    @msSqlConnectionParameters.UserName = OperacionesGlobal.User;
            //    @msSqlConnectionParameters.AuthorizationType = MsSqlAuthorizationType.SqlServer;
            //    @msSqlConnectionParameters.Password = OperacionesGlobal.Pasword;

            //}


            //foreach (var dashboardItem in this.dashboardViewer1.Dashboard.Items)
            //{
            //    DataDashboardItem data = (DataDashboardItem)dashboardItem;
            //    data.DataSource = this.dashboardViewer1.Dashboard.DataSources[0];
            //}
        }
    }
}