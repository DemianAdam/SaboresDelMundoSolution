namespace Entities
{
    public class Pago
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Cantidad {  get; set; }
        public TipoPago Tipo { get; set; }
    }
}