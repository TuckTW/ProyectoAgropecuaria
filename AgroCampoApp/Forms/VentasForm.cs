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
    
    public partial class VentasForm : Form
    {
        private string connectionString = "Data Source=TUCKER_LAPTOP; Initial Catalog=AgroCampoSA; Integrated Security=True; Encrypt=True; TrustServerCertificate=True;";
        private enum FormState { Viewing, New, Editing }
        private const decimal TAX_RATE = 0.07m;
        private DataTable detalleVentaTemporal;
        private DataTable productData;
        private FormState currentState = FormState.New;

        public VentasForm()
        {
            InitializeComponent();
            SetupVentaDetailGrid();
            LoadProductosToComboBox();
            LoadClientesToComboBox();
            LoadVentasEstados();
            ResetFormForNewSale();
        }

        private void SetupVentaDetailGrid()
        {
            if (detalleVentaTemporal == null)
            {
                detalleVentaTemporal = new DataTable();
                detalleVentaTemporal.Columns.Add("id_producto", typeof(int));
                detalleVentaTemporal.Columns.Add("nombre_producto", typeof(string));
                detalleVentaTemporal.Columns.Add("cantidad", typeof(decimal));
                detalleVentaTemporal.Columns.Add("precio_unitario", typeof(decimal));
                detalleVentaTemporal.Columns.Add("subtotal", typeof(decimal)); // Quantity * Price
                detalleVentaTemporal.Columns.Add("impuesto", typeof(decimal)); // Subtotal * TAX_RATE
                detalleVentaTemporal.Columns.Add("total_linea", typeof(decimal)); // Subtotal + Tax
            }
            
            dgvVentas.DataSource = detalleVentaTemporal;

            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect; 
            dgvVentas.MultiSelect = false;

            if (dgvVentas.Columns.Count > 0)
            {
                dgvVentas.Columns["id_producto"].Visible = false;
                dgvVentas.Columns["nombre_producto"].HeaderText = "Producto";
                dgvVentas.Columns["cantidad"].DefaultCellStyle.Format = "N2";
                dgvVentas.Columns["precio_unitario"].HeaderText = "Precio Unit.";
                dgvVentas.Columns["precio_unitario"].DefaultCellStyle.Format = "C2";
                dgvVentas.Columns["subtotal"].HeaderText = "Subtotal";
                dgvVentas.Columns["subtotal"].DefaultCellStyle.Format = "C2";
                dgvVentas.Columns["impuesto"].HeaderText = "Impuesto";
                dgvVentas.Columns["impuesto"].DefaultCellStyle.Format = "C2";
                dgvVentas.Columns["total_linea"].HeaderText = "Total Línea";
                dgvVentas.Columns["total_linea"].DefaultCellStyle.Format = "C2";
            }
        }

        private void LoadProductosToComboBox()
        {
            string query = @"SELECT 
                                 id_producto, 
                                 nombre AS nombre_producto, 
                                 precio_unitario AS precio_venta 
                             FROM dbo.PRODUCTOS 
                             WHERE estado = 'ACTIVO'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    
                    productData = new DataTable();
                    adapter.Fill(productData);     

                    comboBox1.DataSource = productData;
                    comboBox1.DisplayMember = "nombre_producto";
                    comboBox1.ValueMember = "id_producto";
                    comboBox1.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar productos: " + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadClientesToComboBox()
        {
            string query = "SELECT id_cliente, nombre FROM dbo.CLIENTES WHERE estado = 'ACTIVO'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbCliente.DataSource = dt;
                    cmbCliente.DisplayMember = "nombre";
                    cmbCliente.ValueMember = "id_cliente";
                    cmbCliente.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void LoadVentasEstados()
        {
            string query = "SELECT DISTINCT estado_venta FROM dbo.VENTAS ORDER BY estado_venta";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable estadosTable = new DataTable();
                    adapter.Fill(estadosTable);

                    DataRow emptyRow = estadosTable.NewRow();
                    emptyRow["estado_venta"] = " (Todos)"; 
                    estadosTable.Rows.InsertAt(emptyRow, 0);

                    cmbEstadoVentas.DataSource = estadosTable;
                    cmbEstadoVentas.DisplayMember = "estado_venta";
                    cmbEstadoVentas.ValueMember = "estado_venta";
                    cmbEstadoVentas.SelectedIndex = 0; // Select (Todos) by default
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar estados de venta: " + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RecalculateTotals()
        {
            decimal subtotalGeneral = 0m;

            if (detalleVentaTemporal != null)
            {
                foreach (DataRow row in detalleVentaTemporal.Rows)
                {
                    if (row["total_linea"] != DBNull.Value)
                    {
                        subtotalGeneral += Convert.ToDecimal(row["total_linea"]);
                    }
                }
            }

            decimal impuestoGeneral = subtotalGeneral * TAX_RATE;
            decimal totalFinal = subtotalGeneral + impuestoGeneral;

            // Update display fields (assuming you have these textboxes)
            // txtSubtotal.Text = subtotalGeneral.ToString("N2");
            // txtImpuesto.Text = impuestoGeneral.ToString("N2");
            txtTotal.Text = totalFinal.ToString("N2");
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null || comboBox1.SelectedIndex == -1)
            {
                nudPrecio.Value = 0m;
                return;
            }

            try
            {
                int selectedProductId = Convert.ToInt32(comboBox1.SelectedValue);

                DataRow[] rows = productData.Select($"id_producto = {selectedProductId}");

                if (rows.Length > 0)
                {
                    object priceValue = rows[0]["precio_venta"];
            
                    if (priceValue != DBNull.Value)
                    {
                        decimal price = Convert.ToDecimal(priceValue);
                        nudPrecio.Value = price;
                    }
                    else
                    {
                        nudPrecio.Value = 0m;
                    }
                }
                else
                {
                    nudPrecio.Value = 0m;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener precio del producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nudPrecio.Value = 0m;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (currentState != FormState.New)
            {
                ResetFormForNewSale();
            }

            if (comboBox1.SelectedValue == null || nudCantidad.Value <= 0)
            {
                MessageBox.Show("Debe seleccionar un producto y especificar una cantidad válida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idProducto = Convert.ToInt32(comboBox1.SelectedValue);
                string nombreProducto = comboBox1.Text;
                decimal cantidad = nudCantidad.Value;
                decimal precioUnitario = nudPrecio.Value;

                // Calculations
                decimal subtotal = cantidad * precioUnitario;
                decimal impuesto = subtotal * TAX_RATE;
                decimal totalLinea = subtotal + impuesto;

                // Add to temporary table
                DataRow newRow = detalleVentaTemporal.NewRow();
                newRow["id_producto"] = idProducto;
                newRow["nombre_producto"] = nombreProducto;
                newRow["cantidad"] = cantidad;
                newRow["precio_unitario"] = precioUnitario;
                newRow["subtotal"] = subtotal;
                newRow["impuesto"] = impuesto;
                newRow["total_linea"] = totalLinea;
                detalleVentaTemporal.Rows.Add(newRow);

                RecalculateTotals();

                comboBox1.SelectedIndex = -1;
                nudCantidad.Value = 1m;
                nudPrecio.Value = 0m;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvVentas.SelectedRows.Count > 0)
            {
                try
                {
                    if (currentState != FormState.New)
                    {
                        MessageBox.Show("Solo puede quitar productos de una nueva venta antes de guardarla.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    
                    DataRowView drv = (DataRowView)dgvVentas.SelectedRows[0].DataBoundItem;
                    drv.Delete();

                    RecalculateTotals();
                    
                    MessageBox.Show("Producto eliminado del detalle de venta.", "Quitar Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al quitar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila para poder quitarla.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBuscarVenta_Click(object sender, EventArgs e)
        {
            currentState = FormState.Viewing; 
            
            int? clientId = null;
            if (cmbCliente?.SelectedValue != null && cmbCliente.SelectedIndex != -1)
            {
                if (int.TryParse(cmbCliente.SelectedValue.ToString(), out int id))
                {
                    clientId = id;
                }
            }
            
            DateTime date = dtpFecha.Value.Date; 
            
            string estado = cmbEstadoVentas?.SelectedValue?.ToString();

            if (estado != null && estado.Trim() == "(Todos)")
            {
                estado = null; // Treat as no filter applied
            }
            
            LoadVentasHeader(clientId, date, estado);
        }

        private void LoadVentasHeader(int? clientId = null, DateTime? date = null, string estado = null)
        {
            if (currentState == FormState.New) return; 

            string whereClause = " WHERE 1=1";
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (clientId.HasValue)
            {
                whereClause += " AND V.id_cliente = @clientId";
                parameters.Add(new SqlParameter("@clientId", clientId.Value));
            }
            
            if (date.HasValue)
            {
                whereClause += " AND CAST(V.fecha_venta AS DATE) = @fechaVenta";
                parameters.Add(new SqlParameter("@fechaVenta", date.Value.Date));
            }

            if (!string.IsNullOrWhiteSpace(estado))
            {
                whereClause += " AND V.estado_venta = @estado";
                parameters.Add(new SqlParameter("@estado", estado));
            }

            string query = @"
                SELECT 
                    V.id_venta, 
                    C.nombre AS NombreCliente, 
                    V.fecha_venta, 
                    V.total_venta, 
                    V.estado_venta
                FROM dbo.VENTAS V
                JOIN dbo.CLIENTES C ON V.id_cliente = C.id_cliente" 
                + whereClause + " ORDER BY V.id_venta DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters.ToArray());

                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable ventasTable = new DataTable();
                        adapter.Fill(ventasTable);
                        
                        dgvVentas.DataSource = ventasTable; 
                        
                        if (dgvVentas.Columns.Contains("total_venta")) 
                        {
                            dgvVentas.Columns["total_venta"].HeaderText = "Total";
                            dgvVentas.Columns["total_venta"].DefaultCellStyle.Format = "C2";
                        }
        }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al buscar ventas: " + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void ResetFormForNewSale()
        {
            currentState = FormState.New;

            cmbCliente.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Now;
            cmbEstadoVentas.Text = "NUEVA"; 
            
            comboBox1.SelectedIndex = -1;
            nudCantidad.Value = 1m;
            nudPrecio.Value = 0m;

            if (detalleVentaTemporal != null)
            {
                detalleVentaTemporal.Clear();
            }

            // Clear Totals (assuming these textboxes exist)
            txtTotal.Text = "0.00";
            // txtSubtotal.Text = "0.00"; 
            // txtImpuesto.Text = "0.00"; 

            dgvVentas.DataSource = detalleVentaTemporal;
            
            SetupVentaDetailGrid(); 
        }

        private bool GuardarVenta()
        {
            if (cmbCliente.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (detalleVentaTemporal == null || detalleVentaTemporal.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto al detalle de venta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            int idCliente = Convert.ToInt32(cmbCliente.SelectedValue);
            DateTime fechaVenta = dtpFecha.Value;
            decimal totalVenta = Convert.ToDecimal(txtTotal.Text);
            string estadoVenta = cmbEstadoVentas.Text;
            string metodoPago = "EFECTIVO";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    string headerQuery = @"
                        INSERT INTO dbo.VENTAS (id_cliente, fecha_venta, total_venta, estado_venta, metodo_pago)
                        OUTPUT INSERTED.id_venta
                        VALUES (@idCliente, @fechaVenta, @totalVenta, @estadoVenta, @metodoPago)";
                    
                    int newIdVenta = 0;

                    using (SqlCommand headerCommand = new SqlCommand(headerQuery, connection, transaction))
                    {
                        headerCommand.Parameters.AddWithValue("@idCliente", idCliente);
                        headerCommand.Parameters.AddWithValue("@fechaVenta", fechaVenta);
                        headerCommand.Parameters.AddWithValue("@totalVenta", totalVenta);
                        headerCommand.Parameters.AddWithValue("@estadoVenta", estadoVenta);
                        headerCommand.Parameters.AddWithValue("@metodoPago", metodoPago);
                        
                        object result = headerCommand.ExecuteScalar();
                        if (result != null)
                        {
                            newIdVenta = Convert.ToInt32(result);
                        }
                        else
                        {
                            throw new Exception("Error al obtener id_venta insertado.");
                        }
                    }

                    string detailQuery = @"
                        INSERT INTO dbo.DETALLE_VENTA (id_venta, id_producto, cantidad, precio_unitario, subtotal)
                        VALUES (@idVenta, @idProducto, @cantidad, @precioUnitario, @subtotal)";

                    foreach (DataRow row in detalleVentaTemporal.Rows)
                    {
                        using (SqlCommand detailCommand = new SqlCommand(detailQuery, connection, transaction))
                        {
                            detailCommand.Parameters.AddWithValue("@idVenta", newIdVenta);
                            // Column names MUST match the structure of detalleVentaTemporal
                            detailCommand.Parameters.AddWithValue("@idProducto", row["id_producto"]);
                            detailCommand.Parameters.AddWithValue("@cantidad", row["cantidad"]);
                            detailCommand.Parameters.AddWithValue("@precioUnitario", row["precio_unitario"]);
                            detailCommand.Parameters.AddWithValue("@subtotal", row["subtotal"]);
                            
                            detailCommand.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error al guardar la venta: " + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private void btnGuardarVenta_Click(object sender, EventArgs e)
        {
            if (GuardarVenta())
            {
                MessageBox.Show("Venta guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetFormForNewSale();
            }
        }
        
        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
