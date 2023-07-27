using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interface;

public interface IProducto : IGeneric<Producto>
{
    // Aqui podemos implementar nuevos metodos unicos de nuestra Entidad
}
