using Entities.Configuraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Configuraciones.Contracts
{
    public interface IConversionService : IGetAll<Conversion>
    {
        public event EventHandler? OnOperationFinished;
        public void Insert(Conversion conversion);
        public void Remove(Conversion conversion);
        public void Update(Conversion conversion);
    }
}
