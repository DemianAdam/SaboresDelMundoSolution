using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForm_UI.Events;

namespace WinForm_UI.Contracts
{
    public interface IEvent
    {
        ActionType Type { get; }
    }
}
