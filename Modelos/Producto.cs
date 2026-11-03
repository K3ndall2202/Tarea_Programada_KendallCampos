namespace Tarea_Programada_KendallCampos.Modelos;

public class Producto
{
    private decimal precio;
    private int stock;

    public int IdProducto { get; set; }
    public string Nombre { get; set; } = "";
    public decimal Precio
    {
        get => precio;
        set => precio = value;
    }
    public int Stock
    {
        get => stock;
        set => stock = value;
    }
    public DateTime FechaRegistro { get; set; }
    public int IdCategoria { get; set; }

    // Este valor se calcula; no se guarda en la base de datos.
    public decimal ValorInventario => Precio * Stock;
}
