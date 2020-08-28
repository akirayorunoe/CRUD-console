using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NETCORE.DatabaseAccess.Models;
using NETCORE.DatabaseAccess.Repositories;

namespace NETCORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberRepository memberRepo;
        public MembersController(IMemberRepository repository)
        {
            memberRepo = repository;
        }

        // GET: api/Members
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        {
            return await memberRepo.GetAll();
        }

        // GET: api/Members/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMember(int id)
        {
            return await memberRepo.Get(id);
        }
        // POST: api/Members
        public async Task<ActionResult<Member>> PostMember(Member member)
        {
            return await memberRepo.Create(member);
        }
        // PUT: api/Members/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Member>> PutMember(int id,Member member)
        {
            return await memberRepo.Update(id,member);
        }
        // DELETE: api/Members/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Member>> DeleteMember(int id)
        {
            return await memberRepo.Delete(id);
        }
    }
}
