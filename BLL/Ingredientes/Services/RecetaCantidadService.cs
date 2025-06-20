using BLL.Ingredientes.Contracts;
using DAL.Configuraciones.Contracts;
using DAL.Configuraciones.Models;
using DAL.Ingredientes;
using DAL.Ingredientes.Contracts;
using DAL.Ingredientes.Models;
using Entities;
using Mapper.Ingredientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Ingredientes.Services
{
    internal class RecetaCantidadService : IRecetaCantidadService
    {
        private readonly IRecetaCantidadIngredienteRepository recetaCantidadIngredienteRepository;
        private readonly IIngredienteUnitOfWork ingredienteUnitOfWork;
        private readonly IUnidadDeMedidaRepository unidadDeMedidaRepository;

        public event EventHandler? OnOperationFinished;
        public RecetaCantidadService(IRecetaCantidadIngredienteRepository recetaCantidadIngredienteRepository, IIngredienteUnitOfWork ingredienteUnitOfWork, IUnidadDeMedidaRepository unidadDeMedidaRepository)
        {
            this.recetaCantidadIngredienteRepository = recetaCantidadIngredienteRepository;
            this.ingredienteUnitOfWork = ingredienteUnitOfWork;
            this.unidadDeMedidaRepository = unidadDeMedidaRepository;
        }
        public List<CantidadIngrediente> GetAll()
        {
            List<RecetaCantidadIngredienteModel> recetaCantidadIngredienteModels = recetaCantidadIngredienteRepository.GetAll();
            List<IngredienteModel> ingredienteModels = ingredienteUnitOfWork.GetAllIngredienteModel();
            List<UnidadDeMedidaModel> unidadDeMedidaModels = unidadDeMedidaRepository.GetAll();

            return recetaCantidadIngredienteModels.ToCantidadIngredientes(ingredienteModels, unidadDeMedidaModels, recetaCantidadIngredienteModels);
        }

        public void Insert(CantidadIngrediente cantidadIngrediente, Receta receta)
        {
            RecetaCantidadIngredienteModel recetaCantidadIngredienteModel = cantidadIngrediente.ToModel(receta);
            recetaCantidadIngredienteRepository.Insert(recetaCantidadIngredienteModel);
            OnOperationFinished?.Invoke(this, EventArgs.Empty);
        }

        public void Remove(CantidadIngrediente cantidadIngrediente, Receta receta)
        {
            RecetaCantidadIngredienteModel recetaCantidadIngredienteModel = cantidadIngrediente.ToModel(receta);
            recetaCantidadIngredienteRepository.Remove(recetaCantidadIngredienteModel);
            OnOperationFinished?.Invoke(this, EventArgs.Empty);
        }

        public void Update(CantidadIngrediente cantidadIngrediente, Receta receta)
        {
            RecetaCantidadIngredienteModel recetaCantidadIngredienteModel = cantidadIngrediente.ToModel(receta);
            recetaCantidadIngredienteRepository.Update(recetaCantidadIngredienteModel);
            OnOperationFinished?.Invoke(this, EventArgs.Empty);
        }

        public List<CantidadIngrediente> GetAllByReceta(Receta receta)
        {
            List<RecetaCantidadIngredienteModel> recetaCantidadIngredienteModels = recetaCantidadIngredienteRepository.GetAllByRecetaId(receta.Id);
            List<IngredienteModel> ingredienteModels = ingredienteUnitOfWork.GetAllIngredienteModel();
            List<UnidadDeMedidaModel> unidadDeMedidaModels = unidadDeMedidaRepository.GetAll();
            return recetaCantidadIngredienteModels.ToCantidadIngredientes(ingredienteModels, unidadDeMedidaModels, recetaCantidadIngredienteModels);
        }
    }
}
