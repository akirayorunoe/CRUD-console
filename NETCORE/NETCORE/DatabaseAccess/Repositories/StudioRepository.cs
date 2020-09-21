using Microsoft.EntityFrameworkCore;
using NETCORE.DatabaseAccess.DBContext;
using NETCORE.DatabaseAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NETCORE.DatabaseAccess.Repositories
{
    public class StudioRepository : IStudioRepository
    {
        private MemberProfileContext _DBcontext;
        public StudioRepository(MemberProfileContext context)
        {
            _DBcontext = context;
        }
        public async Task<Studio> Create(Studio studio)
        {
            _DBcontext.Add(studio);
            await _DBcontext.SaveChangesAsync();
            return studio;
        }

        public async Task<Studio> Delete(int index)
        {
            var studio = await _DBcontext.Studios.FindAsync(index);
            if (studio == null)
            {
                return studio;
            }
            _DBcontext.Remove(studio);
            await _DBcontext.SaveChangesAsync();
            return studio;
        }

        public async Task<Studio> Get(int studioId)
        {
            return await _DBcontext.Studios.FirstOrDefaultAsync(studio => studio.StudioId == studioId); ;
        }

        public async Task<List<Studio>> GetAll()
        {
            return await _DBcontext.Studios.ToListAsync();
        }

        public async Task<Studio> Update(int index, Studio studio)
        {
            var studioToUpdate = await _DBcontext.Studios.FindAsync(index);
            if (studioToUpdate == null)
            {
                return studioToUpdate;
            }
            studioToUpdate.StudioName = studio.StudioName;
            studioToUpdate.Address = studio.Address;
            studioToUpdate.ManagerEmail = studio.ManagerEmail;
            _DBcontext.Studios.Update(studioToUpdate);
            await _DBcontext.SaveChangesAsync();
            return studioToUpdate;
        }
    }
}
