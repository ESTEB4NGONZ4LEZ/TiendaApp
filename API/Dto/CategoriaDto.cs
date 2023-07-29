
namespace API.Dto;

public class CategoriaDto
{
    public string Descripcion { get; set; } = null!;
    public List<ProductoDto>? Productos { get; set; }
}
