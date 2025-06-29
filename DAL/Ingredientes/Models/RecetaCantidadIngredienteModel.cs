using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Ingredientes.Models
{
    public class RecetaCantidadIngredienteModel
    {
        public int Id { get; set; }
        public int RecetaId { get; set; }
        public int ComponenteRecetaId { get; set; }
        public int UnidadDeMedidaId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal DesperdicioAceptado { get; set; }
        public decimal? Costo { get; set; }
    }
}
