using Interfaces;

namespace BLL.Services
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
