using Microsoft.AspNetCore.Mvc;
using WebAppUniversity.Dto;
using WebAppUniversity.Services;

namespace WebAppUniversity.Controllers
{
    [ApiController]
    [Route("rest/group")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetGroupes()
        {
            try
            {
                return Ok(_groupService.GetGroupes()
                    .ConvertAll(t => t.ConvertToGroupDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{groupId}")]
        public IActionResult GetGroup(int groupId)
        {
            try
            {
                return Ok(_groupService.GetGroup(groupId).ConvertToGroupDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateGroup([FromBody] GroupDto group)
        {
            try
            {
                return Ok(_groupService.CreateGroup(group));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{groupId}")]
        public IActionResult DeleteGroup(int groupId)
        {
            try
            {
                _groupService.DeleteGroup(groupId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost]
        [Route("update")]
        public IActionResult UpdateGroup([FromBody] GroupDto group)
        {
            try
            {
                return Ok(_groupService.UpdateGroup(group));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
