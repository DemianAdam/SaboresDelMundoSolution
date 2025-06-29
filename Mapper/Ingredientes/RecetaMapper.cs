using DAL.Configuraciones.Models;
using DAL.Ingredientes.Models;
using DAL.Insumos.Models;
using Entities.Ingredientes;
using Mapper.Configuraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Ingredientes
{
    public static class RecetaMapper
    {
        public static List<Receta> ToRecetas(this List<RecetaModel> recetaModels, List<RecetaCantidadIngredienteModel> recetaCantidadIngredienteModels, List<ComponenteRecetaModel> componenteRecetaModel, List<UnidadDeMedidaModel> unidadDeMedidaModels, List<InsumoModel> insumoModels,List<IngredienteModel> ingredienteModels)
        {
            return recetaModels.Select(recetaModel => recetaModel.ToReceta(recetaCantidadIngredienteModels, componenteRecetaModel, unidadDeMedidaModels, insumoModels, ingredienteModels)).ToList();
        }
        public static Receta ToReceta(this RecetaModel recetaModel, List<RecetaCantidadIngredienteModel> recetaCantidadIngredienteModels, List<ComponenteRecetaModel> componenteRecetaModel, List<UnidadDeMedidaModel> unidadDeMedidaModels, List<InsumoModel> insumoModels,List<IngredienteModel> ingredienteModels)
        {
            List<RecetaCantidadIngredienteModel> cantidadIngredientes = recetaCantidadIngredienteModels
                .Where(rcim => rcim.RecetaId == recetaModel.ComponenteRecetaId)
                .ToList();

            UnidadDeMedidaModel? unidadDeMedidaModel = unidadDeMedidaModels.FirstOrDefault(um => um.Id == recetaModel.UnidadDeMedidaId);

            if (unidadDeMedidaModel is null)
            {
                throw new ArgumentException($"No se encontró la unidad de medida con ID {recetaModel.UnidadDeMedidaId}");
            }

            Receta receta = new Receta
            {
                Id = recetaModel.ComponenteRecetaId,
                Nombre = recetaModel.Nombre,
                Descripcion = recetaModel.Descripcion,
                CantidadIngredientes = cantidadIngredientes.ToCantidadIngredientes(componenteRecetaModel, unidadDeMedidaModels, insumoModels, recetaCantidadIngredienteModels, ingredienteModels),
                UnidadDeMedida = unidadDeMedidaModel.ToUnidadDeMedida(),
                PesoAproximado = recetaModel.PesoAproximado,
            };

            return receta;
        }

        public static RecetaModel ToModel(this Receta receta)
        {
            return new RecetaModel
            {
                ComponenteRecetaId = receta.Id,
                Nombre = receta.Nombre,
                Descripcion = receta.Descripcion,
                UnidadDeMedidaId = receta.UnidadDeMedida.Id,
                PesoAproximado = receta.PesoAproximado
            };
        }
    }
}
