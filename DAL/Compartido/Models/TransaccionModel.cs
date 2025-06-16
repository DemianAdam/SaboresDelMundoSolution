using DAL.Compra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Compartido.Models
{
    public class TransaccionModel
    {
        public int? CompraId
        {
            get
            {
                if (this is CompraModel model)
                {
                    return model.Id;
                }
                return null;
            }
        }
        public int? VentaId
        {
            get
            {
                /*if (this is VentaModel model)
                {
                    return model.Id;
                }*/
                return null;
            }
        }
    }
}
