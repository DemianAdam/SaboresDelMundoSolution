using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Configuraciones.Contracts
{
    public interface IUnidadDeMedidaService : IGetAll<UnidadDeMedida>
    {
        public event EventHandler? OnOperationFinished;
        public void Insert(UnidadDeMedida tipoProducto);
        public void Remove(UnidadDeMedida tipoProducto);
        public void Update(UnidadDeMedida tipoProducto);
    }
}
