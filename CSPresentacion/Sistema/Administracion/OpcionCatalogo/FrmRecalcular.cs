using CSNegocios.Modelos;
using CSNegocios.Servicios;
using CSPresentacion.Sistema.Utilidades;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using System;
using System.Data;
using System.Windows.Forms;

namespace CSPresentacion.Sistema.Administracion.OpcionCatalogo
{
    public partial class FrmRecalcular : DevExpress.XtraEditors.XtraForm
    {
        private ModeloRecalcularMovimiento calcularMovimiento = new ModeloRecalcularMovimiento();
        ServicioRecalcularMovimiento servicioRecalcularMovimiento = new ServicioRecalcularMovimiento();
        private static FrmRecalcular _childInstance = null;
        private WaitDialogForm wait;

        public FrmRecalcular()
        {
            InitializeComponent();

        }
        public static FrmRecalcular Instance()
        {
            if (_childInstance == null || _childInstance.IsDisposed == true)
            {
                _childInstance = new FrmRecalcular();

            }
            _childInstance.BringToFront();

            return _childInstance;
        }

        private void FrmRecalcular_Load(object sender, EventArgs e)
        {
            Start();
        }

        private void Start()
        {
            DateTime date = DateTime.Now;
            FDesde.DateTime = new DateTime(date.Year, date.Month - 1, 1);
            FHasta.DateTime = date;
            servicioRecalcularMovimiento.ObtenerEmpresas(looksucursales);
            servicioRecalcularMovimiento.ObtenerMov(lookmov);
            //servicioRecalcularMovimiento.ObtenerDoc(lookdoc, calcularMovimiento.IdEmpresa, Convert.ToInt32(lookmov.EditValue));
        }

        private void lookmov_EditValueChanged(object sender, EventArgs e)
        {

            calcularMovimiento.IdTipoMov = Convert.ToInt32(lookmov.EditValue);
            calcularMovimiento.IdEmpresa = Convert.ToInt32(looksucursales.EditValue);
            servicioRecalcularMovimiento.ObtenerDoc(lookdoc, calcularMovimiento.IdTipoMov, calcularMovimiento.IdEmpresa);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            gvDocumentos.EditingValue = null;
            calcularMovimiento.Desde = FDesde.DateTime.ToString("yyyy-MM-dd");
            calcularMovimiento.Hasta = FHasta.DateTime.ToString("yyyy-MM-dd");
            calcularMovimiento.IdEmpresa = Convert.ToInt32(looksucursales.EditValue);
            calcularMovimiento.IdTipoDoc = Convert.ToInt32(lookdoc.EditValue);

            servicioRecalcularMovimiento.ObtenerProductosDeLaOrden(gcDocumentos, gvDocumentos, calcularMovimiento);


            gvDocumentos.OptionsBehavior.Editable = true;
            foreach (GridColumn item in gvDocumentos.Columns)
            {
                item.OptionsColumn.AllowEdit = false;
            }

            gvDocumentos.Columns["clRecalcular"].OptionsColumn.AllowEdit = true;
            gvDocumentos.Columns["clContabilizar"].OptionsColumn.AllowEdit = true;
        }

        private void btnRecalcular_Click(object sender, EventArgs e)
        {
            DataRow dr = gvDocumentos.GetDataRow(gvDocumentos.FocusedRowHandle);
            calcularMovimiento.IdTipoDoc = Convert.ToInt32(dr["idTipoDoc"]);
            calcularMovimiento.nodoc = Convert.ToInt32(dr["NoDoc"]);
            calcularMovimiento.periodo = Convert.ToInt32(dr["Periodo"]);

            if (XtraMessageBox.Show(
                         "¿ Está seguro que desea Recalcular Nodoc=\"" + calcularMovimiento.nodoc + "\" ?",
                         "",
                         MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button2
                     ) == DialogResult.Yes)
            {
                WaitDialogForm wait = new WaitDialogForm("Recalculando", "Por favor espere...");

                servicioRecalcularMovimiento.RecalcularMovimiento(calcularMovimiento.IdTipoDoc, calcularMovimiento.nodoc, calcularMovimiento.periodo);
                wait.Close();
                XtraMessageBox.Show("Se ha Recalculado", "",
                 MessageBoxButtons.OK);

            }
            else
            {

                UIHelper.AlertarDeError("OK :)");
            }
        }

        private void BtnContabilizar_Click(object sender, EventArgs e)
        {
            DataRow dr = gvDocumentos.GetDataRow(gvDocumentos.FocusedRowHandle);
            calcularMovimiento.IdTipoDoc = Convert.ToInt32(dr["idTipoDoc"]);
            calcularMovimiento.nodoc = Convert.ToInt32(dr["NoDoc"]);

            if (XtraMessageBox.Show(
                        "¿ Está seguro que desea Contabilizar  Nodoc=\"" + calcularMovimiento.nodoc + "\" ?",
                        "",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2
                    ) == DialogResult.Yes)
            {
                WaitDialogForm wait = new WaitDialogForm("Contabilizando ( ͡° ͜ʖ ͡°)", "Por favor espere...");

                servicioRecalcularMovimiento.ContabilizarDocumento(calcularMovimiento.IdTipoDoc, calcularMovimiento.nodoc);
                wait.Close();
                XtraMessageBox.Show("Se ha Contabilizado :)", "",
                    MessageBoxButtons.OK);

            }
            else
            {

                UIHelper.AlertarDeError("OK :)");
            }
        }

    }
}
