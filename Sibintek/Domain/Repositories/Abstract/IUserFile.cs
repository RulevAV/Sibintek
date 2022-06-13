using System.Linq;

namespace Sibintek.Domain.Repositories.Abstract
{
    public interface IUserFile
    {
        public IQueryable<UserFile> getAll();

        public int Count();
        public void Create(UserFile entity);
        public void Delete(UserFile entity);

        public UserFile userFile(int id);
        public bool existHash(string hash);
    }
}
