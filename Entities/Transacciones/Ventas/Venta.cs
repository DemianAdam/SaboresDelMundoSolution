using Entities.Productos;
using Entities.Transacciones;

namespace Entities.Transacciones.Ventas
{
    public class Venta : Transaccion
    {
        public Dictionary<Producto,int> Productos { get; set; } = new Dictionary<Producto, int>();
        public override bool EstaPagado { get => TotalPago == MontoTotal; }
    }
}