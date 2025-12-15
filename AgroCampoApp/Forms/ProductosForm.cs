using System; 
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace AgroCampoApp.Forms
{
    public partial class ProductosForm : Form
    {
        private string connectionString = "Data Source=TUCKER_LAPTOP; Initial Catalog=AgroCampoSA; Integrated Security=True; Encrypt=True; TrustServerCertificate=True;";
        private enum FormState { Viewing, New, Editing }
        private FormState currentState = FormState.Viewing;

        public ProductosForm()
        {
            InitializeComponent();
            LoadProductosData();
            SetControlsState(FormState.Viewing);
        }

        private void LoadProductosData(string searchTerm = "")
        {
            string query = "SELECT id_producto, nombre, categoria, precio_unitario, unidad_medida, fecha_creacion, estado FROM dbo.PRODUCTOS";
            
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query += @" WHERE nombre LIKE '%' + @search + '%' OR 
                                 categoria LIKE '%' + @search + '%'";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (!string.IsNullOrWhiteSpace(searchTerm))
                    {
                        command.Parameters.AddWithValue("@search", searchTerm);
                    }
                    
                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command); 
                        DataTable productosTable = new DataTable();

                        adapter.Fill(productosTable);
                        dgvProductos.DataSource = productosTable;

                        if (dgvProductos.Columns.Count > 0)
                        {
                            dgvProductos.Columns["id_producto"].Visible = false;
                            dgvProductos.RowHeadersVisible = false;

                            dgvProductos.Columns["nombre"].HeaderText = "Nombre Producto";
                            dgvProductos.Columns["categoria"].HeaderText = "Categoría";
                            
                            dgvProductos.Columns["precio_unitario"].HeaderText = "Precio";
                            dgvProductos.Columns["unidad_medida"].HeaderText = "Stock / Unidad"; 
                            dgvProductos.Columns["fecha_creacion"].HeaderText = "Fecha Creación";
                            dgvProductos.Columns["estado"].HeaderText = "Estado";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar los datos de Productos: " + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadSelectedProducto()
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow selectedRow = dgvProductos.SelectedRows[0];
            
            Func<string, string> GetSafeString = (columnName) =>
            {
                object cellValue = selectedRow.Cells[columnName].Value;
                if (cellValue == DBNull.Value || cellValue == null)
                {
                    return "";
                }
                return cellValue.ToString().Trim();
            };

            // ----------------------------------------------------
            // ASSIGN DATA TO CONTROLS
            // ----------------------------------------------------
            
            txtNombre.Text = GetSafeString("nombre");
            txtCategorias.Text = GetSafeString("categoria");

            string precioStr = GetSafeString("precio_unitario");
            string stockStr = GetSafeString("unidad_medida");
            
            decimal precio = 0;
            if (decimal.TryParse(precioStr, out precio))
            {
                nudPrecio.Value = precio;
            }
            else
            {
                nudPrecio.Value = 0;
            }
            
            txtStock.Text = stockStr;
             string estado = GetSafeString("estado");
            checkBox1.Checked = estado.ToUpper() == "ACTIVO";
        }

        private void ClearFormControls()
        {
            txtNombre.Clear();
            txtCategorias.Clear();
            nudPrecio.Value = 0;
            txtStock.Clear();
            checkBox1.Checked = true; // Default to active
            txtNombre.Focus();
        }

        private void SetControlsState(FormState state)
        {
            bool isEditingOrNew = (state == FormState.New || state == FormState.Editing);
            
            txtNombre.ReadOnly = !isEditingOrNew;
            txtCategorias.ReadOnly = !isEditingOrNew;
            nudPrecio.Enabled = isEditingOrNew;
            txtStock.Enabled = isEditingOrNew;
            checkBox1.Enabled = isEditingOrNew;

            btnNuevo.Enabled = !isEditingOrNew;
            btnEditar.Enabled = !isEditingOrNew;
            btnGuardar.Enabled = isEditingOrNew;
            btnEliminar.Enabled = !isEditingOrNew;
            
            if (state == FormState.Viewing)
            {
                btnEliminar.Enabled = dgvProductos.SelectedRows.Count > 0;
            }
        }
        private void textBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            LoadSelectedProducto();
            SetControlsState(currentState);
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                LoadSelectedProducto();
            }
        }

        private void dgvProductos_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                LoadSelectedProducto();
            }
        }

        private void txtNombre_Click(object sender, EventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            LoadProductosData(textBuscar.Text);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            textBuscar.Clear();
            LoadProductosData();
        }

        private void gbDatos_Enter(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblCategoria_Click(object sender, EventArgs e)
        {

        }

        private void txtCategorias_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPrecio_Click(object sender, EventArgs e)
        {

        }

        private void nudPrecio_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblStock_Click(object sender, EventArgs e)
        {

        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ClearFormControls();
            currentState = FormState.New;
            SetControlsState(currentState);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                currentState = FormState.Editing;
                SetControlsState(currentState);
                txtNombre.Focus(); 
            }
            else
            {
                MessageBox.Show("Seleccione un producto para editar.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (currentState == FormState.Viewing) return;

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del producto es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return; 
            }
            if (string.IsNullOrWhiteSpace(txtStock.Text))
            {
                MessageBox.Show("La unidad del producto es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return; 
            }
            if (string.IsNullOrWhiteSpace(txtCategorias.Text))
            {
                MessageBox.Show("La categoría del producto es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategorias.Focus();
                return; 
            }
            
            // --- Determine SQL Query ---
            string query = "";
            if (currentState == FormState.New)
            {
                query = @"INSERT INTO dbo.PRODUCTOS 
                        (nombre, categoria, precio_unitario, unidad_medida, estado)
                        VALUES 
                        (@nombre, @categoria, @precio, @stock, @estado)";
            }
            else if (currentState == FormState.Editing)
            {
                query = @"UPDATE dbo.PRODUCTOS SET 
                        nombre = @nombre, categoria = @categoria, precio_unitario = @precio, 
                        unidad_medida = @stock, estado = @estado
                        WHERE id_producto = @id";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    command.Parameters.AddWithValue("@categoria", txtCategorias.Text);
                    
                    command.Parameters.AddWithValue("@precio", nudPrecio.Value);
                    command.Parameters.AddWithValue("@stock", txtStock.Text);
                    
                    command.Parameters.AddWithValue("@estado", checkBox1.Checked ? "activo" : "inactivo");

                    if (currentState == FormState.Editing)
                    {
                        object idValue = dgvProductos.SelectedRows[0].Cells["id_producto"].Value;
                        command.Parameters.AddWithValue("@id", idValue);
                    }

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            string action = (currentState == FormState.New) ? "guardado" : "actualizado";
                            MessageBox.Show($"Producto {action} exitosamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            // Reset state and refresh
                            ClearFormControls();
                            LoadProductosData(); 
                            currentState = FormState.Viewing; 
                            SetControlsState(currentState);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo guardar/actualizar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error de Base de Datos al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de que desea eliminar este producto?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                object idValue = dgvProductos.SelectedRows[0].Cells["id_producto"].Value;

                string query = "DELETE FROM dbo.PRODUCTOS WHERE id_producto = @id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", idValue);

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Producto eliminado exitosamente.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadProductosData();
                                ClearFormControls();
                                currentState = FormState.Viewing;
                                SetControlsState(currentState);
                            }
                        }
                        catch (SqlException ex)
                        {
                            if (ex.Number == 547) 
                            {
                                MessageBox.Show("Error: Este producto no puede ser eliminado porque tiene registros de ventas asociados.", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
