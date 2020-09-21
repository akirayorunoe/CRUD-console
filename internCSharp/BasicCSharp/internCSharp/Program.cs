using DatabaseAccess;
using DatabaseAccess.DBContexts;
using DatabaseAccess.Models;
using DatabaseAccess.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace internCSharp
{
    class Program
    {
        //IRepository repository=new Repository();
        static MemberProfileContext context = new MemberProfileContext();
        static readonly IMemberRepository MemberRepository = new MemberRepository(context);
        static readonly IStudioRepository StudioRepository = new StudioRepository(context);
        static void Main(string[] args)
        {
            try
            {
                bool flag = true;
                
                while (flag)
                {
                    Console.WriteLine("Enter number");
                    Console.WriteLine("1.Show all members");
                    Console.WriteLine("2.Show specific member");
                    Console.WriteLine("3.Create member");
                    Console.WriteLine("4.Update member");
                    Console.WriteLine("5.Delete member");
                    Console.WriteLine("6.Pagination");
                    Console.WriteLine("7.Show all studios");
                    Console.WriteLine("8.Show specific studio");
                    Console.WriteLine("9.Create studio");
                    Console.WriteLine("10.Update studio");
                    Console.WriteLine("11.Delete studio");
                    Console.WriteLine("12.Show all member of studio");
                    Console.WriteLine("13.Show all member of studio where manageEmail = ''");
                    Console.WriteLine("Other. Exit");
                    int.TryParse(Console.ReadLine(),out var key);
                    switch (key)
                    {
                        case 1:
                            showList(MemberRepository.GetAll());
                            break;
                        case 2:
                            Console.WriteLine("Choose MemberId to show");
                            int.TryParse(Console.ReadLine(),out var index);
                            MemberRepository.GetById(index)?.show();
                            //MemberRepository.GetAll(member => member.MemberId == index).FirstOrDefault()?.show();
                            break;
                        case 3:
                            Member newMember = createMember();
                            MemberRepository.Create(newMember);
                            break;
                        case 4:
                            Console.WriteLine("Choose MemberId to update");
                            index=int.Parse(Console.ReadLine());
                            MemberRepository.GetById(index)?.show();
                            Console.WriteLine("-----Update to-----");
                            MemberRepository.Update(MemberRepository.GetById(index), createMember());
                            break;
                        case 5:
                            Console.WriteLine("Choose MemberId delete");
                            index = int.Parse(Console.ReadLine());
                            MemberRepository.GetById(index)?.show();
                            Console.WriteLine("=====Delete=====");
                            MemberRepository.Delete(index);
                            break;
                        case 6:
                            //var ketqua = from member in list
                            //             where member.Weight > 100
                            //             select member;
                            //showList(ketqua.ToList());
                            var ketqua = StudioRepository.GetAll();
                            Console.WriteLine("Select number of members will pisplay ");
                            int numberObjPerPage = int.Parse(Console.ReadLine());
                            Console.WriteLine("Select page from 0 to " + (ketqua.Count - 1) / numberObjPerPage);
                            int page = int.Parse(Console.ReadLine());
                            var kq = ketqua.Skip(numberObjPerPage * page).Take(numberObjPerPage);
                            showList(kq.ToList());
                            break;
                        case 7:
                            showList(StudioRepository.GetAll());
                            break;
                        case 8:
                            Console.WriteLine("Choose Studio to show");
                            int.TryParse(Console.ReadLine(), out index);
                            StudioRepository.GetById(index)?.show();
                            //MemberRepository.GetAll(member => member.MemberId == index).FirstOrDefault()?.show();
                            break;
                        case 9:
                            Studio newStudio = createStudio();
                            StudioRepository.Create(newStudio);
                            break;
                        case 10:
                            Console.WriteLine("Choose StudioId to update");
                            index = int.Parse(Console.ReadLine());
                            StudioRepository.GetById(index)?.show();
                            Console.WriteLine("-----Update to-----");
                            StudioRepository.Update(index, createStudio());
                            break;
                        case 11:
                            Console.WriteLine("Choose StudioId delete");
                            index = int.Parse(Console.ReadLine());
                            StudioRepository.GetById(index)?.show();
                            Console.WriteLine("=====Delete=====");
                            StudioRepository.Delete(index);
                            break;
                        case 12:
                            Console.WriteLine("Studio Id:");
                            int.TryParse(Console.ReadLine(),out int studioId);
                            showList(MemberRepository.ShowListMemberOfStudio(studioId));
                            break;
                        case 13:
                            var specialStudio = StudioRepository.Get(studio => studio.ManagerEmail == string.Empty);
                            //var specialStudio = Repository.GetStudio(studio => studio.ManagerEmail == "knnsn@kbs.abc");
                            showList(MemberRepository.GetAll(member => member.StudioId == specialStudio.StudioId));
                            break;
                        default:
                            flag = false;
                            break;
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void showList(List<Member> members)
        {
            foreach (var i in members)
            {
                i.show();
            }
        }
        public static void showList(List<Studio> studios)
        {
            foreach (var i in studios)
            {
                i.show();
            }
        }

        public static Member createMember()
        {
            Member member = new Member();
            //validation
            do {
                Console.WriteLine("Email:");
                member.Email = Console.ReadLine();
            }
            while (!Regex.IsMatch(member.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase)
            || MemberRepository.GetAll().Find(mem=>member.Email==mem.Email)!=null);
            //validation
            do
            {
                Console.WriteLine("UserName:");
                member.UserName = Console.ReadLine();
            }
            while (MemberRepository.GetAll().Find(mem => member.UserName == mem.UserName) != null);
            Console.WriteLine("FirstName:");
            member.FirstName = Console.ReadLine();
            Console.WriteLine("LastName:");
            member.LastName = Console.ReadLine();
            Console.WriteLine("Gender:");
            member.Gender = Console.ReadLine();
            Console.WriteLine("Birth date(MM/DD/YYYY):");
            member.BirthDate = Console.ReadLine();
            Console.WriteLine("Weight:");
            member.Weight = int.Parse(Console.ReadLine());
            Console.WriteLine("--Choose StudioId--");
            showList(StudioRepository.GetAll());
            Console.WriteLine("StudioId:");
            member.StudioId = int.Parse(Console.ReadLine());
            member.StudioName = StudioRepository.GetById(member.StudioId).StudioName;
            return member;
        }
        public static Studio createStudio()
        {
            Studio studio = new Studio();
                Console.WriteLine("StudioName:");
                studio.StudioName = Console.ReadLine();
                Console.WriteLine("ManagerEmail:");
                studio.ManagerEmail = Console.ReadLine();
          
            Console.WriteLine("Address:");
            studio.Address = Console.ReadLine();
           
            return studio;
        }



    }
}
