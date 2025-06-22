namespace Interfaces
{
    public interface IContextFactory
    {
        public T CreateContext<T>(params object[] parameters) where T : IContext;
    }
}
