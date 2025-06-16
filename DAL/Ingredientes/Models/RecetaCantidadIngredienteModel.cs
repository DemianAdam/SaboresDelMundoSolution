using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Ingredientes.Models
{
    public class RecetaCantidadIngredienteModel
    {
        public int RecetaId { get; set; }
        public int IngredienteId { get; set; }
        public int UnidadDeMedidaId { get; set; }
        public decimal Cantidad { get; set; }
    }
}
