using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Compartido.Models
{
    public class PagoModel
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Cantidad { get; set; }
        public int TipoPago { get; set; }
        public int? CompraId { get; set; }
        public int? VentaId { get; set; }
    }
}
