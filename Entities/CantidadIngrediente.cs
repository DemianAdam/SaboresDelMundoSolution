using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CantidadIngrediente : ICloneable<CantidadIngrediente>
    {
        public Ingrediente Ingrediente { get; set; } = null!;
        public decimal Cantidad { get; set; }
        public UnidadDeMedida UnidadDeMedida { get; set; } = null!;
        public CantidadIngrediente Clone()
        {
            return new CantidadIngrediente
            {
                Ingrediente = this.Ingrediente.Clone(),
                Cantidad = this.Cantidad,
                UnidadDeMedida = this.UnidadDeMedida.Clone()
            };
        }
        public override string ToString()
        {
            return $"{Cantidad} x {Ingrediente.Nombre}";
        }
    }
}
