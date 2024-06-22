using Gym.BLL.IRepositories;
using Gym.DAL.Context;
using Gym.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Gym.BLL_EF.Repositories
{
    public class UserPaymentRepository : Repository<UserPayment>, IUserPaymentRepository
    {
        private readonly GymDbContext _context;

        public UserPaymentRepository(GymDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<UserPayment>> GetUserPaymentsByUserId(string userId)
        {
            return await _context.UserPayments.Where(up => up.UserId == userId).ToListAsync();
        }
    }
}
