
using Core.Interface;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly TiendaAppContext _context;
    private CategoriaRepository _categorias;
    private ClienteRepository _clientes;
    private FacturaRepository _facturas;
    private ProductoRepository _productos;
    private ProveedorRepository _proveedores;
    private VentaRepository _ventas;

    public UnitOfWork(TiendaAppContext context)
    {
        _context = context;
    }

    public ICategoria Categorias
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
    public ICliente Clientes
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
    public IFactura Facturas
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
    public IProducto Productos
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
    public IProveedor Proveedores
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
    public IVenta Ventas
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
    }
}

    /*  */