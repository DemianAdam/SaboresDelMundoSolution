using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Compras.Contracts
{
    public interface IValidator<T>
    {
        bool Validate(T entity);
    }
}
