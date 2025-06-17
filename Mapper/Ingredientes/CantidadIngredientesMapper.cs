using DAL.Configuraciones.Models;
using DAL.Ingredientes.Models;
using Entities;
using Mapper.Configuraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Ingredientes
{
    public static class CantidadIngredientesMapper
    {
        public static List<RecetaCantidadIngredienteModel> ToModels(this List<CantidadIngrediente> cantidadIngredientes, Receta receta)
        {
            return cantidadIngredientes.Select(c => c.ToModel(receta)).ToList();
        }
        public static RecetaCantidadIngredienteModel ToModel(this CantidadIngrediente cantidadIngrediente, Receta receta)
        {
            return new RecetaCantidadIngredienteModel
            {
                RecetaId = receta.Id,
                IngredienteId = cantidadIngrediente.Ingrediente.Id,
                UnidadDeMedidaId = cantidadIngrediente.UnidadDeMedida.Id,
                Cantidad = cantidadIngrediente.Cantidad
            };
        }
        public static List<CantidadIngrediente> ToCantidadIngredientes(this List<RecetaCantidadIngredienteModel> cantidadIngredienteModels, List<IngredienteModel> ingredienteModels, List<UnidadDeMedidaModel> unidadDeMedidaModels, List<RecetaCantidadIngredienteModel> recetaCantidadIngredienteModels)
        {
            return cantidadIngredienteModels.Select(c => c.ToCantidadIngrediente(ingredienteModels, unidadDeMedidaModels, recetaCantidadIngredienteModels)).ToList();
        }
        public static CantidadIngrediente ToCantidadIngrediente(this RecetaCantidadIngredienteModel cantidadIngredienteModel, List<IngredienteModel> ingredienteModels, List<UnidadDeMedidaModel> unidadDeMedidaModels, List<RecetaCantidadIngredienteModel> recetaCantidadIngredienteModels)
        {

            Ingrediente? ingrediente = ingredienteModels.FirstOrDefault(i => i.Id == cantidadIngredienteModel.IngredienteId)?.ToIngrediente(recetaCantidadIngredienteModels, ingredienteModels, unidadDeMedidaModels);

            UnidadDeMedida? unidadDeMedida = unidadDeMedidaModels.FirstOrDefault(u => u.Id == cantidadIngredienteModel.UnidadDeMedidaId)?.ToUnidadDeMedida();

            if (ingrediente == null)
            {
                throw new ArgumentException($"No se encontró el ingrediente con ID {cantidadIngredienteModel.IngredienteId}");
            }

            if (unidadDeMedida == null)
            {
                throw new ArgumentException($"No se encontró la unidad de medida con ID {cantidadIngredienteModel.UnidadDeMedidaId}");
            }

            CantidadIngrediente cantidadIngrediente = new CantidadIngrediente
            {
                Cantidad = cantidadIngredienteModel.Cantidad,
                Ingrediente = ingrediente,
                UnidadDeMedida = unidadDeMedida
            };

            return cantidadIngrediente;
        }
    }
}
