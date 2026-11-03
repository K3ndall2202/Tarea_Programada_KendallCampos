using Tarea_Programada_KendallCampos.Modelos;

namespace Tarea_Programada_KendallCampos.Datos;

// Punto de sustitución para que el estudiante integre SQL Server posteriormente.
// Esta interfaz no crea conexiones ni contiene instrucciones SQL.
public interface IRepositorio
{
    List<Categoria> ObtenerCategorias();
    void GuardarCategoria(Categoria categoria);
    void ActualizarCategoria(Categoria categoria);
    void EliminarCategoria(int id);
    List<Producto> ObtenerProductos();
    void GuardarProducto(Producto producto);
    void ActualizarProducto(Producto producto);
    void EliminarProducto(int id);
}
