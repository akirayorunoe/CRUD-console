using AutoMapper;
using NETCORE.DatabaseAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<Member, MemberDTO>(); // means you want to map from Member to MemberDTO
        }
    }
}
