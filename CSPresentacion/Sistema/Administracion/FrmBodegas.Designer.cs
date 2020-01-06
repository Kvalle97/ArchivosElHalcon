namespace CSPresentacion.Sistema.Administracion
{
    partial class FrmBodegas
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBodegas));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gc = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblId = new DevExpress.XtraEditors.LabelControl();
            this.txtId = new DevExpress.XtraEditors.TextEdit();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.lblDescripcion = new DevExpress.XtraEditors.LabelControl();
            this.txtAbreviatura = new DevExpress.XtraEditors.TextEdit();
            this.lblAbreviatura = new DevExpress.XtraEditors.LabelControl();
            this.ckActivo = new DevExpress.XtraEditors.CheckEdit();
            this.lblCosto = new DevExpress.XtraEditors.LabelControl();
            this.txtCosto = new DevExpress.XtraEditors.ButtonEdit();
            this.lblEmpresa = new DevExpress.XtraEditors.LabelControl();
            this.lueEmpresa = new DevExpress.XtraEditors.LookUpEdit();
            this.lblComentarios = new DevExpress.XtraEditors.LabelControl();
            this.meComentarios = new DevExpress.XtraEditors.MemoEdit();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAbreviatura.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckActivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCosto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueEmpresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meComentarios.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // gc
            // 
            this.gc.Location = new System.Drawing.Point(217, 34);
            this.gc.MainView = this.gv;
            this.gc.Name = "gc";
            this.gc.Size = new System.Drawing.Size(402, 333);
            this.gc.TabIndex = 0;
            this.gc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.GridControl = this.gc;
            this.gv.Name = "gv";
            this.gv.OptionsBehavior.Editable = false;
            this.gv.OptionsView.ShowAutoFilterRow = true;
            this.gv.OptionsView.ShowGroupPanel = false;
            // 
            // lblId
            // 
            this.lblId.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblId.Appearance.Options.UseFont = true;
            this.lblId.Location = new System.Drawing.Point(12, 34);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(10, 13);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "Id";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(12, 54);
            this.txtId.Name = "txtId";
            this.txtId.Properties.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(199, 20);
            this.txtId.TabIndex = 2;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(12, 107);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Size = new System.Drawing.Size(199, 20);
            this.txtDescripcion.TabIndex = 4;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblDescripcion.Appearance.Options.UseFont = true;
            this.lblDescripcion.Location = new System.Drawing.Point(12, 87);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(60, 13);
            this.lblDescripcion.TabIndex = 3;
            this.lblDescripcion.Text = "Descripción";
            // 
            // txtAbreviatura
            // 
            this.txtAbreviatura.Location = new System.Drawing.Point(12, 154);
            this.txtAbreviatura.Name = "txtAbreviatura";
            this.txtAbreviatura.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAbreviatura.Size = new System.Drawing.Size(199, 20);
            this.txtAbreviatura.TabIndex = 6;
            // 
            // lblAbreviatura
            // 
            this.lblAbreviatura.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblAbreviatura.Appearance.Options.UseFont = true;
            this.lblAbreviatura.Location = new System.Drawing.Point(12, 134);
            this.lblAbreviatura.Name = "lblAbreviatura";
            this.lblAbreviatura.Size = new System.Drawing.Size(61, 13);
            this.lblAbreviatura.TabIndex = 5;
            this.lblAbreviatura.Text = "Abreviatura";
            // 
            // ckActivo
            // 
            this.ckActivo.Location = new System.Drawing.Point(136, 180);
            this.ckActivo.Name = "ckActivo";
            this.ckActivo.Properties.Caption = "Activo";
            this.ckActivo.Size = new System.Drawing.Size(75, 20);
            this.ckActivo.TabIndex = 7;
            // 
            // lblCosto
            // 
            this.lblCosto.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCosto.Appearance.Options.UseFont = true;
            this.lblCosto.Location = new System.Drawing.Point(12, 202);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(30, 13);
            this.lblCosto.TabIndex = 8;
            this.lblCosto.Text = "Costo";
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(12, 221);
            this.txtCosto.Name = "txtCosto";
            editorButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions2.Image")));
            this.txtCosto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.txtCosto.Size = new System.Drawing.Size(199, 20);
            this.txtCosto.TabIndex = 9;
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblEmpresa.Appearance.Options.UseFont = true;
            this.lblEmpresa.Location = new System.Drawing.Point(12, 247);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(44, 13);
            this.lblEmpresa.TabIndex = 10;
            this.lblEmpresa.Text = "Empresa";
            // 
            // lueEmpresa
            // 
            this.lueEmpresa.Location = new System.Drawing.Point(12, 266);
            this.lueEmpresa.Name = "lueEmpresa";
            this.lueEmpresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueEmpresa.Size = new System.Drawing.Size(199, 20);
            this.lueEmpresa.TabIndex = 11;
            // 
            // lblComentarios
            // 
            this.lblComentarios.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblComentarios.Appearance.Options.UseFont = true;
            this.lblComentarios.Location = new System.Drawing.Point(12, 292);
            this.lblComentarios.Name = "lblComentarios";
            this.lblComentarios.Size = new System.Drawing.Size(66, 13);
            this.lblComentarios.TabIndex = 12;
            this.lblComentarios.Text = "Comentarios";
            // 
            // meComentarios
            // 
            this.meComentarios.Location = new System.Drawing.Point(12, 311);
            this.meComentarios.Name = "meComentarios";
            this.meComentarios.Size = new System.Drawing.Size(199, 56);
            this.meComentarios.TabIndex = 13;
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // FrmBodegas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 374);
            this.Controls.Add(this.meComentarios);
            this.Controls.Add(this.lblComentarios);
            this.Controls.Add(this.lueEmpresa);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.lblCosto);
            this.Controls.Add(this.ckActivo);
            this.Controls.Add(this.txtAbreviatura);
            this.Controls.Add(this.lblAbreviatura);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.gc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmBodegas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bodegas";
            this.Load += new System.EventHandler(this.FrmBodegas_Load);
            this.Controls.SetChildIndex(this.gc, 0);
            this.Controls.SetChildIndex(this.lblId, 0);
            this.Controls.SetChildIndex(this.txtId, 0);
            this.Controls.SetChildIndex(this.lblDescripcion, 0);
            this.Controls.SetChildIndex(this.txtDescripcion, 0);
            this.Controls.SetChildIndex(this.lblAbreviatura, 0);
            this.Controls.SetChildIndex(this.txtAbreviatura, 0);
            this.Controls.SetChildIndex(this.ckActivo, 0);
            this.Controls.SetChildIndex(this.lblCosto, 0);
            this.Controls.SetChildIndex(this.txtCosto, 0);
            this.Controls.SetChildIndex(this.lblEmpresa, 0);
            this.Controls.SetChildIndex(this.lueEmpresa, 0);
            this.Controls.SetChildIndex(this.lblComentarios, 0);
            this.Controls.SetChildIndex(this.meComentarios, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAbreviatura.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckActivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCosto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueEmpresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meComentarios.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gc;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraEditors.LabelControl lblId;
        private DevExpress.XtraEditors.TextEdit txtId;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.LabelControl lblDescripcion;
        private DevExpress.XtraEditors.TextEdit txtAbreviatura;
        private DevExpress.XtraEditors.LabelControl lblAbreviatura;
        private DevExpress.XtraEditors.CheckEdit ckActivo;
        private DevExpress.XtraEditors.LabelControl lblCosto;
        private DevExpress.XtraEditors.ButtonEdit txtCosto;
        private DevExpress.XtraEditors.LabelControl lblEmpresa;
        private DevExpress.XtraEditors.LookUpEdit lueEmpresa;
        private DevExpress.XtraEditors.LabelControl lblComentarios;
        private DevExpress.XtraEditors.MemoEdit meComentarios;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
    }
}