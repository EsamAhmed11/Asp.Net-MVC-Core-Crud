namespace Task_1._0.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T Entity);
        Task UpdateAsync(T Entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task SaveChange_();

    }
}
