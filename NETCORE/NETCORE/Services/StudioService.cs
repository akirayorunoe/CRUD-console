using NETCORE.DatabaseAccess.DBContext;
using NETCORE.DatabaseAccess.Repositories;

namespace NETCORE.Services
{
    public class StudioService : StudioRepository, IStudioService
    {
        public StudioService(MemberProfileContext ctx):base(ctx)
        {
        }
    }
}
