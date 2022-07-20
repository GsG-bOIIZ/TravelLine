using Microsoft.AspNetCore.Mvc;
using WebAppUniversity.Dto;
using WebAppUniversity.Services;

namespace WebAppUniversity.Controllers
{
    [ApiController]
    [Route("rest/student")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetStudents()
        {
            try
            {
                return Ok(_studentService.GetStudents()
                    .ConvertAll(t => t.ConvertToStudentDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{studentId}")]
        public IActionResult GetStudent(int studentId)
        {
            try
            {
                return Ok(_studentService.GetStudent(studentId).ConvertToStudentDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateStudent([FromBody] StudentDto student)
        {
            try
            {
                return Ok(_studentService.CreateStudent(student));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{studentId}")]
        public IActionResult DeleteStudent(int studentId)
        {
            try
            {
                _studentService.DeleteStudent(studentId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
