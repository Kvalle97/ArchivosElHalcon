namespace CSPresentacion.Sistema.Administracion
{
    partial class FrmUsuarios
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
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.tabControlUsuario = new DevExpress.XtraTab.XtraTabControl();
            this.tpDatosGenerales = new DevExpress.XtraTab.XtraTabPage();
            this.ckbActivo = new DevExpress.XtraEditors.CheckEdit();
            this.ckComboRoles = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.lueNievelDeAcceso = new DevExpress.XtraEditors.LookUpEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.lueSucursalDeOrigen = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTelefono = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtApellidos = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtNombres = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtUsuario = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tpOpcionesGenerales = new DevExpress.XtraTab.XtraTabPage();
            this.seDescuentoMaximo = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.seNumeroDeDescuento = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.checkEdit9 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit10 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit5 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit6 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit7 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit8 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit3 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit4 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.tpCorreos = new DevExpress.XtraTab.XtraTabPage();
            this.tpCambioDeContrasenia = new DevExpress.XtraTab.XtraTabPage();
            this.gcUsuarios = new DevExpress.XtraGrid.GridControl();
            this.gvUsuarios = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraScrollableControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlUsuario)).BeginInit();
            this.tabControlUsuario.SuspendLayout();
            this.tpDatosGenerales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckbActivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckComboRoles.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueNievelDeAcceso.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSucursalDeOrigen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefono.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApellidos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombres.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).BeginInit();
            this.tpOpcionesGenerales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seDescuentoMaximo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seNumeroDeDescuento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit9.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit10.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit7.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit8.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Controls.Add(this.tabControlUsuario);
            this.xtraScrollableControl1.Controls.Add(this.gcUsuarios);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 28);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(1137, 469);
            this.xtraScrollableControl1.TabIndex = 4;
            // 
            // tabControlUsuario
            // 
            this.tabControlUsuario.Location = new System.Drawing.Point(3, 6);
            this.tabControlUsuario.Name = "tabControlUsuario";
            this.tabControlUsuario.SelectedTabPage = this.tpDatosGenerales;
            this.tabControlUsuario.Size = new System.Drawing.Size(522, 451);
            this.tabControlUsuario.TabIndex = 1;
            this.tabControlUsuario.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpDatosGenerales,
            this.tpOpcionesGenerales,
            this.tpCorreos,
            this.tpCambioDeContrasenia});
            // 
            // tpDatosGenerales
            // 
            this.tpDatosGenerales.Controls.Add(this.ckbActivo);
            this.tpDatosGenerales.Controls.Add(this.ckComboRoles);
            this.tpDatosGenerales.Controls.Add(this.label3);
            this.tpDatosGenerales.Controls.Add(this.lueNievelDeAcceso);
            this.tpDatosGenerales.Controls.Add(this.label2);
            this.tpDatosGenerales.Controls.Add(this.lueSucursalDeOrigen);
            this.tpDatosGenerales.Controls.Add(this.label1);
            this.tpDatosGenerales.Controls.Add(this.txtTelefono);
            this.tpDatosGenerales.Controls.Add(this.labelControl4);
            this.tpDatosGenerales.Controls.Add(this.txtApellidos);
            this.tpDatosGenerales.Controls.Add(this.labelControl3);
            this.tpDatosGenerales.Controls.Add(this.txtNombres);
            this.tpDatosGenerales.Controls.Add(this.labelControl2);
            this.tpDatosGenerales.Controls.Add(this.txtUsuario);
            this.tpDatosGenerales.Controls.Add(this.labelControl1);
            this.tpDatosGenerales.Name = "tpDatosGenerales";
            this.tpDatosGenerales.Size = new System.Drawing.Size(520, 422);
            this.tpDatosGenerales.Text = "Datos genrales";
            // 
            // ckbActivo
            // 
            this.ckbActivo.Location = new System.Drawing.Point(245, 173);
            this.ckbActivo.Name = "ckbActivo";
            this.ckbActivo.Properties.Caption = "Activo";
            this.ckbActivo.Size = new System.Drawing.Size(75, 20);
            this.ckbActivo.TabIndex = 14;
            // 
            // ckComboRoles
            // 
            this.ckComboRoles.Location = new System.Drawing.Point(17, 173);
            this.ckComboRoles.Name = "ckComboRoles";
            this.ckComboRoles.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ckComboRoles.Size = new System.Drawing.Size(179, 20);
            this.ckComboRoles.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Roles del usuario";
            // 
            // lueNievelDeAcceso
            // 
            this.lueNievelDeAcceso.Location = new System.Drawing.Point(245, 128);
            this.lueNievelDeAcceso.Name = "lueNievelDeAcceso";
            this.lueNievelDeAcceso.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueNievelDeAcceso.Size = new System.Drawing.Size(179, 20);
            this.lueNievelDeAcceso.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(242, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nivel de acceso";
            // 
            // lueSucursalDeOrigen
            // 
            this.lueSucursalDeOrigen.Location = new System.Drawing.Point(245, 32);
            this.lueSucursalDeOrigen.Name = "lueSucursalDeOrigen";
            this.lueSucursalDeOrigen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSucursalDeOrigen.Size = new System.Drawing.Size(179, 20);
            this.lueSucursalDeOrigen.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(242, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Sucursal de origen";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(245, 78);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(179, 20);
            this.txtTelefono.TabIndex = 7;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(245, 58);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(46, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Telefóno";
            // 
            // txtApellidos
            // 
            this.txtApellidos.Location = new System.Drawing.Point(17, 128);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(179, 20);
            this.txtApellidos.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(17, 108);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Apellidos";
            // 
            // txtNombres
            // 
            this.txtNombres.Location = new System.Drawing.Point(17, 78);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(179, 20);
            this.txtNombres.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(17, 58);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Nombres";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(17, 32);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(179, 20);
            this.txtUsuario.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(17, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Usuario";
            // 
            // tpOpcionesGenerales
            // 
            this.tpOpcionesGenerales.Controls.Add(this.seDescuentoMaximo);
            this.tpOpcionesGenerales.Controls.Add(this.labelControl6);
            this.tpOpcionesGenerales.Controls.Add(this.seNumeroDeDescuento);
            this.tpOpcionesGenerales.Controls.Add(this.labelControl5);
            this.tpOpcionesGenerales.Controls.Add(this.checkEdit9);
            this.tpOpcionesGenerales.Controls.Add(this.checkEdit10);
            this.tpOpcionesGenerales.Controls.Add(this.checkEdit5);
            this.tpOpcionesGenerales.Controls.Add(this.checkEdit6);
            this.tpOpcionesGenerales.Controls.Add(this.checkEdit7);
            this.tpOpcionesGenerales.Controls.Add(this.checkEdit8);
            this.tpOpcionesGenerales.Controls.Add(this.checkEdit3);
            this.tpOpcionesGenerales.Controls.Add(this.checkEdit4);
            this.tpOpcionesGenerales.Controls.Add(this.checkEdit2);
            this.tpOpcionesGenerales.Controls.Add(this.checkEdit1);
            this.tpOpcionesGenerales.Name = "tpOpcionesGenerales";
            this.tpOpcionesGenerales.Size = new System.Drawing.Size(520, 422);
            this.tpOpcionesGenerales.Text = "Opciones Generales";
            // 
            // seDescuentoMaximo
            // 
            this.seDescuentoMaximo.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seDescuentoMaximo.Location = new System.Drawing.Point(139, 118);
            this.seDescuentoMaximo.Name = "seDescuentoMaximo";
            this.seDescuentoMaximo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seDescuentoMaximo.Size = new System.Drawing.Size(114, 20);
            this.seDescuentoMaximo.TabIndex = 13;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(139, 98);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(97, 13);
            this.labelControl6.TabIndex = 12;
            this.labelControl6.Text = "Descuento máximo";
            // 
            // seNumeroDeDescuento
            // 
            this.seNumeroDeDescuento.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seNumeroDeDescuento.Location = new System.Drawing.Point(8, 118);
            this.seNumeroDeDescuento.Name = "seNumeroDeDescuento";
            this.seNumeroDeDescuento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seNumeroDeDescuento.Size = new System.Drawing.Size(114, 20);
            this.seNumeroDeDescuento.TabIndex = 11;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(8, 98);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(114, 13);
            this.labelControl5.TabIndex = 10;
            this.labelControl5.Text = "Número de descuento";
            // 
            // checkEdit9
            // 
            this.checkEdit9.Location = new System.Drawing.Point(389, 56);
            this.checkEdit9.Name = "checkEdit9";
            this.checkEdit9.Properties.Caption = "Proyecto";
            this.checkEdit9.Size = new System.Drawing.Size(99, 20);
            this.checkEdit9.TabIndex = 9;
            // 
            // checkEdit10
            // 
            this.checkEdit10.Location = new System.Drawing.Point(389, 19);
            this.checkEdit10.Name = "checkEdit10";
            this.checkEdit10.Properties.Caption = "Cartera";
            this.checkEdit10.Size = new System.Drawing.Size(99, 20);
            this.checkEdit10.TabIndex = 8;
            // 
            // checkEdit5
            // 
            this.checkEdit5.Location = new System.Drawing.Point(284, 56);
            this.checkEdit5.Name = "checkEdit5";
            this.checkEdit5.Properties.Caption = "Proveedores";
            this.checkEdit5.Size = new System.Drawing.Size(99, 20);
            this.checkEdit5.TabIndex = 7;
            // 
            // checkEdit6
            // 
            this.checkEdit6.Location = new System.Drawing.Point(284, 19);
            this.checkEdit6.Name = "checkEdit6";
            this.checkEdit6.Properties.Caption = "Producción";
            this.checkEdit6.Size = new System.Drawing.Size(99, 20);
            this.checkEdit6.TabIndex = 6;
            // 
            // checkEdit7
            // 
            this.checkEdit7.Location = new System.Drawing.Point(179, 56);
            this.checkEdit7.Name = "checkEdit7";
            this.checkEdit7.Properties.Caption = "Administración";
            this.checkEdit7.Size = new System.Drawing.Size(99, 20);
            this.checkEdit7.TabIndex = 5;
            // 
            // checkEdit8
            // 
            this.checkEdit8.Location = new System.Drawing.Point(179, 19);
            this.checkEdit8.Name = "checkEdit8";
            this.checkEdit8.Properties.Caption = "Compras";
            this.checkEdit8.Size = new System.Drawing.Size(99, 20);
            this.checkEdit8.TabIndex = 4;
            // 
            // checkEdit3
            // 
            this.checkEdit3.Location = new System.Drawing.Point(89, 56);
            this.checkEdit3.Name = "checkEdit3";
            this.checkEdit3.Properties.Caption = "Bancos";
            this.checkEdit3.Size = new System.Drawing.Size(75, 20);
            this.checkEdit3.TabIndex = 3;
            // 
            // checkEdit4
            // 
            this.checkEdit4.Location = new System.Drawing.Point(89, 19);
            this.checkEdit4.Name = "checkEdit4";
            this.checkEdit4.Properties.Caption = "Inventario";
            this.checkEdit4.Size = new System.Drawing.Size(75, 20);
            this.checkEdit4.TabIndex = 2;
            // 
            // checkEdit2
            // 
            this.checkEdit2.Location = new System.Drawing.Point(8, 56);
            this.checkEdit2.Name = "checkEdit2";
            this.checkEdit2.Properties.Caption = "Caja";
            this.checkEdit2.Size = new System.Drawing.Size(75, 20);
            this.checkEdit2.TabIndex = 1;
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(8, 19);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Ventas";
            this.checkEdit1.Size = new System.Drawing.Size(75, 20);
            this.checkEdit1.TabIndex = 0;
            // 
            // tpCorreos
            // 
            this.tpCorreos.Name = "tpCorreos";
            this.tpCorreos.Size = new System.Drawing.Size(520, 422);
            this.tpCorreos.Text = "Correos";
            // 
            // tpCambioDeContrasenia
            // 
            this.tpCambioDeContrasenia.Name = "tpCambioDeContrasenia";
            this.tpCambioDeContrasenia.PageEnabled = false;
            this.tpCambioDeContrasenia.Size = new System.Drawing.Size(520, 422);
            this.tpCambioDeContrasenia.Text = "Cambio de contraseña";
            // 
            // gcUsuarios
            // 
            this.gcUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcUsuarios.Location = new System.Drawing.Point(531, 6);
            this.gcUsuarios.MainView = this.gvUsuarios;
            this.gcUsuarios.Name = "gcUsuarios";
            this.gcUsuarios.Size = new System.Drawing.Size(594, 451);
            this.gcUsuarios.TabIndex = 0;
            this.gcUsuarios.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUsuarios});
            // 
            // gvUsuarios
            // 
            this.gvUsuarios.GridControl = this.gcUsuarios;
            this.gvUsuarios.Name = "gvUsuarios";
            this.gvUsuarios.OptionsBehavior.Editable = false;
            this.gvUsuarios.OptionsCustomization.AllowGroup = false;
            this.gvUsuarios.OptionsView.ShowAutoFilterRow = true;
            this.gvUsuarios.OptionsView.ShowGroupPanel = false;
            this.gvUsuarios.OptionsView.ShowViewCaption = true;
            this.gvUsuarios.ViewCaption = "Usuarios";
            // 
            // FrmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 497);
            this.Controls.Add(this.xtraScrollableControl1);
            this.Name = "FrmUsuarios";
            this.Text = "Usuarios del sistema";
            this.Load += new System.EventHandler(this.FrmUsuarios_Load);
            this.Controls.SetChildIndex(this.xtraScrollableControl1, 0);
            this.xtraScrollableControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControlUsuario)).EndInit();
            this.tabControlUsuario.ResumeLayout(false);
            this.tpDatosGenerales.ResumeLayout(false);
            this.tpDatosGenerales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckbActivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckComboRoles.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueNievelDeAcceso.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSucursalDeOrigen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefono.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApellidos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombres.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).EndInit();
            this.tpOpcionesGenerales.ResumeLayout(false);
            this.tpOpcionesGenerales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seDescuentoMaximo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seNumeroDeDescuento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit9.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit10.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit7.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit8.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private DevExpress.XtraGrid.GridControl gcUsuarios;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUsuarios;
        private DevExpress.XtraTab.XtraTabControl tabControlUsuario;
        private DevExpress.XtraTab.XtraTabPage tpDatosGenerales;
        private DevExpress.XtraTab.XtraTabPage tpOpcionesGenerales;
        private DevExpress.XtraTab.XtraTabPage tpCorreos;
        private DevExpress.XtraTab.XtraTabPage tpCambioDeContrasenia;
        private DevExpress.XtraEditors.CheckedComboBoxEdit ckComboRoles;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.LookUpEdit lueNievelDeAcceso;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.LookUpEdit lueSucursalDeOrigen;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtTelefono;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtApellidos;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtNombres;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtUsuario;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit ckbActivo;
        private DevExpress.XtraEditors.CheckEdit checkEdit3;
        private DevExpress.XtraEditors.CheckEdit checkEdit4;
        private DevExpress.XtraEditors.CheckEdit checkEdit2;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.CheckEdit checkEdit9;
        private DevExpress.XtraEditors.CheckEdit checkEdit10;
        private DevExpress.XtraEditors.CheckEdit checkEdit5;
        private DevExpress.XtraEditors.CheckEdit checkEdit6;
        private DevExpress.XtraEditors.CheckEdit checkEdit7;
        private DevExpress.XtraEditors.CheckEdit checkEdit8;
        private DevExpress.XtraEditors.SpinEdit seDescuentoMaximo;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SpinEdit seNumeroDeDescuento;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}