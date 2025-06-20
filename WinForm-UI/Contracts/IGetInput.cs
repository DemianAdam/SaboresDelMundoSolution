namespace WinForm_UI.Contracts
{
    public interface IGetInput<T>
    {
        T? GetObjectFromInputs(int id = -1);    
    }
}