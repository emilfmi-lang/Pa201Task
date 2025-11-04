using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApp.BLL.Dtos.Groups
{
    public class GroupCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Limit { get; set; }

        public override string ToString()
        {
            return $"Group Name: {Name}, Description: {Description}, Limit: {Limit}";
        }
    }
}
