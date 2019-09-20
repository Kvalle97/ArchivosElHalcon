using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CSNegocios;

namespace CSPresentacion
{
    /// <summary>
    /// Formulario Sucursales
    /// </summary>
    public partial class FrmSucursales : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FrmSucursales()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmSucursales_Load(object sender, EventArgs e)
        {
            lueSucursales.Properties.DataSource = OperacionesGlobal
                .CargarDS("exec halcon.dbo.spObtenerEmpresasUsuario '" + Datos_Globales.Usuario + "'").Tables[0];
            lueSucursales.Properties.DisplayMember = "Sucursal";
            lueSucursales.Properties.ValueMember = "ID";
            lueSucursales.EditValue = OperacionesGlobal.numGet_Int(
                "select top 1 IdEmpresaUbicacion from halcon.dbo.Usuarios where Usuario = '" + Datos_Globales.Usuario +
                "'");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Datos_Globales.IdSucursal = Convert.ToInt32(lueSucursales.EditValue);
            Datos_Globales.NombreSucursal = lueSucursales.Text;

            if (this.chkRecordarSucursal.Checked)
            {
                if (OperacionesGlobal.numGet_Int("exec halcon.dbo.spActualizarIdSucursalUsuario '" +
                                                 Datos_Globales.Usuario + "', " +
                                                 Datos_Globales.IdSucursal.ToString()) != 1)
                {
                    // Si el resultado es distinto de 1 el usuario no existe o esta duplicado
                    XtraMessageBox.Show(
                        "Hay un problema con su usuario, por favor contacte al Administrador del Sistema");
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion
    }
}