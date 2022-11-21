using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DAL.Models.Base
{
    public abstract class NamedEntity : Entity
    {  
        public string Name { get; set; }
    }
}
