using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Resumen
    {
        public Resumen()
        {
            Compras = new List<Compra>();
            Ventas = new List<Venta>();
        }
        public decimal Caja { get => Ventas.Sum(x => x.TotalPago) - Compras.Sum(x => x.TotalPago); }
        public decimal TotalDeudores { get => Ventas.Sum(x => x.TotalDeuda); }
        public List<Compra> Compras { get; set; }
        public List<Venta> Ventas { get; set; }
    }
}
