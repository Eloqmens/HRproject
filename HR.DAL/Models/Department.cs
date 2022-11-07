using HR.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DAL.Models
{
    public class Department : NamedEntity
    {
        public override string ToString() => $"Отдел {Name}";
    }
}
