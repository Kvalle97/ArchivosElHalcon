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
using System.Diagnostics;
using CSNegocios;
using DevExpress.Utils;
using DevExpress.LookAndFeel;

namespace CSPresentacion
{
    /// <summary>
    /// Formulario de incio de sesion
    /// </summary>
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FrmLogin()
        {
            InitializeComponent();
        }


        #region Metodos

        /// <summary>
        /// List items
        /// </summary>
        private void ListItems()
        {
            lstItems.DataSource = Properties.Settings.Default.ServerAddress.Cast<string>().ToArray();
            //lstItems.Refresh();
            //Properties.Settings.Default.Items.Cast<string>().ToArray();
            lstItems.SelectedIndex = -1;
        }

        /// <summary>
        /// Validar String de coneccion
        /// </summary>
        /// <returns></returns>
        public string ValidarConnString()
        {
            int n = lstItems.Items.Count;


            var retryCount = 0;
            while (true)
            {
                try
                {
                    this.txtValue.Text = lstItems.Items[retryCount].ToString();
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
            }

            if (retryCount < n)
                return lstItems.Items[retryCount].ToString();
            else
                return string.Empty;
        }

        #endregion

        #region Eventos

        private void frmLogin_Load(object sender, EventArgs e)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            this.lblVersion.Text = "v" + version;
            Datos_Globales.VersionSistemaLocal = version;

            this.Width = 210;
            this.txtLogin.EditValue = Properties.Settings.Default.Login;
            this.txtPassword.EditValue = Properties.Settings.Default.Password;
            this.txtTimeOut.EditValue = Properties.Settings.Default.TimeOut;
            this.txtDataBase.EditValue = Properties.Settings.Default.DataBase;
            ListItems();

            if (Properties.Settings.Default.Recordar == true)
            {
                this.chkRecordar.Checked = Properties.Settings.Default.Recordar;
                this.txtUsuario.Text = Properties.Settings.Default.User.Trim();
                this.txtClave.Text = Properties.Settings.Default.Pass.Trim();
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
                Properties.Settings.Default.ServerAddress.Add(txtValue.Text);
                txtValue.ResetText();
                txtValue.Focus();
                ListItems();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ServerAddress.Remove(txtValue.Text);
            txtValue.ResetText();
            txtValue.Focus();
            ListItems();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }


        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            string mensaje = ValidarConnString();
            if (mensaje != string.Empty)
                XtraMessageBox.Show(mensaje);
        }

        private void txtValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd.PerformClick();
            }
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
            login.User = this.txtUsuario.Text;

            if (login.ValidarUsuario(login))
            {
                Usuarios usuario = new Usuarios();
                usuario.Usuario = txtUsuario.Text;


                Datos_Globales.TituloEmpresa = OperacionesGlobal.ObtenerNombreEmpresa();


                //******************* Aqui empieza la parte copiada*************//


                //if (loguin.ValidarUsuario(loguin))
                //{

                login.User = this.txtUsuario.Text.Trim();
                object PassW = login.ObtenerPassword(login);

                if (PassW.ToString() != this.txtClave.Text.Trim())
                {
                    wait.Close();
                    XtraMessageBox.Show("La Contraseña es Incorrecta", "Inicio de Sesión", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    this.txtClave.EditValue = null;
                    this.txtClave.Focus();
                    return;
                }


                // #region Verifica si existe un cambio en la contraseña
                DataTable dtb = new DataTable();
                dtb.Clear();
                dtb = login.Cargar("select PasswordUsuario,CambioPassword from Halcon.dbo.Usuarios where Usuario='" +
                                   this.txtUsuario.Text.Trim() + "'");

                if (dtb.Rows.Count > 0)
                {
                    bool Cambio = Convert.ToBoolean(dtb.Rows[0]["CambioPassword"]);

                    if (Cambio)
                    {
                        Usuarios usuariop = new Usuarios();
                        string pass = Convert.ToString(dtb.Rows[0]["PasswordUsuario"]);
                        string usupass = usuariop.DesencriptarEncriptarClave(pass);

                        wait.Close();

                        FrmCambioPassword frm = new FrmCambioPassword(this.txtUsuario.Text.Trim());
                        frm.ShowDialog();

                        if (frm.DialogResult == DialogResult.OK)
                        {
                            if (this.chkRecordar.Checked == true)
                            {
                                Properties.Settings.Default.Pass =
                                    Datos_Globales.NuevaPassword; //this.txtclave.Text.Trim();
                                Properties.Settings.Default.User = this.txtUsuario.Text.Trim();
                                Properties.Settings.Default.Recordar = true;
                            }
                            else
                            {
                                Properties.Settings.Default.Recordar = false;
                                Properties.Settings.Default.Pass = string.Empty;
                                Properties.Settings.Default.User = string.Empty;
                            }

                            Properties.Settings.Default.Save();
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (this.chkRecordar.Checked == true)
                        {
                            Properties.Settings.Default.Pass = this.txtClave.Text.Trim();
                            Properties.Settings.Default.User = this.txtUsuario.Text.Trim();
                            Properties.Settings.Default.Recordar = true;
                        }
                        else
                        {
                            Properties.Settings.Default.Recordar = false;
                            Properties.Settings.Default.Pass = string.Empty;
                            Properties.Settings.Default.User = string.Empty;
                        }

                        Properties.Settings.Default.Save();
                    }
                }

                DateTime srt = DateTime.Now;

                if (login.EjecutarIDLogin(this.txtUsuario.Text.Trim(), srt.ToString()) != 0)
                {
                    DataTable dt2 = new DataTable();

                    dt2 = login.ObtenerIDLogin(srt.ToString());

                    Datos_Globales.IdLogin = Convert.ToInt32(dt2.Rows[0][0]);
                    Datos_Globales.Correo = login.ObtenerCorreo(login);

                    Datos_Globales.Usuario = this.txtUsuario.Text.Trim();
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
            if (this.chkRecordar.Checked)
            {
                Properties.Settings.Default.UserPalette = Datos_Globales.userPalette;
            }

            Datos_Globales.Usuario = this.txtUsuario.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Properties.Settings.Default.Login = this.txtLogin.Text;
            Properties.Settings.Default.Password = this.txtPassword.Text;
            Properties.Settings.Default.TimeOut = Convert.ToInt32(this.txtTimeOut.Text);
            Properties.Settings.Default.DataBase = this.txtDataBase.Text;
            Properties.Settings.Default.Save();


            this.Close();
        }

        private void txtClave_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtClave.Properties.UseSystemPasswordChar = false;
        }

        private void txtClave_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtClave.Properties.UseSystemPasswordChar = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (this.Width == 868)
            {
                this.Width = 210;
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
                        this.Width = 868;
            }
        }

        private void Args_Showing(object sender, XtraMessageShowingArgs e)
        {
            // set a dialog icon 
            e.Form.Icon = this.Icon;
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
                {
                    txtClave.Focus();
                    //return;
                }
                else
                {
                    btnIngresar.PerformClick();
                }
            }
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtClave.EditValue == null)
                {
                    txtClave.Focus();
                    //return;
                }
                else
                {
                    btnIngresar.PerformClick();
                }
            }
        }

        #endregion
    }
}