using APIOne.src.Contratos.IServices;
using APIOne.src.Entity;
using Microsoft.AspNetCore.Mvc;

namespace APIOne.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUsersServices _UserService) : ControllerBase
    {
        [HttpPost("CREATE")]
        public async Task<IActionResult> Create([FromBody] UsersEntity request)
        {
            try
            {
                return Ok(await _UserService.Create(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}/get")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _UserService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}/Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await _UserService.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UsersEntity request)
        {
            try
            {
                return Ok(await _UserService.Update(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            try
            {
                return Ok(await _UserService.List());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}




