using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Ingredientes
{
    public class Ingrediente : ComponenteReceta
    {
        public override Ingrediente Clone()
        {
            return new Ingrediente
            {
                Id = Id,
                Nombre = Nombre,
                Descripcion = Descripcion,
            };
        }
    }
}
