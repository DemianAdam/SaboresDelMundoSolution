using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_UI.Events
{
    internal class UnidadDeMedidaChangedEvent : BaseEvent<UnidadDeMedida>
    {
        public UnidadDeMedidaChangedEvent(UnidadDeMedida data, ActionType type) : base(data, type)
        {
        }
    }
}
