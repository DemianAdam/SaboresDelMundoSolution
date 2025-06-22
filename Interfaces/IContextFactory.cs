namespace Interfaces
{
    public interface IContextFactory
    {
        public T CreateInstance<T>(params object[] parameters) where T : IContext;
    }
}
