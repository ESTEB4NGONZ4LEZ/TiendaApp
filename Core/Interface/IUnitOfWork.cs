
namespace Core.Interface;

public interface IUnitOfWork
{
    ICategoria Categorias { get; set; }
    ICliente Clientes { get; set; }
    IFactura Facturas { get; set; }
    IProducto Productos { get; set; }
    IProveedor Proveedores { get; set; }
    IVenta Ventas { get; set; }
    Task<int> SaveAsync();
}
