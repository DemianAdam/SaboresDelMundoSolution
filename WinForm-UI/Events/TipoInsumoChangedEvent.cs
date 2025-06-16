using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_UI.Events
{


    internal class TipoInsumoChangedEvent : BaseEvent<TipoInsumo>
    {
        public TipoInsumoChangedEvent(TipoInsumo data, ActionType type) : base(data, type)
        {
        }
    }
}
