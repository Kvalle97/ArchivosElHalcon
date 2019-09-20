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
    /// Formulario cambio de password
    /// </summary>
    public partial class FrmCambioPassword : DevExpress.XtraEditors.XtraForm
    {
        private Logueo loguin = new Logueo();
        private string UsuarioResp;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Usuario"></param>
        public FrmCambioPassword(string Usuario)
        {
            InitializeComponent();
            UsuarioResp = Usuario;
        }

        #region Metodos

        /// <summary>
        /// Validar contraseña
        /// </summary>
        /// <param name="pwd"></param>
        /// <param name="minLength"></param>
        /// <param name="numUpper"></param>
        /// <param name="numLower"></param>
        /// <param name="numNumbers"></param>
        /// <param name="numSpecial"></param>
        /// <returns></returns>
        public bool ValidatePassword(string pwd, int minLength = 6, int numUpper = 1, int numLower = 1,
            int numNumbers = 1, int numSpecial = 2)
        {
            // Replace [A-Z] with \p{Lu}, to allow for Unicode uppercase letters.
            System.Text.RegularExpressions.Regex upper = new System.Text.RegularExpressions.Regex("[A-Z]");
            System.Text.RegularExpressions.Regex lower = new System.Text.RegularExpressions.Regex("[a-z]");
            System.Text.RegularExpressions.Regex number = new System.Text.RegularExpressions.Regex("[0-9]");
            // Special is "none of the above".
            System.Text.RegularExpressions.Regex special = new System.Text.RegularExpressions.Regex("[^a-zA-Z0-9]");

            // Check the length.
            if ((pwd.Length) < minLength)
                return false;
            // Check for minimum number of occurrences.
            if (upper.Matches(pwd).Count < numUpper)
                return false;
            if (lower.Matches(pwd).Count < numLower)
                return false;
            if (number.Matches(pwd).Count < numNumbers)
                return false;
            //if (special.Matches(pwd).Count < numSpecial)
            //    return false;

            // Passed all checks.
            return true;
        }

        #endregion

        #region Eventos

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {
        }


        private void btnaceptar_Click(object sender, EventArgs e)
        {
            try
            {
                loguin.User = UsuarioResp;
                object PassW = loguin.ObtenerPassword(loguin);

                if (PassW.ToString() != this.txtpasswordactual.Text.Trim())
                {
                    MessageBox.Show("La Contraseña Actual no es Correcta", Global.NombreEmpresa, MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    this.txtpasswordactual.SelectionStart = 0;
                    this.txtpasswordactual.SelectionLength = this.txtpasswordactual.Text.Length;
                    this.txtpasswordactual.Focus();
                    return;
                }

                //password = "Carlos";
                //// Demonstrate that "Z9f%a>2kQ" is not complex.
                //MessageBox.Show(password + " is complex: " + ValidatePassword(password));


                if (this.txtpasswordnueva.Text.Trim() != this.txtpasswordrepita.Text.Trim())
                {
                    MessageBox.Show("No Coincide la Contraseña", Global.NombreEmpresa, MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    this.txtpasswordnueva.SelectionStart = 0;
                    this.txtpasswordnueva.SelectionLength = this.txtpasswordnueva.Text.Length;
                    this.txtpasswordnueva.Focus();
                    return;
                }

                if (ValidatePassword(this.txtpasswordnueva.Text.Trim()) == false)
                {
                    MessageBox.Show("La Contraseña es Muy Débil", Global.NombreEmpresa, MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    this.txtpasswordnueva.SelectionStart = 0;
                    this.txtpasswordnueva.SelectionLength = this.txtpasswordnueva.Text.Length;
                    this.txtpasswordnueva.Focus();
                    return;
                }

                Usuarios usuario = new Usuarios();


                DataSet ds = new DataSet();
                ds.Clear();

                usuario.Usuario = UsuarioResp;
                usuario.Password = this.txtpasswordrepita.Text.Trim();
                usuario.Opcion = 1;
                usuario.Actualizar_Password(usuario);

                Global.NuevaPassword = this.txtpasswordrepita.Text.Trim();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtpasswordactual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) (13))
            {
                if (this.txtpasswordactual.Text.Trim() == "")
                {
                    MessageBox.Show("Debe de escribir la Contraseña Actual", Global.NombreEmpresa, MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    this.txtpasswordactual.SelectionStart = 0;
                    this.txtpasswordactual.SelectionLength = this.txtpasswordactual.Text.Length;
                    this.txtpasswordactual.Focus();
                    return;
                }
                else
                {
                    this.txtpasswordnueva.Focus();
                }
            }
        }

        private void txtpasswordnueva_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) (13))
            {
                if (this.txtpasswordnueva.Text.Trim() == "")
                {
                    MessageBox.Show("Debe de escribir la Nueva Contraseña", Global.NombreEmpresa, MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    this.txtpasswordnueva.SelectionStart = 0;
                    this.txtpasswordnueva.SelectionLength = this.txtpasswordnueva.Text.Length;
                    this.txtpasswordnueva.Focus();
                    return;
                }
                else
                {
                    this.txtpasswordrepita.Focus();
                }
            }
        }

        private void txtpasswordrepita_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) (13))
            {
                if (this.txtpasswordrepita.Text.Trim() == "")
                {
                    MessageBox.Show("Debe de repetir la Contraseña", Global.NombreEmpresa, MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    this.txtpasswordrepita.SelectionStart = 0;
                    this.txtpasswordrepita.SelectionLength = this.txtpasswordrepita.Text.Length;
                    this.txtpasswordrepita.Focus();
                    return;
                }
                else
                {
                    this.btnaceptar.Focus();
                }
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        #endregion
    }
}