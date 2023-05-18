using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModule.Models
{
    [Table("Person", Schema = "dbo")]
    public class PersonModel
    {
        [Key]
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
    }
}
