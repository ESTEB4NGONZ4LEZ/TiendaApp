
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Cliente : BaseEntity
{
    // * A tributos de la clase
    public string Nombre { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public string Telefono { get; set; } = null!;
    // * ICollection
    public ICollection<Factura>? Facturas { get; set; }
}
