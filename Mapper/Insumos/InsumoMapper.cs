using DAL.Insumos.Models;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Insumos
{
    public static class InsumoMapper
    {
        public static Insumo ToInsumo(this InsumoModel insumoModel, List<TipoInsumoModel> tipoInsumoModels)
        {

            TipoInsumo? tipoInsumo = tipoInsumoModels.FirstOrDefault(t => t.Id == insumoModel.TipoInsumoId)?.ToTipoInsumo();

            if (tipoInsumo is null)
            {
                throw new ArgumentException($"Tipo de insumo con ID {insumoModel.TipoInsumoId} no encontrado.");
            }

            return new Insumo
            {
                Id = insumoModel.Id,
                Nombre = insumoModel.Nombre,
                Descripcion = insumoModel.Descripcion,
                Tipo = tipoInsumo
            };
        }
        public static InsumoModel ToModel(this Insumo insumo)
        {
            return new InsumoModel
            {
                Id = insumo.Id,
                Nombre = insumo.Nombre,
                Descripcion = insumo.Descripcion,
                TipoInsumoId = insumo.Tipo.Id
            };
        }
        public static List<Insumo> ToInsumos(this List<InsumoModel> insumosModels, List<TipoInsumoModel> tipoInsumoModels)
        {
            return insumosModels.Select(im => im.ToInsumo(tipoInsumoModels)).ToList();
        }
    }
}
