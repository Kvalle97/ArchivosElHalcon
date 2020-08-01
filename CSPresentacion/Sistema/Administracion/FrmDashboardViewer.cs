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
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;

namespace CSPresentacion.Sistema.Administracion
{
    public partial class FrmDashboardViewer : XtraForm
    {
        private readonly ServicioDashboard servicioDashboard = new ServicioDashboard();
        private readonly int dashboardId;
        private ParametroPorDefecto parametroPorDefecto = null;

        public FrmDashboardViewer(int dashboarId, ParametroPorDefecto parametroPorDefecto = null)
        {
            this.dashboardId = dashboarId;
            InitializeComponent();
            this.parametroPorDefecto = parametroPorDefecto;
            this.WindowState = FormWindowState.Maximized;
        }

        private void CargarDashboard(int id)
        {
            try
            {
                string tempFile = Path.GetTempPath() + "Viewer_" + DateTime.Now.ToFileTime().ToString() + ".xml";

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
            dashboardViewer1.CustomParameters += DashboardViewer1OnCustomParameters;
        }

        private void DashboardViewer1OnCustomParameters(object sender, CustomParametersEventArgs e)
        {
            //if (parametroPorDefecto != null)
            //{
            //    dashboardViewer1.Dashboard.Parameters[parametroPorDefecto.Nombre].Value = parametroPorDefecto.Valor;

            foreach (var parm in e.Parameters)
            {
                if (parm is DashboardParameter @prmS && parametroPorDefecto != null &&
                    @prmS.Name == parametroPorDefecto.Nombre)
                {
                    prmS.Value = parametroPorDefecto.Valor;
                    dashboardViewer1.Dashboard.Parameters[parametroPorDefecto.Nombre].Value = parametroPorDefecto.Valor;
                    parametroPorDefecto = null;
                }
            }

            //}
        }


        private void DashboardViewer1OnDashboardItemClick(object sender, DashboardItemMouseActionEventArgs e)
        {
            if (e.GetAxisPoint() != null)
            {
                DataRow dr = servicioDashboard.CargarSubReporte(e.DashboardItemName, dashboardId);

                if (dr != null)
                {
                    new FrmDashboardViewer(Convert.ToInt32(dr["SubDashboardId"]),
                            new ParametroPorDefecto(e.GetAxisPoint().Value, Convert.ToString(dr["Param"])))
                        {MdiParent = this.MdiParent}.Show();
                }
            }
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