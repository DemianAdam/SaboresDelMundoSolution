using DAL.Compartido.Models;
using DAL.Compra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Compra
{
    public interface ICompraUnitOfWork
    {
        public List<ProveedorModel> GetAllProveedores();
        public List<CompraModel> GetAllCompras();
        public List<DetalleCompraModel> GetAllDetalleCompras();
        public void Insert(ProveedorModel compra);
        public void Remove(ProveedorModel compra);
        public void Update(ProveedorModel compra);

        public void Insert(CompraModel compra, List<DetalleCompraModel>? detalleCompraModels, List<PagoModel>? pagoModels);
        public void Remove(CompraModel compra);
        public void Update(CompraModel compra, List<DetalleCompraModel>? detalleCompraModels, List<PagoModel>? pagoModels);
    }
}
