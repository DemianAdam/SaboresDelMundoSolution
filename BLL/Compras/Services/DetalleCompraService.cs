using BLL.Compras.Contracts;
using DAL.Compra.Contracts;
using DAL.Compra.Models;
using DAL.Configuraciones.Contracts;
using DAL.Configuraciones.Models;
using DAL.Insumos;
using DAL.Insumos.Models;
using Entities;
using Mapper.Transacciones.Compras;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Compras.Services
{
    internal class DetalleCompraService : IDetalleCompraService
    {
        private readonly IDetalleCompraRepository detalleCompraRepository;
        private readonly IInsumoUnitOfWork insumoUnitOfWork;
        private readonly IUnidadDeMedidaRepository unidadDeMedidaRepository;

        public event EventHandler? OnOperationFinished;
        public DetalleCompraService(IDetalleCompraRepository detalleCompraRepository, IInsumoUnitOfWork insumoUnitOfWork, IUnidadDeMedidaRepository unidadDeMedidaRepository)
        {
            this.detalleCompraRepository = detalleCompraRepository;
            this.insumoUnitOfWork = insumoUnitOfWork;
            this.unidadDeMedidaRepository = unidadDeMedidaRepository;
        }
        public List<DetalleCompra> GetAll()
        {
            List<InsumoModel> insumos = insumoUnitOfWork.GetAllInsumos();
            List<TipoInsumoModel> tiposInsumos = insumoUnitOfWork.GetAllTiposInsumos();
            List<UnidadDeMedidaModel> unidadDeMedidas = unidadDeMedidaRepository.GetAll();
            List<DetalleCompra> list = detalleCompraRepository.GetAll().ToDetalles(insumos, tiposInsumos, unidadDeMedidas);
            return list;
        }

        public List<DetalleCompra> GetAllByPurchaseId(Compra compra)
        {
            List<InsumoModel> insumos = insumoUnitOfWork.GetAllInsumos();
            List<TipoInsumoModel> tiposInsumos = insumoUnitOfWork.GetAllTiposInsumos();
            List<UnidadDeMedidaModel> unidadDeMedidas = unidadDeMedidaRepository.GetAll();
            CompraModel compraModel = compra.ToModel();
            List<DetalleCompra> list = detalleCompraRepository.GetAllByCompraId(compraModel).ToDetalles(insumos, tiposInsumos, unidadDeMedidas);
            return list;
        }

        public void Insert(DetalleCompra detalleCompra, Compra compra)
        {
            DetalleCompraModel detalleCompraModel = detalleCompra.ToModel(compra);
            detalleCompraRepository.Insert(detalleCompraModel);
        }

        public void Remove(DetalleCompra detalleCompra)
        {
            DetalleCompraModel detalleCompraModel = detalleCompra.ToModel(new Compra());
            detalleCompraRepository.Remove(detalleCompraModel);
            OnOperationFinished?.Invoke(this, EventArgs.Empty);
        }

        public void Update(DetalleCompra detalleCompra, Compra compra)
        {
            DetalleCompraModel detalleCompraModel = detalleCompra.ToModel(compra);
            detalleCompraRepository.Update(detalleCompraModel);
            OnOperationFinished?.Invoke(this, EventArgs.Empty);
        }
    }
}
