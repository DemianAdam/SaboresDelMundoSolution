using Entities.Abstracciones;

namespace Entities.Ingredientes
{
    public abstract class ComponenteReceta : BaseEntity, ICloneable<ComponenteReceta>
    {
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }

        public abstract ComponenteReceta Clone();

        public override string ToString()
        {
            return $"{Nombre}{(string.IsNullOrEmpty(Descripcion) ? string.Empty : $" ({Descripcion})")}";
        }
    }
}