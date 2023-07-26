
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Cliente
{
    // * A tributos de la clase
    [Key]
    public int Id_cliente { get; set; }
    public string Nombre { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public string Telefono { get; set; } = null!;
    // * ICollection
    public ICollection<Factura>? Facturas { get; set; }
}
