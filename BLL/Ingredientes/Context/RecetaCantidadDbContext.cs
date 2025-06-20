using BLL.Ingredientes.Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Ingredientes.Context
{
    public class RecetaCantidadDbContext : IRecetaCantidadContext
    {
        private readonly IRecetaCantidadService recetaCantidadService;
        public Receta Receta { get; }

        public event EventHandler? OnOperationFinished;
        public RecetaCantidadDbContext(IRecetaCantidadService recetaCantidadService, Receta receta)
        {
            this.recetaCantidadService = recetaCantidadService;
            this.Receta = receta;
            recetaCantidadService.OnOperationFinished += (sender, e) => OnOperationFinished?.Invoke(this, EventArgs.Empty);
        }
        public void Add(CantidadIngrediente cantidadIngrediente)
        {
            if (Receta.CantidadIngredientes is null)
            {
                Receta.CantidadIngredientes = new List<CantidadIngrediente>();
            }
            recetaCantidadService.Insert(cantidadIngrediente, Receta);
        }

        public List<CantidadIngrediente> GetAll()
        {
            return recetaCantidadService.GetAllByReceta(Receta);
        }

        public void Remove(CantidadIngrediente cantidadIngrediente)
        {
            if (Receta.CantidadIngredientes is null)
            {
                return;
            }
            recetaCantidadService.Remove(cantidadIngrediente, Receta);
        }

        public void Update(CantidadIngrediente cantidadIngrediente)
        {
            if (Receta.CantidadIngredientes is null)
            {
                return;
            }
            recetaCantidadService.Update(cantidadIngrediente, Receta);
        }
    }
}
