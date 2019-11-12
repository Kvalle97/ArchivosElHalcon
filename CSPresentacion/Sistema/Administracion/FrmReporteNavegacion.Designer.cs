namespace CSPresentacion.Sistema.Administracion
{
    partial class FrmReporteNavegacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReporteNavegacion));
            this.groupDatos = new DevExpress.XtraEditors.GroupControl();
            this.reporteGeneral1 = new CSPresentacion.Sistema.Utilidades.ReporteGeneral();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupDatos)).BeginInit();
            this.groupDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupDatos
            // 
            this.groupDatos.Controls.Add(this.simpleButton1);
            this.groupDatos.Controls.Add(this.textEdit1);
            this.groupDatos.Controls.Add(this.labelControl1);
            this.groupDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupDatos.Location = new System.Drawing.Point(0, 28);
            this.groupDatos.Name = "groupDatos";
            this.groupDatos.Size = new System.Drawing.Size(632, 76);
            this.groupDatos.TabIndex = 4;
            // 
            // reporteGeneral1
            // 
            this.reporteGeneral1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reporteGeneral1.Location = new System.Drawing.Point(0, 104);
            this.reporteGeneral1.Name = "reporteGeneral1";
            this.reporteGeneral1.Size = new System.Drawing.Size(632, 250);
            this.reporteGeneral1.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Usuario";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(5, 49);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.ReadOnly = true;
            this.textEdit1.Size = new System.Drawing.Size(154, 20);
            this.textEdit1.TabIndex = 1;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.simpleButton1.Location = new System.Drawing.Point(165, 49);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(50, 20);
            this.simpleButton1.TabIndex = 2;
            // 
            // FrmReporteNavegacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 354);
            this.Controls.Add(this.reporteGeneral1);
            this.Controls.Add(this.groupDatos);
            this.Name = "FrmReporteNavegacion";
            this.Text = "FrmReporteNavegacion";
            this.Controls.SetChildIndex(this.groupDatos, 0);
            this.Controls.SetChildIndex(this.reporteGeneral1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupDatos)).EndInit();
            this.groupDatos.ResumeLayout(false);
            this.groupDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupDatos;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Utilidades.ReporteGeneral reporteGeneral1;
    }
}