using HRproject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DAL.Models.Base
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
