using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sibintek.Common;
using System.Threading.Tasks;

namespace Sibintek.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser()
        {
            var UserName = UserAssistant.GetUser(User);
            return Ok(new { UserName });
        }
    }
}
