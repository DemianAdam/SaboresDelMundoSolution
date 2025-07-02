using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForm_UI.Helpers;

namespace WinForm_UI.Contracts
{
    internal interface IDataForm<T> : IGetInput<T>
        where T : class
    {
        List<ColumnConfiguration> ColumnsConfiguration { get; }
        void UpdateData();
    }
}
