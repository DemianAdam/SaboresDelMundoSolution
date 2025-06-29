using Entities.Ingredientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Ingredientes.Contracts
{
    public interface IRecetaService : IGetAll<Receta>
    {
        public event EventHandler? OnOperationFinished;

        public List<ComponenteReceta> GetAvailableIngredientes(Receta receta);
        void Insert(Receta receta);
        void Remove(Receta receta);
        void Update(Receta updatedReceta);
    }
}
