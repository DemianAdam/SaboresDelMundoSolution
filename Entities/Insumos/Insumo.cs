using Entities.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Insumos
{
    public class Insumo : BaseEntity
    {
        public string Nombre { get; set; } = null!; 
        public string? Descripcion { get; set; }
        public TipoInsumo Tipo { get; set; } = null!; 

        override public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Nombre);
            if (!string.IsNullOrEmpty(Descripcion))
            {
                sb.Append($" - {Descripcion}");
            }
            return sb.ToString();
        }
    }
}
