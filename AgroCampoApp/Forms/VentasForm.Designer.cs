using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace AgroCampoApp.Forms
{
    partial class VentasForm
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
            btnMenuPrincipal = new Button();
            lblCliente = new Label();
            cmbCliente = new ComboBox();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            lblEstadoVentas = new Label();
            cmbEstadoVentas = new ComboBox();
            dgvVentas = new DataGridView();
            gbAgregarItems = new GroupBox();
            txtTotal = new TextBox();
            lblTotal = new Label();
            btnQuitar = new Button();
            btnAgregar = new Button();
            nudPrecio = new NumericUpDown();
            nudCantidad = new NumericUpDown();
            lblPrecio = new Label();
            lblCantidad = new Label();
            comboBox1 = new ComboBox();
            lblProducto = new Label();
            btnBuscarVenta = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            gbAgregarItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = SystemColors.ButtonFace;
            lblTitulo.Font = new Font("Arial Narrow", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(356, 22);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(224, 33);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Registro de Ventas";
            // 
            // btnMenuPrincipal
            // 
            btnMenuPrincipal.BackColor = SystemColors.Info;
            btnMenuPrincipal.Location = new Point(25, 22);
            btnMenuPrincipal.Name = "btnMenuPrincipal";
            btnMenuPrincipal.Size = new Size(120, 29);
            btnMenuPrincipal.TabIndex = 2;
            btnMenuPrincipal.Text = "Menu Principal";
            btnMenuPrincipal.UseVisualStyleBackColor = false;
            btnMenuPrincipal.Click += btnMenuPrincipal_Click;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(12, 98);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(58, 20);
            lblCliente.TabIndex = 3;
            lblCliente.Text = "Cliente:";
            // 
            // cmbCliente
            // 
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(89, 98);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(151, 28);
            cmbCliente.TabIndex = 4;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(291, 96);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(54, 20);
            lblFecha.TabIndex = 5;
            lblFecha.Text = "Fecha :";
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(365, 91);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(150, 27);
            dtpFecha.TabIndex = 6;
            // 
            // lblNventas
            // 
            lblEstadoVentas.AutoSize = true;
            lblEstadoVentas.Location = new Point(555, 96);
            lblEstadoVentas.Name = "lblEstadoVentas";
            lblEstadoVentas.Size = new Size(76, 20);
            lblEstadoVentas.TabIndex = 7;
            lblEstadoVentas.Text = "Estado de Ventas";
            // 
            // txtNventas
            // 
            cmbEstadoVentas.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstadoVentas.FormattingEnabled = true;
            cmbEstadoVentas.Location = new Point(667, 93);
            cmbEstadoVentas.Name = "txtEstadoVentas";
            cmbEstadoVentas.Size = new Size(125, 27);
            cmbEstadoVentas.TabIndex = 8;
            // 
            // btnBuscarVenta
            // 
            btnBuscarVenta.BackColor = SystemColors.ControlLight;
            btnBuscarVenta.Location = new Point(810, 91);
            btnBuscarVenta.Name = "btnBuscarVenta";
            btnBuscarVenta.Size = new Size(94, 29);
            btnBuscarVenta.TabIndex = 8;
            btnBuscarVenta.Text = "Buscar";
            btnBuscarVenta.UseVisualStyleBackColor = false;
            btnBuscarVenta.Click += btnBuscarVenta_Click;
            // 
            // dgvVentas
            // 
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Location = new Point(25, 132);
            dgvVentas.MultiSelect = false;
            dgvVentas.Name = "dgvVentas";
            dgvVentas.ReadOnly = true;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.RowHeadersWidth = 51;
            dgvVentas.Size = new Size(732, 399);
            dgvVentas.TabIndex = 9;
            // 
            // gbAgregarItems
            // 
            gbAgregarItems.BackColor = SystemColors.ButtonFace;
            gbAgregarItems.Controls.Add(txtTotal);
            gbAgregarItems.Controls.Add(lblTotal);
            gbAgregarItems.Controls.Add(btnBuscarVenta);
            gbAgregarItems.Controls.Add(btnQuitar);
            gbAgregarItems.Controls.Add(btnAgregar);
            gbAgregarItems.Controls.Add(nudPrecio);
            gbAgregarItems.Controls.Add(nudCantidad);
            gbAgregarItems.Controls.Add(lblPrecio);
            gbAgregarItems.Controls.Add(lblCantidad);
            gbAgregarItems.Controls.Add(comboBox1);
            gbAgregarItems.Controls.Add(lblProducto);
            gbAgregarItems.Location = new Point(763, 144);
            gbAgregarItems.Name = "gbAgregarItems";
            gbAgregarItems.Size = new Size(216, 387);
            gbAgregarItems.TabIndex = 10;
            gbAgregarItems.TabStop = false;
            gbAgregarItems.Text = "Agregar Items";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(57, 304);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(74, 27);
            txtTotal.TabIndex = 9;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(6, 304);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(42, 20);
            lblTotal.TabIndex = 8;
            lblTotal.Text = "Total";
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(106, 235);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(94, 29);
            btnQuitar.TabIndex = 7;
            btnQuitar.Text = "Quitar";
            btnQuitar.UseVisualStyleBackColor = true;
            btnQuitar.Click += btnQuitar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(6, 235);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(94, 29);
            btnAgregar.TabIndex = 6;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click; 
            // 
            // nudPrecio
            // 
            nudPrecio.DecimalPlaces = 2;
            nudPrecio.Location = new Point(57, 148);
            nudPrecio.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudPrecio.Name = "nudPrecio";
            nudPrecio.Size = new Size(150, 27);
            nudPrecio.TabIndex = 5;
            // 
            // nudCantidad
            // 
            nudCantidad.DecimalPlaces = 2;
            nudCantidad.Location = new Point(76, 105);
            nudCantidad.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(134, 27);
            nudCantidad.TabIndex = 4;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(1, 150);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(50, 20);
            lblPrecio.TabIndex = 3;
            lblPrecio.Text = "Precio";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(0, 107);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(69, 20);
            lblCantidad.TabIndex = 2;
            lblCantidad.Text = "Cantidad";
            // 
            // comboBox1
            // 
            comboBox1.DisplayMember = "nombre_producto";
            comboBox1.ValueMember = "id_producto";
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(76, 62);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(120, 28);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedValueChanged += comboBox1_SelectedValueChanged;
            // 
            // lblProducto
            // 
            lblProducto.AutoSize = true;
            lblProducto.Location = new Point(1, 65);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(69, 20);
            lblProducto.TabIndex = 0;
            lblProducto.Text = "Producto";
            // 
            // VentasForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(982, 553);
            Controls.Add(gbAgregarItems);
            Controls.Add(dgvVentas);
            Controls.Add(cmbEstadoVentas);
            Controls.Add(lblEstadoVentas);
            Controls.Add(btnBuscarVenta);
            Controls.Add(dtpFecha);
            Controls.Add(lblFecha);
            Controls.Add(cmbCliente);
            Controls.Add(lblCliente);
            Controls.Add(btnMenuPrincipal);
            Controls.Add(lblTitulo);
            Name = "VentasForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agro Campo Ventas";
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            gbAgregarItems.ResumeLayout(false);
            gbAgregarItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Button btnMenuPrincipal;
        private Label lblCliente;
        private ComboBox cmbCliente;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private Label lblEstadoVentas;
        private ComboBox cmbEstadoVentas;
        private Button btnBuscarVenta;
        private DataGridView dgvVentas;
        private GroupBox gbAgregarItems;
        private ComboBox comboBox1;
        private Label lblProducto;
        private Label lblPrecio;
        private Label lblCantidad;
        private TextBox txtTotal;
        private Label lblTotal;
        private Button btnQuitar;
        private Button btnAgregar;
        private NumericUpDown nudPrecio;
        private NumericUpDown nudCantidad;
    }
}