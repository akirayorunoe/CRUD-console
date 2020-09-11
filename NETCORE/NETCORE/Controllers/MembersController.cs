﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using NETCORE.DatabaseAccess.Models;
using NETCORE.DatabaseAccess.Repositories;
using NETCORE.Services;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace NETCORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMemberService memberService;
        private readonly Microsoft.Extensions.Logging.ILogger _logger;
        private CacheMemberHelper cacheMember;
        public MembersController(IMemberService service, ILogger<MembersController> logger, IMemoryCache memoryCache, IMapper mapper)
        {
            memberService = service;
            _logger = logger;
            cacheMember = new CacheMemberHelper(memoryCache);
            _mapper = mapper;
        }
        // GET: api/Members
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDTO>>> GetMembers()
        {
            try
            {
                List<Member> members=new List<Member>();
                if (cacheMember.CacheGetAll("listMembers") == null)
                {
                    members = await memberService.GetAll();
                    cacheMember.CacheSet("listMembers", members);
                }
                else { members = cacheMember.CacheGetAll("listMembers"); }
                _logger.LogInformation("GET: {req}", Request.Path);
                _logger.LogInformation("Start : Response status : {res}", Response.StatusCode);
                _logger.LogInformation("Start : Response data : {res}", JsonSerializer.Serialize(members));
                var membersDto = _mapper.Map<List<MemberDTO>>(members);
                return membersDto;
            }
            catch (Exception e)
            {
                _logger.LogInformation("Error {res}", e);
                return null;
            }
        }

        // GET: api/Members/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MemberDTO>> GetMember(int id)
        {
            try
            {
                var members = await memberService.Get(id);
                _logger.LogInformation("GET: {req}", Request.Path);
                _logger.LogInformation("Getting item details with id {ID}", id);
                _logger.LogInformation("Response status : {res}", Response.StatusCode);
                _logger.LogInformation("Response data : {res}", JsonSerializer.Serialize(members));
                var membersDto = _mapper.Map<MemberDTO>(members);
                return membersDto;
            }
            catch (Exception e)
            {
                _logger.LogInformation("Error {res}", e);
                return null;
            }
        }
        // POST: api/Members
        public async Task<ActionResult<MemberDTO>> PostMember(Member member)
        {
            try
            {
                var members = await memberService.Create(member);
                _logger.LogInformation("POST: {req}", Request.Path);
                _logger.LogInformation("Request body: {req}", JsonSerializer.Serialize(member));
                _logger.LogInformation("Response status : {res}", Response.StatusCode);
                _logger.LogInformation("Response data : {res}", JsonSerializer.Serialize(members));
                var membersDto = _mapper.Map<MemberDTO>(members);
                return membersDto;
            }
            catch (Exception e)
            {
                _logger.LogInformation("Error {res}", e);
                return null;
            }
        }
        // PUT: api/Members/5
        [HttpPut("{id}")]
        public async Task<ActionResult<MemberDTO>> PutMember(int id, Member member)
        {
            try
            {
                var members = await memberService.Update(id, member);
                _logger.LogInformation("PUT: {req}", Request.Path);
                _logger.LogInformation("Getting item details with id {ID}", id);
                _logger.LogInformation("Request body: {req}", JsonSerializer.Serialize(member));
                _logger.LogInformation("Response status : {res}", Response.StatusCode);
                _logger.LogInformation("Response data : {res}", JsonSerializer.Serialize(members));
                var membersDto = _mapper.Map<MemberDTO>(members);
                return membersDto;
            }
            catch (Exception e)
            {
                _logger.LogInformation("Error {res}", e);
                return null;
            }
        }
        // DELETE: api/Members/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MemberDTO>> DeleteMember(int id)
        {
            try
            {
                var members = await memberService.Delete(id);
                _logger.LogInformation("DELETE: {req}", Request.Path);
                _logger.LogInformation("Getting item details with id {ID}", id);
                _logger.LogInformation("Response status : {res}", Response.StatusCode);
                _logger.LogInformation("Response data : {res}", JsonSerializer.Serialize(members));
                var membersDto = _mapper.Map<MemberDTO>(members);
                return membersDto;
            }
            catch (Exception e)
            {
                _logger.LogInformation("Error {res}", e);
                return null;
            }
        }
    }
}
