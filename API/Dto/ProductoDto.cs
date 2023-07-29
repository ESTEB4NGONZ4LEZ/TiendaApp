
namespace API.Dto;

public class ProductoDto
{
    public string Descripcion { get; set; } = null!;
    public double Precio { get; set; }
    public int Id_categoria { get; set; }
    public int Id_proveedor { get; set; }
    // public List<VentaDto>? Ventas { get; set; }

}
