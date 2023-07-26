
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Proveedor
{
    // * Atributos de la Clase
    [Key]
    public int Id_proveedor { get; set; }
    public string Nombre { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public string Telefono { get; set; } = null!;
    // * ICollection
    public ICollection<Producto>? Productos { get; set; }
}
