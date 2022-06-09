using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sibintek.Domain.Entities;
using Sibintek.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sibintek.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserFileController : ControllerBase
    {
        private DataManager Context;

        public UserFileController(DataManager _Context)
        {
            Context = _Context;
        }

        [HttpPost("existHash")]
        public async Task<IActionResult> existHash(UserFile model)
        {
            return Ok(new { exist = false });
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
           

            return Ok(new { message = "ok" });
        }

        [HttpPost()]
        public async Task<IActionResult> Post(UserFile model)
        {
            //if hash
            Context.UserFiles.Create(model);
            return Ok(new { message = "ok" });
        }

        [HttpDelete()]
        public async Task<IActionResult> HttpDelete(UserFile model)
        {
            return Ok(new { message = "ok" });
        }

       
    }
}
