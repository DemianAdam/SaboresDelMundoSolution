using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CantidadTipoProducto : ICloneable<CantidadTipoProducto>
    {
        public TipoProducto TipoProducto { get; set; } = null!;
        public int Cantidad { get; set; }

        public CantidadTipoProducto Clone()
        {
            return new CantidadTipoProducto
            {
                TipoProducto = this.TipoProducto.Clone(),
                Cantidad = this.Cantidad
            };
        }
    }
}
