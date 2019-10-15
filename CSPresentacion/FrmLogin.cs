using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CSNegocios;
using CSPresentacion.Properties;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace CSPresentacion
{
    /// <summary>
    ///     Formulario de incio de sesion
    /// </summary>
    public partial class FrmLogin : XtraForm
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        public FrmLogin()
        {
            InitializeComponent();
        }


        #region Metodos

        /// <summary>
        ///     List items
        /// </summary>
        private void ListItems()
        {
            lstItems.DataSource = Settings.Default.ServerAddress.Cast<string>().ToArray();
            //lstItems.Refresh();
            //Properties.Settings.Default.Items.Cast<string>().ToArray();
            lstItems.SelectedIndex = -1;
        }

        /// <summary>
        ///     Validar String de coneccion
        /// </summary>
        /// <returns></returns>
        public string ValidarConnString()
        {
            int n = lstItems.Items.Count;


            var retryCount = 0;
            while (true)
                try
                {
                    txtValue.Text = lstItems.Items[retryCount].ToString();
                    OperacionesGlobal.IntentarConectar(lstItems.Items[retryCount].ToString(), txtDataBase.Text,
                        txtLogin.Text, txtPassword.Text, Convert.ToInt32(txtTimeOut.EditValue));

                    break;
                }

                //catch (Exception tex)
                catch (Exception)
                {
                    if (++retryCount < n) continue;


                    MessageBox.Show("No se pudo conectar al Servidor");
                    break;

                    //throw; //or handle error and break/return
                }

            if (retryCount < n)
                return lstItems.Items[retryCount].ToString();
            return string.Empty;
        }

        #endregion

        #region Eventos

        private void frmLogin_Load(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            lblVersion.Text = "v" + version;
            Datos_Globales.VersionSistemaLocal = version;

            Width = 210;
            txtLogin.EditValue = Settings.Default.Login;
            txtPassword.EditValue = Settings.Default.Password;
            txtTimeOut.EditValue = Settings.Default.TimeOut;
            txtDataBase.EditValue = Settings.Default.DataBase;
            ListItems();

            if (Settings.Default.Recordar)
            {
                chkRecordar.Checked = Settings.Default.Recordar;
                txtUsuario.Text = Settings.Default.User.Trim();
                txtClave.Text = Settings.Default.Pass.Trim();
            }
        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstItems.SelectedItem == null)
                txtValue.ResetText();
            else
                txtValue.Text = lstItems.SelectedItem.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtValue.Text != string.Empty)
            {
                Settings.Default.ServerAddress.Add(txtValue.Text);
                txtValue.ResetText();
                txtValue.Focus();
                ListItems();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Settings.Default.ServerAddress.Remove(txtValue.Text);
            txtValue.ResetText();
            txtValue.Focus();
            ListItems();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }


        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            string mensaje = ValidarConnString();
            if (mensaje != string.Empty)
                XtraMessageBox.Show(mensaje);
        }

        private void txtValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnAdd.PerformClick();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            WaitDialogForm wait = new WaitDialogForm("Por Favor Espere...", "Conectando Con el Servidor");
            wait.Show();
            Datos_Globales.IPLocal = ValidarConnString();
            if (Datos_Globales.IPLocal == string.Empty)
            {
                wait.Close();
                return;
            }

            Logueo login = new Logueo(txtLogin.Text, txtPassword.Text, Datos_Globales.IPLocal, txtDataBase.Text);
            login.User = txtUsuario.Text;

            if (login.ValidarUsuario(login))
            {
                Usuarios usuario = new Usuarios();
                usuario.Usuario = txtUsuario.Text;


                Datos_Globales.TituloEmpresa = OperacionesGlobal.ObtenerNombreEmpresa();


                //******************* Aqui empieza la parte copiada*************//


                //if (loguin.ValidarUsuario(loguin))
                //{

                login.User = txtUsuario.Text.Trim();
                object PassW = login.ObtenerPassword(login);

                if (PassW.ToString() != txtClave.Text.Trim())
                {
                    wait.Close();
                    XtraMessageBox.Show("La Contraseña es Incorrecta", "Inicio de Sesión", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    txtClave.EditValue = null;
                    txtClave.Focus();
                    return;
                }


                // #region Verifica si existe un cambio en la contraseña
                DataTable dtb = new DataTable();
                dtb.Clear();
                dtb = login.Cargar("select PasswordUsuario,CambioPassword from Halcon.dbo.Usuarios where Usuario='" +
                                   txtUsuario.Text.Trim() + "'");

                if (dtb.Rows.Count > 0)
                {
                    bool Cambio = Convert.ToBoolean(dtb.Rows[0]["CambioPassword"]);

                    if (Cambio)
                    {
                        Usuarios usuariop = new Usuarios();
                        string pass = Convert.ToString(dtb.Rows[0]["PasswordUsuario"]);
                        string usupass = usuariop.DesencriptarEncriptarClave(pass);

                        wait.Close();

                        FrmCambioPassword frm = new FrmCambioPassword(txtUsuario.Text.Trim());
                        frm.ShowDialog();

                        if (frm.DialogResult == DialogResult.OK)
                        {
                            if (chkRecordar.Checked)
                            {
                                Settings.Default.Pass =
                                    Datos_Globales.NuevaPassword; //this.txtclave.Text.Trim();
                                Settings.Default.User = txtUsuario.Text.Trim();
                                Settings.Default.Recordar = true;
                            }
                            else
                            {
                                Settings.Default.Recordar = false;
                                Settings.Default.Pass = string.Empty;
                                Settings.Default.User = string.Empty;
                            }

                            Settings.Default.Save();
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (chkRecordar.Checked)
                        {
                            Settings.Default.Pass = txtClave.Text.Trim();
                            Settings.Default.User = txtUsuario.Text.Trim();
                            Settings.Default.Recordar = true;
                        }
                        else
                        {
                            Settings.Default.Recordar = false;
                            Settings.Default.Pass = string.Empty;
                            Settings.Default.User = string.Empty;
                        }

                        Settings.Default.Save();
                    }
                }

                DateTime srt = DateTime.Now;

                if (login.EjecutarIDLogin(txtUsuario.Text.Trim(), srt.ToString()) != 0)
                {
                    DataTable dt2 = new DataTable();

                    dt2 = login.ObtenerIDLogin(srt.ToString());

                    Datos_Globales.IdLogin = Convert.ToInt32(dt2.Rows[0][0]);
                    Datos_Globales.Correo = login.ObtenerCorreo(login);

                    Datos_Globales.Usuario = txtUsuario.Text.Trim();
                    Datos_Globales.PC = Environment.MachineName;
                }
                else
                {
                    wait.Close();
                    MessageBox.Show(Personalizar.Mensaje_Error.Trim(), "No Genero el ID Login", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                wait.Close();
                XtraMessageBox.Show("Usuario no existe!");
                return;
            }


            wait.Close();
            Datos_Globales.userPalette = OperacionesGlobal.strGet_String(
                "select top 1 isnull(Paleta, 'The Bezier') from Halcon.dbo.Usuarios where Usuario = '" +
                Datos_Globales.Usuario + "'", "The Bezier");
            UserLookAndFeel.Default.SetSkinStyle("The Bezier", Datos_Globales.userPalette);
            if (chkRecordar.Checked) Settings.Default.UserPalette = Datos_Globales.userPalette;

            Datos_Globales.Usuario = txtUsuario.Text;
            DialogResult = DialogResult.OK;
            Settings.Default.Login = txtLogin.Text;
            Settings.Default.Password = txtPassword.Text;
            Settings.Default.TimeOut = Convert.ToInt32(txtTimeOut.Text);
            Settings.Default.DataBase = txtDataBase.Text;
            Settings.Default.Save();


            Close();
        }

        private void txtClave_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            txtClave.Properties.UseSystemPasswordChar = false;
        }

        private void txtClave_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            txtClave.Properties.UseSystemPasswordChar = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (Width == 868)
            {
                Width = 210;
            }
            else
            {
                XtraInputBoxArgs args = new XtraInputBoxArgs();
                args.Caption = "Configuración";
                args.Prompt = "Introduzca la Clave de Acceso a Configuración";
                args.DefaultButtonIndex = 0;
                args.Showing += Args_Showing;
                TextEdit editor = new TextEdit();
                editor.Properties.UseSystemPasswordChar = true;
                args.Editor = editor;
                args.DefaultResponse = string.Empty;
                var result = XtraInputBox.Show(args);

                if (result != null)
                    if (result.ToString() == "E727cd9b1f")
                        Width = 868;
            }
        }

        private void Args_Showing(object sender, XtraMessageShowingArgs e)
        {
            // set a dialog icon 
            e.Form.Icon = Icon;
        }

        private void txtUsuario_EditValueChanged(object sender, EventArgs e)
        {
            if (txtClave.EditValue != null)
                txtClave.EditValue = null;
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtClave.EditValue == null)
                    txtClave.Focus();
                //return;
                else
                    btnIngresar.PerformClick();
            }
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtClave.EditValue == null)
                    txtClave.Focus();
                //return;
                else
                    btnIngresar.PerformClick();
            }
        }

        #endregion
    }
}