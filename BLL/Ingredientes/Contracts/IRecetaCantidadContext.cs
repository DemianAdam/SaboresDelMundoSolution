using BLL.Compartido.Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Ingredientes.Contracts
{
    public interface IRecetaCantidadContext : IContext
    {
        public Receta Receta { get; }
        event EventHandler? OnOperationFinished;
        void Add(CantidadIngrediente cantidadIngrediente);
        List<CantidadIngrediente> GetAll();
        void Remove(CantidadIngrediente cantidadIngrediente);
        void Update(CantidadIngrediente cantidadIngrediente);
    }
}
