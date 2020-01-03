namespace CSPresentacion.Sistema.Administracion
{
    partial class FrmInformacion
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInformacion));
            this.xtraScrollableControl = new DevExpress.XtraEditors.XtraScrollableControl();
            this.meDireccion = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtRuc = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnQuitar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCargar = new DevExpress.XtraEditors.SimpleButton();
            this.peFoto = new DevExpress.XtraEditors.PictureEdit();
            this.txtCompania = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.xtraScrollableControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meDireccion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peFoto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompania.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraScrollableControl
            // 
            this.xtraScrollableControl.Controls.Add(this.meDireccion);
            this.xtraScrollableControl.Controls.Add(this.labelControl4);
            this.xtraScrollableControl.Controls.Add(this.txtRuc);
            this.xtraScrollableControl.Controls.Add(this.labelControl3);
            this.xtraScrollableControl.Controls.Add(this.labelControl2);
            this.xtraScrollableControl.Controls.Add(this.btnQuitar);
            this.xtraScrollableControl.Controls.Add(this.btnCargar);
            this.xtraScrollableControl.Controls.Add(this.peFoto);
            this.xtraScrollableControl.Controls.Add(this.txtCompania);
            this.xtraScrollableControl.Controls.Add(this.labelControl1);
            this.xtraScrollableControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl.Location = new System.Drawing.Point(0, 28);
            this.xtraScrollableControl.Name = "xtraScrollableControl";
            this.xtraScrollableControl.Size = new System.Drawing.Size(381, 245);
            this.xtraScrollableControl.TabIndex = 4;
            // 
            // meDireccion
            // 
            this.meDireccion.Location = new System.Drawing.Point(193, 83);
            this.meDireccion.Name = "meDireccion";
            this.meDireccion.Size = new System.Drawing.Size(175, 105);
            this.meDireccion.TabIndex = 9;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(193, 64);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 13);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Dirección";
            // 
            // txtRuc
            // 
            this.txtRuc.Location = new System.Drawing.Point(193, 31);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(175, 20);
            this.txtRuc.TabIndex = 7;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(193, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(19, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Ruc";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 64);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Foto";
            // 
            // btnQuitar
            // 
            this.btnQuitar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitar.ImageOptions.Image")));
            this.btnQuitar.Location = new System.Drawing.Point(100, 194);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(82, 24);
            this.btnQuitar.TabIndex = 4;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnCargar
            // 
            this.btnCargar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCargar.ImageOptions.Image")));
            this.btnCargar.Location = new System.Drawing.Point(12, 194);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(82, 24);
            this.btnCargar.TabIndex = 3;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // peFoto
            // 
            this.peFoto.Location = new System.Drawing.Point(12, 83);
            this.peFoto.Name = "peFoto";
            this.peFoto.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.peFoto.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.peFoto.Size = new System.Drawing.Size(175, 105);
            this.peFoto.TabIndex = 2;
            // 
            // txtCompania
            // 
            this.txtCompania.Location = new System.Drawing.Point(12, 31);
            this.txtCompania.Name = "txtCompania";
            this.txtCompania.Size = new System.Drawing.Size(175, 20);
            this.txtCompania.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Compañía";
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // FrmInformacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 273);
            this.Controls.Add(this.xtraScrollableControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmInformacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Información";
            this.Load += new System.EventHandler(this.FrmInformacion_Load);
            this.Controls.SetChildIndex(this.xtraScrollableControl, 0);
            this.xtraScrollableControl.ResumeLayout(false);
            this.xtraScrollableControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meDireccion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peFoto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompania.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl;
        private DevExpress.XtraEditors.SimpleButton btnQuitar;
        private DevExpress.XtraEditors.SimpleButton btnCargar;
        private DevExpress.XtraEditors.PictureEdit peFoto;
        private DevExpress.XtraEditors.TextEdit txtCompania;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtRuc;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.MemoEdit meDireccion;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
    }
}