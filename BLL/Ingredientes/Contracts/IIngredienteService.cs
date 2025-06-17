using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Ingredientes.Contracts
{
    public interface IIngredienteService : IGetAll<Ingrediente>
    {
        public event EventHandler? OnOperationFinished;
        void Insert(Ingrediente ingrediente);
        void Remove(Ingrediente ingrediente);
        void Update(Ingrediente ingrediente);
    }
}
