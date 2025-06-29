using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Ingrediente :ComponenteReceta
    {
        public override Ingrediente Clone()
        {
            return new Ingrediente
            {
                Id = this.Id,
                Nombre = this.Nombre,
                Descripcion = this.Descripcion,
            };
        }
    }
}
