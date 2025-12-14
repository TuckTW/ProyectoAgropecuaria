namespace AgroCampoApp.Forms
{
    partial class MainForm
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
            btnVentas = new Button();
            btnClientes = new Button();
            btnProductos = new Button();
            btnProveedores = new Button();
            SuspendLayout();
            // 
            // btnVentas
            // 
            btnVentas.BackColor = SystemColors.ActiveCaption;
            btnVentas.Location = new Point(24, 353);
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(142, 54);
            btnVentas.TabIndex = 4;
            btnVentas.Text = "Ventas";
            btnVentas.UseVisualStyleBackColor = false;
            btnVentas.Click += btnVentas_Click;
            // 
            // btnClientes
            // 
            btnClientes.BackColor = SystemColors.ActiveCaption;
            btnClientes.Location = new Point(24, 262);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(142, 51);
            btnClientes.TabIndex = 2;
            btnClientes.Text = "Clientes";
            btnClientes.UseVisualStyleBackColor = false;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnProductos
            // 
            btnProductos.BackColor = SystemColors.ActiveCaption;
            btnProductos.Location = new Point(24, 432);
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(142, 51);
            btnProductos.TabIndex = 1;
            btnProductos.Text = "Productos";
            btnProductos.UseVisualStyleBackColor = false;
            btnProductos.Click += btnProductos_Click;
            // 
            // btnProveedores
            // 
            btnProveedores.BackColor = SystemColors.ActiveCaption;
            btnProveedores.Location = new Point(24, 187);
            btnProveedores.Name = "btnProveedores";
            btnProveedores.Size = new Size(142, 52);
            btnProveedores.TabIndex = 3;
            btnProveedores.Text = "Proveedores";
            btnProveedores.UseVisualStyleBackColor = false;
            btnProveedores.Click += btnProveedores_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.AgroCampo;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(882, 553);
            Controls.Add(btnProductos);
            Controls.Add(btnProveedores);
            Controls.Add(btnClientes);
            Controls.Add(btnVentas);
            Name = "MainForm";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnVentas;
        private Button btnClientes;
        private Button btnProductos;
        private Button btnProveedores;
    }
}