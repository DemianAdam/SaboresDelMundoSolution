using Entities.Insumos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Insumos.Contracts
{
    public interface ITipoInsumoService :IGetAll<TipoInsumo>
    {
        public event EventHandler? OnOperationFinished;
        public void Insert(TipoInsumo tipoInsumo);
        public void Remove(TipoInsumo tipoInsumo);
        public void Update(TipoInsumo tipoInsumo);
    }
}
