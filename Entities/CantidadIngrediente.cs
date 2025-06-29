using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CantidadIngrediente : ICloneable<CantidadIngrediente>
    {
        private decimal costo;
        public int Id { get; set; }
        public ComponenteReceta ComponenteReceta { get; set; } = null!;
        public decimal Cantidad { get; set; }
        public UnidadDeMedida UnidadDeMedida { get; set; } = null!;
        public decimal DesperdicioAceptado { get; set; } = 0;
        public required decimal Costo
        {
            get
            {
                if (ComponenteReceta is Receta receta)
                {
                    return receta.CostoUnitario * Cantidad;
                }
                return costo;
            }

            set => costo = value;
        }

        public CantidadIngrediente Clone()
        {
            return new CantidadIngrediente
            {
                Id = this.Id,
                ComponenteReceta = this.ComponenteReceta.Clone(),
                Cantidad = this.Cantidad,
                UnidadDeMedida = this.UnidadDeMedida.Clone(),
                DesperdicioAceptado = this.DesperdicioAceptado,
                Costo = this.Costo
            };
        }
        public override string ToString()
        {
            return $"{Cantidad} x {ComponenteReceta.Nombre}";
        }
    }
}
