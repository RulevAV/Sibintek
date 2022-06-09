using Sibintek.Domain.Entities;
using System.Linq;

namespace Sibintek.Domain.Repositories.Abstract
{
    public interface IUserFile
    {
        public IQueryable<UserFile> getAll();

        public void Create(UserFile entity);
        public void Delete(UserFile entity);
    }
}
