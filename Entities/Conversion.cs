using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Conversion
    {
        public Conversion(int id, Insumo insumo, UnidadDeMedida unidadDeMedidaFrom, UnidadDeMedida unidadDeMedidaTo, decimal factor)
        {
            Id = id;
            Insumo = insumo;
            UnidadDeMedidaFrom = unidadDeMedidaFrom;
            UnidadDeMedidaTo = unidadDeMedidaTo;
            Factor = factor;
        }

        public Conversion(int id, Insumo insumo, UnidadDeMedida unidadDeMedidaFrom, decimal cantidadFrom, UnidadDeMedida unidadDeMedidaTo, decimal cantidadTo) :this(id, insumo, unidadDeMedidaFrom, unidadDeMedidaTo, cantidadTo / cantidadFrom)
        {
        }
        public int Id { get; set; }
        public Insumo Insumo { get; set; } = null!;
        public UnidadDeMedida UnidadDeMedidaFrom { get; set; } = null!;
        public UnidadDeMedida UnidadDeMedidaTo { get; set; } = null!;
        public decimal Factor { get; set; }
    }
}
