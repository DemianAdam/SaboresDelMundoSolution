using BLL.Ingredientes.Contracts;
using Entities.Ingredientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Ingredientes.Context
{
    public class RecetaCantidadMemoryContext : IRecetaCantidadContext
    {
        public Receta Receta { get; }

        public event EventHandler? OnOperationFinished;

        public RecetaCantidadMemoryContext(Receta receta)
        {
            this.Receta = receta;
        }

        public void Add(CantidadIngrediente cantidadIngrediente)
        {
            if (Receta.CantidadIngredientes is null)
            {
                Receta.CantidadIngredientes = new List<CantidadIngrediente>();
            }
            Receta.CantidadIngredientes.Add(cantidadIngrediente);
            OnOperationFinished?.Invoke(this, EventArgs.Empty);
        }


        public void Remove(CantidadIngrediente cantidadIngrediente)
        {
            if (Receta.CantidadIngredientes is null || Receta.CantidadIngredientes.Count == 0)
            {
                return;
            }
            Receta.CantidadIngredientes.RemoveAll(ci => ci.Id == cantidadIngrediente.Id);
            OnOperationFinished?.Invoke(this, EventArgs.Empty);
        }

        public void Update(CantidadIngrediente cantidadIngrediente)
        {
            if (Receta.CantidadIngredientes is null || Receta.CantidadIngredientes.Count == 0)
            {
                return;
            }
            Receta.CantidadIngredientes.RemoveAll(x => x.Id == cantidadIngrediente.Id);
            Receta.CantidadIngredientes.Add(cantidadIngrediente);

            OnOperationFinished?.Invoke(this, EventArgs.Empty);
        }

        public List<CantidadIngrediente> GetAll()
        {
            if (Receta.CantidadIngredientes is null)
            {
                return new List<CantidadIngrediente>();
            }
            return Receta.CantidadIngredientes;
        }
    }
}
