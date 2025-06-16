namespace Entities
{
    public class TipoInsumo
    {
        public int Id { get; set; }
        public required string Tipo { get; set; }

        public override string ToString()
        {
            return Tipo;
        }
    }
}