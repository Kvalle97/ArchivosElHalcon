using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSNegocios.Modelos.Bodegas;
using CSNegocios.Servicios;
using CSPresentacion.Sistema.General;
using CSPresentacion.Sistema.Utilidades;
using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace CSPresentacion.Sistema.Administracion
{
    /// <summary>
    /// Formulario base
    /// </summary>
    public partial class FrmTipoBodega : FrmBase
    {
        // ReSharper disable once InconsistentNaming
        private static FrmTipoBodega childInstance = null;

        private readonly ServicioBodegas servicioBodegas = new ServicioBodegas();

        private TipoBodega tipoBodega;

        //// <summary>
        // Constructor
        //// </summary>
        public FrmTipoBodega()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Nueva instancia
        /// </summary>
        /// <returns></returns>
        public static FrmTipoBodega Instance()
        {
            if (childInstance == null || childInstance.IsDisposed)
            {
                childInstance = new FrmTipoBodega();


                childInstance.MostrarBotones(true, Opciones.Guardar, Opciones.Nuevo);
            }


            childInstance.BringToFront();

            return childInstance;
        }

        #region Constructor

        /// <inheritdoc />
        protected override void NuevoEvent()
        {
            tipoBodega = new TipoBodega();
            servicioBodegas.MostrarBodegas(gc, gv);
        }

        /// <inheritdoc />
        protected override void GuardarEvent()
        {
            WaitDialogForm wait = new WaitDialogForm("Por favor espere...", "Guardando");

            wait.Show();

            try
            {
                List<Error> lstErrores = new List<Error>();

                if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
                {
                    lstErrores.Add(new Error("Ingrese la descripcion", txtDescripcion));
                }

                if (string.IsNullOrWhiteSpace(txtAbreviatura.Text))
                {
                    lstErrores.Add(new Error("Ingrese la abreviatura", txtAbreviatura));
                }

                if (lstErrores.Count > 0)
                {
                    UIHelper.AlertarDeError(dxErrorProvider, lstErrores);
                }
                else
                {
                    servicioBodegas.GuardarTipoBodega(Convert.ToInt32(txtId.Text), txtDescripcion.Text,
                        txtAbreviatura.Text, ckActivo.Checked);

                    NuevoEvent();
                }
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

        private void FrmBodegas_Load(object sender, EventArgs e)
        {
        }

        private void FrmTipoBodega_Shown(object sender, EventArgs e)
        {
            NuevoEvent();
        }

        private void gv_DoubleClick(object sender, EventArgs e)
        {
        }

        #endregion
    }
}