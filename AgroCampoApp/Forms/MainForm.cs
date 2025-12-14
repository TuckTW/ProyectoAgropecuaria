using System;
using System.Windows.Forms;

namespace AgroCampoApp.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Text = "AgroCampoApp - Menú Principal";
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {
            // Esto lo puedes dejar vacío o borrarlo del Designer si no lo necesitas
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            new ProductosForm().ShowDialog();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            new ClientesForm().ShowDialog();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            new ProveedoresForm().ShowDialog();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            new VentasForm().ShowDialog();
        }
    }
}
