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
using CSPresentacion.Sistema.General;
using CSPresentacion.Sistema.Utilidades;
using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace CSPresentacion.Sistema.Administracion
{
    /// <summary>
    /// Formulario base
    /// </summary>
    public partial class FrmBodegas : FrmBase
    {
        // ReSharper disable once InconsistentNaming
        private static FrmBodegas childInstance = null;
        private readonly ServicioBodegas servicioBodegas = new ServicioBodegas();

        /// <summary>
        /// Tipo de pantalla a mostrar
        /// </summary>
        public enum PantallaMostrar
        {
            /// <summary>
            /// Bodega
            /// </summary>
            Bodega,

            /// <summary>
            /// Tipo de bodega
            /// </summary>
            TipoBodega
        }

        /// <summary>
        /// Pantalla a mostrar
        /// </summary>
        public PantallaMostrar Pantalla { get; set; }

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
        public static FrmBodegas Instance(PantallaMostrar pantalla)
        {
            if (childInstance == null || childInstance.IsDisposed)
            {
                childInstance = new FrmBodegas {Pantalla = pantalla};


                childInstance.MostrarBotones(true, Opciones.Guardar, Opciones.Nuevo);
            }

            childInstance.BringToFront();

            return childInstance;
        }

        #region Constructor

        /// <inheritdoc />
        protected override void NuevoEvent()
        {
            if (Pantalla == PantallaMostrar.TipoBodega)
            {
                servicioBodegas.MostrarTipoBodega(gc, gv);
            }
            else
            {
                servicioBodegas.MostrarBodegas(gc, gv);
            }

            txtId.Text = @"0";
        }

        /// <inheritdoc />
        protected override void GuardarEvent()
        {
            WaitDialogForm wait = new WaitDialogForm("Por favor espere...", "Guardando");

            wait.Show();

            try
            {
                if (Pantalla == PantallaMostrar.TipoBodega)
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
            NuevoEvent();

            if (Pantalla == PantallaMostrar.TipoBodega)
            {
                UIHelper.ShowComponents(false, lblComentarios, meComentarios, lblEmpresa, lueEmpresa, lblCosto,
                    txtCosto);
            }
            else
            {
                UIHelper.ShowComponents(false, ckActivo);
            }
        }

        #endregion
    }
}