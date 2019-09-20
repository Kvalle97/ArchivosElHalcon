using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSPresentacion.Sistema.Utilidades;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;

namespace CSPresentacion.Sistema.General
{
    /// <summary>
    /// Formulario para mostrar reportes de devexpress
    /// </summary>
    public partial class FrmReportViewer : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Consturctor
        /// </summary>
        public FrmReportViewer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="caption"></param>
        public FrmReportViewer(string caption)
        {
            InitializeComponent();

            this.Text = caption;
        }

        /// <summary>
        /// Accede al componente para manejar el reporte
        /// </summary>
        public ReporteGeneral Report => report;

        /// <summary>
        /// Muestra un boton para importar a excel (Usar cuando el reporte es demasiado grande)
        /// </summary>
        public bool ExportacionPersonalizada
        {
            get { return panelControl1.Visible; }
            set { panelControl1.Visible = value; }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            report.DocumtViewer.PrintingSystem.Document.ScaleFactor = 1;
            report.DocumtViewer.ExecCommand(PrintingSystemCommand.ExportXlsx);
            report.DocumtViewer.PrintingSystem.Document.AutoFitToPagesWidth = 1;
        }
    }
}