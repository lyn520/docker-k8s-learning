using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore入门.Models
{
    public class Cat
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
    }
}
