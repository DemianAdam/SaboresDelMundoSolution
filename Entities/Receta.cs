using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Receta : ComponenteReceta
    {
        public List<CantidadIngrediente>? CantidadIngredientes { get; set; }
        public required UnidadDeMedida UnidadDeMedida { get; set; }
        public required decimal PesoAproximado { get; set; }
        public decimal Costo { get => CantidadIngredientes?.Sum(x => x.Costo)??0;}

        public decimal CostoUnitario
        {
            get
            {
                if (PesoAproximado <= 0)
                    return 0;
                return Costo / PesoAproximado;
            }
        }

        public override Receta Clone()
        {
            return new Receta
            {
                Id = this.Id,
                Nombre = this.Nombre,
                Descripcion = this.Descripcion,
                CantidadIngredientes = this.CantidadIngredientes?.Select(ci => ci.Clone()).ToList(),
                UnidadDeMedida = this.UnidadDeMedida.Clone(),
                PesoAproximado = this.PesoAproximado,
            };
        }

        public bool RemoveAllCantidadIngredienteById(Ingrediente ingrediente)
        {
            if (CantidadIngredientes is null)
            {
                return false;
            }
            CantidadIngredientes = CantidadIngredientes.FindAll(ci => ci.ComponenteReceta.Id != ingrediente.Id);
            return true;
        }

        public void AddOrUpdateCantidadIngrediente(CantidadIngrediente cantidadIngrediente)
        {
            if (CantidadIngredientes is null)
            {
                return;
            }
            CantidadIngrediente? findedCantidadIngrediente = CantidadIngredientes
                            .FirstOrDefault(ci => ci.ComponenteReceta.Id == cantidadIngrediente.ComponenteReceta.Id);
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
            return CantidadIngredientes.Any(ci => ci.ComponenteReceta.Id == receta.Id ||
                                                   (ci.ComponenteReceta is Receta r && r.TieneReceta(receta)));
        }
    }
}
