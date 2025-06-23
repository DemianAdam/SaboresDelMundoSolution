using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Conversion
    {
        public int Id { get; set; }
        public Insumo Insumo { get; set; } = null!;
        public UnidadDeMedida UnidadDeMedidaFrom { get; set; } = null!;
        public UnidadDeMedida UnidadDeMedidaTo { get; set; } = null!;
        public decimal Factor { get; set; }
    }
}
