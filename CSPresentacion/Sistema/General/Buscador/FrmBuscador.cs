using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CSNegocios.Servicios;
using CSPresentacion.Sistema.Utilidades;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace CSPresentacion.Sistema.General.Buscador
{
    /// <summary>
    ///     Formulario de busquedas
    /// </summary>
    public partial class FrmBuscador : XtraForm
    {
        private readonly ServicioDocumentos servicioDocumentos = new ServicioDocumentos();

        /// <summary>
        ///     Tipo buscador
        /// </summary>
        public enum TipoBuscador
        {
            /// <summary>
            /// Crea un dialogo que muestra las brechas del buscador
            /// </summary>
            BrechasEnTipoDoc,
            Dashboards
        }


        private bool multiSelect;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="tipoBuscador"></param>
        public FrmBuscador(TipoBuscador tipoBuscador)
        {
            try
            {
                InitializeComponent();

                WaitDialogForm wait = new WaitDialogForm("Por favor espere...", "Cargando");

                wait.Show();
                switch (tipoBuscador)
                {
                    case TipoBuscador.Dashboards:
                        ServicioDashboard servicioDashboard = new ServicioDashboard();

                        servicioDashboard.CargarDashboardDisponibles(gcBuscador, gvBuscador);
                        gvBuscador.ViewCaption = "Dashboards";
                        break;
                    case TipoBuscador.BrechasEnTipoDoc:

                        servicioDocumentos.CargarBrechasDelTipoDoc(gcBuscador, gvBuscador);
                        gvBuscador.ViewCaption = "Brechas";

                        break;
                }

                wait.Close();
            }
            catch (Exception ex)
            {
                UIHelper.MostrarError(ex);
            }
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="tipoBuscador"></param>
        /// <param name="idEmrpesa"></param>
        /// <param name="strVal"></param>
        public FrmBuscador(TipoBuscador tipoBuscador, int idEmrpesa, string strVal)
        {
            try
            {
                InitializeComponent();

            }
            catch (Exception ex)
            {
                UIHelper.MostrarError(ex);
            }
        }

        #region SobreCargas

        /// <inheritdoc />
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool ret = false;

            switch (keyData)
            {
                case Keys.Control | Keys.B:

                    if (btnBuscar.Visible)
                    {
                        ret = true;
                        btnBuscar.PerformClick();
                    }

                    break;

                case Keys.Control | Keys.N:

                    if (btnLimpiar.Visible)
                    {
                        ret = true;
                        btnLimpiar.PerformClick();
                    }

                    break;
            }

            return ret;
        }

        #endregion

        #region Eventos

        private void frmBuscador_Load(object sender, EventArgs e)
        {
            gvBuscador.ViewCaption = CaptionBuscador;
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (multiSelect)
                {
                    if (gvBuscador.SelectedRowsCount > 0)
                        DialogResult = DialogResult.OK;
                    else
                        UIHelper.AlertarDeError("Debe seleccionar al menos un elemento");
                }
                else
                {
                    if (gvBuscador.GetFocusedDataSourceRowIndex() >= 0)
                    {
                        ValorDeLaCelda =
                            gvBuscador.GetRowCellValue(gvBuscador.FocusedRowHandle, gvBuscador.FocusedColumn);
                        DataRow = gvBuscador.GetDataRow(gvBuscador.FocusedRowHandle);

                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        UIHelper.AlertarDeError("Debe seleccionar un elemento primero");
                    }
                }
            }
            catch (Exception ex)
            {
                UIHelper.MostrarError(ex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void gcBuscador_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (multiSelect) return;

                    if (gvBuscador.GetFocusedDataSourceRowIndex() >= 0)
                    {
                        ValorDeLaCelda =
                            gvBuscador.GetRowCellValue(gvBuscador.FocusedRowHandle, gvBuscador.FocusedColumn);
                        DataRow = gvBuscador.GetDataRow(gvBuscador.FocusedRowHandle);

                        DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                UIHelper.MostrarError(ex);
            }
        }

        private void gcBuscador_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (multiSelect) return;

                if (gvBuscador.GetFocusedDataSourceRowIndex() >= 0)
                {
                    ValorDeLaCelda =
                        gvBuscador.GetRowCellValue(gvBuscador.FocusedRowHandle, gvBuscador.FocusedColumn);
                    DataRow = gvBuscador.GetDataRow(gvBuscador.FocusedRowHandle);

                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                UIHelper.MostrarError(ex);
            }
        }

        #endregion

        #region Propiedades

        /// <summary>
        ///     Fila obtenida de la busqueda
        /// </summary>
        public DataRow DataRow { get; private set; }

        /// <summary>
        /// Tiene el valor de la celda seleccionada
        /// </summary>
        public object ValorDeLaCelda { get; set; }

        /// <summary>
        ///     Seleccion multiple ?
        ///     Convierte el buscador en un buscador de multiples filas
        /// </summary>
        public bool MultiSelect
        {
            get => multiSelect;
            set
            {
                if (value)
                {
                    gvBuscador.OptionsSelection.MultiSelect = true;
                    gvBuscador.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
                }


                multiSelect = value;
            }
        }

        /// <summary>
        ///     Cuando el buscador es de multiple filas, obtiene todas las seleccionadas
        /// </summary>
        /// <returns></returns>
        public List<DataRow> ObtenerFilasSeleccionadas()
        {
            List<DataRow> rows = new List<DataRow>();

            foreach (int i in gvBuscador.GetSelectedRows()) rows.Add(gvBuscador.GetDataRow(i));

            return rows;
        }

        /// <summary>
        ///     Caption que mostrara el buscador
        /// </summary>
        public string CaptionBuscador { get; set; } = "";

        #endregion
    }
}