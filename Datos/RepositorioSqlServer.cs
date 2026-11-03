
using Microsoft.Data.SqlClient;
using Tarea_Programada_KendallCampos.Modelos;

namespace Tarea_Programada_KendallCampos.Datos;

public class RepositorioSqlServer : IRepositorio
{
    private readonly string cadenaConexion =
        @"Server=localhost\SQLEXPRESS;Database=BD_GestionProductos;Integrated Security=True;TrustServerCertificate=True;";

    private SqlConnection CrearConexion()
    {
        return new SqlConnection(cadenaConexion);
    }


    public List<Categoria> ObtenerCategorias()
    {
        List<Categoria> categorias = new List<Categoria>();

        using (SqlConnection conexion = CrearConexion())
        {
            conexion.Open();

            string consulta = "SELECT IdCategoria, Nombre, Descripcion FROM Categorias";

            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataReader lector = comando.ExecuteReader())
            {
                while (lector.Read())
                {
                    Categoria categoria = new Categoria();

                    categoria.IdCategoria = Convert.ToInt32(lector["IdCategoria"]);
                    categoria.Nombre = lector["Nombre"].ToString() ?? "";
                    categoria.Descripcion = lector["Descripcion"].ToString() ?? "";

                    categorias.Add(categoria);
                }
            }
        }

        return categorias;
    }

    public void GuardarCategoria(Categoria categoria)
    {
        using (SqlConnection conexion = CrearConexion())
        {
            conexion.Open();

            string consulta = "INSERT INTO Categorias (Nombre, Descripcion) VALUES (@Nombre, @Descripcion)";

            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);

                comando.ExecuteNonQuery();
            }
        }
    }

    public void ActualizarCategoria(Categoria categoria)
    {
        using (SqlConnection conexion = CrearConexion())
        {
            conexion.Open();

            string consulta = "UPDATE Categorias SET Nombre = @Nombre, Descripcion = @Descripcion WHERE IdCategoria = @IdCategoria";

            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);
                comando.Parameters.AddWithValue("@IdCategoria", categoria.IdCategoria);

                comando.ExecuteNonQuery();
            }
        }
    }

    public void EliminarCategoria(int id)
    {
        using (SqlConnection conexion = CrearConexion())
        {
            conexion.Open();

            string consulta = "DELETE FROM Categorias WHERE IdCategoria = @IdCategoria";

            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@IdCategoria", id);

                comando.ExecuteNonQuery();
            }
        }
    }

    public List<Producto> ObtenerProductos()
    {
        List<Producto> productos = new List<Producto>();

        using (SqlConnection conexion = CrearConexion())
        {
            conexion.Open();

            string consulta = "SELECT IdProducto, Nombre, Precio, Stock, FechaRegistro, IdCategoria FROM Productos";

            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataReader lector = comando.ExecuteReader())
            {
                while (lector.Read())
                {
                    Producto producto = new Producto();

                    producto.IdProducto = Convert.ToInt32(lector["IdProducto"]);
                    producto.Nombre = lector["Nombre"].ToString() ?? "";
                    producto.Precio = Convert.ToDecimal(lector["Precio"]);
                    producto.Stock = Convert.ToInt32(lector["Stock"]);
                    producto.FechaRegistro = Convert.ToDateTime(lector["FechaRegistro"]);
                    producto.IdCategoria = Convert.ToInt32(lector["IdCategoria"]);

                    productos.Add(producto);
                }
            }
        }

        return productos;
    }

    public void GuardarProducto(Producto producto)
    {
        using (SqlConnection conexion = CrearConexion())
        {
            conexion.Open();

            string consulta = "INSERT INTO Productos (Nombre, Precio, Stock, FechaRegistro, IdCategoria) VALUES (@Nombre, @Precio, @Stock, @FechaRegistro, @IdCategoria)";

            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                comando.Parameters.AddWithValue("@Precio", producto.Precio);
                comando.Parameters.AddWithValue("@Stock", producto.Stock);
                comando.Parameters.AddWithValue("@FechaRegistro", producto.FechaRegistro);
                comando.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);

                comando.ExecuteNonQuery();
            }
        }
    }

    public void ActualizarProducto(Producto producto)
    {
        using (SqlConnection conexion = CrearConexion())
        {
            conexion.Open();

            string consulta = "UPDATE Productos SET Nombre = @Nombre, Precio = @Precio, Stock = @Stock, IdCategoria = @IdCategoria WHERE IdProducto = @IdProducto";

            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                comando.Parameters.AddWithValue("@Precio", producto.Precio);
                comando.Parameters.AddWithValue("@Stock", producto.Stock);
                comando.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);
                comando.Parameters.AddWithValue("@IdProducto", producto.IdProducto);

                comando.ExecuteNonQuery();
            }
        }
    }

    public void EliminarProducto(int id)
    {
        using (SqlConnection conexion = CrearConexion())
        {
            conexion.Open();

            string consulta = "DELETE FROM Productos WHERE IdProducto = @IdProducto";

            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@IdProducto", id);

                comando.ExecuteNonQuery();
            }
        }
    }

}

