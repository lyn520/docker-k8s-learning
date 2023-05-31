using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore入门.Models
{
    public class YearAmount
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public double Amount { get; set; }
    }
}
