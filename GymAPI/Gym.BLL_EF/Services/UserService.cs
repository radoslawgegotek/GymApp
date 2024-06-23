using Gym.BLL.Dto.User;
using Gym.BLL.IServices;
using Gym.Model.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Gym.BLL_EF.Services
{
    public class UserService : IUserService
    {
        private readonly ClaimsPrincipal claims;
        private readonly UserManager<AppUser> userManager;

        public UserService(ClaimsPrincipal claims, UserManager<AppUser> userManager)
        {
            this.claims = claims;
            this.userManager = userManager;
        }


        public async Task<UserInfoDto> GetUserInformation()
        {
            string userId = claims.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var userInfo = await userManager.Users
                .Where(u => u.Id == userId)
                .Select(u => new UserInfoDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Surname = u.Surname,
                    Email = u.Email,
                    BirthDate = u.BirthDate,
                    PhoneNumber = u.PhoneNumber,
                    PESEL = u.PESEL
                })
                .FirstOrDefaultAsync();
            return userInfo;
        }
    }
}
