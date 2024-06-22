using AutoMapper;
using Gym.BLL.Dto;
using Gym.BLL.Dto.Classes;
using Gym.BLL.IRepositories;
using Gym.BLL.IServices;
using Gym.Model.Models;

namespace Gym.BLL_EF.Services
{
    public class ClassService : IClassService
    { 
        private readonly IClassRepository _classRepository;
        private readonly IMapper _mapper;

        public ClassService(IClassRepository classRepository, IMapper mapper)
        {
            _classRepository = classRepository;
            _mapper = mapper;
        }

        public async Task AddClass(ClassRequestDto classDto)
        {
            var cls = _mapper.Map<Class>(classDto);
            await _classRepository.CreateAsync(cls);
        }

        public async void DeleteClass(int id)
        {
            var cl = await _classRepository.GetByIdAsync(id);
            if (cl != null)
            {
                _classRepository.Delete(cl);
            }
        }

        public async void UpdateClass(int classId, ClassRequestDto classDto)
        {
            var cl = await _classRepository.GetByIdAsync(classId);
            if (cl != null)
            {
                _mapper.Map(classDto, cl);
                _classRepository.Update(cl);
            }
        }

        public async Task<List<ClassResponseDto>> GetClasses(int clubId, PageProperties pageProperties)
        {
            var list = await _classRepository.GetClassesByGymId(clubId, pageProperties);
            return _mapper.Map<List<ClassResponseDto>>(list);
        }
    }
}
