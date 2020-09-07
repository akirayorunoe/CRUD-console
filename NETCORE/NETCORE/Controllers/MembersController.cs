using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NETCORE.DatabaseAccess.Models;
using NETCORE.Services;
using log4net.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System;

namespace NETCORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService memberService;
        private readonly Microsoft.Extensions.Logging.ILogger _logger;
        public MembersController(IMemberService service, ILogger<MembersController> logger)
        {
            memberService = service;
            _logger = logger;
        }
        // GET: api/Members
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        {
            try
            {
                var data = await memberService.GetAll();
                _logger.LogInformation("GET: {req}", Request.Path);
                _logger.LogInformation("Start : Response status : {res}", Response.StatusCode);
                _logger.LogInformation("Start : Response data : {res}", JsonSerializer.Serialize(data));
                return data;
            }
            catch(Exception e)
            {
                _logger.LogInformation("Error {res}", e);
                return null;
            }
        }

        // GET: api/Members/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMember(int id)
        {
            try
            {
                var data = await memberService.Get(id);
                _logger.LogInformation("GET: {req}", Request.Path);
                _logger.LogInformation("Getting item details with id {ID}", id);
                _logger.LogInformation("Response status : {res}", Response.StatusCode);
                _logger.LogInformation("Response data : {res}", JsonSerializer.Serialize(data));
                return data;
            }
            catch(Exception e)
            {
                _logger.LogInformation("Error {res}", e);
                return null;
            }
        }
        // POST: api/Members
        public async Task<ActionResult<Member>> PostMember(Member member)
        {
            try
            {
                var data = await memberService.Create(member);
                _logger.LogInformation("POST: {req}", Request.Path);
                _logger.LogInformation("Request body: {req}", JsonSerializer.Serialize(member));
                _logger.LogInformation("Response status : {res}", Response.StatusCode);
                _logger.LogInformation("Response data : {res}", JsonSerializer.Serialize(data));
                return data;
            }
            catch(Exception e)
            {
                _logger.LogInformation("Error {res}", e);
                return null;
            }
        }
        // PUT: api/Members/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Member>> PutMember(int id, Member member)
        {
            try
            {
                var data = await memberService.Update(id, member);

                _logger.LogInformation("PUT: {req}", Request.Path);
                _logger.LogInformation("Getting item details with id {ID}", id);
                _logger.LogInformation("Request body: {req}", JsonSerializer.Serialize(member));
                _logger.LogInformation("Response status : {res}", Response.StatusCode);
                _logger.LogInformation("Response data : {res}", JsonSerializer.Serialize(data));
                return data;
            }catch(Exception e)
            {
                _logger.LogInformation("Error {res}", e);
                return null;
            }
        }
        // DELETE: api/Members/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Member>> DeleteMember(int id)
        {
            try
            {
                var data = await memberService.Delete(id);
                _logger.LogInformation("DELETE: {req}", Request.Path);
                _logger.LogInformation("Getting item details with id {ID}", id);
                _logger.LogInformation("Response status : {res}", Response.StatusCode);
                _logger.LogInformation("Response data : {res}", JsonSerializer.Serialize(data));
                return data;
            }
            catch(Exception e)
            {
                _logger.LogInformation("Error {res}", e);
                return null;
            }
        }
    }
}
