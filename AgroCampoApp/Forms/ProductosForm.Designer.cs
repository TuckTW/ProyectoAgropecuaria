namespace AgroCampoApp.Forms
{
    partial class ProductosForm
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
            txtBuscar = new Label();
            textBuscar = new TextBox();
            btnBuscar = new Button();
            btnLimpiar = new Button();
            dgvProductos = new DataGridView();
            gbDatos = new GroupBox();
            btnEliminar = new Button();
            btnEditar = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            checkBox1 = new CheckBox();
            nudStock = new NumericUpDown();
            nudPrecio = new NumericUpDown();
            txtCategorias = new TextBox();
            txtNombre = new TextBox();
            lblStock = new Label();
            lblPrecio = new Label();
            lblCategoria = new Label();
            lblNombre = new Label();
            btnMenuPrincipal = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = SystemColors.ButtonFace;
            lblTitulo.Font = new Font("Arial Narrow", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(268, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(257, 33);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestion De Productos";
            lblTitulo.Click += lblTitulo_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.AutoSize = true;
            txtBuscar.Location = new Point(410, 127);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(0, 20);
            txtBuscar.TabIndex = 1;
            // 
            // textBuscar
            // 
            textBuscar.Location = new Point(12, 60);
            textBuscar.Name = "textBuscar";
            textBuscar.Size = new Size(607, 27);
            textBuscar.TabIndex = 2;
            textBuscar.Text = "Buscar :";
            textBuscar.TextChanged += textBuscar_TextChanged;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(625, 60);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(85, 26);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(775, 59);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(85, 27);
            btnLimpiar.TabIndex = 4;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // dgvProductos
            // 
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(12, 109);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(607, 352);
            dgvProductos.TabIndex = 5;
            dgvProductos.CellContentClick += dgvProductos_CellContentClick_1;
            // 
            // gbDatos
            // 
            gbDatos.BackColor = SystemColors.ButtonFace;
            gbDatos.Controls.Add(btnEliminar);
            gbDatos.Controls.Add(btnEditar);
            gbDatos.Controls.Add(btnGuardar);
            gbDatos.Controls.Add(btnNuevo);
            gbDatos.Controls.Add(checkBox1);
            gbDatos.Controls.Add(nudStock);
            gbDatos.Controls.Add(nudPrecio);
            gbDatos.Controls.Add(txtCategorias);
            gbDatos.Controls.Add(txtNombre);
            gbDatos.Controls.Add(lblStock);
            gbDatos.Controls.Add(lblPrecio);
            gbDatos.Controls.Add(lblCategoria);
            gbDatos.Controls.Add(lblNombre);
            gbDatos.Location = new Point(625, 109);
            gbDatos.Name = "gbDatos";
            gbDatos.Size = new Size(245, 352);
            gbDatos.TabIndex = 6;
            gbDatos.TabStop = false;
            gbDatos.Text = "Datos del productos";
            gbDatos.Enter += gbDatos_Enter;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(118, 292);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(118, 247);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 29);
            btnEditar.TabIndex = 11;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(6, 289);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(85, 32);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(6, 247);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(85, 27);
            btnNuevo.TabIndex = 9;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(6, 206);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(73, 24);
            checkBox1.TabIndex = 8;
            checkBox1.Text = "Activo";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // nudStock
            // 
            nudStock.Location = new Point(62, 161);
            nudStock.Name = "nudStock";
            nudStock.Size = new Size(150, 27);
            nudStock.TabIndex = 7;
            nudStock.ValueChanged += nudStock_ValueChanged;
            // 
            // nudPrecio
            // 
            nudPrecio.Location = new Point(62, 122);
            nudPrecio.Name = "nudPrecio";
            nudPrecio.Size = new Size(150, 27);
            nudPrecio.TabIndex = 6;
            nudPrecio.ValueChanged += nudPrecio_ValueChanged;
            // 
            // txtCategorias
            // 
            txtCategorias.Location = new Point(86, 80);
            txtCategorias.Name = "txtCategorias";
            txtCategorias.Size = new Size(125, 27);
            txtCategorias.TabIndex = 5;
            txtCategorias.TextChanged += txtCategorias_TextChanged;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(86, 37);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(125, 27);
            txtNombre.TabIndex = 4;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(6, 161);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(45, 20);
            lblStock.TabIndex = 3;
            lblStock.Text = "Stock";
            lblStock.Click += lblStock_Click;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(6, 122);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(50, 20);
            lblPrecio.TabIndex = 2;
            lblPrecio.Text = "Precio";
            lblPrecio.Click += lblPrecio_Click;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(6, 80);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(74, 20);
            lblCategoria.TabIndex = 1;
            lblCategoria.Text = "Categoria";
            lblCategoria.Click += lblCategoria_Click;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(6, 40);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(64, 20);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            lblNombre.Click += txtNombre_Click;
            // 
            // btnMenuPrincipal
            // 
            btnMenuPrincipal.BackColor = SystemColors.Info;
            btnMenuPrincipal.Location = new Point(23, 13);
            btnMenuPrincipal.Name = "btnMenuPrincipal";
            btnMenuPrincipal.Size = new Size(120, 29);
            btnMenuPrincipal.TabIndex = 13;
            btnMenuPrincipal.Text = "Menu Principal";
            btnMenuPrincipal.UseVisualStyleBackColor = false;
            btnMenuPrincipal.Click += btnMenuPrincipal_Click;
            // 
            // ProductosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(882, 553);
            Controls.Add(btnMenuPrincipal);
            Controls.Add(gbDatos);
            Controls.Add(dgvProductos);
            Controls.Add(btnLimpiar);
            Controls.Add(btnBuscar);
            Controls.Add(textBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(lblTitulo);
            Name = "ProductosForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AgroCampo - Productos";
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            gbDatos.ResumeLayout(false);
            gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label txtBuscar;
        private TextBox textBuscar;
        private Button btnBuscar;
        private Button btnLimpiar;
        private DataGridView dgvProductos;
        private GroupBox gbDatos;
        private Label lblNombre;
        private Label lblCategoria;
        private NumericUpDown nudPrecio;
        private TextBox txtCategorias;
        private TextBox txtNombre;
        private Label lblStock;
        private Label lblPrecio;
        private NumericUpDown nudStock;
        private CheckBox checkBox1;
        private Button btnEliminar;
        private Button btnEditar;
        private Button btnGuardar;
        private Button btnNuevo;
        private Button btnMenuPrincipal;
    }
}