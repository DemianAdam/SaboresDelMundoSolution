namespace Entities.Productos
{
    public class Producto : ICloneable<Producto>
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public List<Producto>? SubProductos { get; set; }
        public TipoProducto Tipo { get; set; } = null!;

        public bool TieneSubProducto(Producto producto)
        {
            if (SubProductos == null || SubProductos.Count == 0)
                return false;
            return SubProductos.Any(sp => sp.Id == producto.Id || sp.TieneSubProducto(producto));
        }

        public virtual Producto Clone()
        {
            return new Producto
            {
                Id = Id,
                Nombre = Nombre,
                Precio = Precio,
                Tipo = Tipo.Clone(),
                SubProductos = SubProductos?.Select(sp => sp.Clone()).ToList()
            };
        }
    }
}