namespace CSPresentacion.Sistema.Administracion
{
    partial class FrmReporteUsuarios
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.ckbMostrarInactivo = new DevExpress.XtraEditors.CheckEdit();
            this.lueSucursal = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.reporteGeneral1 = new CSPresentacion.Sistema.Utilidades.ReporteGeneral();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckbMostrarInactivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSucursal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.ckbMostrarInactivo);
            this.groupControl1.Controls.Add(this.lueSucursal);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 28);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(644, 81);
            this.groupControl1.TabIndex = 4;
            // 
            // ckbMostrarInactivo
            // 
            this.ckbMostrarInactivo.Location = new System.Drawing.Point(213, 47);
            this.ckbMostrarInactivo.Name = "ckbMostrarInactivo";
            this.ckbMostrarInactivo.Properties.Caption = "Mostrar inactivos";
            this.ckbMostrarInactivo.Size = new System.Drawing.Size(117, 20);
            this.ckbMostrarInactivo.TabIndex = 3;
            this.ckbMostrarInactivo.CheckedChanged += new System.EventHandler(this.ckbMostrarInactivo_CheckedChanged);
            // 
            // lueSucursal
            // 
            this.lueSucursal.Location = new System.Drawing.Point(5, 47);
            this.lueSucursal.Name = "lueSucursal";
            this.lueSucursal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSucursal.Size = new System.Drawing.Size(191, 20);
            this.lueSucursal.TabIndex = 2;
            this.lueSucursal.EditValueChanged += new System.EventHandler(this.lueSucursal_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(43, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Sucursal";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.reporteGeneral1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 109);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(644, 202);
            this.panelControl1.TabIndex = 5;
            // 
            // reporteGeneral1
            // 
            this.reporteGeneral1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reporteGeneral1.Location = new System.Drawing.Point(2, 2);
            this.reporteGeneral1.Name = "reporteGeneral1";
            this.reporteGeneral1.Size = new System.Drawing.Size(640, 198);
            this.reporteGeneral1.TabIndex = 0;
            // 
            // FrmReporteUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 311);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.groupControl1);
            this.Name = "FrmReporteUsuarios";
            this.Text = "Reporte de usuarios";
            this.Load += new System.EventHandler(this.FrmReporteUsuarios_Load);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckbMostrarInactivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSucursal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit ckbMostrarInactivo;
        private DevExpress.XtraEditors.LookUpEdit lueSucursal;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private Utilidades.ReporteGeneral reporteGeneral1;
    }
}