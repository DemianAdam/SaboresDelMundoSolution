using BLL.Insumos.Contracts;
using DAL.Insumos;
using DAL.Insumos.Contracts;
using DAL.Insumos.Models;
using Entities;
using Mapper.Insumos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Insumos.Services
{
    internal class InsumoService : IInsumoService
    {
        private readonly IInsumoUnitOfWork insumoRepository;

        public event EventHandler? OnOperationFinished;

        public InsumoService(IInsumoUnitOfWork insumoRepository)
        {
            this.insumoRepository = insumoRepository;
        }

        public List<Insumo> GetAll()
        {
            List<InsumoModel> insumoModels = insumoRepository.GetAllInsumos();
            List<TipoInsumoModel> tipoInsumoModels = insumoRepository.GetAllTiposInsumos();
            List<Insumo> insumos = insumoModels.ToInsumos(tipoInsumoModels);

            return insumos;
        }

        public void Insert(Insumo insumo)
        {
            InsumoModel insumoModel = insumo.ToModel();
            insumoRepository.Insert(insumoModel);
            OnOperationFinished?.Invoke(this, EventArgs.Empty);
        }

        public void Remove(Insumo insumo)
        {
            InsumoModel insumoModel = insumo.ToModel();
            insumoRepository.Remove(insumoModel);
            OnOperationFinished?.Invoke(this, EventArgs.Empty);

        }

        public void Update(Insumo insumo)
        {
            InsumoModel insumoModel = insumo.ToModel();
            insumoRepository.Update(insumoModel);
            OnOperationFinished?.Invoke(this, EventArgs.Empty);
        }
    }
}
