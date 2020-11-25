namespace CSPresentacion.Sistema.Administracion
{
    partial class FrmBloqueoDeMargen
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
            this.gcProductos = new DevExpress.XtraGrid.GridControl();
            this.gvProductos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblCodigo = new DevExpress.XtraEditors.LabelControl();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.txtProducto = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.seDescuentoMaximo = new DevExpress.XtraEditors.SpinEdit();
            this.seMargenMinimo = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnActualizar = new DevExpress.XtraEditors.SimpleButton();
            this.ckMargenMinimo = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProducto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seDescuentoMaximo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seMargenMinimo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckMargenMinimo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcProductos
            // 
            this.gcProductos.Location = new System.Drawing.Point(12, 112);
            this.gcProductos.MainView = this.gvProductos;
            this.gcProductos.Name = "gcProductos";
            this.gcProductos.Size = new System.Drawing.Size(552, 271);
            this.gcProductos.TabIndex = 0;
            this.gcProductos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProductos});
            // 
            // gvProductos
            // 
            this.gvProductos.GridControl = this.gcProductos;
            this.gvProductos.Name = "gvProductos";
            this.gvProductos.OptionsBehavior.Editable = false;
            this.gvProductos.OptionsView.ColumnAutoWidth = false;
            this.gvProductos.OptionsView.ShowAutoFilterRow = true;
            this.gvProductos.OptionsView.ShowGroupPanel = false;
            this.gvProductos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gvProductos_KeyUp);
            this.gvProductos.DoubleClick += new System.EventHandler(this.gvProductos_DoubleClick);
            // 
            // lblCodigo
            // 
            this.lblCodigo.Location = new System.Drawing.Point(12, 12);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(38, 13);
            this.lblCodigo.TabIndex = 1;
            this.lblCodigo.Text = "Codigo";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(12, 31);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Properties.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(181, 20);
            this.txtCodigo.TabIndex = 2;
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(12, 73);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Properties.ReadOnly = true;
            this.txtProducto.Size = new System.Drawing.Size(181, 20);
            this.txtProducto.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 54);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Producto";
            // 
            // seDescuentoMaximo
            // 
            this.seDescuentoMaximo.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seDescuentoMaximo.Location = new System.Drawing.Point(199, 31);
            this.seDescuentoMaximo.Name = "seDescuentoMaximo";
            this.seDescuentoMaximo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seDescuentoMaximo.Size = new System.Drawing.Size(100, 20);
            this.seDescuentoMaximo.TabIndex = 5;
            // 
            // seMargenMinimo
            // 
            this.seMargenMinimo.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seMargenMinimo.Location = new System.Drawing.Point(199, 73);
            this.seMargenMinimo.Name = "seMargenMinimo";
            this.seMargenMinimo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seMargenMinimo.Size = new System.Drawing.Size(100, 20);
            this.seMargenMinimo.TabIndex = 6;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(199, 54);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(82, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Margen Minímo";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(199, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(97, 13);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Descuento máximo";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(305, 28);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(138, 23);
            this.btnActualizar.TabIndex = 9;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // ckMargenMinimo
            // 
            this.ckMargenMinimo.Location = new System.Drawing.Point(305, 73);
            this.ckMargenMinimo.Name = "ckMargenMinimo";
            this.ckMargenMinimo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ckMargenMinimo.Size = new System.Drawing.Size(138, 20);
            this.ckMargenMinimo.TabIndex = 10;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(305, 54);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(82, 13);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "Margen Minímo";
            // 
            // FrmBloqueoDeMargen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 395);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.ckMargenMinimo);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.seMargenMinimo);
            this.Controls.Add(this.seDescuentoMaximo);
            this.Controls.Add(this.txtProducto);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.gcProductos);
            this.Name = "FrmBloqueoDeMargen";
            this.Text = "Bloqueo de margen";
            this.Shown += new System.EventHandler(this.FrmBloqueoDeMargen_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gcProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProducto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seDescuentoMaximo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seMargenMinimo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckMargenMinimo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcProductos;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProductos;
        private DevExpress.XtraEditors.LabelControl lblCodigo;
        private DevExpress.XtraEditors.TextEdit txtCodigo;
        private DevExpress.XtraEditors.TextEdit txtProducto;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SpinEdit seDescuentoMaximo;
        private DevExpress.XtraEditors.SpinEdit seMargenMinimo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnActualizar;
        private DevExpress.XtraEditors.CheckedComboBoxEdit ckMargenMinimo;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}