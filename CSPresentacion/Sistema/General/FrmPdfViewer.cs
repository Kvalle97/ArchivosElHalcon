using DevExpress.XtraEditors;

namespace CSPresentacion.Sistema.General
{
    /// <summary>
    ///     Formulario para pre visualizacion de archivos tipo PDFs
    /// </summary>
    public partial class FrmPdfViewer : XtraForm
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        public FrmPdfViewer()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Cargar documento
        /// </summary>
        /// <param name="ruta"></param>
        public void CargarDocumento(string ruta)
        {
            pdfViewer1.LoadDocument(ruta);
            pdfViewer1.Show();
        }
    }
}