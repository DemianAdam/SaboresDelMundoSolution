using DAL.Configuraciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configuraciones.Contracts
{
    public interface IUnidadDeMedidaRepository
    {
        void Insert(UnidadDeMedidaModel unidadDeMedida);
        void Remove(UnidadDeMedidaModel unidadDeMedida);
        void Update(UnidadDeMedidaModel unidadDeMedida);
        List<UnidadDeMedidaModel> GetAll();
    }
}
