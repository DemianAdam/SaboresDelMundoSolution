using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_UI.Contracts
{
    internal interface IDataForm<T> : IGetInput<T>
        where T : class
    {
        void UpdateData();
    }
}
