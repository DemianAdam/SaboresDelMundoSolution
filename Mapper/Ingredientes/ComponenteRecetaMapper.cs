using DAL.Configuraciones.Models;
using DAL.Ingredientes.Models;
using DAL.Insumos.Models;
using Entities.Ingredientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Ingredientes
{
    public static class ComponenteRecetaMapper
    {
        public static ComponenteReceta ToComponenteReceta(this ComponenteRecetaModel componenteRecetaModel,List<InsumoModel> insumoModels, List<RecetaCantidadIngredienteModel> recetaCantidadIngredienteModels, List<ComponenteRecetaModel> componenteRecetaModels, List<UnidadDeMedidaModel> unidadDeMedidaModels,List<IngredienteModel> ingredienteModels)
        {
            if (componenteRecetaModel is IngredienteModel ingredienteModel)
            {
                return ingredienteModel.ToIngrediente(insumoModels);
            }
            else if (componenteRecetaModel is RecetaModel recetaModel)
            {
                return recetaModel.ToReceta(recetaCantidadIngredienteModels,componenteRecetaModels,unidadDeMedidaModels,insumoModels, ingredienteModels);
            }
            else
            {
                throw new ArgumentException($"Tipo de componenteReceta no reconocido: {componenteRecetaModel.GetType().Name}");
            }
        }
    }
}
