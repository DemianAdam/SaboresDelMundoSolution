using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForm_UI.Contracts;

namespace WinForm_UI.Services
{
    internal class EventBus : IEventBus
    {
        private readonly Dictionary<Type, List<Delegate>> _subscribers = new();
        public void Subscribe<TEvent>(Action<TEvent> handler) where TEvent : IEvent
        {
            Type eventType = typeof(TEvent);
            if (!_subscribers.TryGetValue(eventType, out List<Delegate>? value))
            {
                value = new List<Delegate>();
                _subscribers[eventType] = value;
            }

            value.Add(handler);
        }
        public void Unsubscribe<TEvent>(Action<TEvent> handler) where TEvent : IEvent
        {
            Type eventType = typeof(TEvent);
            if (_subscribers.TryGetValue(eventType, out List<Delegate>? value))
            {
                value.Remove(handler);
            }
        }
        public void Publish<TEvent>(TEvent eventMessage) where TEvent : IEvent
        {
            if (_subscribers.ContainsKey(eventMessage.GetType()))
            {
                foreach (var handler in _subscribers[eventMessage.GetType()])
                {
                    ((Action<TEvent>)handler).Invoke(eventMessage);
                }
            }
        }


    }
}
