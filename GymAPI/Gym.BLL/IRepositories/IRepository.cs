namespace Gym.BLL.IRepositories
{
    public interface IRepository<T> where T : class
    {
        public Task CreateAsync(T entity);
        void Update(T entity);
        Task<T> GetByIdAsync(int id);
        void Delete(T entity);
    }
}
