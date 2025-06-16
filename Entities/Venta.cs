namespace Entities
{
    public class Venta : Transaccion
    {
        public Dictionary<Producto,int> Productos { get; set; } = new Dictionary<Producto, int>();
        public override bool EstaPagado { get => TotalPago == MontoTotal; }
    }
}