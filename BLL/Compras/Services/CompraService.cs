using BLL.Compras.Contracts;
using DAL.Compartido.Contracts;
using DAL.Compartido.Models;
using DAL.Compra;
using DAL.Compra.Models;
using DAL.Configuraciones.Contracts;
using DAL.Configuraciones.Models;
using DAL.Insumos;
using DAL.Insumos.Models;
using Entities;
using Mapper.Compartido;
using Mapper.Transacciones.Compras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Compras.Services
{
    internal class CompraService : ICompraService
    {
        private readonly ICompraUnitOfWork compraUnitOfWork;
        private readonly IInsumoUnitOfWork insumoUnitOfWork;
        private readonly IUnidadDeMedidaRepository unidadDeMedidaRepository;
        private readonly IPagoRepository pagoRepository;

        public event EventHandler? OnOperationFinished;

        public CompraService(ICompraUnitOfWork compraUnitOfWork, IInsumoUnitOfWork insumoUnitOfWork, IUnidadDeMedidaRepository unidadDeMedidaRepository, IPagoRepository pagoRepository)
        {
            this.compraUnitOfWork = compraUnitOfWork;
            this.insumoUnitOfWork = insumoUnitOfWork;
            this.unidadDeMedidaRepository = unidadDeMedidaRepository;
            this.pagoRepository = pagoRepository;
        }

        public List<Compra> GetAll()
        {
            List<CompraModel> compras = compraUnitOfWork.GetAllCompras();
            List<DetalleCompraModel> detalleCompras = compraUnitOfWork.GetAllDetalleCompras();
            List<InsumoModel> insumos = insumoUnitOfWork.GetAllInsumos();
            List<TipoInsumoModel> tiposInsumos = insumoUnitOfWork.GetAllTiposInsumos();
            List<UnidadDeMedidaModel> unidadDeMedidas = unidadDeMedidaRepository.GetAll();
            List<ProveedorModel> proveedores = compraUnitOfWork.GetAllProveedores();
            List<PagoModel> pagos = pagoRepository.GetAll();
            return compras.ToCompras(detalleCompras, insumos, tiposInsumos, unidadDeMedidas, proveedores, pagos);
        }

        public void Insert(Compra compra)
        {
            List<DetalleCompraModel>? detalleCompraModels = compra.Detalles?.ToModels(compra);
            List<PagoModel>? pagoModels = compra.Pagos?.ToModels(compra);
            CompraModel compraModel = compra.ToModel();
            compraUnitOfWork.Insert(compraModel, detalleCompraModels, pagoModels);
            OnOperationFinished?.Invoke(this, EventArgs.Empty);
        }

        public void Remove(Compra compra)
        {
            CompraModel compraModel = compra.ToModel();
            compraUnitOfWork.Remove(compraModel);
            OnOperationFinished?.Invoke(this, EventArgs.Empty);
        }

        public void Update(Compra compra)
        {
            List<DetalleCompraModel>? detalleCompraModels = compra.Detalles?.ToModels(compra);
            List<PagoModel>? pagoModels = compra.Pagos?.ToModels(compra);
            CompraModel compraModel = compra.ToModel();
            compraUnitOfWork.Update(compraModel, detalleCompraModels, pagoModels);
            OnOperationFinished?.Invoke(this, EventArgs.Empty);
        }
    }
}
