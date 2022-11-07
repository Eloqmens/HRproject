using HR.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DAL.Models
{
    public class Position : NamedEntity
    {
        public override string ToString() => $"Должность {Name}";

        [Column(TypeName = "decimal(18,2)")]
        public decimal Patch { get; set; }
    }
}
