
namespace Entities
{
    public class UnidadDeMedida : ICloneable<UnidadDeMedida>
    {
        public int Id { get; set; }
        public string Unidad { get; set; } = null!;

        public override string ToString()
        {
            return Unidad;
        }

        public UnidadDeMedida Clone()
        {
            return new UnidadDeMedida
            {
                Id = this.Id,
                Unidad = this.Unidad
            };
        }
    }
}