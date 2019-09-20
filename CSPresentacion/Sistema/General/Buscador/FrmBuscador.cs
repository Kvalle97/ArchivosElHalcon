using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSNegocios;
using CSNegocios.Global;
using CSNegocios.Servicios;
using DevExpress.DataProcessing;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using UIHelper = CSPresentacion.Sistema.Utilidades.UIHelper;

namespace CSPresentacion.Sistema.General.Buscador
{
    /// <summary>
    /// Formulario de busquedas
    /// </summary>
    public partial class FrmBuscador : DevExpress.XtraEditors.XtraForm
    {
      

        private string caption = "";
        private DataRow dataRow = null;
        private bool multiSelect = false;

        /// <summary>
        /// Tipo buscador
        /// </summary>
        public enum TipoBuscador
        {
           
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tipoBuscador"></param>
        public FrmBuscador(TipoBuscador tipoBuscador)
        {
            try
            {
                InitializeComponent();

                WaitDialogForm wait;

                switch (tipoBuscador)
                {
                
                }
            }
            catch (Exception ex)
            {
                UIHelper.MostrarError(ex);
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tipoBuscador"></param>
        /// <param name="idEmrpesa"></param>
        /// <param name="strVal"></param>
        public FrmBuscador(TipoBuscador tipoBuscador, int idEmrpesa, string strVal)
        {
            try
            {
                InitializeComponent();

                switch (tipoBuscador)
                {
                   
                }
            }
            catch (Exception ex)
            {
                UIHelper.MostrarError(ex);
            }
        }

        #region Eventos

        private void frmBuscador_Load(object sender, EventArgs e)
        {
            gvBuscador.ViewCaption = caption;
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (multiSelect)
                {
                    if (gvBuscador.SelectedRowsCount > 0)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        UIHelper.AlertarDeError("Debe seleccionar al menos un elemento");
                    }
                }
                else
                {
                    if (gvBuscador.GetFocusedDataSourceRowIndex() >= 0)
                    {
                        dataRow = gvBuscador.GetDataRow(gvBuscador.FocusedRowHandle);

                        this.DialogResult = DialogResult.OK;
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
            this.DialogResult = DialogResult.Cancel;
        }

        private void gcBuscador_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (multiSelect)
                    {
                        return;
                    }

                    if (gvBuscador.GetFocusedDataSourceRowIndex() >= 0)
                    {
                        dataRow = gvBuscador.GetDataRow(gvBuscador.FocusedRowHandle);

                        this.DialogResult = DialogResult.OK;
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
                if (multiSelect)
                {
                    return;
                }

                if (gvBuscador.GetFocusedDataSourceRowIndex() >= 0)
                {
                    dataRow = gvBuscador.GetDataRow(gvBuscador.FocusedRowHandle);

                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                UIHelper.MostrarError(ex);
            }
        }

        #endregion

        #region SobreCargas

        /// <inheritdoc />
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool ret = false;

            switch (keyData)
            {
                case (Keys.Control | Keys.B):

                    if (btnBuscar.Visible)
                    {
                        ret = true;
                        btnBuscar.PerformClick();
                    }

                    break;

                case (Keys.Control | Keys.N):

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

        #region Propiedades

        /// <summary>
        /// Fila obtenida de la busqueda
        /// </summary>
        public DataRow DataRow => dataRow;

        /// <summary>
        /// Seleccion multiple ?
        /// Convierte el buscador en un buscador de multiples filas
        /// </summary>
        public bool MultiSelect
        {
            get { return multiSelect; }
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
        /// Cuando el buscador es de multiple filas, obtiene todas las seleccionadas
        /// </summary>
        /// <returns></returns>
        public List<DataRow> ObtenerFilasSeleccionadas()
        {
            List<DataRow> rows = new List<DataRow>();

            foreach (int i in gvBuscador.GetSelectedRows())
            {
                rows.Add(gvBuscador.GetDataRow(i));
            }

            return rows;
        }

        /// <summary>
        /// Caption que mostrara el buscador    
        /// </summary>
        public string CaptionBuscador
        {
            get { return caption; }
            set { caption = value; }
        }

        #endregion
    }
}