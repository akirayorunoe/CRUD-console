using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace internCSharp
{
    class Program
    {
        private static List<Members> list;
        public static List<Members> readFromFile()
        {
            string json = File.ReadAllText("../../../data.json");
            var l = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Members>>(json);
            return l;
        }
        public static void showList(List<Members> l)
        {
           foreach(var i in l)
            {
                Console.WriteLine("================================");
                Console.WriteLine("MemberId:"+ i.MemberId);
                Console.WriteLine("Email:"+ i.Email.ToString());
                Console.WriteLine("UserName:"+i.UserName.ToString());
                Console.WriteLine("FirstName:"+ i.FirstName.ToString());
                Console.WriteLine("LastName:"+ i.LastName.ToString());
                Console.WriteLine("Gender:"+ i.Gender.ToString());
                Console.WriteLine("Weight:"+ i.Weight);
                Console.WriteLine("================================");
            }
        }

        public static Members createMember()
        {
            Members m=new Members();
            Console.WriteLine("MemberId:");
            m.MemberId = int.Parse(Console.ReadLine());
            Console.WriteLine("Email:");
            m.Email =Console.ReadLine();
            Console.WriteLine("UserName:");
            m.UserName = Console.ReadLine();
            Console.WriteLine("FirstName:");
            m.FirstName = Console.ReadLine();
            Console.WriteLine("LastName:");
            m.LastName = Console.ReadLine();
            Console.WriteLine("Gender:");
            m.Gender = Console.ReadLine();
            Console.WriteLine("Weight:");
            m.Weight = int.Parse(Console.ReadLine());
            return m;
        }

        public static void updateMember(int i)
        {
            Members m = new Members();
            Console.WriteLine("MemberId:");
            m.MemberId = int.Parse(Console.ReadLine());
            Console.WriteLine("Email:");
            m.Email = Console.ReadLine();
            Console.WriteLine("UserName:");
            m.UserName = Console.ReadLine();
            Console.WriteLine("FirstName:");
            m.FirstName = Console.ReadLine();
            Console.WriteLine("LastName:");
            m.LastName = Console.ReadLine();
            Console.WriteLine("Gender:");
            m.Gender = Console.ReadLine();
            Console.WriteLine("Weight:");
            m.Weight = int.Parse(Console.ReadLine());
            list.Insert(i, m);
            list.RemoveAt(i + 1);
        }

        public static void deleteMember(int i)
        {
            list.RemoveAt(i);
        }

        static void Main(string[] args)
        {
            try
            {
                bool flag = true;
                list = readFromFile();
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
                            showList(list);
                            break;
                        case 2:
                            Console.WriteLine("Choose index of member from 0 to " + (list.Count - 1));
                            int index = int.Parse(Console.ReadLine());
                            list[index].show();
                            break;
                        case 3:
                            Members m = createMember();
                            list.Add(m);
                            break;
                        case 4:
                            Console.WriteLine("Choose index of member from 0 to " + (list.Count - 1) + " to update");
                            index = int.Parse(Console.ReadLine());
                            list[index].show();
                            Console.WriteLine("-----Update to-----");
                            updateMember(index);
                            break;
                        case 5:
                            Console.WriteLine("Choose index of member from 0 to " + (list.Count - 1) + " to update");
                            index = int.Parse(Console.ReadLine());
                            list[index].show();
                            Console.WriteLine("=====Delete=====");
                            deleteMember(index);
                            break;
                        case 6:
                            //var ketqua = from member in list
                            //             where member.Weight > 100
                            //             select member;
                            //showList(ketqua.ToList());
                            var ketqua = from member in list
                                         select member;
                            Console.WriteLine("Select number of members will pisplay ");
                            int numberObjPerPage = int.Parse(Console.ReadLine());
                            Console.WriteLine("Select page from 0 to " + (list.Count-1) / numberObjPerPage);
                            int page = int.Parse(Console.ReadLine());
                            var kq=ketqua.Skip(numberObjPerPage * page).Take(10);
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
    }
}
