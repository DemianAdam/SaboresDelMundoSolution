using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Ingredientes.Contracts
{
    public interface IRecetaCantidadService : IGetAll<CantidadIngrediente>
    {
        event EventHandler? OnOperationFinished;
        void Insert(CantidadIngrediente cantidadIngrediente,Receta receta);
        void Remove(CantidadIngrediente cantidadIngrediente, Receta receta);
        void Update(CantidadIngrediente cantidadIngrediente,Receta receta);
        List<CantidadIngrediente> GetAllByReceta(Receta receta);
    }
}
