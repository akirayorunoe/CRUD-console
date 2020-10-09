using AutoMapper;
using NETCORE.DatabaseAccess.Models;
using NETCORE.DatabaseAccess.Repositories;
using System.Collections.Generic;

namespace NETCORE.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMapper _mapper;
        private readonly IMemberRepository memberRepository;

        public MemberService(IMemberRepository memRepository, IMapper mapper)//https://stackoverflow.com/questions/57203893/how-to-fix-there-is-no-argument-given-that-corresponds-to-the-required-formal-p
        {
            memberRepository = memRepository;
            _mapper = mapper;
        }

        public List<MemberDTO> GetListMemberDTOs(List<Member> members)
        {
            return _mapper.Map<List<MemberDTO>>(members);
        }
        public MemberDTO GetMemberDTOs(Member member)
        {
            return _mapper.Map<MemberDTO>(member);
        }
        public List<MemberDTO> GetAll()
        {
            var members = memberRepository.GetAll();
            return GetListMemberDTOs(members.Result);
        }
        public MemberDTO Get(int id)
        {
            var member = memberRepository.Get(id);
            return GetMemberDTOs(member.Result);
        }
        public MemberDTO Create(Member member)
        {
            var memberdto = memberRepository.Create(member);
            return GetMemberDTOs(memberdto.Result);
        }
        public MemberDTO Update(int id, Member member)
        {
            var memberdto = memberRepository.Update(id, member);
            return GetMemberDTOs(memberdto.Result);
        }
        public MemberDTO Delete(int id)
        {
            var member = memberRepository.Delete(id);
            return GetMemberDTOs(member.Result);
        }

        public List<MemberDTO> GetPagination(int pageNum, int pageSize)
        {
            var members= memberRepository.GetPagination(pageNum, pageSize);
            return GetListMemberDTOs(members.Result);
        }
    }
}
