
using Core.Interface;
using Infrastructure.Datal;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly TiendaAppContext _context;

    public UnitOfWork(TiendaAppContext context)
    {
        _context = context;
    }

    public ICategoria Categorias { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public ICliente Clientes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public IFactura Facturas { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public IProducto Productos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public IProveedor Proveedores { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public IVenta Ventas { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveAsync()
    {
        throw new NotImplementedException();
    }
}

    /* public ICategoria Categoria
    { 
        get 
        {
            if (_categorias == null) {
                _categorias = new CategoriaRepository(_context);
            }
            return _categorias;
        } 

        set
        {
            if(_categorias == null) {
                _categorias = new CategoriaRepository(_context);
            }
        } 
    }
    public ICliente Cliente
    { 
        get 
        {
            if (_clientes == null) {
                _clientes = new ClienteRepository(_context);
            }
            return _clientes;
        } 

        set
        {
            if(_clientes == null) {
                _clientes = new ClienteRepository(_context);
            }
        } 
    }
    public IFactura Factura
    { 
        get 
        {
            if (_facturas == null) {
                _facturas = new FacturaRepository(_context);
            }
            return _facturas;
        } 

        set
        {
            if(_facturas == null) {
                _facturas = new FacturaRepository(_context);
            }
        } 
    }
    public IProducto Producto
    { 
        get 
        {
            if (_productos == null) {
                _productos = new ProductoRepository(_context);
            }
            return _productos;
        } 

        set
        {
            if(_productos == null) {
                _productos = new ProductoRepository(_context);
            }
        } 
    }
    public IProveedor Proveedor
    { 
        get 
        {
            if (_proveedores == null) {
                _proveedores = new ProveedorRepository(_context);
            }
            return _proveedores;
        } 

        set
        {
            if(_proveedores == null) {
                _proveedores = new ProveedorRepository(_context);
            }
        } 
    }
    public IVenta Venta
    { 
        get 
        {
            if (_ventas == null) {
                _ventas = new VentaRepository(_context);
            }
            return _ventas;
        } 

        set
        {
            if(_ventas == null) {
                _ventas = new VentaRepository(_context);
            }
        } 
    }
    public void Dispose()
    {
        _context.Dispose();
    }

    public Task<int> SaveAsync()
    {
        return _context.SaveChangesAsync();
    } */