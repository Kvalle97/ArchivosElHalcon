namespace CSPresentacion.Sistema.Administracion
{
    partial class FrmGuardarDashboard
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
            this.txtNombreAMostrar = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lueSistemaOModulo = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGuardar = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcSubReportes = new DevExpress.XtraGrid.GridControl();
            this.gvSubReportes = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.ckComboParametrosHereados = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.lueItemsDisponibles = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lueSubReporte = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lueParamName = new DevExpress.XtraEditors.LookUpEdit();
            this.ckEsSubReporte = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreAMostrar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSistemaOModulo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSubReportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSubReportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckComboParametrosHereados.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueItemsDisponibles.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSubReporte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueParamName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckEsSubReporte.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombreAMostrar
            // 
            this.txtNombreAMostrar.Location = new System.Drawing.Point(12, 25);
            this.txtNombreAMostrar.Name = "txtNombreAMostrar";
            this.txtNombreAMostrar.Size = new System.Drawing.Size(159, 20);
            this.txtNombreAMostrar.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(109, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Nombre a dashboard";
            // 
            // lueSistemaOModulo
            // 
            this.lueSistemaOModulo.Location = new System.Drawing.Point(177, 25);
            this.lueSistemaOModulo.Name = "lueSistemaOModulo";
            this.lueSistemaOModulo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSistemaOModulo.Size = new System.Drawing.Size(198, 20);
            this.lueSistemaOModulo.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(177, 6);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(92, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Sistema o modulo";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.btnCancelar.Appearance.Options.UseBackColor = true;
            this.btnCancelar.Location = new System.Drawing.Point(200, 370);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(82, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btnGuardar.Appearance.Options.UseBackColor = true;
            this.btnGuardar.Location = new System.Drawing.Point(288, 370);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(82, 23);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lueParamName);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.gcSubReportes);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.ckComboParametrosHereados);
            this.groupControl1.Controls.Add(this.lueItemsDisponibles);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.lueSubReporte);
            this.groupControl1.Location = new System.Drawing.Point(12, 79);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(363, 285);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "Sub reportes";
            // 
            // gcSubReportes
            // 
            this.gcSubReportes.Location = new System.Drawing.Point(9, 115);
            this.gcSubReportes.MainView = this.gvSubReportes;
            this.gcSubReportes.Name = "gcSubReportes";
            this.gcSubReportes.Size = new System.Drawing.Size(349, 152);
            this.gcSubReportes.TabIndex = 6;
            this.gcSubReportes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSubReportes});
            // 
            // gvSubReportes
            // 
            this.gvSubReportes.GridControl = this.gcSubReportes;
            this.gvSubReportes.Name = "gvSubReportes";
            this.gvSubReportes.OptionsBehavior.Editable = false;
            this.gvSubReportes.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(9, 73);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(115, 13);
            this.labelControl5.TabIndex = 5;
            this.labelControl5.Text = "Parametros heradados";
            // 
            // ckComboParametrosHereados
            // 
            this.ckComboParametrosHereados.Location = new System.Drawing.Point(9, 89);
            this.ckComboParametrosHereados.Name = "ckComboParametrosHereados";
            this.ckComboParametrosHereados.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ckComboParametrosHereados.Size = new System.Drawing.Size(150, 20);
            this.ckComboParametrosHereados.TabIndex = 4;
            // 
            // lueItemsDisponibles
            // 
            this.lueItemsDisponibles.Location = new System.Drawing.Point(165, 47);
            this.lueItemsDisponibles.Name = "lueItemsDisponibles";
            this.lueItemsDisponibles.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueItemsDisponibles.Size = new System.Drawing.Size(157, 20);
            this.lueItemsDisponibles.TabIndex = 3;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(165, 30);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(51, 13);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "Al clickear";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 28);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(41, 13);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Reporte";
            // 
            // lueSubReporte
            // 
            this.lueSubReporte.Location = new System.Drawing.Point(9, 47);
            this.lueSubReporte.Name = "lueSubReporte";
            this.lueSubReporte.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSubReporte.Size = new System.Drawing.Size(150, 20);
            this.lueSubReporte.TabIndex = 0;
            this.lueSubReporte.EditValueChanged += new System.EventHandler(this.lueSubReporte_EditValueChanged);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(165, 73);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(63, 13);
            this.labelControl6.TabIndex = 8;
            this.labelControl6.Text = "Param Name";
            // 
            // lueParamName
            // 
            this.lueParamName.Location = new System.Drawing.Point(165, 89);
            this.lueParamName.Name = "lueParamName";
            this.lueParamName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueParamName.Size = new System.Drawing.Size(157, 20);
            this.lueParamName.TabIndex = 9;
            // 
            // ckEsSubReporte
            // 
            this.ckEsSubReporte.Location = new System.Drawing.Point(12, 51);
            this.ckEsSubReporte.Name = "ckEsSubReporte";
            this.ckEsSubReporte.Properties.Caption = "Es sub reporte ? ";
            this.ckEsSubReporte.Size = new System.Drawing.Size(144, 20);
            this.ckEsSubReporte.TabIndex = 7;
            // 
            // FrmGuardarDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 405);
            this.Controls.Add(this.ckEsSubReporte);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lueSistemaOModulo);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtNombreAMostrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmGuardarDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Guardar dashboard";
            this.Load += new System.EventHandler(this.FrmGuardarDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreAMostrar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSistemaOModulo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSubReportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSubReportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckComboParametrosHereados.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueItemsDisponibles.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSubReporte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueParamName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckEsSubReporte.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtNombreAMostrar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lueSistemaOModulo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGuardar;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.CheckedComboBoxEdit ckComboParametrosHereados;
        private DevExpress.XtraEditors.LookUpEdit lueItemsDisponibles;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit lueSubReporte;
        private DevExpress.XtraGrid.GridControl gcSubReportes;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSubReportes;
        private DevExpress.XtraEditors.LookUpEdit lueParamName;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.CheckEdit ckEsSubReporte;
    }
}