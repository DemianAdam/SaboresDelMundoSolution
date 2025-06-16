using BLL.Insumos.Contracts;
using Entities;
using DAL.Insumos.Contracts;
using DAL.Insumos.Models;
using Mapper.Insumos;
using DAL.Insumos;

namespace BLL.Insumos.Services
{
    internal class TipoInsumoService : ITipoInsumoService
    {
        private readonly IInsumoUnitOfWork tipoInsumoRepository;

        public event EventHandler? OnOperationFinished;
        public TipoInsumoService(IInsumoUnitOfWork tipoInsumoRepository)
        {
            this.tipoInsumoRepository = tipoInsumoRepository;
        }

        public List<TipoInsumo> GetAll()
        {
            List<TipoInsumoModel> tipoInsumoModels = tipoInsumoRepository.GetAllTiposInsumos();
            return tipoInsumoModels.ToTiposInsumos();
        }

        public void Insert(TipoInsumo tipoInsumo)
        {
            TipoInsumoModel tipoInsumoModel = tipoInsumo.ToModel();
            tipoInsumoRepository.Insert(tipoInsumoModel);
            OnOperationFinished?.Invoke(this, EventArgs.Empty);
        }

        public void Remove(TipoInsumo tipoInsumo)
        {
            TipoInsumoModel tipoInsumoModel = tipoInsumo.ToModel();
            tipoInsumoRepository.Remove(tipoInsumoModel);
            OnOperationFinished?.Invoke(this, EventArgs.Empty);
        }

        public void Update(TipoInsumo tipoInsumo)
        {
            TipoInsumoModel tipoInsumoModel = tipoInsumo.ToModel();
            tipoInsumoRepository.Update(tipoInsumoModel);
            OnOperationFinished?.Invoke(this, EventArgs.Empty);
        }
    }
}
