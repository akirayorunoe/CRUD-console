using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DatabaseAccess.Models
{
    public class Studio
    {
        [Key]
    public int StudioId{ get; set; }
    public string StudioName { get; set; }
    public string ManagerEmail { get; set; }
    public string Address { get; set; }
        public void show()
        {
            Console.WriteLine("================================");
            Console.WriteLine("StudioId:" + StudioId);
            Console.WriteLine("StudioName:" + StudioName);
            Console.WriteLine("ManagerEmail:" + ManagerEmail);
            Console.WriteLine("Address:" + Address);
            Console.WriteLine("================================");
        }
    }
}
