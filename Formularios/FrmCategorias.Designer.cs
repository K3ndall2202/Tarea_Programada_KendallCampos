using System.Drawing;
using System.Windows.Forms;

namespace Tarea_Programada_KendallCampos.Formularios;

partial class FrmCategorias
{
    private System.ComponentModel.IContainer? components = null;
    private Label lblTitulo = null!;
    private Label lblNombre = null!;
    private TextBox txtNombre = null!;
    private Label lblDescripcion = null!;
    private TextBox txtDescripcion = null!;
    private Button btnGuardar = null!;
    private Button btnModificar = null!;
    private Button btnEliminar = null!;
    private Button btnLimpiar = null!;
    private Button btnProductos = null!;
    private DataGridView dgvCategorias = null!;
    private ErrorProvider errorProvider1 = null!;
    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        SuspendLayout();
        Text = "Sistema de Gestión de Productos - Categorías";
        Name = "FrmCategorias";
        ClientSize = new Size(920, 610);
        StartPosition = FormStartPosition.CenterScreen;
        Font = new Font("Segoe UI", 10F);
        MinimumSize = new Size(920, 650);
        lblTitulo = new Label();
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Text = "GESTIÓN DE CATEGORÍAS";
        lblTitulo.Location = new Point(25, 18);
        lblTitulo.Size = new Size(450, 36);
        lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        Controls.Add(lblTitulo);
        lblNombre = new Label();
        lblNombre.Name = "lblNombre";
        lblNombre.Text = "Nombre de la categoría:";
        lblNombre.Location = new Point(25, 83);
        lblNombre.Size = new Size(220, 28);
        
        Controls.Add(lblNombre);
        txtNombre = new TextBox();
        txtNombre.Name = "txtNombre";
        txtNombre.Text = "";
        txtNombre.Location = new Point(250, 79);
        txtNombre.Size = new Size(425, 31);
        
        Controls.Add(txtNombre);
        lblDescripcion = new Label();
        lblDescripcion.Name = "lblDescripcion";
        lblDescripcion.Text = "Descripción:";
        lblDescripcion.Location = new Point(25, 133);
        lblDescripcion.Size = new Size(220, 28);
        
        Controls.Add(lblDescripcion);
        txtDescripcion = new TextBox();
        txtDescripcion.Name = "txtDescripcion";
        txtDescripcion.Text = "";
        txtDescripcion.Location = new Point(250, 129);
        txtDescripcion.Size = new Size(425, 31);
        
        Controls.Add(txtDescripcion);
        btnGuardar = new Button();
        btnGuardar.Name = "btnGuardar";
        btnGuardar.Text = "Guardar";
        btnGuardar.Location = new Point(25, 190);
        btnGuardar.Size = new Size(150, 42);
        
        Controls.Add(btnGuardar);
        btnModificar = new Button();
        btnModificar.Name = "btnModificar";
        btnModificar.Text = "Modificar";
        btnModificar.Location = new Point(200, 190);
        btnModificar.Size = new Size(150, 42);
        
        Controls.Add(btnModificar);
        btnEliminar = new Button();
        btnEliminar.Name = "btnEliminar";
        btnEliminar.Text = "Eliminar";
        btnEliminar.Location = new Point(375, 190);
        btnEliminar.Size = new Size(150, 42);
        
        Controls.Add(btnEliminar);
        btnLimpiar = new Button();
        btnLimpiar.Name = "btnLimpiar";
        btnLimpiar.Text = "Limpiar";
        btnLimpiar.Location = new Point(550, 190);
        btnLimpiar.Size = new Size(150, 42);
        
        Controls.Add(btnLimpiar);
        btnProductos = new Button();
        btnProductos.Name = "btnProductos";
        btnProductos.Text = "Ver productos";
        btnProductos.Location = new Point(725, 190);
        btnProductos.Size = new Size(150, 42);
        
        Controls.Add(btnProductos);
        dgvCategorias = new DataGridView();
        dgvCategorias.Name = "dgvCategorias";
        dgvCategorias.Text = "";
        dgvCategorias.Location = new Point(25, 255);
        dgvCategorias.Size = new Size(860, 310);
        dgvCategorias.ReadOnly = true;
        dgvCategorias.MultiSelect = false;
        dgvCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvCategorias.AllowUserToAddRows = false;
        dgvCategorias.AllowUserToDeleteRows = false;
        dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvCategorias.RowHeadersVisible = false;
        Controls.Add(dgvCategorias);
        errorProvider1 = new ErrorProvider(components);
        errorProvider1.ContainerControl = this;
        btnGuardar.Click += btnGuardar_Click;
        btnModificar.Click += btnModificar_Click;
        btnEliminar.Click += btnEliminar_Click;
        btnLimpiar.Click += btnLimpiar_Click;
        btnProductos.Click += btnProductos_Click;
        dgvCategorias.SelectionChanged += dgvCategorias_SelectionChanged;
        ResumeLayout(false);
        PerformLayout();
    }
}
