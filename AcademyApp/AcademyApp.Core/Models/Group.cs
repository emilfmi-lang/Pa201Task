using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApp.Core.Models
{
    public class Group:BaseEntity
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public int Limit { get; set; }
        [NotMapped]
        public string ShortDescription =>
            Description.Length <= 15 ? Description : Description.Substring(0, 15) + "...";
        public List<Student> Students { get; set; }

        public override string ToString()
        {
            return $"Group Id: {Id}, Name: {Name}, ShortDescription: {ShortDescription}, Limit: {Limit}";
        }
    }
}
