using Entities.Configuraciones;
using Entities.Insumos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Transacciones.Compras
{
    public class DetalleCompra
    {
        public int Id { get; set; }
        public required Insumo Insumo { get; set; }
        public required UnidadDeMedida Unidad { get; set; }
        public decimal Cantidad { get; set; } 
        public decimal Costo { get; set; }
    }
}
