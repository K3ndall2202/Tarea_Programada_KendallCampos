using Tarea_Programada_KendallCampos.Modelos;

namespace Tarea_Programada_KendallCampos.Datos;

// Almacén provisional en memoria: los cambios se pierden al cerrar el programa.
// NO configura ni abre conexiones a SQL Server.
public class RepositorioTemporal : IRepositorio
{
    private readonly List<Categoria> categorias = new();
    private readonly List<Producto> productos = new();
    private int siguienteCategoria = 1;
    private int siguienteProducto = 1;

    public RepositorioTemporal()
    {
        // Ejemplos temporales para practicar la interfaz, sin consultar la BD real.
        GuardarCategoria(new Categoria { Nombre = "Computación", Descripcion = "Equipos y componentes de computadora" });
        GuardarCategoria(new Categoria { Nombre = "Accesorios", Descripcion = "Accesorios para computadora" });
        GuardarCategoria(new Categoria { Nombre = "Impresión", Descripcion = "Impresoras y suministros" });
        GuardarCategoria(new Categoria { Nombre = "Redes", Descripcion = "Equipos y accesorios de red" });
        GuardarProducto(new Producto { Nombre = "Teclado", Precio = 8500, Stock = 15, IdCategoria = 2, FechaRegistro = DateTime.Now });
        GuardarProducto(new Producto { Nombre = "Mouse", Precio = 5500, Stock = 25, IdCategoria = 2, FechaRegistro = DateTime.Now });
        GuardarProducto(new Producto { Nombre = "Monitor", Precio = 95000, Stock = 8, IdCategoria = 1, FechaRegistro = DateTime.Now });
        GuardarProducto(new Producto { Nombre = "Impresora", Precio = 75000, Stock = 5, IdCategoria = 3, FechaRegistro = DateTime.Now });
        GuardarProducto(new Producto { Nombre = "Cable de red", Precio = 2500, Stock = 40, IdCategoria = 4, FechaRegistro = DateTime.Now });
        GuardarProducto(new Producto { Nombre = "Memoria USB", Precio = 6500, Stock = 20, IdCategoria = 2, FechaRegistro = DateTime.Now });
    }

    public List<Categoria> ObtenerCategorias() => categorias.Select(c => new Categoria
    { IdCategoria = c.IdCategoria, Nombre = c.Nombre, Descripcion = c.Descripcion }).ToList();
    public void GuardarCategoria(Categoria c) { c.IdCategoria = siguienteCategoria++; categorias.Add(c); }
    public void ActualizarCategoria(Categoria c)
    {
        var actual = categorias.FirstOrDefault(x => x.IdCategoria == c.IdCategoria)
            ?? throw new InvalidOperationException("La categoría ya no existe.");
        actual.Nombre = c.Nombre;
        actual.Descripcion = c.Descripcion;
    }
    public void EliminarCategoria(int id)
    {
        if (productos.Any(p => p.IdCategoria == id))
            throw new InvalidOperationException("No se puede eliminar una categoría que tiene productos asociados.");
        var c = categorias.FirstOrDefault(x => x.IdCategoria == id)
            ?? throw new InvalidOperationException("La categoría ya no existe.");
        categorias.Remove(c);
    }

    public List<Producto> ObtenerProductos() => productos.Select(p => new Producto
    {
        IdProducto = p.IdProducto, Nombre = p.Nombre, Precio = p.Precio,
        Stock = p.Stock, FechaRegistro = p.FechaRegistro, IdCategoria = p.IdCategoria
    }).ToList();
    public void GuardarProducto(Producto p) { p.IdProducto = siguienteProducto++; productos.Add(p); }
    public void ActualizarProducto(Producto p)
    {
        var actual = productos.FirstOrDefault(x => x.IdProducto == p.IdProducto)
            ?? throw new InvalidOperationException("El producto ya no existe.");
        actual.Nombre = p.Nombre;
        actual.Precio = p.Precio;
        actual.Stock = p.Stock;
        actual.IdCategoria = p.IdCategoria;
        // No se modifica la fecha original de registro.
    }
    public void EliminarProducto(int id)
    {
        var p = productos.FirstOrDefault(x => x.IdProducto == id)
            ?? throw new InvalidOperationException("El producto ya no existe.");
        productos.Remove(p);
    }
}
