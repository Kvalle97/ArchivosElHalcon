using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSNegocios.Servicios;
using CSPresentacion.Sistema.Utilidades;
using DevExpress.DashboardCommon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace CSPresentacion.Sistema.Administracion
{
    public partial class FrmGuardarDashboard : XtraForm
    {
        private readonly ServicioDashboard servicioDashboard = new ServicioDashboard();
        private string xml;
        private int? id;
        private Dashboard dashboard;

        public FrmGuardarDashboard(int? id, string xml, Dashboard dashboard)
        {
            this.id = id;
            this.xml = xml;
            this.dashboard = dashboard;
            InitializeComponent();
        }

        public new void Show()
        {
            throw new Exception("Use showDialog");
        }

        private void FrmGuardarDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                if (id.HasValue)
                {
                    txtNombreAMostrar.Text = servicioDashboard.ObtenerNombreDelDashboard(id.Value);

                    lueItemsDisponibles.Properties.DataSource =
                        dashboard.Items.Select(x => x.ComponentName).GetEnumerator();

                    ckComboParametrosHereados.Properties.DataSource =
                        dashboard.Parameters.Select(p => p.Name).GetEnumerator();

                    ckComboParametrosHereados.Properties.EditValueType = EditValueTypeCollection.List;

                    servicioDashboard.CargarDashboardDisponibles(lueSubReporte);

                    lueItemsDisponibles.ItemIndex = 0;
                }

                servicioDashboard.MostrarSistemasOModulo(lueSistemaOModulo);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombreAMostrar.Text))
                {
                    UIHelper.AlertarDeError("El nombre es obligatorio");
                    return;
                }

                if (lueSistemaOModulo.EditValue is null)
                {
                    servicioDashboard.Guardar(id, txtNombreAMostrar.Text, null, xml, ckEsSubReporte.Checked);
                }
                else
                {
                    servicioDashboard.Guardar(id, txtNombreAMostrar.Text, Convert.ToInt32(lueSistemaOModulo.EditValue),
                        xml, ckEsSubReporte.Checked);
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void lueSubReporte_EditValueChanged(object sender, EventArgs e)
        {
            if (lueSubReporte.EditValue != null)
            {
                string tempFile = Path.GetTempPath() + "Save_" + DateTime.Now.ToFileTime().ToString() + ".xml";


                File.WriteAllText(tempFile,
                    servicioDashboard.ObtenerDashboard(Convert.ToInt32(lueSubReporte.EditValue)));

                var subDashboard = new Dashboard();
                subDashboard.LoadFromXml(tempFile);

                lueParamName.Properties.DataSource = subDashboard.Parameters.Select(p => p.Name).GetEnumerator();
                lueParamName.ItemIndex = 0;

                File.Delete(tempFile);
            }
        }
    }
}