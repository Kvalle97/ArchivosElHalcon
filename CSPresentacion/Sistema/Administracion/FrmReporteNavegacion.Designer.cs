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
            this.groupDatos = new DevExpress.XtraEditors.GroupControl();
            this.glueUsuarios = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dpHasta = new DevExpress.XtraEditors.DateEdit();
            this.dpDesde = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.reporteGeneral = new CSPresentacion.Sistema.Utilidades.ReporteGeneral();
            this.btnVerReporte = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupDatos)).BeginInit();
            this.groupDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.glueUsuarios.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpDesde.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupDatos
            // 
            this.groupDatos.Controls.Add(this.btnVerReporte);
            this.groupDatos.Controls.Add(this.glueUsuarios);
            this.groupDatos.Controls.Add(this.labelControl3);
            this.groupDatos.Controls.Add(this.labelControl2);
            this.groupDatos.Controls.Add(this.dpHasta);
            this.groupDatos.Controls.Add(this.dpDesde);
            this.groupDatos.Controls.Add(this.labelControl1);
            this.groupDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupDatos.Location = new System.Drawing.Point(0, 28);
            this.groupDatos.Name = "groupDatos";
            this.groupDatos.Size = new System.Drawing.Size(632, 76);
            this.groupDatos.TabIndex = 4;
            // 
            // glueUsuarios
            // 
            this.glueUsuarios.Location = new System.Drawing.Point(5, 49);
            this.glueUsuarios.Name = "glueUsuarios";
            this.glueUsuarios.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.glueUsuarios.Properties.PopupView = this.gridLookUpEdit1View;
            this.glueUsuarios.Size = new System.Drawing.Size(210, 20);
            this.glueUsuarios.TabIndex = 7;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(373, 30);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(29, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Hasta";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(221, 30);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(32, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Desde";
            // 
            // dpHasta
            // 
            this.dpHasta.EditValue = null;
            this.dpHasta.Location = new System.Drawing.Point(373, 49);
            this.dpHasta.Name = "dpHasta";
            this.dpHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpHasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpHasta.Size = new System.Drawing.Size(146, 20);
            this.dpHasta.TabIndex = 4;
            // 
            // dpDesde
            // 
            this.dpDesde.EditValue = null;
            this.dpDesde.Location = new System.Drawing.Point(221, 49);
            this.dpDesde.Name = "dpDesde";
            this.dpDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpDesde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpDesde.Size = new System.Drawing.Size(146, 20);
            this.dpDesde.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Usuario";
            // 
            // reporteGeneral
            // 
            this.reporteGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reporteGeneral.Location = new System.Drawing.Point(0, 104);
            this.reporteGeneral.Name = "reporteGeneral";
            this.reporteGeneral.Size = new System.Drawing.Size(632, 250);
            this.reporteGeneral.TabIndex = 5;
            // 
            // btnVerReporte
            // 
            this.btnVerReporte.Location = new System.Drawing.Point(525, 47);
            this.btnVerReporte.Name = "btnVerReporte";
            this.btnVerReporte.Size = new System.Drawing.Size(95, 23);
            this.btnVerReporte.TabIndex = 8;
            this.btnVerReporte.Text = "Ver reporte";
            this.btnVerReporte.Click += new System.EventHandler(this.btnVerReporte_Click);
            // 
            // FrmReporteNavegacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 354);
            this.Controls.Add(this.reporteGeneral);
            this.Controls.Add(this.groupDatos);
            this.Name = "FrmReporteNavegacion";
            this.Text = "FrmReporteNavegacion";
            this.Load += new System.EventHandler(this.FrmReporteNavegacion_Load);
            this.Controls.SetChildIndex(this.groupDatos, 0);
            this.Controls.SetChildIndex(this.reporteGeneral, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupDatos)).EndInit();
            this.groupDatos.ResumeLayout(false);
            this.groupDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.glueUsuarios.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpDesde.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupDatos;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Utilidades.ReporteGeneral reporteGeneral;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dpHasta;
        private DevExpress.XtraEditors.DateEdit dpDesde;
        private DevExpress.XtraEditors.GridLookUpEdit glueUsuarios;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraEditors.SimpleButton btnVerReporte;
    }
}