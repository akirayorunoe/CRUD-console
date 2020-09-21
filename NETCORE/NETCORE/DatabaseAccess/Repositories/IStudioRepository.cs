using NETCORE.DatabaseAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NETCORE.DatabaseAccess.Repositories
{
    public interface IStudioRepository
    {
        Task<List<Studio>> GetAll();
        Task<Studio> Get(int studioId);
        Task<Studio> Create(Studio studio);
        Task<Studio> Update(int index, Studio studio);
        Task<Studio> Delete(int index);
    }
}
