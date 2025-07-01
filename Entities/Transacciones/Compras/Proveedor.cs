using Entities.Abstracciones;

namespace Entities.Transacciones.Compras
{
    public class Proveedor : BaseEntity
    {
        public string Nombre { get; set; } = null!;
    }
}