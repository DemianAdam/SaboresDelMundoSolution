using Entities.Compartido;
using Entities.Configuraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Ingredientes
{
    public class Receta : ComponenteReceta
    {
        public List<CantidadIngrediente>? CantidadIngredientes { get; set; }
        public required Peso Peso { get; set; }
        public decimal Costo { get => CantidadIngredientes?.Sum(x => x.Costo)??0;}
        public required int Porciones { get; set; }

        public decimal CostoPorPeso
        {
            get
            {
                if (Peso.Valor <= 0)
                    return 0;
                return Costo / Peso.Valor;
            }
        }

        public decimal CostoPorPorcion
        {
            get
            {
                if (Porciones <= 0)
                    return 0;
                return Costo / Porciones;
            }
        }

        public override Receta Clone()
        {
            return new Receta
            {
                Id = Id,
                Nombre = Nombre,
                Descripcion = Descripcion,
                CantidadIngredientes = CantidadIngredientes?.Select(ci => ci.Clone()).ToList(),
                Peso = Peso.Clone(),
                Porciones = Porciones
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
                findedCantidadIngrediente.Peso = cantidadIngrediente.Peso.Clone();
                findedCantidadIngrediente.DesperdicioAceptado = cantidadIngrediente.DesperdicioAceptado;
            }
        }

        public bool TieneReceta(Receta receta)
        {
            if (CantidadIngredientes is null || CantidadIngredientes.Count == 0)
                return false;
            return CantidadIngredientes.Any(ci => ci.ComponenteReceta.Id == receta.Id ||
                                                   ci.ComponenteReceta is Receta r && r.TieneReceta(receta));
        }
    }
}
