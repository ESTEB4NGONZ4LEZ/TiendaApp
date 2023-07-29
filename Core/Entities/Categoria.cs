
namespace Core.Entities;

public class Categoria : BaseEntity
{
    // * Atributos de la Clase
    public string Descripcion { get; set; } = null!;
    // * ICollection
    public ICollection<Producto>? Productos { get; set; }
}
