using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore一对多.Models
{
    public class Article
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public ICollection<Comment> WithComments { get; set; } = new List<Comment>();
    }
}
