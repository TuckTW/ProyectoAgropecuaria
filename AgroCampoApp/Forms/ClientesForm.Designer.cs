using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace AgroCampoApp.Forms
{
    partial class ClientesForm
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
            txtbuscar = new TextBox();
            btnBuscar = new Button();
            btnLimpiar = new Button();
            dgvClientes = new DataGridView();
            gbDatos = new GroupBox();
            cmbTipo = new ComboBox();
            txtDireccion = new TextBox();
            txtTelefono = new TextBox();
            txtNombre = new TextBox();
            btnEliminar = new Button();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnNuevo = new Button();
            chkActivo = new CheckBox();
            lblTipo = new Label();
            lblDireccion = new Label();
            lblTelefono = new Label();
            lblNombre = new Label();
            btnMenuPrincipal = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            gbDatos.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = SystemColors.ButtonFace;
            lblTitulo.Font = new Font("Arial Narrow", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(302, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(226, 33);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestion de clientes";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.Click += lblTitulo_Click;
            // 
            // txtbuscar
            // 
            txtbuscar.Location = new Point(12, 67);
            txtbuscar.Name = "txtbuscar";
            txtbuscar.Size = new Size(607, 27);
            txtbuscar.TabIndex = 2;
            txtbuscar.Text = "";
            txtbuscar.TextChanged += txtbuscar_TextChanged;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(631, 61);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(94, 29);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(776, 61);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(94, 29);
            btnLimpiar.TabIndex = 4;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(12, 113);
            dgvClientes.MultiSelect = false;
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersWidth = 51;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(607, 361);
            dgvClientes.TabIndex = 5;
            dgvClientes.CellContentClick += dgvClientes_CellContentClick;
            // 
            // gbDatos
            // 
            gbDatos.BackColor = SystemColors.ButtonFace;
            gbDatos.Controls.Add(cmbTipo);
            gbDatos.Controls.Add(txtDireccion);
            gbDatos.Controls.Add(txtTelefono);
            gbDatos.Controls.Add(txtNombre);
            gbDatos.Controls.Add(btnEliminar);
            gbDatos.Controls.Add(btnGuardar);
            gbDatos.Controls.Add(btnEditar);
            gbDatos.Controls.Add(btnNuevo);
            gbDatos.Controls.Add(chkActivo);
            gbDatos.Controls.Add(lblTipo);
            gbDatos.Controls.Add(lblDireccion);
            gbDatos.Controls.Add(lblTelefono);
            gbDatos.Controls.Add(lblCedula);
            gbDatos.Controls.Add(lblNombre);
            gbDatos.Location = new Point(631, 113);
            gbDatos.Name = "gbDatos";
            gbDatos.Size = new Size(250, 361);
            gbDatos.TabIndex = 6;
            gbDatos.TabStop = false;
            gbDatos.Text = "Datos del cliente";
            gbDatos.Enter += gbDatos_Enter;
            // 
            // cmbTipo
            // 
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Items.AddRange(new object[] { "minorista", "mayorista", "distribuidor", "proveedor" });
            cmbTipo.Location = new Point(86, 184);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(141, 28);
            cmbTipo.TabIndex = 19;
            cmbTipo.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(86, 102);
            txtDireccion.Multiline = true;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(141, 64);
            txtDireccion.TabIndex = 18;
            txtDireccion.Multiline = true;
            txtDireccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtDireccion.TextChanged += txtDireccion_TextChanged;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(86, 64);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(141, 27);
            txtTelefono.TabIndex = 17;
            txtTelefono.TextChanged += txtTelefono_TextChanged;

            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(86, 33);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(141, 27);
            txtNombre.TabIndex = 15;
            txtNombre.Multiline = true;
            txtNombre.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
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
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(6, 184);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(39, 20);
            lblTipo.TabIndex = 4;
            lblTipo.Text = "Tipo";
            lblTipo.Click += lblTipo_Click;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(6, 105);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(72, 20);
            lblDireccion.TabIndex = 3;
            lblDireccion.Text = "Direccion";
            lblDireccion.Click += lblDireccion_Click;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(6, 67);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(67, 20);
            lblTelefono.TabIndex = 2;
            lblTelefono.Text = "Telefono";
            lblTelefono.Click += lblTelefono_Click;

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
            btnMenuPrincipal.Location = new Point(12, 15);
            btnMenuPrincipal.Name = "btnMenuPrincipal";
            btnMenuPrincipal.Size = new Size(120, 29);
            btnMenuPrincipal.TabIndex = 20;
            btnMenuPrincipal.Text = "Menu Principal";
            btnMenuPrincipal.UseVisualStyleBackColor = false;
            btnMenuPrincipal.Click += btnMenuPrincipal_Click;
            // 
            // ClientesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(882, 553);
            Controls.Add(btnMenuPrincipal);
            Controls.Add(gbDatos);
            Controls.Add(dgvClientes);
            Controls.Add(btnLimpiar);
            Controls.Add(btnBuscar);
            Controls.Add(txtbuscar);
            Controls.Add(lblTitulo);
            Name = "ClientesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ClientesForm";
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            gbDatos.ResumeLayout(false);
            gbDatos.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblBuscar;
        private TextBox txtbuscar;
        private Button btnBuscar;
        private Button btnLimpiar;
        private DataGridView dgvClientes;
        private GroupBox gbDatos;
        private Label lblTelefono;
        private Label lblCedula;
        private Label lblNombre;
        private Label lblTipo;
        private Label lblDireccion;
        private CheckBox chkActivo;
        private Button btnNuevo;
        private Button btnEditar;
        private Button btnGuardar;
        private Button btnEliminar;
        private TextBox txtNombre;
        private ComboBox cmbTipo;
        private TextBox txtDireccion;
        private TextBox txtTelefono;
        private Button btnMenuPrincipal;
    }
}