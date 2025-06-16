using DAL.Compartido.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Compra.Models
{
    public class CompraModel : TransaccionModel
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int? ProveedorId { get; set; }
    }
}
