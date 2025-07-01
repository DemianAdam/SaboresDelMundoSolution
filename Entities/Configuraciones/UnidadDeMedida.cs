using Entities.Abstracciones;

namespace Entities.Configuraciones
{
    public class UnidadDeMedida : BaseEntity, ICloneable<UnidadDeMedida>
    {
        public string Unidad { get; set; } = null!;

        public override string ToString()
        {
            return Unidad;
        }

        public UnidadDeMedida Clone()
        {
            return new UnidadDeMedida
            {
                Id = Id,
                Unidad = Unidad
            };
        }
    }
}