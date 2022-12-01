using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_AssignmentDbWpf.Models.Entities
{
    public class CustomerEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public ICollection<OrderEntity>? Orders { get; set; }
    }
}
