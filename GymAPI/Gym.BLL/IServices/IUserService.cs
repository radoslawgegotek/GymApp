using Gym.BLL.Dto.User;

namespace Gym.BLL.IServices
{
    public interface IUserService
    {
        Task<UserInfoDto> GetUserInformation();
    }
}
