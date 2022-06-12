using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Sibintek.Common;
using Sibintek.Domain.Entities;
using Sibintek.Domain.Repositories;
using Sibintek.Model;
using System;
using System.IO;
using System.Linq;
using System.Text;
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
            if (Context.UserFiles.existHash(model.hash))
                return Ok(new { message = "Данный файл уже загружен" });
            else
                return Ok();
        }

        [HttpGet("GetFile")]
        public IActionResult GetFile(int id)
        {
            var userFile = Context.UserFiles.userFile(id);
            var provider = new FileExtensionContentTypeProvider();
            string contentType;

            if (userFile==null)
            {
                return StatusCode(409, $"Файл не найден");
            }

            if (!provider.TryGetContentType(userFile.Name, out contentType))
            {
                contentType = "application/octet-stream";
            }

            return File(userFile.file, contentType, userFile.Name);
        }

        [HttpGet()]
        public async Task<IActionResult> get(int page=1)
        {
            var size = Context.UserFiles.Count();
            var pageSize = 10;
            var skip = pageSize * (page - 1);
            var canPage = skip < size;
            var files = Context.UserFiles.getAll()
                .Where(u=>u.sender== UserAssistant.GetUser(User))
                .Select(u => new { u.Id, u.DateAdd, u.Name, u.sender })
                .OrderBy(u=>u.Name)
                .Skip(skip)
                .Take(pageSize)
                .ToArray();

            var count = Math.Ceiling((decimal)size / pageSize);

           return Ok(new { count, page , files }) ;
        }

        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload([FromForm] FormUserFile model)
        {
            try
            {
                UserFile userFile = new UserFile { hash = model.hash };
                byte[] Data = null;

                using (var binaryReader = new BinaryReader(model.file.OpenReadStream()))
                {
                    Data = binaryReader.ReadBytes((int)model.file.Length);
                }

                var strhash = FileAssistant.GethashMD5(Data);

                if (Context.UserFiles.existHash(strhash))
                {
                    return StatusCode(409, $"Данный файл уже загружен");
                }

                userFile.file = Data;
                userFile.Name = model.file.FileName;
                userFile.sender = UserAssistant.GetUser(User);
                Context.UserFiles.Create(userFile);

                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(500, $"внутренняя ошибка сервера");
            }
        }

        [HttpDelete()]
        public async Task<IActionResult> HttpDelete(int id)
        {
            Context.UserFiles.Delete(new UserFile() { Id=id});
            return Ok(new { message = "ok" });
        }
    }
}
