using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Entity
{
    public interface IEFEntity<TKey>
    {
        public TKey Id { get; set; }
    }

}
