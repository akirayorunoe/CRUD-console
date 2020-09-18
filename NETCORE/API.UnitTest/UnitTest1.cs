using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using NETCORE;
using NETCORE.DatabaseAccess.DBContext;
using NETCORE.DatabaseAccess.Models;
using NETCORE.DatabaseAccess.Repositories;
using NETCORE.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace API.UnitTest
{
    public class UnitTest1
    {
        private readonly List<Member> members;
        private readonly IMemberRepository _memberRepoMock;
        private readonly Member member;
        private readonly MemberService service;
        public UnitTest1()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });
            var mapper = config.CreateMapper();
            Mock<IMemberRepository> memberRepoMock = new Mock<IMemberRepository>();
            members = GetTestMembers();
            member = new Member();
            // Return all the products
            memberRepoMock.Setup(rp => rp.GetAll()).ReturnsAsync(members);
            memberRepoMock.Setup(rp => rp.Get(It.IsAny<int>())).ReturnsAsync((int i) => members.FirstOrDefault(
                x => x.MemberId == i)??new Member());
            //create
            //create
            memberRepoMock.Setup(rp => rp.Create(It.IsAny<Member>())).ReturnsAsync((Member target) =>
            {
                target.MemberId = members.Count() + 1;
                members.Add(target);
                return target;
            });
            //remove
            memberRepoMock.Setup(rp => rp.Delete(It.IsAny<int>())).ReturnsAsync((int i) =>
            {
                var mem = members.Find(m => m.MemberId == i);
                members.RemoveAll(x => x.MemberId == i);
                return mem;
            }
                );
            //update
            memberRepoMock.Setup(rp => rp.Update(It.IsAny<int>(), It.IsAny<Member>())).ReturnsAsync((int i, Member target) =>
               {
                   members[i].Email = target.Email;
                   members[i].UserName = target.UserName;
                   members[i].FirstName = target.FirstName;
                   members[i].LastName = target.LastName;
                   members[i].Gender = target.Gender;
                   members[i].BirthDate = target.BirthDate;
                   members[i].Weight = target.Weight;
                   members[i].StudioId = target.StudioId;
                   members[i].StudioName = target.StudioName;
                   members[i].UpdateDate = DateTime.Now;
                   return members[i];
               });
            // Complete the setup of our Mock Product Repository
            _memberRepoMock = memberRepoMock.Object;
            service = new MemberService(_memberRepoMock, mapper);
        }
        [Fact]
        public void GetAllMembersTest()
        {
            //_memberRepoMock.Setup(rp => rp.GetAll().Result).Returns(GetTestMembers());
            Assert.Equal(2, _memberRepoMock.GetAll().Result.Count);

        }

        public List<Member> GetTestMembers()
        {
            var sessions = new List<Member>();
            sessions.Add(new Member
            {
                MemberId = 1,
                MemberUUId = "as5d4as564d5a4",
                Email = "auyf45@lll.caa",
                UserName = "48a6s",
                FirstName = "465asd",
                LastName = "45asd",
                BirthDate = "05/09/1989",
                Weight = 44,
                Gender = "Female",
                StudioId = 4,
                StudioName = "khabanh"
            });
            sessions.Add(new Member()
            {
                MemberId = 2,
                MemberUUId = "asasdsd5a4",
                Email = "auasd5@lll.caa",
                UserName = "4asd",
                FirstName = "46asdasd",
                LastName = "45asdsad",
                BirthDate = "05/09/1989",
                Weight = 43,
                Gender = "Male",
                StudioId = 4,
                StudioName = "khabanh"
            });
            return sessions;
        }

        [Theory]
        [InlineData(typeof(MemberDTO), 999)]
        [InlineData(typeof(MemberDTO),1)]
        [InlineData(typeof(MemberDTO), 2)]
        public void GetMemberTest(object expect,int id)
        {
            var b = service.Get(id);
            Assert.Equal(expect,service.Get(id).GetType());
        }
        [Fact]
        public void CreateMemberTest()
        {
            Member member = new Member
            {
                Email = "auyf45@lll.caa",
                UserName = "48a6s",
                FirstName = "465asd",
                LastName = "45asd",
                BirthDate = "05/09/1989",
                Weight = 44,
                Gender = "Female",
                StudioId = 4,
                StudioName = "khabanh"
            };
            Assert.IsType<MemberDTO>(service.Create(member));
            Assert.Equal(3, service.GetAll().Count);
        }

        [Fact]
        public void DeleteMemberTest()
        {
            //test MemberService
            Assert.IsType<MemberDTO>(service.Delete(2));
            Assert.Single(service.GetAll());
        }

        [Fact]
        public void UpdateMemberTest()
        {
            Member member = new Member
            {
                Email = "auasd5@lll.caa",
                UserName = "4asd",
                FirstName = "46asdasd",
                LastName = "45asdsad",
                BirthDate = "05/09/1989",
                Weight = 45,
                Gender = "Male",
                StudioId = 4,
                StudioName = "khabanh"
            };
            Assert.IsType<MemberDTO>(service.Update(1, member));
        }

        //private readonly List<MemberDTO> members;
        //private readonly MemberDTO member;
        //private readonly IMemberService _memberService;
        //public UnitTest1()
        //{
        //    var options = new DbContextOptionsBuilder<MemberProfileContext>()
        //   .UseMySQL("server=localhost;user=root;password=admin;database=member_profile")
        //   .Options;
        //    var config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.AddProfile(new AutoMapping());
        //    });
        //    var mapper = config.CreateMapper();
        //    Mock<IMemberRepository> repositoryMock = new Mock<IMemberRepository>();
        //    Mock<IMapper> mapperMock = new Mock<IMapper>();
        //    Mock<MemberService>serviceMock = new Mock<MemberService>(repositoryMock.Object, mapperMock.Object);
        //    serviceMock.Setup(rp => rp.GetAll()).Returns(members);
        //    _memberService = serviceMock.Object;
        //}
        //[Fact]
        //public void GetAllMembersTest()
        //{
        //    //_memberRepoMock.Setup(rp => rp.GetAll().Result).Returns(GetTestMembers());
        //    Assert.Equal(7, _memberService.GetAll().Count);

        //}
    }
}