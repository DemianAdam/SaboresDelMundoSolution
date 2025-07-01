using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstracciones
{
    public class BaseEntity
    {
        [Browsable(false)]
        public int Id { get; set; }
    }
}
