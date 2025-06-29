using Entities.Transacciones.Compras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Compras.Contracts
{
    public interface IProveedorService : IGetAll<Proveedor>
    {
        public event EventHandler? OnOperationFinished;
        void Insert(Proveedor proveedor);
        void Remove(Proveedor proveedor);
        void Update(Proveedor proveedor);
    }
}
