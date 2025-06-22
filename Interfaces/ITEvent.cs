using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_UI.Contracts
{
    public interface ITEvent<T> : IEvent
    {
        T Data { get; }
    }
}
