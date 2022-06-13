

using Sibintek.Domain.Repositories.Abstract;
using System.Linq;

namespace Sibintek.Domain.Repositories.EntityFramework
{
    public class EFUserFile : IUserFile
    {
        private readonly SibintekContext _context;

        public EFUserFile (SibintekContext context) => _context = context;

        public IQueryable<UserFile> getAll()
        {
            return _context.UserFiles;
        }

        public void Create(UserFile entity)
        {
            _context.UserFiles.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(UserFile entity)
        {
            _context.UserFiles.Remove(entity);
            _context.SaveChanges();
        }

        public bool existHash(string hash)
        {
            return _context.UserFiles.Where(u=>u.Hash == hash).Any();
        }

        public UserFile userFile(int id)
        {
            return _context.UserFiles.FirstOrDefault(u => u.Id == id);
        }

        public int Count()
        {
            return _context.UserFiles.Count();
        }
    }
}
