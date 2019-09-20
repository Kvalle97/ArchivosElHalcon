using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraPrinting.Preview;

namespace CSPresentacion.Sistema.Utilidades
{
    /// <summary>
    /// Clase de reporte general
    /// </summary>
    public partial class ReporteGeneral : UserControl
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ReporteGeneral()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Acceso al document viewer
        /// </summary>
        public DocumentViewer DocumtViewer => dvReportes;
    }
}