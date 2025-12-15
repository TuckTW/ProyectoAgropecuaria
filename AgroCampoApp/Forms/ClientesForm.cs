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
    public partial class ClientesForm : Form
    {
        private string connectionString = "Data Source=TUCKER_LAPTOP; Initial Catalog=AgroCampoSA; Integrated Security=True; Encrypt=True; TrustServerCertificate=True;";
        private enum FormState { Viewing, New, Editing }
        private FormState currentState = FormState.Viewing;

        public ClientesForm()
        {
            InitializeComponent();
            LoadClientesData();
        }

        private void ClearFormControls()
        {
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            // Assuming txtEmail.Clear(); if you have one
            cmbTipo.SelectedIndex = -1; 
            chkActivo.Checked = true; 
            txtNombre.Focus();
        }

        private void LoadSelectedClient()
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                return; // Exit if no row is selected
            }

            DataGridViewRow selectedRow = dgvClientes.SelectedRows[0];

            Func<string, string> GetSafeString = (columnName) =>
            {
                object cellValue = selectedRow.Cells[columnName].Value;
                
                // If the value is DBNull.Value (SQL NULL) or is just C# null, return ""
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
            txtTelefono.Text = GetSafeString("telefono");
            txtDireccion.Text = GetSafeString("direccion");
            string tipo = GetSafeString("tipo_cliente");
            if (!string.IsNullOrEmpty(tipo))
            {
                // Must match one of the constrained values: minorista, mayorista, etc.
                cmbTipo.SelectedItem = tipo; 
            }
            else
            {
                cmbTipo.SelectedIndex = -1;
            }
            string estado = GetSafeString("estado");
            chkActivo.Checked = estado.ToUpper() == "ACTIVO";
        }

        private void LoadClientesData(string searchTerm = "")
        {
            string query = "SELECT id_cliente, nombre, direccion, telefono, email, tipo_cliente, fecha_registro, estado FROM dbo.CLIENTES";

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query += @" WHERE nombre LIKE '%' + @search + '%' OR 
                            telefono LIKE '%' + @search + '%' OR
                            direccion LIKE '%' + @search + '%'";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                
                {
                    if (!string.IsNullOrWhiteSpace(searchTerm))
                    {
                        // Add the search parameter (CRUCIAL for security)
                        // We pass the raw search term as the parameter value
                        command.Parameters.AddWithValue("@search", searchTerm);
                    }

                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable clientesTable = new DataTable();

                        adapter.Fill(clientesTable);

                        // dgvClientes is your DataGridView control
                        dgvClientes.DataSource = clientesTable; 
                        dgvClientes.RowHeadersVisible = false;
                        dgvClientes.Columns["id_cliente"].Visible = false;

                        if (dgvClientes.Rows.Count > 0)
                        {
                            dgvClientes.Rows[0].Selected = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            LoadClientesData(txtbuscar.Text);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtbuscar.Clear();
            LoadClientesData();
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                LoadSelectedClient();
            }
        }

        private void gbDatos_Enter(object sender, EventArgs e)
        {

        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTelefono_Click(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblDireccion_Click(object sender, EventArgs e)
        {

        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTipo_Click(object sender, EventArgs e)
        {

        }

        private void chkActivo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ClearFormControls();
            currentState = FormState.New;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
                {
                    currentState = FormState.Editing;
                    txtNombre.Focus(); // Start editing
                }
                else
                {
                    MessageBox.Show("Seleccione un cliente para editar.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (currentState == FormState.Viewing)
    {
        MessageBox.Show("Por favor, presione 'Nuevo' o 'Editar' primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }

    // Determine if we are INSERTING or UPDATING
    string query = "";
    if (currentState == FormState.New)
    {
        // INSERT QUERY (from previous response)
        query = @"INSERT INTO dbo.CLIENTES 
                  (nombre, direccion, telefono, email, tipo_cliente, fecha_registro, estado)
                  VALUES 
                  (@nombre, @direccion, @telefono, @email, @tipo, GETDATE(), @estado)";
    }
    else if (currentState == FormState.Editing)
    {
        // UPDATE QUERY
        // Requires the primary key (id_cliente) of the selected row
        query = @"UPDATE dbo.CLIENTES SET 
                  nombre = @nombre, direccion = @direccion, telefono = @telefono, email = @email,
                  tipo_cliente = @tipo, estado = @estado
                  WHERE id_cliente = @id";
    }

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            // Add Parameters
            command.Parameters.AddWithValue("@nombre", txtNombre.Text);
            command.Parameters.AddWithValue("@direccion", txtDireccion.Text);
            command.Parameters.AddWithValue("@telefono", txtTelefono.Text);
            command.Parameters.AddWithValue("@tipo", cmbTipo.SelectedItem?.ToString().Trim());
            command.Parameters.AddWithValue("@estado", chkActivo.Checked ? "ACTIVO" : "INACTIVO");

            if (currentState == FormState.Editing)
            {
                // Must pass the ID of the selected client for the WHERE clause
                object idValue = dgvClientes.SelectedRows[0].Cells["id_cliente"].Value;
                command.Parameters.AddWithValue("@id", idValue);
            }

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    string action = (currentState == FormState.New) ? "guardado" : "actualizado";
                    MessageBox.Show($"Cliente {action} exitosamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    currentState = FormState.Viewing; // Reset state
                    LoadClientesData(); // Refresh the grid
                }
                // Error handling for 0 rows affected goes here...
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Base de Datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione un cliente para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("¿Está seguro de que desea eliminar este cliente?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Get the ID of the selected row
                    object idValue = dgvClientes.SelectedRows[0].Cells["id_cliente"].Value;

                    string query = "DELETE FROM dbo.CLIENTES WHERE id_cliente = @id";

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
                                    MessageBox.Show("Cliente eliminado exitosamente.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadClientesData(); // Refresh the grid
                                    ClearFormControls();
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
