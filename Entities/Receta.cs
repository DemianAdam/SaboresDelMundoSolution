using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Receta : Ingrediente
    {
        public List<CantidadIngrediente>? CantidadIngredientes { get; set; }

        public override Receta Clone()
        {
            return new Receta
            {
                Id = this.Id,
                Nombre = this.Nombre,
                Descripcion = this.Descripcion,
                CantidadIngredientes = this.CantidadIngredientes?.Select(ci => ci.Clone()).ToList(),
            };
        }

        public bool RemoveAllCantidadIngredienteById(Ingrediente ingrediente)
        {
            if (CantidadIngredientes is null)
            {
                return false;
            }
            CantidadIngredientes = CantidadIngredientes.FindAll(ci => ci.Ingrediente.Id != ingrediente.Id);
            return true;
        }

        public void AddOrUpdateCantidadIngrediente(CantidadIngrediente cantidadIngrediente)
        {
            if (CantidadIngredientes is null)
            {
                return;
            }
            CantidadIngrediente? findedCantidadIngrediente = CantidadIngredientes
                            .FirstOrDefault(ci => ci.Ingrediente.Id == cantidadIngrediente.Ingrediente.Id);
            if (findedCantidadIngrediente is null)
            {
                CantidadIngredientes.Add(cantidadIngrediente.Clone());
            }
            else
            {
                findedCantidadIngrediente.Cantidad = cantidadIngrediente.Cantidad;
                findedCantidadIngrediente.UnidadDeMedida = cantidadIngrediente.UnidadDeMedida.Clone();
                findedCantidadIngrediente.DesperdicioAceptado = cantidadIngrediente.DesperdicioAceptado;
            }
        }

        public bool TieneReceta(Receta receta)
        {
            if (CantidadIngredientes is null || CantidadIngredientes.Count == 0)
                return false;
            return CantidadIngredientes.Any(ci => ci.Ingrediente.Id == receta.Id || 
                                                   (ci.Ingrediente is Receta r && r.TieneReceta(receta)));
        }
    }
}
