using Gym.BLL.Dto;
using Gym.BLL.Dto.Classes;

namespace Gym.BLL.IServices
{
    public interface IClassService
    {
        Task AddClass(ClassRequestDto classDto);
        void DeleteClass(int id);
        void UpdateClass(int classId, ClassRequestDto classDto);
        Task<List<ClassResponseDto>> GetClasses(int clubId, PageProperties pageProperties);
    }
}
