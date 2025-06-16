using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Productos.Models
{
    public class TipoProductoModel
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = null!;
    }
}
