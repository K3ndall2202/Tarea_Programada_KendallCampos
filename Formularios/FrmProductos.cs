using Tarea_Programada_KendallCampos.Logica;
using Tarea_Programada_KendallCampos.Modelos;

namespace Tarea_Programada_KendallCampos.Formularios;

public partial class FrmProductos : Form
{
    private readonly GestionServicio servicio;
    private int idSeleccionado;
    private bool actualizandoTabla;

    // Constructor sin parámetros para abrir el diseñador de Visual Studio.
    public FrmProductos() : this(new GestionServicio(new Datos.RepositorioTemporal())) { }

    public FrmProductos(GestionServicio servicio)
    {
        InitializeComponent();
        this.servicio = servicio;
        CargarCategorias();
        CargarProductos(servicio.ObtenerProductos());
        this.Shown += (s, e) => { dgvProductos.ClearSelection(); LimpiarCampos(); };
    }
    private void CargarCategorias()
    {
        cmbCategoria.DataSource = servicio.ObtenerCategorias();
        cmbCategoria.DisplayMember = "Nombre";
        cmbCategoria.ValueMember = "IdCategoria";
        cmbCategoria.SelectedIndex = -1;
    }
    private void CargarProductos(List<Producto> productos)
    {
        var categorias = servicio.ObtenerCategorias();
        actualizandoTabla = true;
        dgvProductos.DataSource = productos.Select(p => new
        {
            p.IdProducto, p.Nombre, p.Precio, p.Stock,
            p.FechaRegistro,
            Categoria = categorias.FirstOrDefault(c => c.IdCategoria == p.IdCategoria)?.Nombre ?? "Sin categoría",
            p.ValorInventario,
            p.IdCategoria
        }).ToList();
        if (dgvProductos.Columns.Contains("IdProducto")) dgvProductos.Columns["IdProducto"].HeaderText = "ID";
        if (dgvProductos.Columns.Contains("FechaRegistro")) dgvProductos.Columns["FechaRegistro"].HeaderText = "Fecha de registro";
        if (dgvProductos.Columns.Contains("ValorInventario")) dgvProductos.Columns["ValorInventario"].HeaderText = "Valor del inventario";
        if (dgvProductos.Columns.Contains("IdCategoria")) dgvProductos.Columns["IdCategoria"].Visible = false;
        if (dgvProductos.Columns.Contains("Precio")) dgvProductos.Columns["Precio"].DefaultCellStyle.Format = "N2";
        if (dgvProductos.Columns.Contains("ValorInventario")) dgvProductos.Columns["ValorInventario"].DefaultCellStyle.Format = "N2";
        if (dgvProductos.Columns.Contains("FechaRegistro")) dgvProductos.Columns["FechaRegistro"].DefaultCellStyle.Format = "g";
        dgvProductos.ClearSelection();
        actualizandoTabla = false;
    }
    private void LimpiarCampos()
    {
        idSeleccionado = 0;
        txtNombre.Clear();
        txtPrecio.Clear();
        txtStock.Clear();
        cmbCategoria.SelectedIndex = -1;
        errorProvider1.Clear();
        dgvProductos.ClearSelection();
        txtNombre.Focus();
    }
    private bool ValidarCampos()
    {
        errorProvider1.Clear();
        bool correcto = true;
        if (string.IsNullOrWhiteSpace(txtNombre.Text))
        { errorProvider1.SetError(txtNombre, "Ingrese el nombre del producto."); correcto = false; }
        if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
        { errorProvider1.SetError(txtPrecio, "El precio debe ser mayor que cero."); correcto = false; }
        if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
        { errorProvider1.SetError(txtStock, "El stock debe ser cero o mayor."); correcto = false; }
        if (cmbCategoria.SelectedItem is not Categoria)
        { errorProvider1.SetError(cmbCategoria, "Seleccione una categoría."); correcto = false; }
        if (!correcto) MessageBox.Show("Revise los campos señalados.", "Advertencia",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return correcto;
    }
    private int CategoriaElegida() => cmbCategoria.SelectedItem is Categoria c ? c.IdCategoria : 0;
    private void MostrarError(Exception ex) => MessageBox.Show(ex.Message, "Advertencia",
        MessageBoxButtons.OK, MessageBoxIcon.Warning);

    private void btnGuardar_Click(object? sender, EventArgs e)
    {
        if (!ValidarCampos()) return;
        try
        {
            servicio.GuardarProducto(txtNombre.Text, txtPrecio.Text, txtStock.Text, CategoriaElegida());
            CargarProductos(servicio.ObtenerProductos());
            LimpiarCampos();
            MessageBox.Show("Producto registrado correctamente.", "Información");
        }
        catch (Exception ex) { MostrarError(ex); }
    }
    private void btnModificar_Click(object? sender, EventArgs e)
    {
        if (idSeleccionado == 0) { MessageBox.Show("Seleccione un producto de la tabla."); return; }
        if (!ValidarCampos()) return;
        try
        {
            servicio.ModificarProducto(idSeleccionado, txtNombre.Text, txtPrecio.Text,
                txtStock.Text, CategoriaElegida());
            CargarProductos(servicio.ObtenerProductos());
            LimpiarCampos();
            MessageBox.Show("Producto modificado correctamente.", "Información");
        }
        catch (Exception ex) { MostrarError(ex); }
    }
    private void btnEliminar_Click(object? sender, EventArgs e)
    {
        if (idSeleccionado == 0) { MessageBox.Show("Seleccione un producto de la tabla."); return; }
        if (MessageBox.Show("¿Desea eliminar este producto?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
        try
        {
            servicio.EliminarProducto(idSeleccionado);
            CargarProductos(servicio.ObtenerProductos());
            LimpiarCampos();
            MessageBox.Show("Producto eliminado correctamente.", "Información");
        }
        catch (Exception ex) { MostrarError(ex); }
    }
    private void btnLimpiar_Click(object? sender, EventArgs e) => LimpiarCampos();
    private void btnBuscar_Click(object? sender, EventArgs e)
    {
        var encontrados = servicio.BuscarProductos(txtBuscar.Text);
        CargarProductos(encontrados);
        LimpiarCampos();
        if (encontrados.Count == 0) MessageBox.Show("No se encontraron productos.", "Búsqueda");
    }
    private void btnMostrarTodos_Click(object? sender, EventArgs e)
    {
        txtBuscar.Clear();
        CargarProductos(servicio.ObtenerProductos());
        LimpiarCampos();
    }
    private void dgvProductos_SelectionChanged(object? sender, EventArgs e)
    {
        if (actualizandoTabla || dgvProductos.SelectedRows.Count == 0 || dgvProductos.CurrentRow == null) return;
        var r = dgvProductos.CurrentRow;
        if (r.Cells["IdProducto"].Value == null) return;
        idSeleccionado = Convert.ToInt32(r.Cells["IdProducto"].Value);
        txtNombre.Text = Convert.ToString(r.Cells["Nombre"].Value) ?? "";
        txtPrecio.Text = Convert.ToString(r.Cells["Precio"].Value) ?? "";
        txtStock.Text = Convert.ToString(r.Cells["Stock"].Value) ?? "";
        cmbCategoria.SelectedValue = Convert.ToInt32(r.Cells["IdCategoria"].Value);
        errorProvider1.Clear();
    }
}
