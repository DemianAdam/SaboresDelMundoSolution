using DAL.Configuraciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configuraciones.Contracts
{
    public interface IConversionRepository
    {
        void Insert(ConversionModel conversion);
        void Remove(ConversionModel conversion);
        void Update(ConversionModel conversion);
        List<ConversionModel> GetAll();
    }
}
