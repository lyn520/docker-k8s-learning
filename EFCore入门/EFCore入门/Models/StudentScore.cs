using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore入门.Models
{
    public class StudentScore
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public double Score { get; set; }
    }
}
