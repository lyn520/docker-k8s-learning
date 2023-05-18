using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore一对多.Models
{
    public class OrgUnit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public OrgUnit? Parent { get; set; }
        public List<OrgUnit> Children { get; set; } = new List<OrgUnit>();
    }
}
