using DAL.Insumos.Models;
using Entities.Insumos;

namespace Mapper.Insumos
{
    public static class TipoInsumoMapper
    {
        public static TipoInsumoModel ToModel(this TipoInsumo tipoInsumo)
        {
            return new TipoInsumoModel
            {
                Id = tipoInsumo.Id,
                Tipo = tipoInsumo.Tipo,
            };
        }
        public static List<TipoInsumo> ToTiposInsumos(this List<TipoInsumoModel> tipos)
        {
            return tipos.Select(t => t.ToTipoInsumo()).ToList();
        }
        public static TipoInsumo ToTipoInsumo(this TipoInsumoModel tipo)
        {
            return new TipoInsumo
            {
                Id = tipo.Id,
                Tipo = tipo.Tipo,
            };
        }
    }
}
