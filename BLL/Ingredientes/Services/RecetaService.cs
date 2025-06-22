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
    internal class RecetaService : IRecetaService
    {
        private readonly IRecetaRepository recetaRepository;
        private readonly IIngredienteUnitOfWork ingredienteUnitOfWork;
        private readonly IUnidadDeMedidaRepository unidadDeMedidaRepository;
        private readonly IIngredienteService ingredienteService;

        public RecetaService(IRecetaRepository recetaRepository, IIngredienteUnitOfWork ingredienteUnitOfWork, IUnidadDeMedidaRepository unidadDeMedidaRepository, IIngredienteService ingredienteService)
        {
            this.recetaRepository = recetaRepository;
            this.ingredienteUnitOfWork = ingredienteUnitOfWork;
            this.unidadDeMedidaRepository = unidadDeMedidaRepository;
            this.ingredienteService = ingredienteService;
        }
        public List<Receta> GetAll()
        {
            List<IngredienteModel> recetasModel = recetaRepository.GetAll();
            List<IngredienteModel> ingredienteModels = ingredienteUnitOfWork.GetAllIngredienteModel();
            List<RecetaCantidadIngredienteModel> recetaCantidadIngredienteModels = ingredienteUnitOfWork.GetAllRecetaCantidadIngredienteModels();
            List<UnidadDeMedidaModel> unidadDeMedidaModels = unidadDeMedidaRepository.GetAll();
            List<Receta> recetas = recetasModel.ToRecetas(recetaCantidadIngredienteModels, ingredienteModels, unidadDeMedidaModels);
            return recetas;
        }
        public List<Ingrediente> GetAvailableIngredientes(Receta receta)
        {
            return ingredienteService.GetAll().Where(i =>
            {
                if (i is Receta r)
                {
                    if (r.TieneReceta(receta))
                    {
                        return false; // No incluir recetas que ya contienen la receta actual
                    }
                    if (r.Id == receta.Id)
                    {
                        return false;
                    }
                }
                return true;
            }
            ).ToList();
        }
    }
}
