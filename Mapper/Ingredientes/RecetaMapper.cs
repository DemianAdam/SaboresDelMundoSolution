using DAL.Configuraciones.Models;
using DAL.Ingredientes.Models;
using DAL.Ingredientes.Models.Recetas;
using DAL.Insumos.Models;
using Entities.Compartido;
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
        public static List<Receta> ToRecetas(this List<RecetaModel> recetaModels, List<RecetaCantidadIngredienteModel> recetaCantidadIngredienteModels, List<ComponenteRecetaModel> componenteRecetaModel, List<UnidadDeMedidaModel> unidadDeMedidaModels, List<InsumoModel> insumoModels, List<IngredienteModel> ingredienteModels)
        {
            return recetaModels.Select(recetaModel => recetaModel.ToReceta(recetaCantidadIngredienteModels, componenteRecetaModel, unidadDeMedidaModels, insumoModels, ingredienteModels)).ToList();
        }
        public static Receta ToReceta(this RecetaModel recetaModel, List<RecetaCantidadIngredienteModel> recetaCantidadIngredienteModels, List<ComponenteRecetaModel> componenteRecetaModel, List<UnidadDeMedidaModel> unidadDeMedidaModels, List<InsumoModel> insumoModels, List<IngredienteModel> ingredienteModels)
        {
            List<RecetaCantidadIngredienteModel> cantidadIngredientes = recetaCantidadIngredienteModels
                .Where(rcim => rcim.RecetaId == recetaModel.ComponenteRecetaId)
                .ToList();

            UnidadDeMedidaModel? unidadDeMedidaModel = unidadDeMedidaModels.FirstOrDefault(um => um.Id == recetaModel.UnidadDeMedidaId);

            if (unidadDeMedidaModel is null)
            {
                throw new ArgumentException($"No se encontró la unidad de medida con ID {recetaModel.UnidadDeMedidaId}");
            }

            Peso peso = new Peso
            {
                Valor = recetaModel.PesoAproximado,
                UnidadDeMedida = unidadDeMedidaModel.ToUnidadDeMedida()
            };

            Receta receta = new Receta
            {
                Id = recetaModel.ComponenteRecetaId,
                Nombre = recetaModel.Nombre,
                Descripcion = recetaModel.Descripcion,
                CantidadIngredientes = cantidadIngredientes.ToCantidadIngredientes(componenteRecetaModel, unidadDeMedidaModels, insumoModels, recetaCantidadIngredienteModels, ingredienteModels),
                Peso = peso,
                Porciones = recetaModel.Porciones
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
                UnidadDeMedidaId = receta.Peso.UnidadDeMedida.Id,
                PesoAproximado = receta.Peso.Valor,
                Porciones = receta.Porciones
            };
        }

        public static InsertRecetaModel ToInsert(this RecetaModel recetaModel)
        {
            return new InsertRecetaModel
            {
                Nombre = recetaModel.Nombre,
                Descripcion = recetaModel.Descripcion,
                UnidadDeMedidaId = recetaModel.UnidadDeMedidaId,
                PesoAproximado = recetaModel.PesoAproximado,
                Porciones = recetaModel.Porciones
            };
        }
    }
}
