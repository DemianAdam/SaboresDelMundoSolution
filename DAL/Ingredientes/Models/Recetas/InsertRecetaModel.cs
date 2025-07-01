using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Ingredientes.Models.Recetas
{
    public class InsertRecetaModel
    {
        public required string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public required int UnidadDeMedidaId { get; set; }
        public required decimal PesoAproximado { get; set; }
        public required int Porciones { get; set; }
    }
}
