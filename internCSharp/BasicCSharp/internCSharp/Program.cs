using DataAccess;
using DatabaseAccess;
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
        static readonly IRepository MemberRepository = new Repository();
        static List<Member> members = MemberRepository.GetAll();
        static void Main(string[] args)
        {
            
            try
            {
                bool flag = true;
                
                while (flag)
                {
                    Console.WriteLine("Enter number");
                    Console.WriteLine("1.Show all");
                    Console.WriteLine("2.Show specific member");
                    Console.WriteLine("3.Create member");
                    Console.WriteLine("4.Update member");
                    Console.WriteLine("5.Delete member");
                    Console.WriteLine("6.Pagination");
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
                            MemberRepository.GetMemberByMemberId(index)?.show();
                            //MemberRepository.GetAll(member => member.MemberId == index).FirstOrDefault()?.show();
                            break;
                        case 3:
                            Member newMember = createMember();
                            MemberRepository.Create(newMember);
                            break;
                        case 4:
                            Console.WriteLine("Choose MemberId to update");
                            index=int.Parse(Console.ReadLine());
                            MemberRepository.GetMemberByMemberId(index)?.show();
                            Console.WriteLine("-----Update to-----");
                            MemberRepository.Update(index, createMember());
                            break;
                        case 5:
                            Console.WriteLine("Choose MemberId delete");
                            index = int.Parse(Console.ReadLine());
                            MemberRepository.GetMemberByMemberId(index)?.show();
                            Console.WriteLine("=====Delete=====");
                            MemberRepository.Delete(index);
                            break;
                        case 6:
                            //var ketqua = from member in list
                            //             where member.Weight > 100
                            //             select member;
                            //showList(ketqua.ToList());
                            var ketqua = from member in members
                                         select member;
                            Console.WriteLine("Select number of members will pisplay ");
                            int numberObjPerPage = int.Parse(Console.ReadLine());
                            Console.WriteLine("Select page from 0 to " + (members.Count - 1) / numberObjPerPage);
                            int page = int.Parse(Console.ReadLine());
                            var kq = ketqua.Skip(numberObjPerPage * page).Take(numberObjPerPage);
                            showList(kq.ToList());
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

        public static Member createMember()
        {
            Member member = new Member();
            //validation
            do {
                Console.WriteLine("Email:");
                member.Email = Console.ReadLine();
            }
            while (!Regex.IsMatch(member.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase)
            || members.Find(mem=>member.Email==mem.Email)!=null);
            //validation
            do
            {
                Console.WriteLine("UserName:");
                member.UserName = Console.ReadLine();
            }
            while (members.Find(mem => member.UserName == mem.UserName) != null);
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
            return member;
        }



    }
}
