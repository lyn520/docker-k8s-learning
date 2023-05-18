using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore一对多.Models
{
    public class Comment
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public long WithArticleId { get; set; }
        public Article WithArticle { get; set; }

    }
}
