
namespace CSPresentacion.Sistema.Administracion
{
    partial class FrmUsuarioCajaChica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsuarioCajaChica));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.ckactivo = new DevExpress.XtraEditors.CheckEdit();
            this.ckComboGasto = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.btnEliminarCaja = new DevExpress.XtraEditors.SimpleButton();
            this.btnAgregarCaja = new DevExpress.XtraEditors.SimpleButton();
            this.txtDescripcionCaja = new DevExpress.XtraEditors.TextEdit();
            this.luEmpresa = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gccaja = new DevExpress.XtraGrid.GridControl();
            this.gvCajas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.DescripcionCajaChica = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Empresa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IdCajaChica = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.ckactivo1 = new DevExpress.XtraEditors.CheckEdit();
            this.btnEliminarUsu = new DevExpress.XtraEditors.SimpleButton();
            this.btnAgregarUsu = new DevExpress.XtraEditors.SimpleButton();
            this.luusuario = new DevExpress.XtraEditors.LookUpEdit();
            this.luempresaUsuario = new DevExpress.XtraEditors.LookUpEdit();
            this.lucajac = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.gcusuarios = new DevExpress.XtraGrid.GridControl();
            this.gvusuarios = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Usuarios = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Nombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IdCaja = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DescripcionCaja = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EmpresaUsuario = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckactivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckComboGasto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcionCaja.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luEmpresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gccaja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCajas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckactivo1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luusuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luempresaUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lucajac.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcusuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvusuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.ckactivo);
            this.groupControl1.Controls.Add(this.ckComboGasto);
            this.groupControl1.Controls.Add(this.btnEliminarCaja);
            this.groupControl1.Controls.Add(this.btnAgregarCaja);
            this.groupControl1.Controls.Add(this.txtDescripcionCaja);
            this.groupControl1.Controls.Add(this.luEmpresa);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(3, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(378, 150);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Agregar o Eliminar Caja Chica";
            // 
            // ckactivo
            // 
            this.ckactivo.Location = new System.Drawing.Point(33, 114);
            this.ckactivo.Name = "ckactivo";
            this.ckactivo.Properties.Appearance.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold);
            this.ckactivo.Properties.Appearance.Options.UseFont = true;
            this.ckactivo.Properties.Caption = "Activo";
            this.ckactivo.Size = new System.Drawing.Size(88, 20);
            this.ckactivo.TabIndex = 5;
            // 
            // ckComboGasto
            // 
            this.ckComboGasto.Location = new System.Drawing.Point(169, 55);
            this.ckComboGasto.Name = "ckComboGasto";
            this.ckComboGasto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ckComboGasto.Size = new System.Drawing.Size(189, 20);
            this.ckComboGasto.TabIndex = 4;
            // 
            // btnEliminarCaja
            // 
            this.btnEliminarCaja.Appearance.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarCaja.Appearance.Options.UseFont = true;
            this.btnEliminarCaja.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarCaja.ImageOptions.Image")));
            this.btnEliminarCaja.Location = new System.Drawing.Point(283, 111);
            this.btnEliminarCaja.Name = "btnEliminarCaja";
            this.btnEliminarCaja.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarCaja.TabIndex = 3;
            this.btnEliminarCaja.Text = "Eliminar";
            // 
            // btnAgregarCaja
            // 
            this.btnAgregarCaja.Appearance.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarCaja.Appearance.Options.UseFont = true;
            this.btnAgregarCaja.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarCaja.ImageOptions.Image")));
            this.btnAgregarCaja.Location = new System.Drawing.Point(202, 111);
            this.btnAgregarCaja.Name = "btnAgregarCaja";
            this.btnAgregarCaja.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarCaja.TabIndex = 3;
            this.btnAgregarCaja.Text = "Agregar";
            this.btnAgregarCaja.Click += new System.EventHandler(this.btnAgregarCaja_Click);
            // 
            // txtDescripcionCaja
            // 
            this.txtDescripcionCaja.EditValue = "";
            this.txtDescripcionCaja.Location = new System.Drawing.Point(169, 27);
            this.txtDescripcionCaja.Name = "txtDescripcionCaja";
            this.txtDescripcionCaja.Size = new System.Drawing.Size(189, 20);
            this.txtDescripcionCaja.TabIndex = 2;
            // 
            // luEmpresa
            // 
            this.luEmpresa.Location = new System.Drawing.Point(169, 85);
            this.luEmpresa.Name = "luEmpresa";
            this.luEmpresa.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.luEmpresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luEmpresa.Properties.NullText = "";
            this.luEmpresa.Size = new System.Drawing.Size(189, 20);
            this.luEmpresa.TabIndex = 1;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(33, 29);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(110, 15);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Descripcion Caja Chica:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(33, 60);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 15);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Gasto Sucursal:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(33, 92);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(43, 15);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Empresa:";
            // 
            // gccaja
            // 
            this.gccaja.Location = new System.Drawing.Point(387, 6);
            this.gccaja.MainView = this.gvCajas;
            this.gccaja.Name = "gccaja";
            this.gccaja.Size = new System.Drawing.Size(409, 301);
            this.gccaja.TabIndex = 1;
            this.gccaja.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCajas});
            this.gccaja.Click += new System.EventHandler(this.gccaja_Click);
            // 
            // gvCajas
            // 
            this.gvCajas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.DescripcionCajaChica,
            this.Empresa,
            this.IdCajaChica});
            this.gvCajas.CustomizationFormBounds = new System.Drawing.Rectangle(520, 325, 250, 280);
            this.gvCajas.GridControl = this.gccaja;
            this.gvCajas.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", null, "")});
            this.gvCajas.Name = "gvCajas";
            this.gvCajas.OptionsView.ShowGroupPanel = false;
            this.gvCajas.OptionsView.ShowViewCaption = true;
            this.gvCajas.ViewCaption = "Cajas Chicas";
            // 
            // DescripcionCajaChica
            // 
            this.DescripcionCajaChica.Caption = "DescripcionCajaChica";
            this.DescripcionCajaChica.FieldName = "DescripcionCajaChica";
            this.DescripcionCajaChica.Name = "DescripcionCajaChica";
            this.DescripcionCajaChica.OptionsColumn.AllowEdit = false;
            this.DescripcionCajaChica.Visible = true;
            this.DescripcionCajaChica.VisibleIndex = 1;
            this.DescripcionCajaChica.Width = 139;
            // 
            // Empresa
            // 
            this.Empresa.Caption = "Empresa";
            this.Empresa.FieldName = "Empresa";
            this.Empresa.Name = "Empresa";
            this.Empresa.OptionsColumn.AllowEdit = false;
            this.Empresa.Visible = true;
            this.Empresa.VisibleIndex = 2;
            this.Empresa.Width = 168;
            // 
            // IdCajaChica
            // 
            this.IdCajaChica.Caption = "IdCajaChica";
            this.IdCajaChica.FieldName = "IdCajaChica";
            this.IdCajaChica.Name = "IdCajaChica";
            this.IdCajaChica.OptionsColumn.AllowEdit = false;
            this.IdCajaChica.Visible = true;
            this.IdCajaChica.VisibleIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.ckactivo1);
            this.groupControl2.Controls.Add(this.btnEliminarUsu);
            this.groupControl2.Controls.Add(this.btnAgregarUsu);
            this.groupControl2.Controls.Add(this.luusuario);
            this.groupControl2.Controls.Add(this.luempresaUsuario);
            this.groupControl2.Controls.Add(this.lucajac);
            this.groupControl2.Controls.Add(this.labelControl6);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Location = new System.Drawing.Point(3, 158);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(378, 149);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "Agregar Usuario a Caja Chica";
            // 
            // ckactivo1
            // 
            this.ckactivo1.Location = new System.Drawing.Point(33, 125);
            this.ckactivo1.Name = "ckactivo1";
            this.ckactivo1.Properties.Appearance.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold);
            this.ckactivo1.Properties.Appearance.Options.UseFont = true;
            this.ckactivo1.Properties.Caption = "Activo";
            this.ckactivo1.Size = new System.Drawing.Size(88, 20);
            this.ckactivo1.TabIndex = 5;
            // 
            // btnEliminarUsu
            // 
            this.btnEliminarUsu.Appearance.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarUsu.Appearance.Options.UseFont = true;
            this.btnEliminarUsu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarUsu.ImageOptions.Image")));
            this.btnEliminarUsu.Location = new System.Drawing.Point(268, 123);
            this.btnEliminarUsu.Name = "btnEliminarUsu";
            this.btnEliminarUsu.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarUsu.TabIndex = 4;
            this.btnEliminarUsu.Text = "Eliminar";
            // 
            // btnAgregarUsu
            // 
            this.btnAgregarUsu.Appearance.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarUsu.Appearance.Options.UseFont = true;
            this.btnAgregarUsu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarUsu.ImageOptions.Image")));
            this.btnAgregarUsu.Location = new System.Drawing.Point(187, 123);
            this.btnAgregarUsu.Name = "btnAgregarUsu";
            this.btnAgregarUsu.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarUsu.TabIndex = 5;
            this.btnAgregarUsu.Text = "Agregar";
            this.btnAgregarUsu.Click += new System.EventHandler(this.btnAgregarUsu_Click);
            // 
            // luusuario
            // 
            this.luusuario.Location = new System.Drawing.Point(169, 95);
            this.luusuario.Name = "luusuario";
            this.luusuario.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.luusuario.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luusuario.Properties.NullText = "";
            this.luusuario.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.luusuario.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.luusuario.Size = new System.Drawing.Size(174, 20);
            this.luusuario.TabIndex = 1;
            // 
            // luempresaUsuario
            // 
            this.luempresaUsuario.Location = new System.Drawing.Point(169, 63);
            this.luempresaUsuario.Name = "luempresaUsuario";
            this.luempresaUsuario.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.luempresaUsuario.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luempresaUsuario.Properties.NullText = "";
            this.luempresaUsuario.Size = new System.Drawing.Size(174, 20);
            this.luempresaUsuario.TabIndex = 1;
            this.luempresaUsuario.EditValueChanged += new System.EventHandler(this.luempresaUsuario_EditValueChanged);
            // 
            // lucajac
            // 
            this.lucajac.Location = new System.Drawing.Point(169, 33);
            this.lucajac.Name = "lucajac";
            this.lucajac.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lucajac.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lucajac.Properties.NullText = "";
            this.lucajac.Size = new System.Drawing.Size(174, 20);
            this.lucajac.TabIndex = 1;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(5, 66);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(151, 15);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Seleccione Sucursal del Usuario:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(52, 36);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(104, 15);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Seleccione Caja Chica:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(50, 98);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(106, 15);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Seleccione un Usuario:";
            // 
            // gcusuarios
            // 
            this.gcusuarios.Location = new System.Drawing.Point(3, 313);
            this.gcusuarios.MainView = this.gvusuarios;
            this.gcusuarios.Name = "gcusuarios";
            this.gcusuarios.Size = new System.Drawing.Size(793, 227);
            this.gcusuarios.TabIndex = 1;
            this.gcusuarios.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvusuarios});
            // 
            // gvusuarios
            // 
            this.gvusuarios.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Usuarios,
            this.Nombre,
            this.IdCaja,
            this.DescripcionCaja,
            this.EmpresaUsuario});
            this.gvusuarios.GridControl = this.gcusuarios;
            this.gvusuarios.Name = "gvusuarios";
            this.gvusuarios.OptionsView.ShowViewCaption = true;
            this.gvusuarios.ViewCaption = "Usuarios Caja Chica";
            // 
            // Usuarios
            // 
            this.Usuarios.Caption = "Usuarios";
            this.Usuarios.FieldName = "Usuario";
            this.Usuarios.Name = "Usuarios";
            this.Usuarios.Visible = true;
            this.Usuarios.VisibleIndex = 0;
            // 
            // Nombre
            // 
            this.Nombre.Caption = "Nombre";
            this.Nombre.FieldName = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.Visible = true;
            this.Nombre.VisibleIndex = 1;
            // 
            // IdCaja
            // 
            this.IdCaja.Caption = "IdCaja";
            this.IdCaja.FieldName = "IdCajaChica";
            this.IdCaja.Name = "IdCaja";
            this.IdCaja.Visible = true;
            this.IdCaja.VisibleIndex = 2;
            // 
            // DescripcionCaja
            // 
            this.DescripcionCaja.Caption = "Descripcion Caja";
            this.DescripcionCaja.FieldName = "DescripcionCajaChica";
            this.DescripcionCaja.Name = "DescripcionCaja";
            this.DescripcionCaja.Visible = true;
            this.DescripcionCaja.VisibleIndex = 3;
            // 
            // EmpresaUsuario
            // 
            this.EmpresaUsuario.Caption = "Empresa";
            this.EmpresaUsuario.FieldName = "Empresa";
            this.EmpresaUsuario.Name = "EmpresaUsuario";
            this.EmpresaUsuario.Visible = true;
            this.EmpresaUsuario.VisibleIndex = 4;
            // 
            // FrmUsuarioCajaChica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 561);
            this.Controls.Add(this.gcusuarios);
            this.Controls.Add(this.gccaja);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "FrmUsuarioCajaChica";
            this.Text = "FrmUsuarioCajaChica";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckactivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckComboGasto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcionCaja.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luEmpresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gccaja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCajas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckactivo1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luusuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luempresaUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lucajac.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcusuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvusuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit luEmpresa;
        private DevExpress.XtraEditors.TextEdit txtDescripcionCaja;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraGrid.GridControl gccaja;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCajas;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LookUpEdit luusuario;
        private DevExpress.XtraEditors.LookUpEdit lucajac;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraGrid.GridControl gcusuarios;
        private DevExpress.XtraGrid.Views.Grid.GridView gvusuarios;
        private DevExpress.XtraEditors.SimpleButton btnAgregarCaja;
        private DevExpress.XtraEditors.SimpleButton btnEliminarCaja;
        private DevExpress.XtraEditors.SimpleButton btnEliminarUsu;
        private DevExpress.XtraEditors.SimpleButton btnAgregarUsu;
        private DevExpress.XtraEditors.LookUpEdit luempresaUsuario;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.CheckedComboBoxEdit ckComboGasto;
        private DevExpress.XtraEditors.CheckEdit ckactivo;
        private DevExpress.XtraGrid.Columns.GridColumn DescripcionCajaChica;
        private DevExpress.XtraGrid.Columns.GridColumn Empresa;
        private DevExpress.XtraGrid.Columns.GridColumn IdCajaChica;
        private DevExpress.XtraEditors.CheckEdit ckactivo1;
        private DevExpress.XtraGrid.Columns.GridColumn Usuarios;
        private DevExpress.XtraGrid.Columns.GridColumn Nombre;
        private DevExpress.XtraGrid.Columns.GridColumn IdCaja;
        private DevExpress.XtraGrid.Columns.GridColumn DescripcionCaja;
        private DevExpress.XtraGrid.Columns.GridColumn EmpresaUsuario;
    }
}