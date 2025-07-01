using Entities.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Productos
{
    public class TipoProducto : BaseEntity, ICloneable<TipoProducto>
    {
        public string Tipo { get; set; } = null!;
        public TipoProducto Clone()
        {
            return new TipoProducto
            {
                Id = Id,
                Tipo = Tipo
            };
        }

        public override string ToString()
        {
            return Tipo;
        }
    }
}
