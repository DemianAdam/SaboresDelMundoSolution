using Entities.Abstracciones;

namespace Entities.Insumos
{
    public class TipoInsumo : BaseEntity
    {
        public required string Tipo { get; set; }

        public override string ToString()
        {
            return Tipo;
        }
    }
}