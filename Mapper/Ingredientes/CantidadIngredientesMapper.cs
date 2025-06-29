using DAL.Configuraciones.Models;
using DAL.Ingredientes.Models;
using DAL.Insumos.Models;
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
                Id = cantidadIngrediente.Id,
                RecetaId = receta.Id,
                ComponenteRecetaId = cantidadIngrediente.ComponenteReceta.Id,
                UnidadDeMedidaId = cantidadIngrediente.UnidadDeMedida.Id,
                Cantidad = cantidadIngrediente.Cantidad,
                DesperdicioAceptado = cantidadIngrediente.DesperdicioAceptado
            };
        }
        public static List<CantidadIngrediente> ToCantidadIngredientes(this List<RecetaCantidadIngredienteModel> cantidadIngredienteModels, List<ComponenteRecetaModel> componenteRecetaModel, List<UnidadDeMedidaModel> unidadDeMedidaModels, List<InsumoModel> insumoModel, List<RecetaCantidadIngredienteModel> recetaCantidadIngredienteModels, List<IngredienteModel> ingredienteModels)
        {
            return cantidadIngredienteModels.Select(c => c.ToCantidadIngrediente(componenteRecetaModel, unidadDeMedidaModels, insumoModel, recetaCantidadIngredienteModels, ingredienteModels)).ToList();
        }
        public static CantidadIngrediente ToCantidadIngrediente(this RecetaCantidadIngredienteModel cantidadIngredienteModel, List<ComponenteRecetaModel> componenteRecetaModel, List<UnidadDeMedidaModel> unidadDeMedidaModels, List<InsumoModel> insumoModels, List<RecetaCantidadIngredienteModel> recetaCantidadIngredienteModels, List<IngredienteModel> ingredienteModels)
        {

            ComponenteReceta? componenteReceta = componenteRecetaModel.FirstOrDefault(i => i.ComponenteRecetaId == cantidadIngredienteModel.ComponenteRecetaId)?.ToComponenteReceta(insumoModels, recetaCantidadIngredienteModels, componenteRecetaModel, unidadDeMedidaModels, ingredienteModels);

            UnidadDeMedida? unidadDeMedida = unidadDeMedidaModels.FirstOrDefault(u => u.Id == cantidadIngredienteModel.UnidadDeMedidaId)?.ToUnidadDeMedida();

            if (componenteReceta == null)
            {
                throw new ArgumentException($"No se encontró el componenteReceta con ID {cantidadIngredienteModel.ComponenteRecetaId}");
            }

            if (unidadDeMedida == null)
            {
                throw new ArgumentException($"No se encontró la unidad de medida con ID {cantidadIngredienteModel.UnidadDeMedidaId}");
            }

            decimal costo = cantidadIngredienteModel.Costo??0;

            CantidadIngrediente cantidadIngrediente = new CantidadIngrediente
            {
                Id = cantidadIngredienteModel.Id,
                Cantidad = cantidadIngredienteModel.Cantidad,
                ComponenteReceta = componenteReceta,
                UnidadDeMedida = unidadDeMedida,
                DesperdicioAceptado = cantidadIngredienteModel.DesperdicioAceptado,
                Costo = costo,
            };

            return cantidadIngrediente;
        }
    }
}
