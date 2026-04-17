namespace Siemns.DotNet.PmsApp.APIs.Models.Dao.Abstractions
{
    public interface IDbService<T, TId> where T : class
    {
        Task<ICollection<T>> FetchAll();
        Task<T?> Fetch(TId pkeyValue);
        Task<T> Insert(T data);
        Task<T> Modify(TId pkeyValue, T data);
        Task<T> Remove(TId pkeyValue);
    }
}
