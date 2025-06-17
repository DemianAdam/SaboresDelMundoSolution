using BLL.Ingredientes.Contracts;
using DAL.Configuraciones.Contracts;
using DAL.Configuraciones.Models;
using DAL.Ingredientes;
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
    internal class IngredienteService : IIngredienteService
    {
        private readonly IIngredienteUnitOfWork ingredienteUnitOfWork;
        private readonly IUnidadDeMedidaRepository unidadDeMedidaRepository;

        public IngredienteService(IIngredienteUnitOfWork ingredienteUnitOfWork, IUnidadDeMedidaRepository unidadDeMedidaRepository)
        {
            this.ingredienteUnitOfWork = ingredienteUnitOfWork;
            this.unidadDeMedidaRepository = unidadDeMedidaRepository;
        }
        public event EventHandler? OnOperationFinished;

        public List<Ingrediente> GetAll()
        {
            List<IngredienteModel> ingredienteModels = ingredienteUnitOfWork.GetAllIngredienteModel();
            List<RecetaCantidadIngredienteModel> recetaCantidadIngredienteModels = ingredienteUnitOfWork.GetAllRecetaCantidadIngredienteModels();
            List<UnidadDeMedidaModel> unidadDeMedidaModels = unidadDeMedidaRepository.GetAll();

            List<Ingrediente> ingredientes = ingredienteModels.ToIngredientes(recetaCantidadIngredienteModels, ingredienteModels, unidadDeMedidaModels);

            return ingredientes;
        }

        public void Insert(Ingrediente ingrediente)
        {
            IngredienteModel ingredienteModel = ingrediente.ToModel();
            List<RecetaCantidadIngredienteModel>? recetaCantidadIngredienteModels = null;
            if (ingrediente is Receta receta)
            {
                recetaCantidadIngredienteModels = receta.CantidadIngredientes?.ToModels(receta);
            }
            try
            {
                ingredienteUnitOfWork.Insert(ingredienteModel, recetaCantidadIngredienteModels);
                OnOperationFinished?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public void Remove(Ingrediente ingrediente)
        {
            IngredienteModel ingredienteModel = ingrediente.ToModel();
            try
            {
                ingredienteUnitOfWork.Remove(ingredienteModel);
                OnOperationFinished?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public void Update(Ingrediente ingrediente)
        {
            IngredienteModel ingredienteModel = ingrediente.ToModel();
            List<RecetaCantidadIngredienteModel>? recetaCantidadIngredienteModels = null;
            if (ingrediente is Receta receta)
            {
                recetaCantidadIngredienteModels = receta.CantidadIngredientes?.ToModels(receta);
            }
            try
            {
                ingredienteUnitOfWork.Update(ingredienteModel, recetaCantidadIngredienteModels);
                OnOperationFinished?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
