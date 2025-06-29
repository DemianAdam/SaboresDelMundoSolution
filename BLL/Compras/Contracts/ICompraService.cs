using Entities.Transacciones.Compras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Compras.Contracts
{
    public interface ICompraService : IGetAll<Compra>
    {
        public event EventHandler? OnOperationFinished;
        void Insert(Compra compra);
        void Remove(Compra compra);
        void Update(Compra compra);
    }
}
