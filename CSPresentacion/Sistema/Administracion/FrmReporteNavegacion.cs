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

namespace CSPresentacion.Sistema.Administracion
{
    /// <summary>
    /// Reporte navegacion
    /// </summary>
    public partial class FrmReporteNavegacion : FrmBase
    {
        // ReSharper disable once InconsistentNaming
        private static FrmReporteNavegacion childInstance;
        private readonly ServicioNavegacion servicioNavegacion = new ServicioNavegacion();

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

        #region Eventos

        private void FrmReporteNavegacion_Load(object sender, EventArgs e)
        {
            dpDesde.DateTime = DateTime.Now.Date;
            dpHasta.DateTime = DateTime.Now.Date;
            servicioNavegacion.CargarUsarios(glueUsuarios);
        }

        private void btnVerReporte_Click(object sender, EventArgs e)
        {
            try
            {
                ReporteNavegacion reporteNavegacion = new ReporteNavegacion();

                reporteNavegacion.Parameters["Titulo"].Value = "Navegación registrada";
                reporteNavegacion.Parameters["Empresa"].Value = Datos_Globales.TituloEmpresa;

                reporteNavegacion.DataSource = servicioNavegacion.ObtenerNavegacion(
                    (int) glueUsuarios.EditValue, dpDesde.DateTime.Date, dpHasta.DateTime.Date);
                reporteNavegacion.DataMember = "spObtenerReporteNavegacion";

                reporteNavegacion.CreateDocument();

                reporteGeneral.DocumtViewer.DocumentSource = reporteNavegacion;
                reporteGeneral.DocumtViewer.PrintingSystem = reporteNavegacion.PrintingSystem;
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        #endregion
    }
}