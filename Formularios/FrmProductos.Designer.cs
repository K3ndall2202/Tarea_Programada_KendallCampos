using System.Drawing;
using System.Windows.Forms;

namespace Tarea_Programada_KendallCampos.Formularios;

partial class FrmProductos
{
    private System.ComponentModel.IContainer? components = null;
    private Label lblTitulo = null!;
    private Label lblNombre = null!;
    private TextBox txtNombre = null!;
    private Label lblPrecio = null!;
    private TextBox txtPrecio = null!;
    private Label lblStock = null!;
    private TextBox txtStock = null!;
    private Label lblCategoria = null!;
    private ComboBox cmbCategoria = null!;
    private Label lblBuscar = null!;
    private TextBox txtBuscar = null!;
    private Button btnBuscar = null!;
    private Button btnMostrarTodos = null!;
    private Button btnGuardar = null!;
    private Button btnModificar = null!;
    private Button btnEliminar = null!;
    private Button btnLimpiar = null!;
    private DataGridView dgvProductos = null!;
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
        Text = "Sistema de Gestión de Productos - Productos";
        Name = "FrmProductos";
        ClientSize = new Size(1050, 705);
        StartPosition = FormStartPosition.CenterParent;
        Font = new Font("Segoe UI", 10F);
        MinimumSize = new Size(1060, 740);
        lblTitulo = new Label();
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Text = "GESTIÓN DE PRODUCTOS";
        lblTitulo.Location = new Point(25, 14);
        lblTitulo.Size = new Size(550, 40);
        lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        Controls.Add(lblTitulo);
        lblNombre = new Label();
        lblNombre.Name = "lblNombre";
        lblNombre.Text = "Nombre del producto:";
        lblNombre.Location = new Point(25, 76);
        lblNombre.Size = new Size(215, 28);
        
        Controls.Add(lblNombre);
        txtNombre = new TextBox();
        txtNombre.Name = "txtNombre";
        txtNombre.Text = "";
        txtNombre.Location = new Point(245, 72);
        txtNombre.Size = new Size(300, 31);
        
        Controls.Add(txtNombre);
        lblPrecio = new Label();
        lblPrecio.Name = "lblPrecio";
        lblPrecio.Text = "Precio (₡):";
        lblPrecio.Location = new Point(570, 76);
        lblPrecio.Size = new Size(145, 28);
        
        Controls.Add(lblPrecio);
        txtPrecio = new TextBox();
        txtPrecio.Name = "txtPrecio";
        txtPrecio.Text = "";
        txtPrecio.Location = new Point(720, 72);
        txtPrecio.Size = new Size(230, 31);
        
        Controls.Add(txtPrecio);
        lblStock = new Label();
        lblStock.Name = "lblStock";
        lblStock.Text = "Stock:";
        lblStock.Location = new Point(25, 123);
        lblStock.Size = new Size(215, 28);
        
        Controls.Add(lblStock);
        txtStock = new TextBox();
        txtStock.Name = "txtStock";
        txtStock.Text = "";
        txtStock.Location = new Point(245, 119);
        txtStock.Size = new Size(300, 31);
        
        Controls.Add(txtStock);
        lblCategoria = new Label();
        lblCategoria.Name = "lblCategoria";
        lblCategoria.Text = "Categoría:";
        lblCategoria.Location = new Point(570, 123);
        lblCategoria.Size = new Size(145, 28);
        
        Controls.Add(lblCategoria);
        cmbCategoria = new ComboBox();
        cmbCategoria.Name = "cmbCategoria";
        cmbCategoria.Text = "";
        cmbCategoria.Location = new Point(720, 119);
        cmbCategoria.Size = new Size(230, 31);
        cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
        Controls.Add(cmbCategoria);
        btnGuardar = new Button();
        btnGuardar.Name = "btnGuardar";
        btnGuardar.Text = "Guardar";
        btnGuardar.Location = new Point(25, 181);
        btnGuardar.Size = new Size(175, 39);
        
        Controls.Add(btnGuardar);
        btnModificar = new Button();
        btnModificar.Name = "btnModificar";
        btnModificar.Text = "Modificar";
        btnModificar.Location = new Point(225, 181);
        btnModificar.Size = new Size(175, 39);
        
        Controls.Add(btnModificar);
        btnEliminar = new Button();
        btnEliminar.Name = "btnEliminar";
        btnEliminar.Text = "Eliminar";
        btnEliminar.Location = new Point(425, 181);
        btnEliminar.Size = new Size(175, 39);
        
        Controls.Add(btnEliminar);
        btnLimpiar = new Button();
        btnLimpiar.Name = "btnLimpiar";
        btnLimpiar.Text = "Limpiar";
        btnLimpiar.Location = new Point(625, 181);
        btnLimpiar.Size = new Size(175, 39);
        
        Controls.Add(btnLimpiar);
        lblBuscar = new Label();
        lblBuscar.Name = "lblBuscar";
        lblBuscar.Text = "Buscar producto:";
        lblBuscar.Location = new Point(25, 257);
        lblBuscar.Size = new Size(185, 28);
        
        Controls.Add(lblBuscar);
        txtBuscar = new TextBox();
        txtBuscar.Name = "txtBuscar";
        txtBuscar.Text = "";
        txtBuscar.Location = new Point(205, 252);
        txtBuscar.Size = new Size(365, 31);
        
        Controls.Add(txtBuscar);
        btnBuscar = new Button();
        btnBuscar.Name = "btnBuscar";
        btnBuscar.Text = "Buscar";
        btnBuscar.Location = new Point(590, 248);
        btnBuscar.Size = new Size(160, 38);
        
        Controls.Add(btnBuscar);
        btnMostrarTodos = new Button();
        btnMostrarTodos.Name = "btnMostrarTodos";
        btnMostrarTodos.Text = "Mostrar todos";
        btnMostrarTodos.Location = new Point(765, 248);
        btnMostrarTodos.Size = new Size(180, 38);
        
        Controls.Add(btnMostrarTodos);
        dgvProductos = new DataGridView();
        dgvProductos.Name = "dgvProductos";
        dgvProductos.Text = "";
        dgvProductos.Location = new Point(25, 306);
        dgvProductos.Size = new Size(995, 345);
        dgvProductos.ReadOnly = true;
        dgvProductos.MultiSelect = false;
        dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvProductos.AllowUserToAddRows = false;
        dgvProductos.AllowUserToDeleteRows = false;
        dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvProductos.RowHeadersVisible = false;
        Controls.Add(dgvProductos);
        errorProvider1 = new ErrorProvider(components);
        errorProvider1.ContainerControl = this;
        btnGuardar.Click += btnGuardar_Click;
        btnModificar.Click += btnModificar_Click;
        btnEliminar.Click += btnEliminar_Click;
        btnLimpiar.Click += btnLimpiar_Click;
        btnBuscar.Click += btnBuscar_Click;
        btnMostrarTodos.Click += btnMostrarTodos_Click;
        dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;
        ResumeLayout(false);
        PerformLayout();
    }
}
