using BLL.Compartido.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_UI.Contracts
{
    public interface IContextFactory
    {
        public T CreateInstance<T>(params object[] parameters) where T : IContext;
    }
}
