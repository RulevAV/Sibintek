using System.Linq;
using System.Security.Claims;

namespace Sibintek.Common
{
    public class UserAssistant
    {
        public static string GetUser(ClaimsPrincipal User)
        {
            var Name = User.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();
            var UserName = Name.Split('\\')[1];
            return UserName;
        }
    }
}
