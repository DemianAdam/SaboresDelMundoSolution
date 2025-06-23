using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configuraciones.Models
{
    public class ConversionModel
    {
        public int Id { get; set; }
        public int InsumoId { get; set; }
        public int UnidadFromId { get; set; }
        public int UnidadToId { get; set; }
        public decimal Factor { get; set; }
    }
}
