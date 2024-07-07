using Gym.BLL.Dto;
using Gym.BLL.Dto.Classes;
using Gym.BLL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassesController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpPost]
        public async Task<IActionResult> AddClass([FromBody] ClassRequestDto classDto)
        {
            await _classService.AddClass(classDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            _classService.DeleteClass(id);
            return NoContent();
        }

        [HttpPut("{classId}")]
        public async Task<IActionResult> UpdateClass([FromRoute]int classId, [FromBody] ClassRequestDto classDto)
        {
            _classService.UpdateClass(classId, classDto);
            return Ok();
        }

        [HttpGet("Club/{clubId}")]
        public async Task<IActionResult> GetClasses([FromRoute]int clubId, [FromQuery] PageProperties pageProperties)
        {
            var classes = await _classService.GetClasses(clubId, pageProperties);
            return Ok(classes);
        }

        [HttpGet("Club/User/{classId}")]
        public async Task<IActionResult> GetClassesByID([FromRoute] int classId, [FromQuery] PageProperties pageProperties)
        {
            var classes = await _classService.GetClassesById(classId, pageProperties);
            return Ok(classes);
        }
    }
}
