using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Models
{
    public class Order:BaseEntity
    {
        public string UserName { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public Order()
        {
            Date = DateTime.Now;
        }
    }
}
