
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Factura
{
    // * Atributos de la Clase
    [Key]
    public int Id_factura { get; set; }
    public DateTime Fecha { get; set; }
    public int Id_cliente { get; set; }
    // * ICollection
    public ICollection<Venta>? Ventas { get; set; }
    // * Referencia a la Entidad
    public Cliente? Cliente { get; set; }
}
