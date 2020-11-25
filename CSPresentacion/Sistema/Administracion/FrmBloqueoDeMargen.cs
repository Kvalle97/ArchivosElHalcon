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
using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace CSPresentacion.Sistema.Administracion
{
    public partial class FrmBloqueoDeMargen : XtraForm
    {
        private readonly ServicioProducto servicioProducto = new ServicioProducto();
        private static FrmBloqueoDeMargen _childInstance;

        private string codigo;
        private string descripcion;


        public FrmBloqueoDeMargen()
        {
            InitializeComponent();
        }

        #region Metodos

        public static FrmBloqueoDeMargen Instance()
        {
            if (_childInstance is null || _childInstance.IsDisposed)
            {
                _childInstance = new FrmBloqueoDeMargen();
            }


            return _childInstance;
        }

        private void CargarProducto()
        {
            try
            {
                if (!gvProductos.IsValidRowHandle(gvProductos.FocusedRowHandle))
                {
                    return;
                }

                DataRow dr = gvProductos.GetFocusedDataRow();

                txtCodigo.Text = Convert.ToString(dr["Codigo"]);
                txtProducto.Text = Convert.ToString(dr["Producto"]);

                servicioProducto.MostrarSucursalesPorProduct(ckMargenMinimo, txtCodigo.Text);
            }
            catch (Exception e)
            {
                UIHelper.MostrarError(e);
            }
        }

        #endregion

        #region Eventos

        private void FrmBloqueoDeMargen_Shown(object sender, EventArgs e)
        {
            WaitDialogForm wait = new WaitDialogForm("Por favor espere...", "Cargando pantalla");

            wait.Show();

            try
            {
                servicioProducto.MostrarProductos(gcProductos, gvProductos);
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProducto.Text))
            {
                UIHelper.AlertarDeError("Primero seleccione el producto");
                return;
            }

            try
            {
                if (ckMargenMinimo.EditValue is null)
                {
                    UIHelper.AlertarDeError("Seleccione al menos una empresa");
                    return;
                }
                else
                {
                    List<object> lst = (List<object>) ckMargenMinimo.EditValue;

                    if (lst.Count > 0)
                    {
                        foreach (object ob in lst)
                        {
                            int emprId = Convert.ToInt32(ob);

                            servicioProducto.ActualizarMargenYDescuentoMaximo(seMargenMinimo.Value,
                                seDescuentoMaximo.Value, txtCodigo.Text, emprId);
                        }

                        XtraMessageBox.Show("Actualizado");
                    }
                    else
                    {
                        UIHelper.AlertarDeError("Seleccione al menos una empresa");
                        return;
                    }
                }
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }


        private void gvProductos_DoubleClick(object sender, EventArgs e)
        {
            CargarProducto();
        }

        private void gvProductos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            CargarProducto();
        }

        #endregion
    }
}