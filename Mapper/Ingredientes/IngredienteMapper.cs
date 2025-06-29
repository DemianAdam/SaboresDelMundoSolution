using DAL.Configuraciones.Models;
using DAL.Ingredientes.Models;
using DAL.Insumos.Models;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Ingredientes
{
    public static class IngredienteMapper
    {
        public static IngredienteModel ToModel(this Ingrediente ingrediente)
        {
            return new IngredienteModel
            {
                ComponenteRecetaId = ingrediente.Id,
            };
        }

        public static Ingrediente ToIngrediente(this IngredienteModel ingredienteModel, List<InsumoModel> insumoModels)
        {
            InsumoModel? insumoModel = insumoModels.FirstOrDefault(i => i.Id == ingredienteModel.InsumoId);
            if (insumoModel is null)
            {
                throw new ArgumentException($"No se encontró el insumo con ID {ingredienteModel.InsumoId}");
            }
            return new Ingrediente
            {
                Id = ingredienteModel.ComponenteRecetaId,
                Nombre = insumoModel.Nombre,
                Descripcion = insumoModel.Descripcion,
            };
        }

        public static List<Ingrediente> ToIngredientes(this List<IngredienteModel> ingredienteModels, List<InsumoModel> insumoModels)
        {
            return ingredienteModels.Select(i => i.ToIngrediente(insumoModels)).ToList();
        }
    }
}
