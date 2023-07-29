
namespace API.Dto;

public class ProveedorDto
{
    public string Nombre { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public string Telefono { get; set; } = null!;
    public List<ProductoDto>? Productos { get; set; }
}
