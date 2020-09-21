using System;
using System.ComponentModel.DataAnnotations;

namespace NETCORE.DatabaseAccess.Models
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
        public bool IsDelete { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
