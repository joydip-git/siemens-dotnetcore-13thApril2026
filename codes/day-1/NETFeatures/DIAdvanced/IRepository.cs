namespace DIAdvanced
{
    public interface IRepository<T>
    {
        ICollection<T> GetAll();
    }
}
