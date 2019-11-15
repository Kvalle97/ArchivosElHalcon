using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSNegocios.Servicios;
using CSPresentacion.Sistema.Utilidades;
using DevExpress.XtraEditors;

namespace CSPresentacion.Sistema.Administracion
{
    /// <summary>
    /// Frm Tipo Mov y Tipo Doc
    /// </summary>
    public partial class FrmDocumentos : XtraForm
    {
        // ReSharper disable once InconsistentNaming
        private static FrmDocumentos childInstance;
        private readonly ServicioDocumentos servicioDocumentos = new ServicioDocumentos();

        /// <summary>
        /// Constructor
        /// </summary>
        public FrmDocumentos()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Nueva instancia
        /// </summary>
        /// <returns></returns>
        public static FrmDocumentos Instance()
        {
            if (childInstance == null || childInstance.IsDisposed)
            {
                childInstance = new FrmDocumentos();
            }

            childInstance.BringToFront();

            return childInstance;
        }

        #region Eventos

        private void FrmDocumentos_Load(object sender, EventArgs e)
        {
            try
            {
                servicioDocumentos.CargarTipoMovs(gcTipoMov, gvTipoMov);
                servicioDocumentos.CargarTipoDocs(gcTipoDoc, gvTipoDoc);
                servicioDocumentos.CargarSucursales(lueEmpresa, false);
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        #endregion
    }
}