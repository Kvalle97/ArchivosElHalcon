namespace CSPresentacion
{
    partial class FrmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.txtUsuario = new DevExpress.XtraEditors.TextEdit();
            this.txtClave = new DevExpress.XtraEditors.ButtonEdit();
            this.lblNombre = new DevExpress.XtraEditors.LabelControl();
            this.txtLogin = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtTimeOut = new DevExpress.XtraEditors.TextEdit();
            this.txtDataBase = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtValue = new DevExpress.XtraEditors.TextEdit();
            this.lstItems = new System.Windows.Forms.ListBox();
            this.btnTestConnection = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.chkRecordar = new DevExpress.XtraEditors.CheckEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnIngresar = new DevExpress.XtraEditors.SimpleButton();
            this.lblVersion = new DevExpress.XtraEditors.LabelControl();
            this.rgEmpresa = new DevExpress.XtraEditors.RadioGroup();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.btnArriba = new DevExpress.XtraEditors.SimpleButton();
            this.btnBajar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClave.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataBase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRecordar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgEmpresa.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(12, 136);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUsuario.Properties.NullValuePrompt = "Usuario";
            this.txtUsuario.Size = new System.Drawing.Size(182, 20);
            this.txtUsuario.TabIndex = 0;
            this.txtUsuario.EditValueChanged += new System.EventHandler(this.txtUsuario_EditValueChanged);
            this.txtUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsuario_KeyDown);
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(12, 162);
            this.txtClave.Name = "txtClave";
            editorButtonImageOptions2.Image = global::CSPresentacion.Properties.Resources.hide_16x16;
            serializableAppearanceObject7.Image = global::CSPresentacion.Properties.Resources.show_16x16;
            serializableAppearanceObject7.Options.UseImage = true;
            this.txtClave.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.txtClave.Properties.NullValuePrompt = "Contraseña";
            this.txtClave.Properties.UseSystemPasswordChar = true;
            this.txtClave.Size = new System.Drawing.Size(182, 20);
            this.txtClave.TabIndex = 1;
            this.txtClave.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtClave_ButtonClick);
            this.txtClave.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtClave_ButtonPressed);
            this.txtClave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtClave_KeyDown);
            // 
            // lblNombre
            // 
            this.lblNombre.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblNombre.Appearance.Options.UseFont = true;
            this.lblNombre.Location = new System.Drawing.Point(12, 100);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(187, 21);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Sistema  de administración";
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(387, 79);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(100, 20);
            this.txtLogin.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(387, 105);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.UseSystemPasswordChar = true;
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // txtTimeOut
            // 
            this.txtTimeOut.Location = new System.Drawing.Point(387, 131);
            this.txtTimeOut.Name = "txtTimeOut";
            this.txtTimeOut.Size = new System.Drawing.Size(100, 20);
            this.txtTimeOut.TabIndex = 6;
            // 
            // txtDataBase
            // 
            this.txtDataBase.Location = new System.Drawing.Point(387, 157);
            this.txtDataBase.Name = "txtDataBase";
            this.txtDataBase.Size = new System.Drawing.Size(100, 20);
            this.txtDataBase.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(545, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Servidor:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(322, 82);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(32, 13);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Login:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(322, 108);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 13);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Password:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(322, 134);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(45, 13);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "Timeout:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(322, 160);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(50, 13);
            this.labelControl4.TabIndex = 12;
            this.labelControl4.Text = "DataBase:";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(607, 78);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(120, 20);
            this.txtValue.TabIndex = 13;
            this.txtValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValue_KeyDown);
            // 
            // lstItems
            // 
            this.lstItems.FormattingEnabled = true;
            this.lstItems.Location = new System.Drawing.Point(607, 104);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(120, 95);
            this.lstItems.TabIndex = 14;
            this.lstItems.SelectedIndexChanged += new System.EventHandler(this.lstItems_SelectedIndexChanged);
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(607, 205);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(120, 23);
            this.btnTestConnection.TabIndex = 15;
            this.btnTestConnection.Text = "Probar Conexión";
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(733, 76);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(733, 105);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 17;
            this.btnRemove.Text = "Eliminar";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // chkRecordar
            // 
            this.chkRecordar.Location = new System.Drawing.Point(119, 188);
            this.chkRecordar.Name = "chkRecordar";
            this.chkRecordar.Properties.Caption = "Recordar";
            this.chkRecordar.Size = new System.Drawing.Size(75, 20);
            this.chkRecordar.TabIndex = 19;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::CSPresentacion.Properties.Resources.admin;
            this.pictureEdit1.Location = new System.Drawing.Point(60, 12);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(100, 87);
            this.pictureEdit1.TabIndex = 21;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.simpleButton1.ImageOptions.Image = global::CSPresentacion.Properties.Resources.documentproperties_16x16;
            this.simpleButton1.Location = new System.Drawing.Point(178, 283);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(16, 16);
            this.simpleButton1.TabIndex = 20;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnIngresar
            // 
            this.btnIngresar.ImageOptions.Image = global::CSPresentacion.Properties.Resources.bouser_32x32;
            this.btnIngresar.Location = new System.Drawing.Point(12, 231);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(182, 46);
            this.btnIngresar.TabIndex = 2;
            this.btnIngresar.Text = "Iniciar Sesión";
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.Appearance.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Appearance.Options.UseFont = true;
            this.lblVersion.Location = new System.Drawing.Point(12, 349);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(5, 11);
            this.lblVersion.TabIndex = 18;
            this.lblVersion.Text = "V";
            // 
            // rgEmpresa
            // 
            this.rgEmpresa.Location = new System.Drawing.Point(12, 313);
            this.rgEmpresa.Name = "rgEmpresa";
            this.rgEmpresa.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgEmpresa.Properties.Appearance.Options.UseFont = true;
            this.rgEmpresa.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.rgEmpresa.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Juan Cajina", true, null, "Juan Cajina"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, " El Halcon S.A.", true, null, " El Halcon S.A.")});
            this.rgEmpresa.Size = new System.Drawing.Size(187, 28);
            this.rgEmpresa.TabIndex = 23;
            this.rgEmpresa.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged_1);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(733, 134);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 24;
            this.btnReset.Text = " Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnArriba
            // 
            this.btnArriba.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnArriba.ImageOptions.Image")));
            this.btnArriba.Location = new System.Drawing.Point(581, 105);
            this.btnArriba.Name = "btnArriba";
            this.btnArriba.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnArriba.Size = new System.Drawing.Size(20, 43);
            this.btnArriba.TabIndex = 25;
            this.btnArriba.Click += new System.EventHandler(this.btnArriba_Click);
            // 
            // btnBajar
            // 
            this.btnBajar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBajar.ImageOptions.Image")));
            this.btnBajar.Location = new System.Drawing.Point(581, 139);
            this.btnBajar.Name = "btnBajar";
            this.btnBajar.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnBajar.Size = new System.Drawing.Size(20, 43);
            this.btnBajar.TabIndex = 25;
            this.btnBajar.Click += new System.EventHandler(this.btnBajar_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 426);
            this.Controls.Add(this.btnBajar);
            this.Controls.Add(this.btnArriba);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.rgEmpresa);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.chkRecordar);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.lstItems);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDataBase);
            this.Controls.Add(this.txtTimeOut);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.txtUsuario);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("FrmLogin.IconOptions.Icon")));
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar Sesión";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLogin_FormClosing);
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClave.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataBase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRecordar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgEmpresa.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtUsuario;
        private DevExpress.XtraEditors.ButtonEdit txtClave;
        private DevExpress.XtraEditors.SimpleButton btnIngresar;
        private DevExpress.XtraEditors.LabelControl lblNombre;
        private DevExpress.XtraEditors.TextEdit txtLogin;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtTimeOut;
        private DevExpress.XtraEditors.TextEdit txtDataBase;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtValue;
        private System.Windows.Forms.ListBox lstItems;
        private DevExpress.XtraEditors.SimpleButton btnTestConnection;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnRemove;
        private DevExpress.XtraEditors.CheckEdit chkRecordar;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl lblVersion;
        private DevExpress.XtraEditors.RadioGroup rgEmpresa;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.XtraEditors.SimpleButton btnArriba;
        private DevExpress.XtraEditors.SimpleButton btnBajar;
    }
}