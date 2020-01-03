using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSNegocios.Modelos;
using CSNegocios.Servicios;
using CSPresentacion.Sistema.General;
using CSPresentacion.Sistema.Utilidades;
using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace CSPresentacion.Sistema.Administracion
{
    /// <summary>
    /// Formulario de informacion  de sistema (BD, TB Información)
    /// </summary>
    public partial class FrmInformacion : FrmBase
    {
        private static FrmInformacion _childInstance = null;
        private readonly ServicioInformacion servicioInformacion = new ServicioInformacion();
        private Informacion informacion = new Informacion();

        /// <summary>
        /// Constructor
        /// </summary>
        public FrmInformacion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Instance
        /// </summary>
        /// <returns></returns>
        public static FrmInformacion Instance()
        {
            if (_childInstance == null || _childInstance.IsDisposed)
            {
                _childInstance = new FrmInformacion();

                _childInstance.MostrarBotones(true, Opciones.Guardar);
            }

            _childInstance.BringToFront();
            return _childInstance;
        }

        #region SobreCargas

        /// <inheritdoc />
        protected override void GuardarEvent()
        {
            if (string.IsNullOrWhiteSpace(txtCompania.Text))
            {
                UIHelper.AlertarDeError(dxErrorProvider, txtCompania, "Este campo es necesario");
            }

            informacion.Compania = txtCompania.Text;
            informacion.Ruc = txtRuc.Text;
            informacion.Direccion = meDireccion.Text;

            WaitDialogForm wait= new WaitDialogForm("Por favor espere...", "Guardando");

            wait.Show();

            try
            {
                servicioInformacion.ActualizarInformacion(informacion);

                XtraMessageBox.Show("Se actualizo la información");
            }
            catch (Exception e)
            {
                UIHelper.MostrarError(e);
            }
            finally
            {
                wait.Close();
            }
        }

        #endregion

        #region Eventos

        private void FrmInformacion_Load(object sender, EventArgs e)
        {
            WaitDialogForm wait = new WaitDialogForm("Por favor espre...", "Cargando");

            wait.Show();

            try
            {
                informacion = servicioInformacion.ObtenerInformacion();

                txtRuc.Text = informacion.Ruc;
                meDireccion.Text = informacion.Direccion;
                UIHelper.AgregarImagen(peFoto, informacion.Logo);
                txtCompania.Text = informacion.Compania;
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
            finally
            {
                wait.Close();
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog
                {
                    Filter = @"Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png;)|*.jpg; *.jpeg; *.gif; *.bmp; *.png"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    peFoto.Image = Image.FromFile(openFileDialog.FileName);
                    informacion.Logo = UIHelper.ObtenerImagen(peFoto.Image);
                }
            }
            catch (Exception ex)
            {
                UIHelper.MostrarError(ex);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            informacion.Logo = null;
            peFoto.Image = null;
        }

        #endregion
    }
}