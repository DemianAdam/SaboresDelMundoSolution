using BLL.Configuraciones.Contracts;
using DAL.Configuraciones.Contracts;
using DAL.Configuraciones.Models;
using Entities;
using Mapper.Configuraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Configuraciones.Services
{
    internal class UnidadDeMedidaService : IUnidadDeMedidaService
    {
        private readonly IUnidadDeMedidaRepository unidadDeMedidaRepository;

        public event EventHandler? OnOperationFinished;

        public UnidadDeMedidaService(IUnidadDeMedidaRepository unidadDeMedidaRepository)
        {
            this.unidadDeMedidaRepository = unidadDeMedidaRepository;
        }

        public List<UnidadDeMedida> GetAll()
        {
            List<UnidadDeMedidaModel> unidadDeMedidaModels = unidadDeMedidaRepository.GetAll();
            return unidadDeMedidaModels.ToUnidadDeMedidas();
        }

        public void Insert(UnidadDeMedida tipoProducto)
        {
            unidadDeMedidaRepository.Insert(tipoProducto.ToModel());
            OnOperationFinished?.Invoke(tipoProducto, EventArgs.Empty);
        }

        public void Remove(UnidadDeMedida tipoProducto)
        {
            unidadDeMedidaRepository.Remove(tipoProducto.ToModel());
            OnOperationFinished?.Invoke(tipoProducto, EventArgs.Empty);
        }

        public void Update(UnidadDeMedida tipoProducto)
        {
            unidadDeMedidaRepository.Update(tipoProducto.ToModel());
            OnOperationFinished?.Invoke(tipoProducto, EventArgs.Empty);
        }
    }
}
