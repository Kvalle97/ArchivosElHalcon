namespace CSPresentacion.Sistema.Administracion
{
    partial class FrmAdministrarSucursales
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
            this.gcEmpresas = new DevExpress.XtraGrid.GridControl();
            this.gvEmpresas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblSucursal = new DevExpress.XtraEditors.LabelControl();
            this.txtSucursal = new DevExpress.XtraEditors.TextEdit();
            this.txtSlogan = new DevExpress.XtraEditors.TextEdit();
            this.lblSologan = new DevExpress.XtraEditors.LabelControl();
            this.memoDireccion = new DevExpress.XtraEditors.MemoEdit();
            this.lblDireccion = new DevExpress.XtraEditors.LabelControl();
            this.tabSucursal = new DevExpress.XtraTab.XtraTabControl();
            this.tabOtrosAtributos = new DevExpress.XtraTab.XtraTabPage();
            this.txtNombreCorto = new DevExpress.XtraEditors.TextEdit();
            this.lblNombreCorto = new DevExpress.XtraEditors.LabelControl();
            this.txtNombre = new DevExpress.XtraEditors.TextEdit();
            this.lblNombre = new DevExpress.XtraEditors.LabelControl();
            this.seIva = new DevExpress.XtraEditors.SpinEdit();
            this.lblIva = new DevExpress.XtraEditors.LabelControl();
            this.txtWebSite = new DevExpress.XtraEditors.TextEdit();
            this.lblWebSite = new DevExpress.XtraEditors.LabelControl();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.lblEmail = new DevExpress.XtraEditors.LabelControl();
            this.txtFax = new DevExpress.XtraEditors.TextEdit();
            this.lblFax = new DevExpress.XtraEditors.LabelControl();
            this.txtTelefonos = new DevExpress.XtraEditors.TextEdit();
            this.lblTelefonos = new DevExpress.XtraEditors.LabelControl();
            this.txtOficina = new DevExpress.XtraEditors.TextEdit();
            this.lblOficina = new DevExpress.XtraEditors.LabelControl();
            this.tabCuentas = new DevExpress.XtraTab.XtraTabPage();
            this.gcCuentas = new DevExpress.XtraGrid.GridControl();
            this.gvCuentas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lueTipoDeSucursal = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.seSucursalId = new DevExpress.XtraEditors.SpinEdit();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gcEmpresas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEmpresas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSucursal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSlogan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoDireccion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabSucursal)).BeginInit();
            this.tabSucursal.SuspendLayout();
            this.tabOtrosAtributos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreCorto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seIva.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWebSite.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefonos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOficina.Properties)).BeginInit();
            this.tabCuentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcCuentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCuentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTipoDeSucursal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seSucursalId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // gcEmpresas
            // 
            this.gcEmpresas.Location = new System.Drawing.Point(12, 318);
            this.gcEmpresas.MainView = this.gvEmpresas;
            this.gcEmpresas.Name = "gcEmpresas";
            this.gcEmpresas.Size = new System.Drawing.Size(527, 141);
            this.gcEmpresas.TabIndex = 4;
            this.gcEmpresas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEmpresas});
            // 
            // gvEmpresas
            // 
            this.gvEmpresas.GridControl = this.gcEmpresas;
            this.gvEmpresas.Name = "gvEmpresas";
            this.gvEmpresas.OptionsBehavior.Editable = false;
            this.gvEmpresas.OptionsView.ShowGroupPanel = false;
            this.gvEmpresas.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gvEmpresas_KeyUp);
            this.gvEmpresas.DoubleClick += new System.EventHandler(this.gvEmpresas_DoubleClick);
            // 
            // lblSucursal
            // 
            this.lblSucursal.Location = new System.Drawing.Point(13, 91);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(43, 13);
            this.lblSucursal.TabIndex = 5;
            this.lblSucursal.Text = "Sucursal";
            // 
            // txtSucursal
            // 
            this.txtSucursal.Location = new System.Drawing.Point(13, 110);
            this.txtSucursal.Name = "txtSucursal";
            this.txtSucursal.Size = new System.Drawing.Size(181, 20);
            this.txtSucursal.TabIndex = 6;
            // 
            // txtSlogan
            // 
            this.txtSlogan.Location = new System.Drawing.Point(13, 155);
            this.txtSlogan.Name = "txtSlogan";
            this.txtSlogan.Size = new System.Drawing.Size(181, 20);
            this.txtSlogan.TabIndex = 8;
            // 
            // lblSologan
            // 
            this.lblSologan.Location = new System.Drawing.Point(13, 136);
            this.lblSologan.Name = "lblSologan";
            this.lblSologan.Size = new System.Drawing.Size(36, 13);
            this.lblSologan.TabIndex = 7;
            this.lblSologan.Text = "Slogan";
            // 
            // memoDireccion
            // 
            this.memoDireccion.Location = new System.Drawing.Point(13, 241);
            this.memoDireccion.Name = "memoDireccion";
            this.memoDireccion.Size = new System.Drawing.Size(181, 77);
            this.memoDireccion.TabIndex = 9;
            // 
            // lblDireccion
            // 
            this.lblDireccion.Location = new System.Drawing.Point(13, 222);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(48, 13);
            this.lblDireccion.TabIndex = 10;
            this.lblDireccion.Text = "Dirección";
            // 
            // tabSucursal
            // 
            this.tabSucursal.Location = new System.Drawing.Point(199, 45);
            this.tabSucursal.Name = "tabSucursal";
            this.tabSucursal.SelectedTabPage = this.tabOtrosAtributos;
            this.tabSucursal.Size = new System.Drawing.Size(337, 267);
            this.tabSucursal.TabIndex = 11;
            this.tabSucursal.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabOtrosAtributos,
            this.tabCuentas});
            // 
            // tabOtrosAtributos
            // 
            this.tabOtrosAtributos.Controls.Add(this.txtNombreCorto);
            this.tabOtrosAtributos.Controls.Add(this.lblNombreCorto);
            this.tabOtrosAtributos.Controls.Add(this.txtNombre);
            this.tabOtrosAtributos.Controls.Add(this.lblNombre);
            this.tabOtrosAtributos.Controls.Add(this.seIva);
            this.tabOtrosAtributos.Controls.Add(this.lblIva);
            this.tabOtrosAtributos.Controls.Add(this.txtWebSite);
            this.tabOtrosAtributos.Controls.Add(this.lblWebSite);
            this.tabOtrosAtributos.Controls.Add(this.txtEmail);
            this.tabOtrosAtributos.Controls.Add(this.lblEmail);
            this.tabOtrosAtributos.Controls.Add(this.txtFax);
            this.tabOtrosAtributos.Controls.Add(this.lblFax);
            this.tabOtrosAtributos.Controls.Add(this.txtTelefonos);
            this.tabOtrosAtributos.Controls.Add(this.lblTelefonos);
            this.tabOtrosAtributos.Controls.Add(this.txtOficina);
            this.tabOtrosAtributos.Controls.Add(this.lblOficina);
            this.tabOtrosAtributos.Name = "tabOtrosAtributos";
            this.tabOtrosAtributos.Size = new System.Drawing.Size(335, 238);
            this.tabOtrosAtributos.Text = "Otros atributos";
            // 
            // txtNombreCorto
            // 
            this.txtNombreCorto.Location = new System.Drawing.Point(177, 179);
            this.txtNombreCorto.Name = "txtNombreCorto";
            this.txtNombreCorto.Size = new System.Drawing.Size(140, 20);
            this.txtNombreCorto.TabIndex = 22;
            // 
            // lblNombreCorto
            // 
            this.lblNombreCorto.Location = new System.Drawing.Point(177, 160);
            this.lblNombreCorto.Name = "lblNombreCorto";
            this.lblNombreCorto.Size = new System.Drawing.Size(71, 13);
            this.lblNombreCorto.TabIndex = 21;
            this.lblNombreCorto.Text = "Nombre corto";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(17, 179);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(140, 20);
            this.txtNombre.TabIndex = 20;
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(17, 160);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(41, 13);
            this.lblNombre.TabIndex = 19;
            this.lblNombre.Text = "Nombre";
            // 
            // seIva
            // 
            this.seIva.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seIva.Location = new System.Drawing.Point(177, 129);
            this.seIva.Name = "seIva";
            this.seIva.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seIva.Size = new System.Drawing.Size(140, 20);
            this.seIva.TabIndex = 18;
            // 
            // lblIva
            // 
            this.lblIva.Location = new System.Drawing.Point(177, 110);
            this.lblIva.Name = "lblIva";
            this.lblIva.Size = new System.Drawing.Size(14, 13);
            this.lblIva.TabIndex = 17;
            this.lblIva.Text = "Iva";
            // 
            // txtWebSite
            // 
            this.txtWebSite.Location = new System.Drawing.Point(17, 129);
            this.txtWebSite.Name = "txtWebSite";
            this.txtWebSite.Size = new System.Drawing.Size(140, 20);
            this.txtWebSite.TabIndex = 16;
            // 
            // lblWebSite
            // 
            this.lblWebSite.Location = new System.Drawing.Point(17, 110);
            this.lblWebSite.Name = "lblWebSite";
            this.lblWebSite.Size = new System.Drawing.Size(43, 13);
            this.lblWebSite.TabIndex = 15;
            this.lblWebSite.Text = "WebSite";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(177, 81);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(140, 20);
            this.txtEmail.TabIndex = 14;
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(177, 62);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(27, 13);
            this.lblEmail.TabIndex = 13;
            this.lblEmail.Text = "Email";
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(17, 81);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(140, 20);
            this.txtFax.TabIndex = 12;
            // 
            // lblFax
            // 
            this.lblFax.Location = new System.Drawing.Point(17, 62);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(17, 13);
            this.lblFax.TabIndex = 11;
            this.lblFax.Text = "Fax";
            // 
            // txtTelefonos
            // 
            this.txtTelefonos.Location = new System.Drawing.Point(177, 37);
            this.txtTelefonos.Name = "txtTelefonos";
            this.txtTelefonos.Size = new System.Drawing.Size(140, 20);
            this.txtTelefonos.TabIndex = 10;
            // 
            // lblTelefonos
            // 
            this.lblTelefonos.Location = new System.Drawing.Point(177, 18);
            this.lblTelefonos.Name = "lblTelefonos";
            this.lblTelefonos.Size = new System.Drawing.Size(51, 13);
            this.lblTelefonos.TabIndex = 9;
            this.lblTelefonos.Text = "Télefonos";
            // 
            // txtOficina
            // 
            this.txtOficina.Location = new System.Drawing.Point(17, 37);
            this.txtOficina.Name = "txtOficina";
            this.txtOficina.Size = new System.Drawing.Size(140, 20);
            this.txtOficina.TabIndex = 8;
            // 
            // lblOficina
            // 
            this.lblOficina.Location = new System.Drawing.Point(17, 18);
            this.lblOficina.Name = "lblOficina";
            this.lblOficina.Size = new System.Drawing.Size(37, 13);
            this.lblOficina.TabIndex = 7;
            this.lblOficina.Text = "Oficina";
            // 
            // tabCuentas
            // 
            this.tabCuentas.Controls.Add(this.gcCuentas);
            this.tabCuentas.Name = "tabCuentas";
            this.tabCuentas.PageEnabled = false;
            this.tabCuentas.Size = new System.Drawing.Size(335, 238);
            this.tabCuentas.Text = "Cuentas";
            // 
            // gcCuentas
            // 
            this.gcCuentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCuentas.Location = new System.Drawing.Point(0, 0);
            this.gcCuentas.MainView = this.gvCuentas;
            this.gcCuentas.Name = "gcCuentas";
            this.gcCuentas.Size = new System.Drawing.Size(335, 238);
            this.gcCuentas.TabIndex = 0;
            this.gcCuentas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCuentas});
            // 
            // gvCuentas
            // 
            this.gvCuentas.GridControl = this.gcCuentas;
            this.gvCuentas.Name = "gvCuentas";
            this.gvCuentas.OptionsView.ShowGroupPanel = false;
            this.gvCuentas.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvCuentas_CellValueChanged);
            // 
            // lueTipoDeSucursal
            // 
            this.lueTipoDeSucursal.Location = new System.Drawing.Point(13, 200);
            this.lueTipoDeSucursal.Name = "lueTipoDeSucursal";
            this.lueTipoDeSucursal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTipoDeSucursal.Size = new System.Drawing.Size(181, 20);
            this.lueTipoDeSucursal.TabIndex = 12;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 181);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(84, 13);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "Tipo de sucursal";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 46);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(43, 13);
            this.labelControl2.TabIndex = 14;
            this.labelControl2.Text = "Sucursal";
            // 
            // seSucursalId
            // 
            this.seSucursalId.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seSucursalId.Location = new System.Drawing.Point(13, 65);
            this.seSucursalId.Name = "seSucursalId";
            this.seSucursalId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seSucursalId.Properties.Mask.EditMask = "d";
            this.seSucursalId.Size = new System.Drawing.Size(181, 20);
            this.seSucursalId.TabIndex = 19;
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // FrmAdministrarSucursales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 471);
            this.Controls.Add(this.seSucursalId);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lueTipoDeSucursal);
            this.Controls.Add(this.tabSucursal);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.memoDireccion);
            this.Controls.Add(this.txtSlogan);
            this.Controls.Add(this.lblSologan);
            this.Controls.Add(this.txtSucursal);
            this.Controls.Add(this.lblSucursal);
            this.Controls.Add(this.gcEmpresas);
            this.Name = "FrmAdministrarSucursales";
            this.Text = "Sucursales";
            this.Shown += new System.EventHandler(this.FrmAdministrarSucursales_Shown);
            this.Controls.SetChildIndex(this.gcEmpresas, 0);
            this.Controls.SetChildIndex(this.lblSucursal, 0);
            this.Controls.SetChildIndex(this.txtSucursal, 0);
            this.Controls.SetChildIndex(this.lblSologan, 0);
            this.Controls.SetChildIndex(this.txtSlogan, 0);
            this.Controls.SetChildIndex(this.memoDireccion, 0);
            this.Controls.SetChildIndex(this.lblDireccion, 0);
            this.Controls.SetChildIndex(this.tabSucursal, 0);
            this.Controls.SetChildIndex(this.lueTipoDeSucursal, 0);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.labelControl2, 0);
            this.Controls.SetChildIndex(this.seSucursalId, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gcEmpresas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEmpresas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSucursal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSlogan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoDireccion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabSucursal)).EndInit();
            this.tabSucursal.ResumeLayout(false);
            this.tabOtrosAtributos.ResumeLayout(false);
            this.tabOtrosAtributos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreCorto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seIva.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWebSite.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefonos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOficina.Properties)).EndInit();
            this.tabCuentas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcCuentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCuentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTipoDeSucursal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seSucursalId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcEmpresas;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEmpresas;
        private DevExpress.XtraEditors.LabelControl lblSucursal;
        private DevExpress.XtraEditors.TextEdit txtSucursal;
        private DevExpress.XtraEditors.TextEdit txtSlogan;
        private DevExpress.XtraEditors.LabelControl lblSologan;
        private DevExpress.XtraEditors.MemoEdit memoDireccion;
        private DevExpress.XtraEditors.LabelControl lblDireccion;
        private DevExpress.XtraTab.XtraTabControl tabSucursal;
        private DevExpress.XtraTab.XtraTabPage tabOtrosAtributos;
        private DevExpress.XtraTab.XtraTabPage tabCuentas;
        private DevExpress.XtraEditors.TextEdit txtTelefonos;
        private DevExpress.XtraEditors.LabelControl lblTelefonos;
        private DevExpress.XtraEditors.TextEdit txtOficina;
        private DevExpress.XtraEditors.LabelControl lblOficina;
        private DevExpress.XtraEditors.SpinEdit seIva;
        private DevExpress.XtraEditors.LabelControl lblIva;
        private DevExpress.XtraEditors.TextEdit txtWebSite;
        private DevExpress.XtraEditors.LabelControl lblWebSite;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.LabelControl lblEmail;
        private DevExpress.XtraEditors.TextEdit txtFax;
        private DevExpress.XtraEditors.LabelControl lblFax;
        private DevExpress.XtraEditors.TextEdit txtNombreCorto;
        private DevExpress.XtraEditors.LabelControl lblNombreCorto;
        private DevExpress.XtraEditors.TextEdit txtNombre;
        private DevExpress.XtraEditors.LabelControl lblNombre;
        private DevExpress.XtraGrid.GridControl gcCuentas;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCuentas;
        private DevExpress.XtraEditors.LookUpEdit lueTipoDeSucursal;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SpinEdit seSucursalId;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
    }
}