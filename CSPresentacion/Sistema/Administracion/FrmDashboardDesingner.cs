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
using CSNegocios.Servicios;
using CSPresentacion.Sistema.General.Buscador;
using CSPresentacion.Sistema.Utilidades;
using DevExpress.XtraEditors;

namespace CSPresentacion.Sistema.Administracion
{
    public partial class FrmDashboardDesingner : XtraForm
    {
        private int? idDashboard = null;
        private readonly ServicioDashboard servicioDashboard = new ServicioDashboard();
        private bool fromLoadDb = false;

        public FrmDashboardDesingner()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnAbrirDesdeBaseDeDatos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmBuscador frmBuscador = new FrmBuscador(FrmBuscador.TipoBuscador.Dashboards);

            if (frmBuscador.ShowDialog() == DialogResult.OK)
            {
                string tempFile = Path.GetTempPath() + new Guid().ToString() + ".xml";

                fromLoadDb = true;

                idDashboard = Convert.ToInt32(frmBuscador.DataRow["Id"]);

                File.WriteAllText(tempFile,
                    servicioDashboard.ObtenerDashboard(idDashboard.Value));

                this.dashboardDesigner1.LoadDashboard(tempFile);

                File.Delete(tempFile);
            }
        }

        private void btnGuardarABaseDeDatos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string tempPath = Path.GetTempPath() + Guid.NewGuid().ToString() + ".xml";

            dashboardDesigner1.Dashboard.SaveToXml(tempPath);

            string xmlCode = File.ReadAllText(tempPath);

            new FrmGuardarDashboard(idDashboard, xmlCode).ShowDialog();

            File.Delete(tempPath);

            //if (idDashboard.HasValue)
            //{
            //}
        }

        private void FrmDashboardDesingner_Load(object sender, EventArgs e)
        {
            dashboardDesigner1.AsyncMode = false;
        }

        private void dashboardDesigner1_DashboardLoaded(object sender,
            DevExpress.DashboardWin.DashboardLoadedEventArgs e)
        {
        }

        private void dashboardDesigner1_DashboardOpening(object sender,
            DevExpress.DashboardWin.DashboardOpeningEventArgs e)
        {
        }

        private void dashboardDesigner1_DashboardOptionsChanged(object sender, EventArgs e)
        {
        }

        private void dashboardDesigner1_DashboardChanged(object sender, EventArgs e)
        {
            if (fromLoadDb)
            {
                fromLoadDb = false;
            }
            else
            {
                idDashboard = null;
            }
        }
    }
}