using System.ComponentModel.DataAnnotations;

namespace NETCORE.DatabaseAccess.Models
{
    public class Studio
    {
        [Key]
        public int StudioId { get; set; }
        public string StudioName { get; set; }
        public string ManagerEmail { get; set; }
        public string Address { get; set; }
    }
}
