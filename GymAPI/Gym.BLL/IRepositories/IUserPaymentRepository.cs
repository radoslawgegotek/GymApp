using Gym.Model.Models;

namespace Gym.BLL.IRepositories
{
    public interface IUserPaymentRepository : IRepository<UserPayment>
    {
        Task<List<UserPayment>> GetUserPaymentsByUserId(string userId);
    }
}
