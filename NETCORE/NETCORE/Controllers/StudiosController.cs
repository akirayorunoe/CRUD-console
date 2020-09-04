using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NETCORE.DatabaseAccess.Models;
using NETCORE.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NETCORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudiosController : ControllerBase
    {
        private readonly IStudioService studioRepo;
        public StudiosController(IStudioService repo)
        {
            studioRepo=repo;   
        }

        // GET: api/<StudiosController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Studio>>> GetStudios()
        {
            return await studioRepo.GetAll();
        }

        // GET api/<StudiosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Studio>> Get(int id)
        {
            return await studioRepo.Get(id);
        }

        // POST api/<StudiosController>
        [HttpPost]
        public async Task<ActionResult<Studio>>Post(Studio studio)
        {
            return await studioRepo.Create(studio);
        }

        // PUT api/<StudiosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Studio>>Put(int id, Studio studio)
        {
            return await studioRepo.Update(id,studio);
        }

        // DELETE api/<StudiosController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Studio>> Delete(int id)
        {
            return await studioRepo.Delete(id);
        }
    }
}
