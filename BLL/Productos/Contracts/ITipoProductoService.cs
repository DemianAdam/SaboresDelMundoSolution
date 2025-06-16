using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Productos.Contracts
{
    public interface ITipoProductoService : IGetAll<TipoProducto>
    {
        public event EventHandler? OnOperationFinished;
        public void Insert(TipoProducto tipoProducto);
        public void Remove(TipoProducto tipoProducto);
        public void Update(TipoProducto tipoProducto);
    }
}
