using NETCORE.DatabaseAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
