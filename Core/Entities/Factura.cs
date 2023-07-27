
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Factura : BaseEntity
{
    // * Atributos de la Clase
    public DateTime Fecha { get; set; }
    public int Id_cliente { get; set; }
    // * ICollection
    public ICollection<Venta>? Ventas { get; set; }
    // * Referencia a la Entidad
    public Cliente? Cliente { get; set; }
}
