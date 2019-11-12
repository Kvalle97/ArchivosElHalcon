using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSPresentacion.Sistema.General;

namespace CSPresentacion.Sistema.Administracion
{
    /// <summary>
    /// Reporte navegacion
    /// </summary>
    public partial class FrmReporteNavegacion : FrmBase
    {
        private static FrmReporteNavegacion childInstance;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public FrmReporteNavegacion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Nueva instancia
        /// </summary>
        /// <returns></returns>
        public static FrmReporteNavegacion Instance()
        {
            if (childInstance == null || childInstance.IsDisposed)
            {
                childInstance = new FrmReporteNavegacion();

                childInstance.MostrarBotones(true, Opciones.Cerrar);
            }

            childInstance.BringToFront();

            return childInstance;
        }
    }
}
