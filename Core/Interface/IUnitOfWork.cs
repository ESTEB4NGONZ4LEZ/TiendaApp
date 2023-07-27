
namespace Core.Interface;

public interface IUnitOfWork
{
    ICategoria Categoria { get; set; }
    ICliente Cliente { get; set; }
    IFactura Factura { get; set; }
    IProducto Producto { get; set; }
    IProveedor Proveedor { get; set; }
    IVenta Venta { get; set; }
    Task<int> SaveAsync();
}
