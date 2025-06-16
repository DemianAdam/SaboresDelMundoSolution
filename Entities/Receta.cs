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

        public void AddOrUpdateCantidadIngrediente(Ingrediente ingrediente, int cantidad)
        {
            if (CantidadIngredientes is null)
            {
                return;
            }
            CantidadIngrediente? cantidadIngrediente = CantidadIngredientes
                            .FirstOrDefault(ci => ci.Ingrediente.Id == ingrediente.Id);
            if (cantidadIngrediente is null)
            {
                CantidadIngredientes.Add(new CantidadIngrediente
                {
                    Ingrediente = ingrediente.Clone(),
                    Cantidad = cantidad
                });
            }
            else
            {
                cantidadIngrediente.Cantidad = cantidad;
            }
        }
    }
}
