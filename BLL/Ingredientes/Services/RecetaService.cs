using BLL.Ingredientes.Contracts;
using DAL.Configuraciones.Contracts;
using DAL.Configuraciones.Models;
using DAL.Ingredientes;
using DAL.Ingredientes.Contracts;
using DAL.Ingredientes.Models;
using DAL.Insumos;
using DAL.Insumos.Models;
using Entities;
using Mapper.Ingredientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Ingredientes.Services
{
    internal class RecetaService : IRecetaService
    {
        private readonly IRecetaRepository recetaRepository;
        private readonly IIngredienteUnitOfWork ingredienteUnitOfWork;
        private readonly IUnidadDeMedidaRepository unidadDeMedidaRepository;
        private readonly IInsumoUnitOfWork insumoUnitOfWork;

        public RecetaService(IRecetaRepository recetaRepository, IIngredienteUnitOfWork ingredienteUnitOfWork, IUnidadDeMedidaRepository unidadDeMedidaRepository, IInsumoUnitOfWork insumoUnitOfWork)
        {
            this.recetaRepository = recetaRepository;
            this.ingredienteUnitOfWork = ingredienteUnitOfWork;
            this.unidadDeMedidaRepository = unidadDeMedidaRepository;
            this.insumoUnitOfWork = insumoUnitOfWork;
        }

        public event EventHandler? OnOperationFinished;

        public List<Receta> GetAll()
        {
            List<RecetaModel> recetasModel = recetaRepository.GetAll();
            List<IngredienteModel> ingredienteModels = ingredienteUnitOfWork.GetAllIngredienteModel();
            List<ComponenteRecetaModel> componenteRecetaModels = new List<ComponenteRecetaModel>();
            componenteRecetaModels.AddRange(ingredienteModels);
            componenteRecetaModels.AddRange(recetasModel);
            List<RecetaCantidadIngredienteModel> recetaCantidadIngredienteModels = ingredienteUnitOfWork.GetAllRecetaCantidadIngredienteModels();
            List<UnidadDeMedidaModel> unidadDeMedidaModels = unidadDeMedidaRepository.GetAll();
            List<InsumoModel> insumoModels = insumoUnitOfWork.GetAllInsumos();
            List<Receta> recetas = recetasModel.ToRecetas(recetaCantidadIngredienteModels, componenteRecetaModels, unidadDeMedidaModels, insumoModels, ingredienteModels);
            return recetas;
        }
        public List<ComponenteReceta> GetAvailableIngredientes(Receta receta)
        {
            List<ComponenteReceta> componenteRecetas = new List<ComponenteReceta>();
            List<InsumoModel> insumoModels = insumoUnitOfWork.GetAllInsumos();
            List<IngredienteModel> ingredientesModel = ingredienteUnitOfWork.GetAllIngredienteModel();

            List<Ingrediente> ingredientes = ingredientesModel.ToIngredientes(insumoModels);
            List<Receta> recetas = GetAll().Where(r =>
            {
                if (r.TieneReceta(receta))
                {
                    return false; // No incluir recetas que ya contienen la receta actual
                }
                if (r.Id == receta.Id)
                {
                    return false; // No incluir la receta actual
                }
                return true; // Incluir recetas que no contienen la receta actual
            }
            ).ToList();

            componenteRecetas.AddRange(ingredientes);
            componenteRecetas.AddRange(recetas);
            return componenteRecetas;
        }

        public void Insert(Receta receta)
        {
            RecetaModel recetaModel = receta.ToModel();
            try
            {
                recetaRepository.Insert(recetaModel);
                OnOperationFinished?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void Remove(Receta receta)
        {
            RecetaModel recetaModel = receta.ToModel();
            try
            {
                recetaRepository.Remove(recetaModel);
                OnOperationFinished?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Receta updatedReceta)
        {
            RecetaModel recetaModel = updatedReceta.ToModel();
            try
            {
                recetaRepository.Update(recetaModel);
                OnOperationFinished?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
