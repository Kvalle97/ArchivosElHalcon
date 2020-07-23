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
using CSPresentacion.Sistema.Utilidades;
using DevExpress.XtraEditors;

namespace CSPresentacion.Sistema.Administracion
{
    public partial class FrmGuardarDashboard : XtraForm
    {
        private readonly ServicioDashboard servicioDashboard = new ServicioDashboard();
        private string xml;
        private int? id;

        public FrmGuardarDashboard(int? id, string xml)
        {
            this.id = id;
            this.xml = xml;
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
                    servicioDashboard.ObtenerNombreDelDashboard(id.Value);
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
                    servicioDashboard.Guardar(id, txtNombreAMostrar.Text, null, xml);
                }
                else
                {
                    servicioDashboard.Guardar(id, txtNombreAMostrar.Text, Convert.ToInt32(lueSistemaOModulo.EditValue),
                        xml);
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
    }
}