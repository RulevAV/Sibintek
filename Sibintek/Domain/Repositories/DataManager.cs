
using Sibintek.Domain.Repositories.Abstract;

namespace Sibintek.Domain.Repositories
{
    public class DataManager
    {
        public IUserFile UserFiles { get; set; }

        public DataManager(IUserFile _UserFiles) => UserFiles = _UserFiles;
    }
}
