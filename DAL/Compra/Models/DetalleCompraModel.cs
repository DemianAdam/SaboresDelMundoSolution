using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Compra.Models
{
    public class DetalleCompraModel
    {
        public int Id { get; set; }
        public int CompraId { get; set; }
        public int InsumoId { get; set; }
        public int UnidadDeMedidaId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Costo { get; set; }
    }
}
