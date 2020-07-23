using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSNegocios;
using CSNegocios.Servicios;
using CSPresentacion.Sistema.Utilidades;
using DevExpress.DashboardCommon;
using DevExpress.DashboardWin;
using DevExpress.DataAccess;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace CSPresentacion.Sistema.Administracion
{
    public partial class FrmDashboardViewer : XtraForm
    {
        private readonly ServicioDashboard servicioDashboard = new ServicioDashboard();
        private readonly int dashboardId;


        public FrmDashboardViewer(int dashboarId)
        {
            this.dashboardId = dashboarId;
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void CargarDashboard(int id)
        {
            try
            {
                string tempFile = Path.GetTempPath() + new Guid().ToString() + ".xml";

                File.WriteAllText(tempFile, servicioDashboard.ObtenerDashboard(id));


                dashboardViewer1.LoadDashboard(tempFile);

                File.Delete(tempFile);
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        private void FrmDashboardViewer_Load(object sender, EventArgs e)
        {
            dashboardViewer1.ConfigureDataConnection += DashboardViewer1OnConfigureDataConnection;
            dashboardViewer1.DashboardItemClick += DashboardViewer1OnDashboardItemClick;
        }

        private void DashboardViewer1OnDashboardItemClick(object sender, DashboardItemMouseActionEventArgs e)
        {
            new FrmDashboardViewer(3) {MdiParent = this.MdiParent}.Show();
        }

        private void DashboardViewer1OnConfigureDataConnection(object sender,
            DashboardConfigureDataConnectionEventArgs e)
        {
            if (e.ConnectionParameters is SqlServerConnectionParametersBase @msSql)
            {
                msSql.ServerName = OperacionesGlobal.Server;
                msSql.UserName = OperacionesGlobal.User;
                msSql.Password = OperacionesGlobal.Pasword;
            }
        }


        private void FrmDashboardViewer_Shown(object sender, EventArgs e)
        {
            // Cargamos el dashboard del constructor
            CargarDashboard(dashboardId);
        }


        private void dashboardViewer1_DashboardChanged(object sender, EventArgs e)
        {
            this.Text = dashboardViewer1.Dashboard.Title.Text;
        }
    }
}