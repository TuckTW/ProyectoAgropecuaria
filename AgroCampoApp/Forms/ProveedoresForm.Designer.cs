using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace AgroCampoApp.Forms
{
    partial class ProveedoresForm
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
            lblTitulo = new Label();
            txtBuscar = new TextBox();
            dgvProveedores = new DataGridView();
            btnBuscar = new Button();
            btnLimpiar = new Button();
            gbDatos = new GroupBox();
            txtDireccion = new TextBox();
            txtTelefono = new TextBox();
            txtContacto = new TextBox();
            txtNombre = new TextBox();
            btnEliminar = new Button();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnNuevo = new Button();
            chkActivo = new CheckBox();
            lblDireccion = new Label();
            lblTelefono = new Label();
            lblContacto = new Label();
            lblNombre = new Label();
            btnMenuPrincipal = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).BeginInit();
            gbDatos.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = SystemColors.ButtonFace;
            lblTitulo.Font = new Font("Arial Narrow", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(281, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(279, 33);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestion de proveedores";
            lblTitulo.Click += lblTitulo_Click;
            // 
            // txtbuscar
            // 
            txtBuscar.Location = new Point(12, 88);
            txtBuscar.Name = "txtbuscar";
            txtBuscar.Size = new Size(607, 27);
            txtBuscar.TabIndex = 3;
            txtBuscar.Text = "";
            txtBuscar.TextChanged += txtbuscar_TextChanged;
            // 
            // dgvProveedores
            // 
            dgvProveedores.AllowUserToAddRows = false;
            dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProveedores.Location = new Point(12, 130);
            dgvProveedores.MultiSelect = false;
            dgvProveedores.Name = "dgvProveedores";
            dgvProveedores.ReadOnly = true;
            dgvProveedores.RowHeadersWidth = 51;
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProveedores.Size = new Size(607, 361);
            dgvProveedores.TabIndex = 6;
            dgvProveedores.CellContentClick += dgvProveedores_CellContentClick;
            this.dgvProveedores.SelectionChanged += new System.EventHandler(this.dgvProveedores_SelectionChanged);
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(644, 87);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(94, 29);
            btnBuscar.TabIndex = 7;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(776, 86);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(94, 29);
            btnLimpiar.TabIndex = 8;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // gbDatos
            // 
            gbDatos.BackColor = SystemColors.ButtonFace;
            gbDatos.Controls.Add(txtDireccion);
            gbDatos.Controls.Add(txtTelefono);
            gbDatos.Controls.Add(txtContacto);
            gbDatos.Controls.Add(txtNombre);
            gbDatos.Controls.Add(btnEliminar);
            gbDatos.Controls.Add(btnGuardar);
            gbDatos.Controls.Add(btnEditar);
            gbDatos.Controls.Add(btnNuevo);
            gbDatos.Controls.Add(chkActivo);
            gbDatos.Controls.Add(lblDireccion);
            gbDatos.Controls.Add(lblTelefono);
            gbDatos.Controls.Add(lblContacto);
            gbDatos.Controls.Add(lblNombre);
            gbDatos.Location = new Point(625, 130);
            gbDatos.Name = "gbDatos";
            gbDatos.Size = new Size(250, 361);
            gbDatos.TabIndex = 9;
            gbDatos.TabStop = false;
            gbDatos.Text = "Datos del cliente";
            gbDatos.Enter += gbDatos_Enter;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(86, 142);
            txtDireccion.Multiline = true;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(141, 34);
            txtDireccion.TabIndex = 18;
            txtDireccion.TextChanged += txtDireccion_TextChanged;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(86, 104);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(141, 27);
            txtTelefono.TabIndex = 17;
            txtTelefono.TextChanged += txtTelefono_TextChanged;
            // 
            // txtCedula
            // 
            txtContacto.Location = new Point(86, 66);
            txtContacto.Name = "txtContacto";
            txtContacto.Size = new Size(141, 27);
            txtContacto.TabIndex = 16;
            txtContacto.TextChanged += txtCedula_TextChanged;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(86, 33);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(141, 27);
            txtNombre.TabIndex = 15;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(121, 315);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 14;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(9, 312);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(85, 32);
            btnGuardar.TabIndex = 13;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(121, 266);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 29);
            btnEditar.TabIndex = 12;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(9, 268);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(85, 27);
            btnNuevo.TabIndex = 10;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(5, 221);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(73, 24);
            chkActivo.TabIndex = 5;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            chkActivo.CheckedChanged += chkActivo_CheckedChanged;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(6, 145);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(72, 20);
            lblDireccion.TabIndex = 3;
            lblDireccion.Text = "Direccion";
            lblDireccion.Click += lblDireccion_Click;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(6, 107);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(67, 20);
            lblTelefono.TabIndex = 2;
            lblTelefono.Text = "Telefono";
            lblTelefono.Click += lblTelefono_Click;
            // 
            // lblContacto
            // 
            lblContacto.AutoSize = true;
            lblContacto.Location = new Point(6, 69);
            lblContacto.Name = "lblContacto";
            lblContacto.Size = new Size(69, 20);
            lblContacto.TabIndex = 1;
            lblContacto.Text = "Contacto";
            lblContacto.Click += lblContacto_Click;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(6, 36);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(64, 20);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            lblNombre.Click += lblNombre_Click;
            // 
            // btnMenuPrincipal
            // 
            btnMenuPrincipal.BackColor = SystemColors.Info;
            btnMenuPrincipal.Location = new Point(12, 23);
            btnMenuPrincipal.Name = "btnMenuPrincipal";
            btnMenuPrincipal.Size = new Size(120, 29);
            btnMenuPrincipal.TabIndex = 10;
            btnMenuPrincipal.Text = "Menu Principal";
            btnMenuPrincipal.UseVisualStyleBackColor = false;
            btnMenuPrincipal.Click += btnMenuPrincipal_Click;
            // 
            // ProveedoresForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(882, 553);
            Controls.Add(btnMenuPrincipal);
            Controls.Add(gbDatos);
            Controls.Add(btnLimpiar);
            Controls.Add(btnBuscar);
            Controls.Add(dgvProveedores);
            Controls.Add(txtBuscar);
            Controls.Add(lblTitulo);
            Name = "ProveedoresForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agro Campo Proveedores";
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).EndInit();
            gbDatos.ResumeLayout(false);
            gbDatos.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private TextBox txtBuscar;
        private DataGridView dgvProveedores;
        private Button btnBuscar;
        private Button btnLimpiar;
        private GroupBox gbDatos;
        private TextBox txtDireccion;
        private TextBox txtTelefono;
        private TextBox txtContacto;
        private TextBox txtNombre;
        private Button btnEliminar;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnNuevo;
        private CheckBox chkActivo;
        private Label lblDireccion;
        private Label lblTelefono;
        private Label lblContacto;
        private Label lblNombre;
        private Button btnMenuPrincipal;
    }
}