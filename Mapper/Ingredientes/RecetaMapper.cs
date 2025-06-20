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
    public static class RecetaMapper
    {
        public static List<Receta> ToRecetas(this List<IngredienteModel> recetaModels, List<RecetaCantidadIngredienteModel> recetaCantidadIngredienteModels, List<IngredienteModel> ingredienteModels, List<UnidadDeMedidaModel> unidadDeMedidaModels)
        {
            return recetaModels.Select(recetaModel => recetaModel.ToReceta(recetaCantidadIngredienteModels, ingredienteModels, unidadDeMedidaModels)).ToList();
        }
        public static Receta ToReceta(this IngredienteModel recetaModel, List<RecetaCantidadIngredienteModel> recetaCantidadIngredienteModels, List<IngredienteModel> ingredienteModels, List<UnidadDeMedidaModel> unidadDeMedidaModels)
        {
            Receta receta = new Receta
            {
                Id = recetaModel.Id,
                Nombre = recetaModel.Nombre,
                Descripcion = recetaModel.Descripcion,
                CantidadIngredientes = recetaCantidadIngredienteModels.ToCantidadIngredientes(ingredienteModels, unidadDeMedidaModels, recetaCantidadIngredienteModels)
            };

            return receta;
        }
    }
}
