using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Ingredientes.Contracts
{
    public interface IRecetaService : IGetAll<Receta>
    {
        public List<Ingrediente> GetAvailableIngredientes(Receta receta);
    }
}
