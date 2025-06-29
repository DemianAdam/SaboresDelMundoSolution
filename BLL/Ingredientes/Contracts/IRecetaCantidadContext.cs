using Entities.Ingredientes;
using Interfaces;

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
