using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore一对多.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
