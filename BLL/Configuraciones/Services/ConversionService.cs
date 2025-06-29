using BLL.Configuraciones.Contracts;
using DAL.Configuraciones.Contracts;
using DAL.Configuraciones.Models;
using DAL.Insumos;
using DAL.Insumos.Models;
using Entities.Configuraciones;
using Mapper.Configuraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Configuraciones.Services
{
    internal class ConversionService : IConversionService
    {
        private readonly IConversionRepository conversionRepository;
        private readonly IUnidadDeMedidaRepository unidadDeMedidaRepository;
        private readonly IInsumoUnitOfWork insumoUnitOfWork;

        public ConversionService(IConversionRepository conversionRepository, IUnidadDeMedidaRepository unidadDeMedidaRepository, IInsumoUnitOfWork insumoUnitOfWork)
        {
            this.conversionRepository = conversionRepository;
            this.unidadDeMedidaRepository = unidadDeMedidaRepository;
            this.insumoUnitOfWork = insumoUnitOfWork;
        }
        public event EventHandler? OnOperationFinished;

        public List<Conversion> GetAll()
        {
            List<ConversionModel> conversionModels = conversionRepository.GetAll();
            List<UnidadDeMedidaModel> unidadDeMedidaModels = unidadDeMedidaRepository.GetAll();
            List<InsumoModel> insumoModels = insumoUnitOfWork.GetAllInsumos();
            List<TipoInsumoModel> tipoInsumoModels = insumoUnitOfWork.GetAllTiposInsumos();
            return conversionModels.ToConversiones(unidadDeMedidaModels, insumoModels, tipoInsumoModels);
        }

        public void Insert(Conversion conversion)
        {
            ConversionModel conversionModel = conversion.ToModel();
            conversionRepository.Insert(conversionModel);
            OnOperationFinished?.Invoke(this, EventArgs.Empty);
        }

        public void Remove(Conversion conversion)
        {
            ConversionModel conversionModel = conversion.ToModel();
            conversionRepository.Remove(conversionModel);
            OnOperationFinished?.Invoke(this, EventArgs.Empty);
        }

        public void Update(Conversion conversion)
        {
            ConversionModel conversionModel = conversion.ToModel();
            conversionRepository.Update(conversionModel);
            OnOperationFinished?.Invoke(this, EventArgs.Empty);
        }
    }
}
