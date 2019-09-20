namespace CSPresentacion
{
    partial class FrmSucursales
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
            this.lueSucursales = new DevExpress.XtraEditors.LookUpEdit();
            this.chkRecordarSucursal = new DevExpress.XtraEditors.CheckEdit();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.lueSucursales.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRecordarSucursal.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lueSucursales
            // 
            this.lueSucursales.Location = new System.Drawing.Point(12, 51);
            this.lueSucursales.Name = "lueSucursales";
            this.lueSucursales.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSucursales.Size = new System.Drawing.Size(240, 20);
            this.lueSucursales.TabIndex = 0;
            // 
            // chkRecordarSucursal
            // 
            this.chkRecordarSucursal.Location = new System.Drawing.Point(177, 77);
            this.chkRecordarSucursal.Name = "chkRecordarSucursal";
            this.chkRecordarSucursal.Properties.Caption = "Recordar";
            this.chkRecordarSucursal.Size = new System.Drawing.Size(75, 20);
            this.chkRecordarSucursal.TabIndex = 1;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(177, 136);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // FrmSucursales
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 171);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.chkRecordarSucursal);
            this.Controls.Add(this.lueSucursales);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSucursales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sucursales";
            this.Load += new System.EventHandler(this.frmSucursales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lueSucursales.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRecordarSucursal.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lueSucursales;
        private DevExpress.XtraEditors.CheckEdit chkRecordarSucursal;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
    }
}