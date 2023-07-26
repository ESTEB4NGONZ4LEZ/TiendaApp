
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Venta
{
    // * Atributos de la Clase
    [Key]
    public int Id_venta { get; set; }
    public int Id_factura { get; set; }
    public int Id_producto { get; set; }
    public int Cantidad { get; set; }
    // * Referencia a las Entidades
    public Factura? Factura { get; set; }
    public Producto? Producto { get; set; }
}
