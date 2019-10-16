using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSNegocios.Servicios;
using CSPresentacion.Sistema.Utilidades;
using DevExpress.XtraEditors;
using Accion = CSNegocios.Modelos.Accion;

namespace CSPresentacion.Sistema.Administracion
{
    /// <summary>
    /// Formulario de acciones y permisos
    /// </summary>
    public partial class FrmAccionesyPermisos : DevExpress.XtraEditors.XtraForm
    {
        private static FrmAccionesyPermisos childInstance = null;
        private readonly ServicioAcciones servicioAcciones = new ServicioAcciones();
        private Accion accion = new Accion();

        /// <summary>
        /// Constructor
        /// </summary>
        public FrmAccionesyPermisos()
        {
            InitializeComponent();
        }

        #region Metodos

        /// <summary>
        /// Nueva instancia
        /// </summary>
        /// <returns></returns>
        public static FrmAccionesyPermisos Instance()
        {
            if (childInstance == null || childInstance.IsDisposed)
            {
                childInstance = new FrmAccionesyPermisos();
            }

            childInstance.BringToFront();

            return childInstance;
        }

        private void CargarAccion()
        {
            txtNombre.Text = accion.Nombre;
            meDescripcion.Text = accion.Descripcion;
            ckbAuditable.Checked = accion.Auditable;
        }

        #endregion

        #region Eventos

        private void FrmAccionesyPermisos_Load(object sender, EventArgs e)
        {
            try
            {
                servicioAcciones.MostrarAcciones(gcAcciones, gvAcciones);
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        private void gvAcciones_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gvAcciones.FocusedRowHandle >= 0)
                {
                    accion = UIHelper.ObtenerItem<Accion>(
                        servicioAcciones.ObtenerAccion(Convert.ToInt32(gvAcciones.GetFocusedDataRow()["Id"])));

                    CargarAccion();
                }
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                dxErrorProvider.ClearErrors();

                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    UIHelper.AlertarDeError(dxErrorProvider, txtNombre, "Nombre no valido");
                    return;
                }

                if (servicioAcciones.EstaEnUsoNombreDeAccion(txtNombre.Text, accion.Id))
                {
                    UIHelper.AlertarDeError(dxErrorProvider,txtNombre, "El nombre ya está en uso");
                    return;
                }

                accion.Nombre = txtNombre.Text;
                accion.Descripcion = meDescripcion.Text;
                accion.Auditable = ckbAuditable.Checked;
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                accion = new Accion();

                CargarAccion();

                servicioAcciones.MostrarAcciones(gcAcciones, gvAcciones);
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        #endregion
    }
}