
namespace API.Dto;

public class ProveedorDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public string Telefono { get; set; } = null!;
    public List<ProductoDto>? Productos { get; set; }
}
