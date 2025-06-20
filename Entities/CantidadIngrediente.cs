using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CantidadIngrediente : ICloneable<CantidadIngrediente>
    {
        public int Id { get; set; }
        public Ingrediente Ingrediente { get; set; } = null!;
        public decimal Cantidad { get; set; }
        public UnidadDeMedida UnidadDeMedida { get; set; } = null!;
        public decimal DesperdicioAceptado { get; set; } = 0;
        public CantidadIngrediente Clone()
        {
            return new CantidadIngrediente
            {
                Id = this.Id,
                Ingrediente = this.Ingrediente.Clone(),
                Cantidad = this.Cantidad,
                UnidadDeMedida = this.UnidadDeMedida.Clone(),
                DesperdicioAceptado = this.DesperdicioAceptado
            };
        }
        public override string ToString()
        {
            return $"{Cantidad} x {Ingrediente.Nombre}";
        }
    }
}
