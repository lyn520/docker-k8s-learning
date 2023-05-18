using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Entity.Models
{
    public class User : AggregateRoot<string>
    {
        public string UserName { get; set; }
        public DateTime Birthday { get; set; }
    }

}
