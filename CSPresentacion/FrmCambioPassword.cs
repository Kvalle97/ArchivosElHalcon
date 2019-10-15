using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CSNegocios;
using DevExpress.XtraEditors;

namespace CSPresentacion
{
    /// <summary>
    ///     Formulario cambio de password
    /// </summary>
    public partial class FrmCambioPassword : XtraForm
    {
        private readonly Logueo loguin = new Logueo();
        private readonly string UsuarioResp;


        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="Usuario"></param>
        public FrmCambioPassword(string Usuario)
        {
            InitializeComponent();
            UsuarioResp = Usuario;
        }

        #region Metodos

        /// <summary>
        ///     Validar contraseña
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
            Regex upper = new Regex("[A-Z]");
            Regex lower = new Regex("[a-z]");
            Regex number = new Regex("[0-9]");
            // Special is "none of the above".
            Regex special = new Regex("[^a-zA-Z0-9]");

            // Check the length.
            if (pwd.Length < minLength)
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

                if (PassW.ToString() != txtpasswordactual.Text.Trim())
                {
                    MessageBox.Show("La Contraseña Actual no es Correcta", Global.NombreEmpresa, MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    txtpasswordactual.SelectionStart = 0;
                    txtpasswordactual.SelectionLength = txtpasswordactual.Text.Length;
                    txtpasswordactual.Focus();
                    return;
                }

                //password = "Carlos";
                //// Demonstrate that "Z9f%a>2kQ" is not complex.
                //MessageBox.Show(password + " is complex: " + ValidatePassword(password));


                if (txtpasswordnueva.Text.Trim() != txtpasswordrepita.Text.Trim())
                {
                    MessageBox.Show("No Coincide la Contraseña", Global.NombreEmpresa, MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    txtpasswordnueva.SelectionStart = 0;
                    txtpasswordnueva.SelectionLength = txtpasswordnueva.Text.Length;
                    txtpasswordnueva.Focus();
                    return;
                }

                if (ValidatePassword(txtpasswordnueva.Text.Trim()) == false)
                {
                    MessageBox.Show("La Contraseña es Muy Débil", Global.NombreEmpresa, MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    txtpasswordnueva.SelectionStart = 0;
                    txtpasswordnueva.SelectionLength = txtpasswordnueva.Text.Length;
                    txtpasswordnueva.Focus();
                    return;
                }

                Usuarios usuario = new Usuarios();


                DataSet ds = new DataSet();
                ds.Clear();

                usuario.Usuario = UsuarioResp;
                usuario.Password = txtpasswordrepita.Text.Trim();
                usuario.Opcion = 1;
                usuario.Actualizar_Password(usuario);

                Global.NuevaPassword = txtpasswordrepita.Text.Trim();
                DialogResult = DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtpasswordactual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) 13)
            {
                if (txtpasswordactual.Text.Trim() == "")
                {
                    MessageBox.Show("Debe de escribir la Contraseña Actual", Global.NombreEmpresa, MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    txtpasswordactual.SelectionStart = 0;
                    txtpasswordactual.SelectionLength = txtpasswordactual.Text.Length;
                    txtpasswordactual.Focus();
                }
                else
                {
                    txtpasswordnueva.Focus();
                }
            }
        }

        private void txtpasswordnueva_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) 13)
            {
                if (txtpasswordnueva.Text.Trim() == "")
                {
                    MessageBox.Show("Debe de escribir la Nueva Contraseña", Global.NombreEmpresa, MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    txtpasswordnueva.SelectionStart = 0;
                    txtpasswordnueva.SelectionLength = txtpasswordnueva.Text.Length;
                    txtpasswordnueva.Focus();
                }
                else
                {
                    txtpasswordrepita.Focus();
                }
            }
        }

        private void txtpasswordrepita_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) 13)
            {
                if (txtpasswordrepita.Text.Trim() == "")
                {
                    MessageBox.Show("Debe de repetir la Contraseña", Global.NombreEmpresa, MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    txtpasswordrepita.SelectionStart = 0;
                    txtpasswordrepita.SelectionLength = txtpasswordrepita.Text.Length;
                    txtpasswordrepita.Focus();
                }
                else
                {
                    btnaceptar.Focus();
                }
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion
    }
}