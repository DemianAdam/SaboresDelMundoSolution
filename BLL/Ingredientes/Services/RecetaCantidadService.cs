using BLL.Ingredientes.Contracts;
using DAL.Configuraciones.Contracts;
using DAL.Configuraciones.Models;
using DAL.Ingredientes;
using DAL.Ingredientes.Contracts;
using DAL.Ingredientes.Models;
using DAL.Insumos;
using DAL.Insumos.Models;
using Entities.Ingredientes;
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
        private readonly IInsumoUnitOfWork insumoUnitOfWork;
        private readonly IRecetaRepository recetaRepository;

        public event EventHandler? OnOperationFinished;
        public RecetaCantidadService(IRecetaCantidadIngredienteRepository recetaCantidadIngredienteRepository, IIngredienteUnitOfWork ingredienteUnitOfWork, IUnidadDeMedidaRepository unidadDeMedidaRepository, IInsumoUnitOfWork insumoUnitOfWork, IRecetaRepository recetaRepository)
        {
            this.recetaCantidadIngredienteRepository = recetaCantidadIngredienteRepository;
            this.ingredienteUnitOfWork = ingredienteUnitOfWork;
            this.unidadDeMedidaRepository = unidadDeMedidaRepository;
            this.insumoUnitOfWork = insumoUnitOfWork;
            this.recetaRepository = recetaRepository;
        }
        public List<CantidadIngrediente> GetAll()
        {
            List<RecetaCantidadIngredienteModel> recetaCantidadIngredienteModels = recetaCantidadIngredienteRepository.GetAll();
            List<IngredienteModel> ingredienteModels = ingredienteUnitOfWork.GetAllIngredienteModel();
            List<ComponenteRecetaModel> componenteRecetaModels = new List<ComponenteRecetaModel>();
            componenteRecetaModels.AddRange(ingredienteModels);
            componenteRecetaModels.AddRange(recetaRepository.GetAll());
            List<UnidadDeMedidaModel> unidadDeMedidaModels = unidadDeMedidaRepository.GetAll();
            List<InsumoModel> insumoModels = insumoUnitOfWork.GetAllInsumos();

            return recetaCantidadIngredienteModels.ToCantidadIngredientes(componenteRecetaModels, unidadDeMedidaModels, insumoModels, recetaCantidadIngredienteModels, ingredienteModels);
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
            List<RecetaCantidadIngredienteModel> allRecetaCantidadIngredient = recetaCantidadIngredienteRepository.GetAll();
            List<RecetaCantidadIngredienteModel> recetaCantidadIngredienteModels = allRecetaCantidadIngredient.Where(x => x.RecetaId == receta.Id).ToList();
            List<IngredienteModel> ingredienteModels = ingredienteUnitOfWork.GetAllIngredienteModel();
            List<ComponenteRecetaModel> componenteRecetaModels = new List<ComponenteRecetaModel>();
            componenteRecetaModels.AddRange(ingredienteModels);
            componenteRecetaModels.AddRange(recetaRepository.GetAll());
            List<UnidadDeMedidaModel> unidadDeMedidaModels = unidadDeMedidaRepository.GetAll();
            List<InsumoModel> insumoModels = insumoUnitOfWork.GetAllInsumos();
            return recetaCantidadIngredienteModels.ToCantidadIngredientes(componenteRecetaModels, unidadDeMedidaModels, insumoModels, allRecetaCantidadIngredient, ingredienteModels);
        }
    }
}
