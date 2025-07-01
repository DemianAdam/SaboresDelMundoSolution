using Entities.Abstracciones;
using Entities.Compartido;
using Entities.Configuraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Ingredientes
{
    public class CantidadIngrediente : BaseEntity, ICloneable<CantidadIngrediente>
    {
        private decimal costo;
        public ComponenteReceta ComponenteReceta { get; set; } = null!;
        public required Peso Peso { get; set; }
        public decimal DesperdicioAceptado { get; set; } = 0;
        public required decimal Costo
        {
            get
            {
                if (ComponenteReceta is Receta receta)
                {
                    return receta.CostoPorPeso * Peso.Valor;
                }
                return costo;
            }

            set => costo = value;
        }

        public CantidadIngrediente Clone()
        {
            return new CantidadIngrediente
            {
                Id = Id,
                ComponenteReceta = ComponenteReceta.Clone(),
                Peso = Peso.Clone(),
                DesperdicioAceptado = DesperdicioAceptado,
                Costo = Costo
            };
        }
        public override string ToString()
        {
            return $"{Peso.Valor} x {ComponenteReceta.Nombre}";
        }
    }
}
