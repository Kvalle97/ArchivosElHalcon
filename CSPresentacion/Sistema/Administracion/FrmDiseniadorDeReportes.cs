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

        class ReportCommandHandler : ICommandHandler
        {
            private XRDesignPanel panel;

            //public ReportCommandHandler(XRDesignPanel panel)
            //{
            //    this.panel = panel;
            //}

            public void HandleCommand(ReportCommand command, object[] args)
            {
                ////switch (command)
                ////{
                ////    case ReportCommand.SaveFileAs:

                ////        XtraMessageBox.Show("SAVE FILE AS");

                ////        break;
                ////    case ReportCommand.SaveAll:
                ////        XtraMessageBox.Show("SAVE ALL");

                ////        break;
                ////    case ReportCommand.SaveFile:
                ////        XtraMessageBox.Show("SAVE FILE ");

                ////        break;
                ////    case ReportCommand.OpenFile:

                ////        Localizer.Active = new ConfiguracionDialogos();

                ////        switch (XtraMessageBox.Show("Donde desea buscar el reporte", "", MessageBoxButtons.YesNo))
                ////        {
                ////            case DialogResult.Yes:
                ////                break;
                ////            case DialogResult.No:
                ////                break;
                ////            default:
                ////                throw new ArgumentOutOfRangeException();
                ////        }

                ////        Localizer.Active = Localizer.CreateDefaultLocalizer();
                ////        break;
                ////}
            }

            public bool CanHandleCommand(ReportCommand command, ref bool useNextHandler)
            {
                switch (command)
                {
                    case ReportCommand.SaveFileAs:
                    case ReportCommand.SaveAll:
                    case ReportCommand.SaveFile:
                    case ReportCommand.OpenFile:


                        useNextHandler = false;
                        break;
                    default:
                        useNextHandler = true;
                        break;
                }

                return !useNextHandler;
            }
        }

       
    }
}