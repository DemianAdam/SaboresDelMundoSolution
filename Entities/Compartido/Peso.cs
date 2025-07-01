using Entities.Configuraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Compartido
{
    public class Peso : ICloneable<Peso>
    {
        public required UnidadDeMedida UnidadDeMedida { get; set; }
        public required decimal Valor { get; set; }

        public Peso Clone()
        {
            return new Peso
            {
                UnidadDeMedida = UnidadDeMedida.Clone(),
                Valor = Valor
            };
        }

        public override string ToString()
        {
            return $"{Valor} {UnidadDeMedida.Unidad}";
        }
    }
}
