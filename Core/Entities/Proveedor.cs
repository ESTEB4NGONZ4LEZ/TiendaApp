
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Proveedor : BaseEntity
{
    // * Atributos de la Clase
    public string Nombre { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public string Telefono { get; set; } = null!;
    // * ICollection
    public ICollection<Producto>? Productos { get; set; }
}
