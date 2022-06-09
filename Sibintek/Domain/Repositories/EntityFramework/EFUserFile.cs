

using Sibintek.Domain.Entities;
using Sibintek.Domain.Repositories.Abstract;
using System.Linq;

namespace Sibintek.Domain.Repositories.EntityFramework
{
    public class EFUserFile : IUserFile
    {
        private readonly AppDbContext _context;

        public EFUserFile (AppDbContext context) => _context = context;

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
            _context.UserFiles.DefaultIfEmpty(entity);
            _context.SaveChanges();
        }
    }
}
