namespace Interfaces
{
    public interface ITEvent<T> : IEvent
    {
        T Data { get; }
    }
}
