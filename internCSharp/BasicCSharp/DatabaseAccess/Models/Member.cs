using System;
using System.ComponentModel.DataAnnotations;

namespace DatabaseAccess.Models
{
    public class Member
    {
        [Key]
        public int MemberId  // property
        { get; set; }
        public string MemberUUId  // property
        { get; set; }
        public string Email  // property
        { get; set; }

        public string UserName  // property
        { get; set; }
        public string FirstName  // property
        { get; set; }
        public string LastName  // property
        { get; set; }
        public string BirthDate  // property
        { get; set; }
        public string Gender  // property
        { get; set; }
        public int Weight  // property
        { get; set; }
        public int StudioId { get; set; }
        public string StudioName { get; set; }
        public void show()
        {
            Console.WriteLine("================================");
            Console.WriteLine("MemberId:" + MemberId);
            Console.WriteLine("MemberUUId:" + MemberUUId);
            Console.WriteLine("Email:" + Email.ToString());
            Console.WriteLine("UserName:" + UserName.ToString());
            Console.WriteLine("FirstName:" + FirstName.ToString());
            Console.WriteLine("LastName:" + LastName.ToString());
            Console.WriteLine("Birthdate:" + BirthDate);
            Console.WriteLine("Gender:" + Gender.ToString());
            Console.WriteLine("Weight:" + Weight);
            Console.WriteLine("StudioId:" + StudioId);
            Console.WriteLine("Studio Name:" + StudioName);
            Console.WriteLine("================================");
        }
    }
}
