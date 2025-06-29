using Entities.Productos;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_UI.Events
{
    internal class TipoProductoChangedEvent : BaseEvent<TipoProducto>
    {
        public TipoProductoChangedEvent(TipoProducto data, ActionType type) : base(data, type)
        {
        }
    }
}
