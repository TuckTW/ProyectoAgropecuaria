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
    public partial class ProveedoresForm : Form
    {
        private string connectionString = "Data Source=TUCKER_LAPTOP; Initial Catalog=AgroCampoSA; Integrated Security=True; Encrypt=True; TrustServerCertificate=True;";
        private enum FormState { Viewing, New, Editing }
        private FormState currentState = FormState.Viewing;

        public ProveedoresForm()
        {
            InitializeComponent();
        }

        private void LoadProveedoresData(string searchTerm = "")
        {
            string query = @"SELECT id_proveedor, nombre_empresa, contacto_nombre, direccion, 
                                    telefono, fecha_registro, estado 
                            FROM dbo.PROVEEDORES";

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query += @" WHERE nombre_empresa LIKE '%' + @search + '%' OR 
                                contacto_nombre LIKE '%' + @search + '%'";
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
                        DataTable proveedoresTable = new DataTable();

                        adapter.Fill(proveedoresTable);
                        dgvProveedores.DataSource = proveedoresTable; // Assuming your grid is named dgvProveedores

                        if (dgvProveedores.Columns.Count > 0)
                        {
                            dgvProveedores.Columns["id_proveedor"].Visible = false;
                            dgvProveedores.RowHeadersVisible = false;

                            dgvProveedores.Columns["nombre_empresa"].HeaderText = "Empresa";
                            dgvProveedores.Columns["contacto_nombre"].HeaderText = "Contacto";
                            dgvProveedores.Columns["direccion"].HeaderText = "Dirección";
                            dgvProveedores.Columns["telefono"].HeaderText = "Teléfono";
                            dgvProveedores.Columns["fecha_registro"].HeaderText = "Registro";
                            dgvProveedores.Columns["estado"].HeaderText = "Estado";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar los datos de Proveedores: " + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadSelectedProveedor()
        {
            if (dgvProveedores.SelectedRows.Count == 0 || dgvProveedores.DataSource == null)
            {
                return;
            }

            DataGridViewRow selectedRow = dgvProveedores.SelectedRows[0];
            
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
            // ASSIGN DATA TO UI CONTROLS (Based on UI image)
            // ----------------------------------------------------
            
            txtNombre.Text = GetSafeString("nombre_empresa");
            txtContacto.Text = GetSafeString("contacto_nombre");
            txtTelefono.Text = GetSafeString("telefono");
            txtDireccion.Text = GetSafeString("direccion");
            
            string estado = GetSafeString("estado");
            chkActivo.Checked = estado.ToUpper() == "ACTIVO";
        }

        private void ClearFormControls()
        {
            txtNombre.Clear();
            txtContacto.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            chkActivo.Checked = true; // Default to 'Activo'
            txtNombre.Focus();
        }

        private void SetControlsState(FormState state)
        {
            bool isEditingOrNew = (state == FormState.New || state == FormState.Editing);
            
            // UI Controls (text boxes)
            txtNombre.ReadOnly = !isEditingOrNew;
            txtContacto.ReadOnly = !isEditingOrNew;
            txtTelefono.ReadOnly = !isEditingOrNew;
            txtDireccion.ReadOnly = !isEditingOrNew;
            chkActivo.Enabled = isEditingOrNew;

            // Action Buttons
            btnNuevo.Enabled = !isEditingOrNew;
            btnEditar.Enabled = !isEditingOrNew;
            btnGuardar.Enabled = isEditingOrNew;
            btnEliminar.Enabled = !isEditingOrNew;

            if (state == FormState.Viewing && dgvProveedores.SelectedRows.Count > 0)
            {
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

        private void dgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            LoadSelectedProveedor();
            SetControlsState(currentState); // If you have SetControlsState defined
        }

        private void lblDireccion_Click(object sender, EventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            LoadProveedoresData(txtBuscar.Text);
            currentState = FormState.Viewing;
            SetControlsState(currentState);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            LoadProveedoresData();
            ClearFormControls();
            currentState = FormState.Viewing;
            SetControlsState(currentState);
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

        private void lblContacto_Click(object sender, EventArgs e)
        {

        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTelefono_Click(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkActivo_CheckedChanged(object sender, EventArgs e)
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
            if (dgvProveedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un proveedor para editar.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            currentState = FormState.Editing;
            
            SetControlsState(currentState);
            
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (currentState == FormState.Viewing) return;

                // --- 1. Validation ---
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("El nombre de la empresa es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return; 
                }
                
                // --- 2. Determine SQL Query ---
                string query = "";
                if (currentState == FormState.New)
                {
                    query = @"INSERT INTO dbo.PROVEEDORES 
                            (nombre_empresa, contacto_nombre, direccion, telefono, tipo_insumo, estado)
                            VALUES 
                            (@nombre, @contacto, @direccion, @telefono, @insumo, @estado)";
                }
                else if (currentState == FormState.Editing)
                {
                    query = @"UPDATE dbo.PROVEEDORES SET 
                            nombre_empresa = @nombre, contacto_nombre = @contacto, direccion = @direccion, 
                            telefono = @telefono, tipo_insumo = @insumo, estado = @estado
                            WHERE id_proveedor = @id";
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // --- 3. Add Parameters ---
                        command.Parameters.AddWithValue("@nombre", txtNombre.Text);
                        command.Parameters.AddWithValue("@contacto", txtContacto.Text);
                        command.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                        command.Parameters.AddWithValue("@telefono", txtTelefono.Text); 
                        
                        command.Parameters.AddWithValue("@estado", chkActivo.Checked ? "ACTIVO" : "INACTIVO");

                        command.Parameters.AddWithValue("@insumo", "semillas");

                        if (currentState == FormState.Editing)
                        {
                            // Get the ID from the currently selected row
                            object idValue = dgvProveedores.SelectedRows[0].Cells["id_proveedor"].Value;
                            command.Parameters.AddWithValue("@id", idValue);
                        }

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                string action = (currentState == FormState.New) ? "guardado" : "actualizado";
                                MessageBox.Show($"Proveedor {action} exitosamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                
                                // Reset state and refresh
                                ClearFormControls();
                                LoadProveedoresData(); 
                                currentState = FormState.Viewing; 
                                SetControlsState(currentState);
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
            if (dgvProveedores.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar un proveedor para eliminar.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                // --- 1. Get ID and Name for Confirmation ---
                object idValue = dgvProveedores.SelectedRows[0].Cells["id_proveedor"].Value;
                string nombre = dgvProveedores.SelectedRows[0].Cells["nombre_empresa"].Value.ToString();

                // --- 2. Confirmation ---
                DialogResult result = MessageBox.Show($"¿Está seguro que desea eliminar al proveedor '{nombre}' (ID: {idValue})? Esta acción no se puede deshacer.", 
                                                    "Confirmar Eliminación", 
                                                    MessageBoxButtons.YesNo, 
                                                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return; // User cancelled the operation
                }

                // --- 3. Execute SQL DELETE ---
                string query = "DELETE FROM dbo.PROVEEDORES WHERE id_proveedor = @id";

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
                                MessageBox.Show("Proveedor eliminado exitosamente.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                
                                // --- 4. Cleanup and Refresh ---
                                ClearFormControls();
                                LoadProveedoresData();
                                currentState = FormState.Viewing;
                                SetControlsState(currentState);
                            }
                            else
                            {
                                MessageBox.Show("No se encontró el proveedor para eliminar o la operación falló.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error de Base de Datos al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
