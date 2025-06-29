using BLL.Ingredientes.Contracts;
using BLL.Insumos.Contracts;
using DAL.Ingredientes;
using DAL.Ingredientes.Models;
using DAL.Insumos;
using DAL.Insumos.Contracts;
using DAL.Insumos.Models;
using Entities.Insumos;
using Mapper.Ingredientes;
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
        private readonly IInsumoUnitOfWork insumoUnitOfWork;

        public event EventHandler? OnOperationFinished;

        public InsumoService(IInsumoUnitOfWork insumoRepository)
        {
            this.insumoUnitOfWork = insumoRepository;
        }

        public List<Insumo> GetAll()
        {
            List<InsumoModel> insumoModels = insumoUnitOfWork.GetAllInsumos();
            List<TipoInsumoModel> tipoInsumoModels = insumoUnitOfWork.GetAllTiposInsumos();
            List<Insumo> insumos = insumoModels.ToInsumos(tipoInsumoModels);

            return insumos;
        }

        public void Insert(Insumo insumo)
        {
            InsumoModel insumoModel = insumo.ToModel();
            if (insumoUnitOfWork.Exists(insumoModel))
            {
                throw new Exception("El insumo ya existe en la base de datos.");
            }
            insumoUnitOfWork.Insert(insumoModel);
            OnOperationFinished?.Invoke(this, EventArgs.Empty);
        }

        public void Remove(Insumo insumo)
        {
            InsumoModel insumoModel = insumo.ToModel();
            insumoUnitOfWork.Remove(insumoModel);
            OnOperationFinished?.Invoke(this, EventArgs.Empty);

        }

        public void Update(Insumo insumo)
        {
            InsumoModel insumoModel = insumo.ToModel();
            insumoUnitOfWork.Update(insumoModel);
            OnOperationFinished?.Invoke(this, EventArgs.Empty);
        }
    }
}
