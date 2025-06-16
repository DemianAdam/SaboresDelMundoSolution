namespace Entities
{
    public class Compra : Transaccion
    {
        public Proveedor? Proveedor { get; set; }
        public List<DetalleCompra>? Detalles { get; set; }
        public override bool EstaPagado { get => TotalPago == MontoTotal; }
    }
}

