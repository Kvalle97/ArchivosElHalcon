namespace CSPresentacion
{
    partial class FrmCambioPassword
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtpasswordactual = new DevExpress.XtraEditors.TextEdit();
            this.txtpasswordnueva = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtpasswordrepita = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnaceptar = new DevExpress.XtraEditors.SimpleButton();
            this.btncancelar = new DevExpress.XtraEditors.SimpleButton();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpasswordactual.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpasswordnueva.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpasswordrepita.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(104, 121);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(230, 17);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Cambio de Contraseña Por Seguridad";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(13, 161);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(153, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Escriba la Contraseña Actual:";
            // 
            // txtpasswordactual
            // 
            this.txtpasswordactual.Location = new System.Drawing.Point(234, 158);
            this.txtpasswordactual.Name = "txtpasswordactual";
            this.txtpasswordactual.Properties.PasswordChar = '*';
            this.txtpasswordactual.Size = new System.Drawing.Size(210, 20);
            this.txtpasswordactual.TabIndex = 3;
            this.txtpasswordactual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpasswordactual_KeyPress);
            // 
            // txtpasswordnueva
            // 
            this.txtpasswordnueva.Location = new System.Drawing.Point(234, 184);
            this.txtpasswordnueva.Name = "txtpasswordnueva";
            this.txtpasswordnueva.Properties.PasswordChar = '*';
            this.txtpasswordnueva.Size = new System.Drawing.Size(210, 20);
            this.txtpasswordnueva.TabIndex = 5;
            this.txtpasswordnueva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpasswordnueva_KeyPress);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(13, 187);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(154, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Escriba la Nueva Contraseña:";
            // 
            // txtpasswordrepita
            // 
            this.txtpasswordrepita.Location = new System.Drawing.Point(234, 210);
            this.txtpasswordrepita.Name = "txtpasswordrepita";
            this.txtpasswordrepita.Properties.PasswordChar = '*';
            this.txtpasswordrepita.Size = new System.Drawing.Size(210, 20);
            this.txtpasswordrepita.TabIndex = 7;
            this.txtpasswordrepita.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpasswordrepita_KeyPress);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(13, 213);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(200, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Escriba Confimación de la Contraseña:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.Location = new System.Drawing.Point(13, 280);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(401, 26);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "Nota: la Clave debe de ser al menos 8 caracteres y debe de contener al menos \r\nun" +
    "a mayúscula, una minúscula y un digito.";
            // 
            // btnaceptar
            // 
            this.btnaceptar.Location = new System.Drawing.Point(269, 236);
            this.btnaceptar.Name = "btnaceptar";
            this.btnaceptar.Size = new System.Drawing.Size(75, 23);
            this.btnaceptar.TabIndex = 9;
            this.btnaceptar.Text = "Aceptar";
            this.btnaceptar.Click += new System.EventHandler(this.btnaceptar_Click);
            // 
            // btncancelar
            // 
            this.btncancelar.Location = new System.Drawing.Point(368, 236);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(75, 23);
            this.btncancelar.TabIndex = 10;
            this.btncancelar.Text = "Cancelar";
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit1.EditValue = global::CSPresentacion.Properties.Resources.LOGO_en_BMP;
            this.pictureEdit1.Location = new System.Drawing.Point(0, 0);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.Image;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.pictureEdit1.Size = new System.Drawing.Size(454, 115);
            this.pictureEdit1.TabIndex = 0;
            this.pictureEdit1.EditValueChanged += new System.EventHandler(this.pictureEdit1_EditValueChanged);
            // 
            // FrmCambioPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 325);
            this.Controls.Add(this.btncancelar);
            this.Controls.Add(this.btnaceptar);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtpasswordrepita);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtpasswordnueva);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtpasswordactual);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.pictureEdit1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCambioPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambio Password";
            ((System.ComponentModel.ISupportInitialize)(this.txtpasswordactual.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpasswordnueva.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpasswordrepita.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtpasswordactual;
        private DevExpress.XtraEditors.TextEdit txtpasswordnueva;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtpasswordrepita;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btnaceptar;
        private DevExpress.XtraEditors.SimpleButton btncancelar;
    }
}