
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Categoria
{
    // * Atributos de la Clase
    [Key]
    public int Id_categoria { get; set; }
    public string Descripcion { get; set; } = null!;
    // * ICollection
    public ICollection<Producto>? Productos { get; set; }
}
