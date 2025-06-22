using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForm_UI.Contracts;

namespace WinForm_UI.Events
{
    internal class ProveedorChangedEvent : BaseEvent<Proveedor>
    {
        public ProveedorChangedEvent(Proveedor data, ActionType type) : base(data, type)
        {
        }
    }
}
