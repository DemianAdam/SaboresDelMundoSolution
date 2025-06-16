using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Configuraciones.Models;
using Entities;

namespace Mapper.Configuraciones
{
    public static class UnidadDeMedidaMapper
    {
        public static List<UnidadDeMedida> ToUnidadDeMedidas(this List<UnidadDeMedidaModel> unidadDeMedidaModels)
        {
            return unidadDeMedidaModels.Select(udm => udm.ToUnidadDeMedida()).ToList();
        }

        public static UnidadDeMedida ToUnidadDeMedida(this UnidadDeMedidaModel unidadDeMedidaModel)
        {
            return new UnidadDeMedida
            {
                Id = unidadDeMedidaModel.Id,
                Unidad = unidadDeMedidaModel.Unidad,
            };
        }
        public static UnidadDeMedidaModel ToModel(this UnidadDeMedida unidadDeMedida)
        {
            return new UnidadDeMedidaModel
            {
                Id = unidadDeMedida.Id,
                Unidad = unidadDeMedida.Unidad,
            };
        }
    }
}
