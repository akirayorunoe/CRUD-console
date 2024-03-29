﻿namespace NETCORE.DatabaseAccess.Models
{
    public class MemberDTO
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
        public int StudioId { get; set; }
        public string StudioName { get; set; }
        public bool Intro { get; set; }
    }
}
