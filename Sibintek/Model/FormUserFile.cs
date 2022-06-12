using Microsoft.AspNetCore.Http;

namespace Sibintek.Model
{
    public class FormUserFile
    {
        public string hash { get; set; }
        public IFormFile file { get; set; }
    }
}
