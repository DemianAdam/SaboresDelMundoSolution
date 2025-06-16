using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_UI.Contracts
{
    public interface IEventBus
    {
        void Subscribe<TEvent>(Action<TEvent> handler) where TEvent : IEvent;
        void Unsubscribe<TEvent>(Action<TEvent> handler) where TEvent : IEvent;
        void Publish<TEvent>(TEvent eventMessage) where TEvent : IEvent;
    }
}
