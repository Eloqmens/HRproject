using HR.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DAL.Models
{
    public class User : NamedEntity
    {
        public string Password { get; set; }
        public DateTime DatedJoined { get; set; }
    }
}
