using DAL.Ingredientes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Ingredientes.Contracts
{
    public interface IRecetaRepository
    {
        List<IngredienteModel> GetAll();
    }
}
