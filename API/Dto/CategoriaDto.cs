
namespace API.Dto;

public class CategoriaDto
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = null!;
    public List<ProductoDto>? Productos { get; set; }
}
