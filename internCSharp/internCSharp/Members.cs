using System;
using System.Collections.Generic;
using System.Text;

namespace internCSharp
{
    class Members
    {
        private int memberId;
        private string email;
        private string username;
        private string firstname;
        private string lastname;
        private string birthdate;
        private string gender;
        private int weight;
        public Members()
        {
        }
        public int MemberId  // property
        {
            get { return memberId; }   // get method
            set { memberId = value; }  // set method
        }
        public string Email  // property
        {
            get { return email; }   // get method
            set { email = value; }  // set method
        }

        public string UserName  // property
        {
            get { return username; }   // get method
            set { username = value; }  // set method
        }
        public string FirstName  // property
        {
            get { return firstname; }   // get method
            set { firstname = value; }  // set method
        }
        public string LastName  // property
        {
            get { return lastname; }   // get method
            set { lastname = value; }  // set method
        }
        public string BirthDate  // property
        {
            get { return birthdate; }   // get method
            set { birthdate = value; }  // set method
        }
        public string Gender  // property
        {
            get { return gender; }   // get method
            set { gender = value; }  // set method
        }
        public int Weight  // property
        {
            get { return weight; }   // get method
            set { weight = value; }  // set method
        }
        public void show()
        {
            Console.WriteLine("================================");
            Console.WriteLine("MemberId:" + this.MemberId);
            Console.WriteLine("Email:" + this.Email.ToString());
            Console.WriteLine("UserName:" + this.UserName.ToString());
            Console.WriteLine("FirstName:" + this.FirstName.ToString());
            Console.WriteLine("LastName:" + this.LastName.ToString());
            Console.WriteLine("Gender:" + this.Gender.ToString());
            Console.WriteLine("Weight:" + this.Weight);
            Console.WriteLine("================================");
        }
    }
}
