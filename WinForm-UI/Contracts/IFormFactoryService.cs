using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_UI.Contracts
{
    public interface IFormFactoryService
    {
        T CreateForm<T>(params object[] parameters) where T : Form;
    }
}
