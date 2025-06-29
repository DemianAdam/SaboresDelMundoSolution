using DAL.Ingredientes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Ingredientes
{
    public interface IIngredienteUnitOfWork
    {
        List<IngredienteModel> GetAllIngredienteModel();
        List<RecetaCantidadIngredienteModel> GetAllRecetaCantidadIngredienteModels();
        void Insert(IngredienteModel ingrediente, List<RecetaCantidadIngredienteModel>? recetaCantidadIngredienteModels = null);
    }
}
