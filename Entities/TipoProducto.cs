using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TipoProducto : ICloneable<TipoProducto>
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = null!;
        public TipoProducto Clone()
        {
            return new TipoProducto
            {
                Id = this.Id,
                Tipo = this.Tipo
            };
        }

        public override string ToString()
        {
            return Tipo;
        }
    }
}
