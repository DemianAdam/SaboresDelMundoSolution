using DAL.Insumos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Insumos
{
    public interface IInsumoUnitOfWork
    { 
        public List<InsumoModel> GetAllInsumos();
        public List<TipoInsumoModel> GetAllTiposInsumos();
        public void Insert(InsumoModel insumo);
        public void Remove(InsumoModel insumo);
        public void Update(InsumoModel insumo);
        public void Insert(TipoInsumoModel tipoInsumo);
        public void Remove(TipoInsumoModel tipoInsumo);
        public void Update(TipoInsumoModel tipoInsumo);
        bool Exists(InsumoModel insumoModel);
    }
}
