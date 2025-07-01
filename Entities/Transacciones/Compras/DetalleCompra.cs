using Entities.Abstracciones;
using Entities.Compartido;
using Entities.Configuraciones;
using Entities.Insumos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Transacciones.Compras
{
    public class DetalleCompra : BaseEntity
    {
        public required Insumo Insumo { get; set; }
        public required Peso Peso { get; set; }
        public decimal Costo { get; set; }
    }
}
