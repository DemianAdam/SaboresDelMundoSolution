using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Insumos.Contracts
{
    public interface IInsumoService : IGetAll<Insumo>
    {
        public event EventHandler? OnOperationFinished;
        public void Insert(Insumo insumo);
        public void Remove(Insumo insumo);
        public void Update(Insumo insumo);
    }
}
