using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Transacciones
{
    public abstract class Transaccion
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal TotalDeuda { get => MontoTotal - TotalPago; }
        public decimal TotalPago
        {
            get
            {
                decimal totalPago = 0;
                if (Pagos is not null)
                {
                    totalPago = Pagos.Sum(x => x.Cantidad);
                }
                return totalPago;
            }
        }
        public abstract bool EstaPagado { get; }
        public List<Pago>? Pagos { get; set; }
    }
}
