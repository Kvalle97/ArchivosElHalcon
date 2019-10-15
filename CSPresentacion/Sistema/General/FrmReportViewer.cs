using System;
using CSPresentacion.Sistema.Utilidades;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;

namespace CSPresentacion.Sistema.General
{
    /// <summary>
    ///     Formulario para mostrar reportes de devexpress
    /// </summary>
    public partial class FrmReportViewer : XtraForm
    {
        /// <summary>
        ///     Consturctor
        /// </summary>
        public FrmReportViewer()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="caption"></param>
        public FrmReportViewer(string caption)
        {
            InitializeComponent();

            Text = caption;
        }

        /// <summary>
        ///     Accede al componente para manejar el reporte
        /// </summary>
        public ReporteGeneral Report { get; private set; }

        /// <summary>
        ///     Muestra un boton para importar a excel (Usar cuando el reporte es demasiado grande)
        /// </summary>
        public bool ExportacionPersonalizada
        {
            get => panelControl1.Visible;
            set => panelControl1.Visible = value;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Report.DocumtViewer.PrintingSystem.Document.ScaleFactor = 1;
            Report.DocumtViewer.ExecCommand(PrintingSystemCommand.ExportXlsx);
            Report.DocumtViewer.PrintingSystem.Document.AutoFitToPagesWidth = 1;
        }
    }
}