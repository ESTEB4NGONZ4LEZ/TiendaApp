
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Producto : BaseEntity
{
    // * Atributos de la Clase
    public string Descripcion { get; set; } = null!;
    public double Precio { get; set; }
    public int Id_categoria { get; set; }
    public int Id_proveedor { get; set; }
    // * ICollection
    public ICollection<Venta>? Ventas { get; set; }
    // * Referencia a las Entidades
    public Categoria? Categoria { get; set; }
    public Proveedor? Proveedor { get; set; }
}
