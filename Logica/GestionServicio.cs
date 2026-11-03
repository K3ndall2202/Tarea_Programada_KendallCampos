using Tarea_Programada_KendallCampos.Datos;
using Tarea_Programada_KendallCampos.Modelos;

namespace Tarea_Programada_KendallCampos.Logica;

// Reglas de negocio separadas de los eventos de Windows Forms.
public class GestionServicio
{
    private readonly IRepositorio repositorio;
    public GestionServicio(IRepositorio repositorio) { this.repositorio = repositorio; }

    public List<Categoria> ObtenerCategorias() => repositorio.ObtenerCategorias();
    public List<Producto> ObtenerProductos() => repositorio.ObtenerProductos();
    public List<Producto> BuscarProductos(string texto) => repositorio.ObtenerProductos()
        .Where(p => p.Nombre.Contains(texto.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();

    public void GuardarCategoria(string nombre, string descripcion)
    {
        ValidarCategoria(nombre, descripcion, 0);
        repositorio.GuardarCategoria(new Categoria { Nombre = nombre.Trim(), Descripcion = descripcion.Trim() });
    }
    public void ModificarCategoria(int id, string nombre, string descripcion)
    {
        ValidarCategoria(nombre, descripcion, id);
        repositorio.ActualizarCategoria(new Categoria { IdCategoria = id, Nombre = nombre.Trim(), Descripcion = descripcion.Trim() });
    }
    public void EliminarCategoria(int id) => repositorio.EliminarCategoria(id);
    private void ValidarCategoria(string nombre, string descripcion, int id)
    {
        if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(descripcion))
            throw new ArgumentException("Complete el nombre y la descripción de la categoría.");
        if (repositorio.ObtenerCategorias().Any(c => c.IdCategoria != id &&
            c.Nombre.Equals(nombre.Trim(), StringComparison.OrdinalIgnoreCase)))
            throw new ArgumentException("Ya existe una categoría con ese nombre.");
    }

    public void GuardarProducto(string nombre, string precioTexto, string stockTexto, int categoriaId)
    {
        var p = CrearProducto(0, nombre, precioTexto, stockTexto, categoriaId);
        p.FechaRegistro = DateTime.Now;
        repositorio.GuardarProducto(p);
    }
    public void ModificarProducto(int id, string nombre, string precioTexto, string stockTexto, int categoriaId)
    {
        var p = CrearProducto(id, nombre, precioTexto, stockTexto, categoriaId);
        repositorio.ActualizarProducto(p);
    }
    public void EliminarProducto(int id) => repositorio.EliminarProducto(id);
    private Producto CrearProducto(int id, string nombre, string precioTexto, string stockTexto, int categoriaId)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("Ingrese el nombre del producto.");
        if (!decimal.TryParse(precioTexto, out decimal precio) || precio <= 0)
            throw new ArgumentException("Ingrese un precio numérico mayor que cero.");
        if (!int.TryParse(stockTexto, out int stock) || stock < 0)
            throw new ArgumentException("Ingrese un stock numérico igual o mayor que cero.");
        if (categoriaId <= 0 || !repositorio.ObtenerCategorias().Any(c => c.IdCategoria == categoriaId))
            throw new ArgumentException("Seleccione una categoría válida.");
        return new Producto { IdProducto = id, Nombre = nombre.Trim(), Precio = precio,
            Stock = stock, IdCategoria = categoriaId };
    }
}
