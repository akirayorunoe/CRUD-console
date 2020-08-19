using DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace internCSharp
{
    class Program
    {
        //IRepository repository=new Repository();
        static readonly IRepository repository = new Repository();
        static void Main(string[] args)
        {
            var members=repository.ReadFromFile();
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
                    int key = int.Parse(Console.ReadLine());
                    switch (key)
                    {
                        case 1:
                            showList(members);
                            break;
                        case 2:
                            Console.WriteLine("Choose index of member from 0 to " + (members.Count - 1));
                            int index = int.Parse(Console.ReadLine());
                            members[index].show();
                            break;
                        case 3:
                            Members newMember = createMember();
                            repository.Create(newMember);
                            break;
                        case 4:
                            Console.WriteLine("Choose index of member from 0 to " + (members.Count - 1) + " to update");
                            index = int.Parse(Console.ReadLine());
                            members[index].show();
                            Console.WriteLine("-----Update to-----");
                            repository.Update(index, createMember());
                            break;
                        case 5:
                            Console.WriteLine("Choose index of member from 0 to " + (members.Count - 1) + " to update");
                            index = int.Parse(Console.ReadLine());
                            members[index].show();
                            Console.WriteLine("=====Delete=====");
                            repository.Delete(index);
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
        public static void showList(List<Members> members)
        {
            foreach (var i in members)
            {
                i.show();
            }
        }

        public static Members createMember()
        {
            Members member = new Members();
            //Console.WriteLine("MemberId:");
            //member.MemberId = int.Parse(Console.ReadLine());
            Console.WriteLine("Email:");
            member.Email = Console.ReadLine();
            Console.WriteLine("UserName:");
            member.UserName = Console.ReadLine();
            Console.WriteLine("FirstName:");
            member.FirstName = Console.ReadLine();
            Console.WriteLine("LastName:");
            member.LastName = Console.ReadLine();
            Console.WriteLine("Gender:");
            member.Gender = Console.ReadLine();
            Console.WriteLine("Weight:");
            member.Weight = int.Parse(Console.ReadLine());
            return member;
        }



    }
}
