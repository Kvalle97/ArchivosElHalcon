using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSPresentacion.Sistema.Utilidades;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.UserDesigner;

namespace CSPresentacion.Sistema.Administracion
{
    public partial class FrmDiseniadorDeReportes : XtraForm
    {
        public FrmDiseniadorDeReportes()
        {
            WaitDialogForm wait = new WaitDialogForm("Por favor espere...", "Cargando");

            wait.Show();
            try
            {
                InitializeComponent();
            }
            catch (Exception e)
            {
                UIHelper.MostrarError(e);
            }
            finally
            {
                wait.Close();
            }
        }
        private void FrmDiseniadorDeReportes_Load(object sender, EventArgs e)
        {
            reportDesigner1.CreateNewReport();
        }
        private void reportDesigner1_DesignPanelLoaded(object sender, DesignerLoadedEventArgs e)
        {
            //XRDesignPanel panel = (XRDesignPanel) sender;

            //ReportCommandHandler commandHandler = new ReportCommandHandler(panel);

            //reportDesigner1.AddCommandHandler(commandHandler);
        }


       
    }
}