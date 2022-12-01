using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_AssignmentDbWpf.Models.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalCost { get; set; }

        public int CustomerId { get; set; }
        public CustomerEntity? Customers { get; set; }

    }
}
