namespace Interfaces
{
    public interface IValidator<T>
    {
        bool Validate(T entity);
    }
}
