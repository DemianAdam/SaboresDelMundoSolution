using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForm_UI.Contracts;


namespace WinForm_UI.Events
{
    internal abstract class BaseEvent<T> : ITEvent<T>
    {
        protected BaseEvent(T data, ActionType type)
        {
            Data = data;
            Type = type;
        }
        public T Data { get; }

        public ActionType Type { get; }
    }
}
