using DAL.Ingredientes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Insumos.Models
{
    public class InsumoModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int TipoInsumoId { get; set; }
        public IngredienteModel? IngredienteModel { get; set; } = null;
    }
}
