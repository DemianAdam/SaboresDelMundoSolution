using DAL.Configuraciones.Models;
using DAL.Insumos.Models;
using Entities.Configuraciones;
using Entities.Insumos;
using Mapper.Insumos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Configuraciones
{
    public static class ConversionMapper
    {
        public static ConversionModel ToModel(this Conversion conversion)
        {
            return new ConversionModel
            {
                Id = conversion.Id,
                InsumoId = conversion.Insumo.Id,
                UnidadFromId = conversion.UnidadDeMedidaFrom.Id,
                UnidadToId = conversion.UnidadDeMedidaTo.Id,
                Factor = conversion.Factor
            };
        }
        public static List<Conversion> ToConversiones(this List<ConversionModel> conversionModels, List<UnidadDeMedidaModel> unidadDeMedidas, List<InsumoModel> insumoModels, List<TipoInsumoModel> tipoInsumoModels)
        {
            return conversionModels.Select(cm => cm.ToConversion(unidadDeMedidas, insumoModels, tipoInsumoModels)).ToList();
        }
        public static Conversion ToConversion(this ConversionModel conversionModel, List<UnidadDeMedidaModel> unidadDeMedidas, List<InsumoModel> insumoModels, List<TipoInsumoModel> tipoInsumoModels)
        {
            Insumo? insumo = insumoModels.FirstOrDefault(i => i.Id == conversionModel.InsumoId)?.ToInsumo(tipoInsumoModels);
            UnidadDeMedida? unidadFrom = unidadDeMedidas.FirstOrDefault(u => u.Id == conversionModel.UnidadFromId)?.ToUnidadDeMedida();
            UnidadDeMedida? unidadTo = unidadDeMedidas.FirstOrDefault(u => u.Id == conversionModel.UnidadToId)?.ToUnidadDeMedida();

            if (insumo == null || unidadFrom == null || unidadTo == null)
            {
                throw new ArgumentException("Invalid conversion model data.");
            }

            return new Conversion(conversionModel.Id, insumo, unidadFrom, unidadTo, conversionModel.Factor);
        }
    }
}
