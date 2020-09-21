using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
