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
using DevExpress.XtraEditors;

namespace CSPresentacion.Sistema.Administracion
{
    /// <summary>
    /// Formulario base
    /// </summary>
    public partial class FrmBodegas : XtraForm
    {
        private static FrmBodegas childInstance = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public FrmBodegas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Nueva instancia
        /// </summary>
        /// <returns></returns>
        public static FrmBodegas Instance()
        {
            if (childInstance == null || childInstance.IsDisposed)
            {
                childInstance = new FrmBodegas();
            }

            childInstance.BringToFront();

            return childInstance;
        }

    }
}