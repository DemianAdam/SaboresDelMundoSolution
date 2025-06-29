using Entities.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Productos.Contracts
{
    public interface IProductoService : IGetAll<Producto>
    {
        public event EventHandler? OnOperationFinished;
        public void Insert(Producto producto);
        public void Remove(Producto producto);
        public void Update(Producto producto);
        List<Producto> GetAvailableSubProducts(Producto producto);
    }
}
