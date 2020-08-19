using System;

namespace DataAccess
{
    public class Members
    {
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
        public void show()
        {
            Console.WriteLine("================================");
            Console.WriteLine("MemberId:" + MemberId);
            Console.WriteLine("MemberId:" + MemberUUId);
            Console.WriteLine("Email:" + Email.ToString());
            Console.WriteLine("UserName:" + UserName.ToString());
            Console.WriteLine("FirstName:" + FirstName.ToString());
            Console.WriteLine("LastName:" + LastName.ToString());
            Console.WriteLine("Gender:" + Gender.ToString());
            Console.WriteLine("Weight:" + Weight);
            Console.WriteLine("================================");
        }
    }
}
