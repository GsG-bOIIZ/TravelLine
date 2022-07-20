using Microsoft.AspNetCore.Mvc;
using WebAppUniversity.Dto;
using WebAppUniversity.Services;

namespace WebAppUniversity.Controllers
{
    [ApiController]
    [Route("rest/faculty")]
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyService _facultyService;

        public FacultyController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetFaculties()
        {
            try
            {
                return Ok(_facultyService.GetFaculties()
                    .ConvertAll(t => t.ConvertToFacultyDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{facultyId}")]
        public IActionResult GetFaculty(int facultyId)
        {
            try
            {
                return Ok(_facultyService.GetFaculty(facultyId).ConvertToFacultyDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateFaculty([FromBody] FacultyDto faculty)
        {
            try
            {
                return Ok(_facultyService.CreateFaculty(faculty));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{facultyId}")]
        public IActionResult DeleteTodo(int facultyId)
        {
            try
            {
                _facultyService.DeleteFaculty(facultyId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
