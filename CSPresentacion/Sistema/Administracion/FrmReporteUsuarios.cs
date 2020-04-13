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
using CSPresentacion.Sistema.Administracion.Reportes;
using CSPresentacion.Sistema.General;
using CSPresentacion.Sistema.Utilidades;
using DevExpress.Utils;

namespace CSPresentacion.Sistema.Administracion
{
    /// <summary>
    /// Formulario reporte usuarios
    /// </summary>
    public partial class FrmReporteUsuarios : FrmBase
    {
        // ReSharper disable once InconsistentNaming
        private static FrmReporteUsuarios childInstance = null;
        private readonly ServicioUsuarios servioUsuarios = new ServicioUsuarios();

        /// <summary>
        /// Constructor
        /// </summary>
        public FrmReporteUsuarios()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Crea una nueva instancia
        /// </summary>
        /// <returns></returns>
        public static FrmReporteUsuarios Instance()
        {
            if (childInstance == null || childInstance.IsDisposed)
            {
                childInstance = new FrmReporteUsuarios();
            }

            childInstance.BringToFront();

            return childInstance;
        }

        #region Funciones

        private void CargarReporte()
        {
            WaitDialogForm waitDialog = new WaitDialogForm("Por favor espere...", "Cargand reporte");

            waitDialog.Show();

            try
            {
                ReporteUsuarios rpUsuarios = new ReporteUsuarios();

                rpUsuarios.DataSource =
                    servioUsuarios.CargarReporteUsuario(Convert.ToInt32(lueSucursal.EditValue),
                        ckbMostrarInactivo.Checked);

                rpUsuarios.DataMember = "";

                rpUsuarios.Parameters["Empresa"].Value = Datos_Globales.TituloEmpresa;
                rpUsuarios.Parameters["Titulo"].Value = "Usuarios";

                rpUsuarios.CreateDocument();

                reporteGeneral1.DocumtViewer.DocumentSource = rpUsuarios;
                reporteGeneral1.DocumtViewer.PrintingSystem = rpUsuarios.PrintingSystem;
            }
            catch (Exception e)
            {
                UIHelper.MostrarError(e);
            }
            finally
            {
                if (!waitDialog.IsDisposed) waitDialog.Close();
            }
        }

        #endregion

        #region Eventos

        private void lueSucursal_EditValueChanged(object sender, EventArgs e)
        {
            CargarReporte();
        }

        private void ckbMostrarInactivo_CheckedChanged(object sender, EventArgs e)
        {
            CargarReporte();
        }

        private void FrmReporteUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                servioUsuarios.CargarSucursales(lueSucursal, true);
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        #endregion
    }
}