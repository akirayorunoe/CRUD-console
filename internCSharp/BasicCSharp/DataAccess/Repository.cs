using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class Repository : IRepository
    {
        public List<Members> Members=new List<Members>();

         List<Members> IRepository.ReadFromFile()
        {
            string json = File.ReadAllText("data.json");
            Members = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Members>>(json);
            return Members;
        }
        //List<Members> IRepository.Read()
        //{
        //    return Members;
        //}

            void IRepository.Create(Members member)
        {
            member.MemberId=Members[Members.Count-1].MemberId + 1;
            Guid g = Guid.NewGuid();
            member.MemberUUId = g.ToString();
            Members.Add(member);
        }

        List<Members> IRepository.Update(int i, Members member)
        {
            Members[i].Email = member.Email;
            Members[i].UserName = member.UserName;
            Members[i].FirstName = member.FirstName;
            Members[i].LastName = member.LastName;
            Members[i].Gender = member.Gender;
            Members[i].Weight = member.Weight;
            return Members;
        }

        List<Members> IRepository.Delete(int i)
        {
            Members.RemoveAt(i);
            return Members;
        }


    }
}
