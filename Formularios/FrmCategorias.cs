using Tarea_Programada_KendallCampos.Logica;
using Tarea_Programada_KendallCampos.Modelos;

namespace Tarea_Programada_KendallCampos.Formularios;

public partial class FrmCategorias : Form
{
    private readonly GestionServicio servicio;
    private int idSeleccionado;
    private bool actualizandoTabla;

    // Constructor sin parámetros para abrir el diseñador de Visual Studio.
    public FrmCategorias() : this(new GestionServicio(new Datos.RepositorioTemporal())) { }

    public FrmCategorias(GestionServicio servicio)
    {
        InitializeComponent();
        this.servicio = servicio;
        CargarCategorias();
        this.Shown += (s, e) => { dgvCategorias.ClearSelection(); LimpiarCampos(); };
    }

    private void CargarCategorias()
    {
        actualizandoTabla = true;
        dgvCategorias.DataSource = servicio.ObtenerCategorias();
        if (dgvCategorias.Columns.Contains("IdCategoria"))
            dgvCategorias.Columns["IdCategoria"].HeaderText = "ID";
        if (dgvCategorias.Columns.Contains("Nombre"))
            dgvCategorias.Columns["Nombre"].HeaderText = "Nombre";
        if (dgvCategorias.Columns.Contains("Descripcion"))
            dgvCategorias.Columns["Descripcion"].HeaderText = "Descripción";
        dgvCategorias.ClearSelection();
        actualizandoTabla = false;
    }
    private void MostrarError(Exception ex)
    {
        if (ex is Microsoft.Data.SqlClient.SqlException error && error.Number == 547)
        {
            MessageBox.Show(
                "No se puede eliminar esta categoría porque tiene productos asociados.",
                "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
        else
        {
            MessageBox.Show(
                ex.Message,
                "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }
    private void LimpiarCampos()
    {
        idSeleccionado = 0;
        txtNombre.Clear();
        txtDescripcion.Clear();
        errorProvider1.Clear();
        dgvCategorias.ClearSelection();
        txtNombre.Focus();
    }
    private bool ValidarCampos()
    {
        errorProvider1.Clear();
        bool correcto = true;
        if (string.IsNullOrWhiteSpace(txtNombre.Text))
        {
            errorProvider1.SetError(txtNombre, "Ingrese el nombre.");
            correcto = false;
        }
        if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
        {
            errorProvider1.SetError(txtDescripcion, "Ingrese una descripción.");
            correcto = false;
        }
        if (!correcto) MessageBox.Show("Complete los campos obligatorios.", "Advertencia",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return correcto;
    }
    private void btnGuardar_Click(object? sender, EventArgs e)
    {
        if (!ValidarCampos()) return;
        try
        {
            servicio.GuardarCategoria(txtNombre.Text, txtDescripcion.Text);
            CargarCategorias();
            LimpiarCampos();
            MessageBox.Show("Categoría registrada correctamente.", "Información");
        }
        catch (Exception ex) { MostrarError(ex); }
    }
    private void btnModificar_Click(object? sender, EventArgs e)
    {
        if (idSeleccionado == 0) { MessageBox.Show("Seleccione una categoría de la tabla."); return; }
        if (!ValidarCampos()) return;
        try
        {
            servicio.ModificarCategoria(idSeleccionado, txtNombre.Text, txtDescripcion.Text);
            CargarCategorias();
            LimpiarCampos();
            MessageBox.Show("Categoría modificada correctamente.", "Información");
        }
        catch (Exception ex) { MostrarError(ex); }
    }
    private void btnEliminar_Click(object? sender, EventArgs e)
    {
        if (idSeleccionado == 0) { MessageBox.Show("Seleccione una categoría de la tabla."); return; }
        if (MessageBox.Show("¿Desea eliminar esta categoría?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
        try
        {
            servicio.EliminarCategoria(idSeleccionado);
            CargarCategorias();
            LimpiarCampos();
            MessageBox.Show("Categoría eliminada correctamente.", "Información");
        }
        catch (Exception ex) { MostrarError(ex); }
    }
    private void btnLimpiar_Click(object? sender, EventArgs e) => LimpiarCampos();
    private void btnProductos_Click(object? sender, EventArgs e)
    {
        using var form = new FrmProductos(servicio);
        form.ShowDialog(this);
        CargarCategorias();
        LimpiarCampos();
    }
    private void dgvCategorias_SelectionChanged(object? sender, EventArgs e)
    {
        if (actualizandoTabla || dgvCategorias.CurrentRow?.DataBoundItem is not Categoria c ||
            dgvCategorias.SelectedRows.Count == 0) return;
        idSeleccionado = c.IdCategoria;
        txtNombre.Text = c.Nombre;
        txtDescripcion.Text = c.Descripcion;

        errorProvider1.Clear();
    }
}
