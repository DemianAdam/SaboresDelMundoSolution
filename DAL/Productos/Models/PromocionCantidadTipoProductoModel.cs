using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Productos.Models
{
    public class PromocionCantidadTipoProductoModel
    {
        public int ProductoId { get; set; }
        public int TipoProductoId { get; set; }
        public int Cantidad { get; set; }
    }
}
