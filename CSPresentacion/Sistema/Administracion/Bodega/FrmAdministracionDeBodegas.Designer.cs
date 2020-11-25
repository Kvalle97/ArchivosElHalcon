namespace CSPresentacion.Sistema.Administracion.Bodega
{
    partial class FrmAdministracionDeBodegas
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
            this.gcBodegas = new DevExpress.XtraGrid.GridControl();
            this.gvBodegas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblIdBodega = new DevExpress.XtraEditors.LabelControl();
            this.txtIdBodega = new DevExpress.XtraEditors.TextEdit();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.lblDescripcion = new DevExpress.XtraEditors.LabelControl();
            this.lblComentarios = new DevExpress.XtraEditors.LabelControl();
            this.memoComentarios = new DevExpress.XtraEditors.MemoEdit();
            this.txtCosto = new DevExpress.XtraEditors.TextEdit();
            this.lblCosto = new DevExpress.XtraEditors.LabelControl();
            this.lueEmpresa = new DevExpress.XtraEditors.LookUpEdit();
            this.lblIdEmpresa = new DevExpress.XtraEditors.LabelControl();
            this.ckComboTipoDeSucursal = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.lblTipoBodega = new DevExpress.XtraEditors.LabelControl();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gcBodegas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBodegas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdBodega.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoComentarios.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCosto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueEmpresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckComboTipoDeSucursal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // gcBodegas
            // 
            this.gcBodegas.Location = new System.Drawing.Point(12, 264);
            this.gcBodegas.MainView = this.gvBodegas;
            this.gcBodegas.Name = "gcBodegas";
            this.gcBodegas.Size = new System.Drawing.Size(546, 200);
            this.gcBodegas.TabIndex = 4;
            this.gcBodegas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBodegas});
            // 
            // gvBodegas
            // 
            this.gvBodegas.GridControl = this.gcBodegas;
            this.gvBodegas.Name = "gvBodegas";
            this.gvBodegas.OptionsBehavior.Editable = false;
            this.gvBodegas.OptionsView.ShowGroupPanel = false;
            this.gvBodegas.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gvBodegas_KeyUp);
            this.gvBodegas.DoubleClick += new System.EventHandler(this.gvBodegas_DoubleClick);
            // 
            // lblIdBodega
            // 
            this.lblIdBodega.Location = new System.Drawing.Point(12, 34);
            this.lblIdBodega.Name = "lblIdBodega";
            this.lblIdBodega.Size = new System.Drawing.Size(53, 13);
            this.lblIdBodega.TabIndex = 5;
            this.lblIdBodega.Text = "Id bodega";
            // 
            // txtIdBodega
            // 
            this.txtIdBodega.Location = new System.Drawing.Point(12, 53);
            this.txtIdBodega.Name = "txtIdBodega";
            this.txtIdBodega.Properties.MaxLength = 2;
            this.txtIdBodega.Size = new System.Drawing.Size(157, 20);
            this.txtIdBodega.TabIndex = 6;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(12, 102);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(157, 20);
            this.txtDescripcion.TabIndex = 8;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(12, 83);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(60, 13);
            this.lblDescripcion.TabIndex = 7;
            this.lblDescripcion.Text = "Descripción";
            // 
            // lblComentarios
            // 
            this.lblComentarios.Location = new System.Drawing.Point(12, 128);
            this.lblComentarios.Name = "lblComentarios";
            this.lblComentarios.Size = new System.Drawing.Size(65, 13);
            this.lblComentarios.TabIndex = 9;
            this.lblComentarios.Text = "Comentarios";
            // 
            // memoComentarios
            // 
            this.memoComentarios.Location = new System.Drawing.Point(12, 147);
            this.memoComentarios.Name = "memoComentarios";
            this.memoComentarios.Size = new System.Drawing.Size(157, 96);
            this.memoComentarios.TabIndex = 10;
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(175, 53);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(157, 20);
            this.txtCosto.TabIndex = 12;
            // 
            // lblCosto
            // 
            this.lblCosto.Location = new System.Drawing.Point(175, 34);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(84, 13);
            this.lblCosto.TabIndex = 11;
            this.lblCosto.Text = "Cuenta de costo";
            // 
            // lueEmpresa
            // 
            this.lueEmpresa.Location = new System.Drawing.Point(175, 102);
            this.lueEmpresa.Name = "lueEmpresa";
            this.lueEmpresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueEmpresa.Size = new System.Drawing.Size(157, 20);
            this.lueEmpresa.TabIndex = 13;
            // 
            // lblIdEmpresa
            // 
            this.lblIdEmpresa.Location = new System.Drawing.Point(175, 83);
            this.lblIdEmpresa.Name = "lblIdEmpresa";
            this.lblIdEmpresa.Size = new System.Drawing.Size(43, 13);
            this.lblIdEmpresa.TabIndex = 14;
            this.lblIdEmpresa.Text = "Sucursal";
            // 
            // ckComboTipoDeSucursal
            // 
            this.ckComboTipoDeSucursal.Location = new System.Drawing.Point(175, 145);
            this.ckComboTipoDeSucursal.Name = "ckComboTipoDeSucursal";
            this.ckComboTipoDeSucursal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ckComboTipoDeSucursal.Size = new System.Drawing.Size(157, 20);
            this.ckComboTipoDeSucursal.TabIndex = 15;
            // 
            // lblTipoBodega
            // 
            this.lblTipoBodega.Location = new System.Drawing.Point(175, 128);
            this.lblTipoBodega.Name = "lblTipoBodega";
            this.lblTipoBodega.Size = new System.Drawing.Size(82, 13);
            this.lblTipoBodega.TabIndex = 16;
            this.lblTipoBodega.Text = "Tipo de bodega";
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // FrmAdministracionDeBodegas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 476);
            this.Controls.Add(this.lblTipoBodega);
            this.Controls.Add(this.ckComboTipoDeSucursal);
            this.Controls.Add(this.lblIdEmpresa);
            this.Controls.Add(this.lueEmpresa);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.lblCosto);
            this.Controls.Add(this.memoComentarios);
            this.Controls.Add(this.lblComentarios);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtIdBodega);
            this.Controls.Add(this.lblIdBodega);
            this.Controls.Add(this.gcBodegas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAdministracionDeBodegas";
            this.Text = "Administración de bodegas";
            this.Shown += new System.EventHandler(this.FrmAdministracionDeBodegas_Shown);
            this.Controls.SetChildIndex(this.gcBodegas, 0);
            this.Controls.SetChildIndex(this.lblIdBodega, 0);
            this.Controls.SetChildIndex(this.txtIdBodega, 0);
            this.Controls.SetChildIndex(this.lblDescripcion, 0);
            this.Controls.SetChildIndex(this.txtDescripcion, 0);
            this.Controls.SetChildIndex(this.lblComentarios, 0);
            this.Controls.SetChildIndex(this.memoComentarios, 0);
            this.Controls.SetChildIndex(this.lblCosto, 0);
            this.Controls.SetChildIndex(this.txtCosto, 0);
            this.Controls.SetChildIndex(this.lueEmpresa, 0);
            this.Controls.SetChildIndex(this.lblIdEmpresa, 0);
            this.Controls.SetChildIndex(this.ckComboTipoDeSucursal, 0);
            this.Controls.SetChildIndex(this.lblTipoBodega, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gcBodegas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBodegas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdBodega.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoComentarios.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCosto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueEmpresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckComboTipoDeSucursal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcBodegas;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBodegas;
        private DevExpress.XtraEditors.LabelControl lblIdBodega;
        private DevExpress.XtraEditors.TextEdit txtIdBodega;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.LabelControl lblDescripcion;
        private DevExpress.XtraEditors.LabelControl lblComentarios;
        private DevExpress.XtraEditors.MemoEdit memoComentarios;
        private DevExpress.XtraEditors.TextEdit txtCosto;
        private DevExpress.XtraEditors.LabelControl lblCosto;
        private DevExpress.XtraEditors.LookUpEdit lueEmpresa;
        private DevExpress.XtraEditors.LabelControl lblIdEmpresa;
        private DevExpress.XtraEditors.CheckedComboBoxEdit ckComboTipoDeSucursal;
        private DevExpress.XtraEditors.LabelControl lblTipoBodega;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
    }
}