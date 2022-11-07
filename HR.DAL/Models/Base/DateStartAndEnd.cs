using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DAL.Models.Base
{
    public abstract class DateStartAndEnd : Person
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
