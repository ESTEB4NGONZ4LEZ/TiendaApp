
namespace API.Dto;

public class ProductosDto
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = null!;
    public double Precio { get; set; }
    public int Id_categoria { get; set; }
    public int Id_proveedor { get; set; }
}
