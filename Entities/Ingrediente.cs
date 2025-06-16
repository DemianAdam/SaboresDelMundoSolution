using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Ingrediente : ICloneable<Ingrediente>
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        
        public virtual Ingrediente Clone()
        {
            return new Ingrediente
            {
                Id = this.Id,
                Nombre = this.Nombre,
                Descripcion = this.Descripcion
            };
        }
    }
}
