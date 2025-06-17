using DAL.Configuraciones.Models;
using DAL.Ingredientes.Models;
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
                Id = ingrediente.Id,
                Nombre = ingrediente.Nombre,
                Descripcion = ingrediente.Descripcion,
                EsReceta = ingrediente is Receta
            };
        }

        public static Ingrediente ToIngrediente(this IngredienteModel ingredienteModel, List<RecetaCantidadIngredienteModel> recetaCantidadIngredienteModels,List<IngredienteModel> ingredienteModels,List<UnidadDeMedidaModel> unidadDeMedidaModels)
        {
            if (ingredienteModel.EsReceta)
            {
                return ingredienteModel.ToReceta(recetaCantidadIngredienteModels, ingredienteModels, unidadDeMedidaModels);
            }
            else
            {
                return new Ingrediente
                {
                    Id = ingredienteModel.Id,
                    Nombre = ingredienteModel.Nombre,
                    Descripcion = ingredienteModel.Descripcion
                };
            }
        }

        public static List<Ingrediente> ToIngredientes(this List<IngredienteModel> ingredienteModels, List<RecetaCantidadIngredienteModel> recetaCantidadIngredienteModels, List<IngredienteModel> ingredienteModels2, List<UnidadDeMedidaModel> unidadDeMedidaModels)
        {
            return ingredienteModels.Select(i => i.ToIngrediente(recetaCantidadIngredienteModels, ingredienteModels2, unidadDeMedidaModels)).ToList();
        }
    }
}
