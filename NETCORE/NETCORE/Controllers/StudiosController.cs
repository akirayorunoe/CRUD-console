using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NETCORE.DatabaseAccess.Models;
using NETCORE.Services;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NETCORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudiosController : ControllerBase
    {
        private readonly IStudioService studioService;
        private readonly Microsoft.Extensions.Logging.ILogger _logger;
        public StudiosController(IStudioService service, ILogger<MembersController> logger)
        {
            studioService = service;
            _logger = logger;
        }

        // GET: api/<StudiosController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Studio>>> GetStudios()
        {
            try
            {
                var data = await studioService.GetAll();
                _logger.LogInformation("GET: {req}", Request.Path);
                _logger.LogInformation("Start : Response status : {res}", Response.StatusCode);
                _logger.LogInformation("Start : Response data : {res}", JsonSerializer.Serialize(data));
                return data;
            }
            catch (Exception e)
            {
                _logger.LogInformation("Error {res}", e);
                return null;
            }
        }

        // GET api/<StudiosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Studio>> Get(int id)
        {
            try
            {
                var data = await studioService.Get(id);
                _logger.LogInformation("GET: {req}", Request.Path);
                _logger.LogInformation("Getting item details with id {ID}", id);
                _logger.LogInformation("Response status : {res}", Response.StatusCode);
                _logger.LogInformation("Response data : {res}", JsonSerializer.Serialize(data));
                return data;
            }
            catch (Exception e)
            {
                _logger.LogInformation("Error {res}", e);
                return null;
            }
        }

        // POST api/<StudiosController>
        [HttpPost]
        public async Task<ActionResult<Studio>> Post(Studio studio)
        {
            try
            {
                var data = await studioService.Create(studio);
                _logger.LogInformation("POST: {req}", Request.Path);
                _logger.LogInformation("Request body: {req}", JsonSerializer.Serialize(studio));
                _logger.LogInformation("Response status : {res}", Response.StatusCode);
                _logger.LogInformation("Response data : {res}", JsonSerializer.Serialize(data));
                return data;
            }
            catch (Exception e)
            {
                _logger.LogInformation("Error {res}", e);
                return null;
            }
        }

        // PUT api/<StudiosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Studio>> Put(int id, Studio studio)
        {
            try
            {
                var data = await studioService.Update(id, studio);

                _logger.LogInformation("PUT: {req}", Request.Path);
                _logger.LogInformation("Getting item details with id {ID}", id);
                _logger.LogInformation("Request body: {req}", JsonSerializer.Serialize(studio));
                _logger.LogInformation("Response status : {res}", Response.StatusCode);
                _logger.LogInformation("Response data : {res}", JsonSerializer.Serialize(data));
                return data;
            }
            catch (Exception e)
            {
                _logger.LogInformation("Error {res}", e);
                return null;
            }
        }

        // DELETE api/<StudiosController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Studio>> Delete(int id)
        {
            try
            {
                var data = await studioService.Delete(id);
                _logger.LogInformation("DELETE: {req}", Request.Path);
                _logger.LogInformation("Getting item details with id {ID}", id);
                _logger.LogInformation("Response status : {res}", Response.StatusCode);
                _logger.LogInformation("Response data : {res}", JsonSerializer.Serialize(data));
                return data;
            }
            catch (Exception e)
            {
                _logger.LogInformation("Error {res}", e);
                return null;
            }
        }
    }
}
